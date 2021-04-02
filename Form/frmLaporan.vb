Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class frmLaporan
    Private Sub frmLaporan_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Public Function CetakQrCode(ByVal cReportName As String,
                                ByVal cFormula As String,
                                ByVal cDBName As String) As Boolean
        Dim cryRpt As New ReportDocument
        Dim crtableLogoninfos As New TableLogOnInfos
        Dim crtableLogoninfo As New TableLogOnInfo
        Dim crConnectionInfo As New ConnectionInfo
        Dim CrTables As Tables
        Dim CrTable As Table

        cryRpt.Load(String.Format("{0}\report\{1}", Application.StartupPath, cReportName))

        With crConnectionInfo
            .Type = ConnectionInfoType.DBFile
            .ServerName = Application.StartupPath & "\" & Trim(cDBName.Trim)
            .DatabaseName = Application.StartupPath & "\" & Trim(cDBName.Trim)
            .UserID = ""
            .Password = "Masuk123!@#"
        End With

        CrTables = cryRpt.Database.Tables
        For Each CrTable In CrTables
            crtableLogoninfo = CrTable.LogOnInfo
            crtableLogoninfo.ConnectionInfo = crConnectionInfo
            CrTable.ApplyLogOnInfo(crtableLogoninfo)
        Next

        'cryRpt.SetParameterValue("tglperiksa", cTglPerika.Trim)
        'cryRpt.SetParameterValue("umur", cUmur.Trim)

        crViewer.ReportSource = cryRpt
        If cFormula.Trim <> "0" Then
            crViewer.SelectionFormula = cFormula.Trim
        End If
        crViewer.Refresh()
        Return True
    End Function

    Private Sub frmLaporan_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.P Then
            crViewer.PrintReport()
        End If
    End Sub

    Private Sub frmLaporan_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        Me.BringToFront()
        Me.WindowState = FormWindowState.Maximized
    End Sub

    Private Sub crViewer_Load(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(crViewer.ReportSource.ToString.Trim) Then
            crViewer.Dispose()
        End If
    End Sub

End Class
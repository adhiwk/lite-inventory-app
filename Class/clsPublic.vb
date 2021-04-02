Imports System.Data.OleDb
Public Class clsPublic
    Public Shared Function FileAccess() As OleDbConnection
        Dim connectionString As String =
                  "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" &
                  Application.StartupPath & "\qrcode.mdb;Jet OLEDB:Database Password="
        ';Extended Properties=Text;HDR=YES;FMT=Delimeted;IMEX=1;Database Password=" & _
        'My.Settings.Local_DB.ToString.Trim & ""

        'Dim ConnectionString As String =
        '    "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" &
        '    Application.StartupPath &
        '    "\qrcode.accdb;Persist Security Info=False;"

        Return New OleDbConnection(connectionString)
    End Function

    Public Shared Function ConvertTanggal(ByVal dtTanggal As DevExpress.XtraEditors.DateEdit) As String
        Dim cBulan As String = ""
        Dim cTanggal As String = ""
        'Dim cTanggalKunjungan As String = ""
        If Len(dtTanggal.DateTime.Month.ToString.Trim) = 1 Then
            cBulan = "0" & dtTanggal.DateTime.Month.ToString.Trim
        Else
            cBulan = dtTanggal.DateTime.Month.ToString.Trim
        End If

        If Len(dtTanggal.DateTime.Day.ToString.Trim) = 1 Then
            cTanggal = "0" & dtTanggal.DateTime.Day.ToString.Trim
        Else
            cTanggal = dtTanggal.DateTime.Day.ToString.Trim
        End If
        ConvertTanggal = dtTanggal.DateTime.Year.ToString.Trim & "-" & cBulan.Trim & "-" & cTanggal.Trim
    End Function

End Class

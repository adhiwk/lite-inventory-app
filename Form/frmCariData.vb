Imports System.Data.OleDb
Public Class frmCariData
    Friend cNomorSeri As String = ""
    Private Sub txtCariData_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCariData.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Dim Conn As OleDbConnection = clsPublic.FileAccess
            Conn.Open()

            Using Cmd As New OleDbCommand
                Try
                    With Cmd
                        .Connection = Conn
                        .CommandText = "select [nomor seri]," &
                                        "[nama barang]," &
                                        "[tahun],[kondisi] " &
                                        "from inventory where [nomor seri] = '" & txtCariData.Text.Trim & "'"
                        Dim rDr As OleDbDataReader = .ExecuteReader

                        grdData.Rows.Clear()
                        While rDr.Read
                            grdData.Rows.Add(New Object() {rDr.Item(0).ToString.Trim,
                                             rDr.Item(1).ToString.Trim,
                                             Format(Date.Parse(rDr.Item(2).ToString.Trim), "dd-MM-yyyy"),
                                             rDr.Item(3).ToString.Trim})
                        End While
                        rDr.Close()

                        .CommandText = "select [nomor seri]," &
                                       "[nama barang]," &
                                       "[tahun],[kondisi] " &
                                       "from inventory where [nama barang] like '%" & txtCariData.Text.Trim & "%'"
                        rDr = .ExecuteReader
                        While rDr.Read
                            grdData.Rows.Add(New Object() {rDr.Item(0).ToString.Trim,
                                           rDr.Item(1).ToString.Trim,
                                           Format(Date.Parse(rDr.Item(2).ToString.Trim), "dd-MM-yyyy"),
                                           rDr.Item(3).ToString.Trim})
                        End While
                        rDr.Close()
                    End With
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
            Conn.Close()
        End If
    End Sub

    Private Sub frmCariData_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cNomorSeri = ""
    End Sub

    Private Sub grdData_KeyPress(sender As Object, e As KeyPressEventArgs) Handles grdData.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Try
                cNomorSeri = grdData.CurrentRow.Cells.Item(0).Value.ToString.Trim
            Catch ex As Exception

            End Try
            Me.Dispose()
        End If
    End Sub
End Class
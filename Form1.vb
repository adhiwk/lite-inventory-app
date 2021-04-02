Imports System.Data.OleDb
Imports System.IO
Imports System.Drawing
Imports MessagingToolkit.QRCode.Codec
Public Class frmMenu
    Dim lNew As Boolean
    Dim lqrCode As Boolean
    Dim QR_code As New QRCodeEncoder
    Dim bytImage() As Byte
    Private Sub ClearScreen()
        txtNomorSeri.Text = ""
        txtNamaBarang.Text = ""
        dtPerolehan.DateTime = Now.Date
        txtKondisi.Text = ""
        txtStatus.Text = ""
        txtKeterangan.Text = ""
        qrCode.Image = Nothing
    End Sub

    Private Sub DisableText()
        txtNomorSeri.Properties.ReadOnly = True
        txtNamaBarang.Properties.ReadOnly = True
        dtPerolehan.Properties.ReadOnly = True
        txtKondisi.Properties.ReadOnly = True
        txtStatus.Properties.ReadOnly = True
        txtKeterangan.Properties.ReadOnly = True
        qrCode.Image = Nothing
    End Sub

    Private Sub EnableText()
        txtNomorSeri.Properties.ReadOnly = False
        txtNamaBarang.Properties.ReadOnly = False
        dtPerolehan.Properties.ReadOnly = False
        txtKondisi.Properties.ReadOnly = False
        txtStatus.Properties.ReadOnly = False
        txtKeterangan.Properties.ReadOnly = False
    End Sub

    Private Sub DefaultSetting()
        ClearScreen()
        DisableText()
        btnTambah.Enabled = True
        btnUbah.Enabled = False
        btnHapus.Enabled = False
        btnSimpan.Enabled = False
        btnCetak.Enabled = False
        btnBatal.Enabled = False
        btnTutup.Enabled = True
    End Sub
    Private Sub btnTutup_Click(sender As Object, e As EventArgs) Handles btnTutup.Click
        Me.Dispose()
    End Sub

    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        lNew = True
        btnSimpan.Enabled = False
        btnUbah.Enabled = False
        btnHapus.Enabled = False
        btnSimpan.Enabled = True
        btnCetak.Enabled = False
        btnBatal.Enabled = True
        btnTutup.Enabled = False
        ClearScreen()
        EnableText()
        txtNomorSeri.Focus()
    End Sub

    Private Sub frmMenu_Load(sender As Object, e As EventArgs) Handles Me.Load
        DefaultSetting()
        lNew = False
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        DefaultSetting()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim cMsg As String = MsgBox("Anda yakin ingin menghapus data ini?", vbOKCancel + vbExclamation, "Konfirmasi")
        If cMsg = vbOK Then
            Dim Conn As OleDbConnection = clsPublic.FileAccess
            Conn.Open()

            Using Cmd As New OleDbCommand
                Try
                    With Cmd
                        .Connection = Conn
                        .CommandText = "delete from inventory where [nomor seri] = '" & txtNomorSeri.Text.Trim & "'"
                        .ExecuteNonQuery()
                    End With
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            End Using
            Conn.Close()
        End If
        DefaultSetting()
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        btnHapus.Enabled = False
        btnSimpan.Enabled = True
        btnBatal.Enabled = True
        btnUbah.Enabled = False
        lNew = False
        EnableText()
        txtNamaBarang.Focus()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If lNew Then
            SaveData
        Else
            UpdateData
        End If
    End Sub

    Private Sub SaveData()
        If txtNomorSeri.Text.Trim = "" Then
            MsgBox("Nomor seri tidak boleh kosong", MsgBoxStyle.Critical, "Error!")
            txtNomorSeri.Focus()
            Exit Sub
        End If

        If DataVerification(txtNomorSeri.Text.Trim) Then
            MsgBox("Nomor seri sudah terdaftar dalam database, silahkan isi nomor seri baru", MsgBoxStyle.Critical, "Error!")
            txtNomorSeri.Text = ""
            txtNomorSeri.Focus()
            Exit Sub
        End If

        Try
            Dim ms As New MemoryStream
            Dim bmpImage As New Bitmap(qrCode.Image)

            bmpImage.Save(ms, Imaging.ImageFormat.Jpeg)
            bytImage = ms.ToArray()
            ms.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim Conn As OleDbConnection = clsPublic.FileAccess
        Conn.Open()

        Using Cmd As New OleDbCommand
            Try
                With Cmd
                    .Connection = Conn
                    .CommandType = CommandType.Text
                    .CommandText = "insert into inventory " &
                                   "([nomor seri],[nama barang]," &
                                   "[tahun],[kondisi],[status],[keterangan],[qrcode]) " &
                                   "values ('" & txtNomorSeri.Text.Trim & "','" &
                                   txtNamaBarang.Text.Trim & "','" &
                                   clsPublic.ConvertTanggal(dtPerolehan) & "','" &
                                   txtKondisi.Text.Trim & "','" &
                                   txtStatus.Text.Trim & "','" &
                                   txtKeterangan.Text.Trim & "'," &
                                   "@qrcode)"
                    .Parameters.AddWithValue("@qrcode", bytImage)
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Using
        Conn.Close()
        MsgBox("Data berhasil disimpan")
        Dim xForm As New DevExpress.Utils.WaitDialogForm
        xForm.LookAndFeel.UseDefaultLookAndFeel = False
        xForm.LookAndFeel.SkinName = "Blue"
        frmLaporan.CetakQrCode("qrcode_single.rpt", "{inventory.nomor seri} = '" & txtNomorSeri.Text.Trim & "'", "qrcode.mdb")
        frmLaporan.Show()
        frmLaporan.BringToFront()
        xForm.Dispose()

        DefaultSetting()
    End Sub

    Private Sub UpdateData()
        If txtNomorSeri.Text.Trim = "" Then
            MsgBox("Nomor seri tidak boleh kosong", MsgBoxStyle.Critical, "Error!")
            txtNomorSeri.Focus()
            Exit Sub
        End If

        Try
            Dim ms As New MemoryStream
            Dim bmpImage As New Bitmap(qrCode.Image)

            bmpImage.Save(ms, Imaging.ImageFormat.Jpeg)
            bytImage = ms.ToArray()
            ms.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

        Dim Conn As OleDbConnection = clsPublic.FileAccess
        Conn.Open()

        Using Cmd As New OleDbCommand
            Try
                With Cmd
                    .Connection = Conn
                    .CommandType = CommandType.Text
                    If lqrCode Then
                        .CommandText = "update inventory " &
                                   "set [nama barang] = '" & txtNamaBarang.Text.Trim & "'," &
                                   "[tahun] = '" & clsPublic.ConvertTanggal(dtPerolehan) & "'," &
                                   "[kondisi] = '" & txtKondisi.Text.Trim & "'," &
                                   "[status] = '" & txtStatus.Text.Trim & "'," &
                                   "[keterangan] = '" & txtKeterangan.Text.Trim & "'," &
                                   "[qrcode] = @qrcode where [nomor seri] = '" &
                                   txtNomorSeri.Text.Trim & "'"
                        .Parameters.AddWithValue("@qrcode", bytImage)
                    Else
                        .CommandText = "update inventory " &
                                  "set [nama barang] = '" & txtNamaBarang.Text.Trim & "'," &
                                  "[tahun] = '" & clsPublic.ConvertTanggal(dtPerolehan) & "'," &
                                  "[kondisi] = '" & txtKondisi.Text.Trim & "'," &
                                  "[status] = '" & txtStatus.Text.Trim & "'," &
                                  "[keterangan] = '" & txtKeterangan.Text.Trim & "' " &
                                  "where [nomor seri] = '" &
                                  txtNomorSeri.Text.Trim & "'"
                    End If
                    .ExecuteNonQuery()
                End With
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Using
        Conn.Close()
        MsgBox("Data berhasil disimpan")
        Dim xForm As New DevExpress.Utils.WaitDialogForm
        xForm.LookAndFeel.UseDefaultLookAndFeel = False
        xForm.LookAndFeel.SkinName = "Blue"
        frmLaporan.CetakQrCode("qrcode_single.rpt", "{inventory.nomor seri} = '" & txtNomorSeri.Text.Trim & "'", "qrcode.mdb")
        frmLaporan.Show()
        frmLaporan.BringToFront()
        xForm.Dispose()

        DefaultSetting()
    End Sub

    Private Function DataVerification(ByVal cNomorSeri As String) As Boolean
        Dim lFound As Boolean = False
        Dim Conn As OleDbConnection = clsPublic.FileAccess
        Conn.Open()

        Using Cmd As New OleDbCommand
            Try
                With Cmd
                    .Connection = Conn
                    .CommandText = "select [nomor seri] from inventory where [nomor seri] = '" & cNomorSeri.Trim & "'"
                    Dim rDr As OleDbDataReader = .ExecuteReader
                    While rDr.Read
                        If rDr.Item(0).ToString.Trim = cNomorSeri.Trim Then
                            lFound = True
                        Else
                            lFound = False
                        End If
                    End While

                    If rDr.HasRows = False Then
                        lFound = False
                    End If
                    rDr.Close()
                End With
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End Using
        Conn.Close()

        Return lFound
    End Function

    Private Sub btnCetak_Click(sender As Object, e As EventArgs) Handles btnCetak.Click
        Dim xForm As New DevExpress.Utils.WaitDialogForm
        xForm.LookAndFeel.UseDefaultLookAndFeel = False
        xForm.LookAndFeel.SkinName = "Blue"
        frmLaporan.CetakQrCode("qrcode_single.rpt", "{inventory.nomor seri} = '" & txtNomorSeri.Text.Trim & "'", "qrcode.mdb")
        frmLaporan.Show()
        frmLaporan.BringToFront()
        xForm.Dispose()
    End Sub

    Private Sub btnCetakAll_Click(sender As Object, e As EventArgs) Handles btnCetakAll.Click
        Dim xForm As New DevExpress.Utils.WaitDialogForm
        xForm.LookAndFeel.UseDefaultLookAndFeel = False
        xForm.LookAndFeel.SkinName = "Blue"
        frmLaporan.CetakQrCode("qrcode_single.rpt", "0", "qrcode.mdb")
        frmLaporan.Show()
        frmLaporan.BringToFront()
        xForm.Dispose()
    End Sub

    Private Sub btnGenqrCode_Click(sender As Object, e As EventArgs) Handles btnGenqrCode.Click
        Try
            Dim cString As String =
                txtNomorSeri.Text.Trim & " " & vbCrLf &
                txtNamaBarang.Text.Trim & " " & vbCrLf &
                Format(Date.Parse(dtPerolehan.DateTime), "dd-MM-yyyy")
            qrCode.Image = QR_code.Encode(cString.Trim)
            qrCode.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
            lqrCode = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtCariData_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtCariData.KeyPress
        If Asc(e.KeyChar) = 13 Then
            Using cfrmCariData As New frmCariData
                cfrmCariData.txtCariData.Text = txtCariData.Text.Trim
                cfrmCariData.ShowDialog()
                If cfrmCariData.cNomorSeri.Trim <> "" Then
                    lqrCode = False
                    txtNomorSeri.Text = cfrmCariData.cNomorSeri.Trim
                    Dim Conn As OleDbConnection = clsPublic.FileAccess
                    Conn.Open()

                    Using Cmd As New OleDbCommand
                        Try
                            With Cmd
                                .Connection = Conn

                                .CommandText = "select [nomor seri],[nama barang]," &
                                               "[tahun],[kondisi],[status],[keterangan],[qrcode] " &
                                               "from inventory where [nomor seri] = '" & txtNomorSeri.Text.Trim & "'"

                                Dim rDr As OleDbDataReader = .ExecuteReader
                                While rDr.Read
                                    txtNamaBarang.Text = rDr.Item(1).ToString.Trim
                                    dtPerolehan.DateTime = Date.Parse(rDr.Item(2).ToString.Trim)
                                    txtKondisi.Text = rDr.Item(3).ToString.Trim
                                    txtStatus.Text = rDr.Item(4).ToString.Trim
                                    txtKeterangan.Text = rDr.Item(5).ToString.Trim
                                    qrCode.Image = byteArrayToImage(rDr.Item(6))
                                    qrCode.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch
                                End While
                                rDr.Close()

                            End With
                        Catch ex As Exception
                            MsgBox(ex.Message)
                        End Try
                    End Using
                    Conn.Close()
                    btnUbah.Enabled = True
                    btnHapus.Enabled = True
                    btnCetak.Enabled = True
                    btnBatal.Enabled = True
                End If
            End Using
        End If
    End Sub

    Private Function byteArrayToImage(ByVal byteArrayIn As Byte()) As Image
        Using mStream As New MemoryStream(byteArrayIn)
            Return Image.FromStream(mStream)
        End Using
    End Function
End Class

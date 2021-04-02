<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmCariData
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim GridViewTextBoxColumn9 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn10 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn11 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim GridViewTextBoxColumn12 As Telerik.WinControls.UI.GridViewTextBoxColumn = New Telerik.WinControls.UI.GridViewTextBoxColumn()
        Dim TableViewDefinition3 As Telerik.WinControls.UI.TableViewDefinition = New Telerik.WinControls.UI.TableViewDefinition()
        Me.LayoutControl1 = New DevExpress.XtraLayout.LayoutControl()
        Me.grdData = New Telerik.WinControls.UI.RadGridView()
        Me.txtCariData = New DevExpress.XtraEditors.TextEdit()
        Me.Root = New DevExpress.XtraLayout.LayoutControlGroup()
        Me.LayoutControlItem1 = New DevExpress.XtraLayout.LayoutControlItem()
        Me.LayoutControlItem2 = New DevExpress.XtraLayout.LayoutControlItem()
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.LayoutControl1.SuspendLayout()
        CType(Me.grdData, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdData.MasterTemplate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtCariData.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LayoutControl1
        '
        Me.LayoutControl1.Controls.Add(Me.grdData)
        Me.LayoutControl1.Controls.Add(Me.txtCariData)
        Me.LayoutControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LayoutControl1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.UltraFlat
        Me.LayoutControl1.LookAndFeel.UseDefaultLookAndFeel = False
        Me.LayoutControl1.Name = "LayoutControl1"
        Me.LayoutControl1.Root = Me.Root
        Me.LayoutControl1.Size = New System.Drawing.Size(784, 561)
        Me.LayoutControl1.TabIndex = 0
        Me.LayoutControl1.Text = "LayoutControl1"
        '
        'grdData
        '
        Me.grdData.BackColor = System.Drawing.SystemColors.Control
        Me.grdData.Cursor = System.Windows.Forms.Cursors.Default
        Me.grdData.Font = New System.Drawing.Font("Segoe UI", 8.25!)
        Me.grdData.ForeColor = System.Drawing.SystemColors.ControlText
        Me.grdData.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.grdData.Location = New System.Drawing.Point(5, 35)
        '
        '
        '
        Me.grdData.MasterTemplate.AllowAddNewRow = False
        Me.grdData.MasterTemplate.AllowEditRow = False
        GridViewTextBoxColumn9.EnableExpressionEditor = False
        GridViewTextBoxColumn9.HeaderText = "NO. REGISTER"
        GridViewTextBoxColumn9.Name = "column1"
        GridViewTextBoxColumn9.Width = 149
        GridViewTextBoxColumn10.EnableExpressionEditor = False
        GridViewTextBoxColumn10.HeaderText = "NAMA BARANG"
        GridViewTextBoxColumn10.Name = "column2"
        GridViewTextBoxColumn10.Width = 379
        GridViewTextBoxColumn11.EnableExpressionEditor = False
        GridViewTextBoxColumn11.HeaderText = "TAHUN"
        GridViewTextBoxColumn11.Name = "column3"
        GridViewTextBoxColumn11.Width = 96
        GridViewTextBoxColumn12.EnableExpressionEditor = False
        GridViewTextBoxColumn12.HeaderText = "KONDISI"
        GridViewTextBoxColumn12.Name = "column4"
        GridViewTextBoxColumn12.Width = 136
        Me.grdData.MasterTemplate.Columns.AddRange(New Telerik.WinControls.UI.GridViewDataColumn() {GridViewTextBoxColumn9, GridViewTextBoxColumn10, GridViewTextBoxColumn11, GridViewTextBoxColumn12})
        Me.grdData.MasterTemplate.EnableAlternatingRowColor = True
        Me.grdData.MasterTemplate.EnableGrouping = False
        Me.grdData.MasterTemplate.ShowRowHeaderColumn = False
        Me.grdData.MasterTemplate.ViewDefinition = TableViewDefinition3
        Me.grdData.Name = "grdData"
        Me.grdData.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.grdData.ShowGroupPanel = False
        Me.grdData.Size = New System.Drawing.Size(774, 521)
        Me.grdData.TabIndex = 5
        Me.grdData.Tag = "Tekan enter untuk memilih record"
        '
        'txtCariData
        '
        Me.txtCariData.EnterMoveNextControl = True
        Me.txtCariData.Location = New System.Drawing.Point(55, 5)
        Me.txtCariData.Name = "txtCariData"
        Me.txtCariData.Size = New System.Drawing.Size(724, 20)
        Me.txtCariData.StyleController = Me.LayoutControl1
        Me.txtCariData.TabIndex = 4
        Me.txtCariData.ToolTip = "Anda bisa melakukan pencarian data berdasarakan [nomor seri] dan [nama barang], " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "untuk memilih data pada data-grid tekan tombol enter."
        Me.txtCariData.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Information
        Me.txtCariData.ToolTipTitle = "Informasi"
        '
        'Root
        '
        Me.Root.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.[True]
        Me.Root.GroupBordersVisible = False
        Me.Root.Items.AddRange(New DevExpress.XtraLayout.BaseLayoutItem() {Me.LayoutControlItem1, Me.LayoutControlItem2})
        Me.Root.Name = "Root"
        Me.Root.OptionsItemText.TextToControlDistance = 5
        Me.Root.Size = New System.Drawing.Size(784, 561)
        Me.Root.TextVisible = False
        '
        'LayoutControlItem1
        '
        Me.LayoutControlItem1.Control = Me.txtCariData
        Me.LayoutControlItem1.Location = New System.Drawing.Point(0, 0)
        Me.LayoutControlItem1.Name = "LayoutControlItem1"
        Me.LayoutControlItem1.Size = New System.Drawing.Size(784, 30)
        Me.LayoutControlItem1.Text = "Cari Data"
        Me.LayoutControlItem1.TextSize = New System.Drawing.Size(45, 13)
        '
        'LayoutControlItem2
        '
        Me.LayoutControlItem2.Control = Me.grdData
        Me.LayoutControlItem2.Location = New System.Drawing.Point(0, 30)
        Me.LayoutControlItem2.Name = "LayoutControlItem2"
        Me.LayoutControlItem2.Size = New System.Drawing.Size(784, 531)
        Me.LayoutControlItem2.TextSize = New System.Drawing.Size(0, 0)
        Me.LayoutControlItem2.TextVisible = False
        '
        'frmCariData
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(784, 561)
        Me.Controls.Add(Me.LayoutControl1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmCariData"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cari Data"
        CType(Me.LayoutControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.LayoutControl1.ResumeLayout(False)
        CType(Me.grdData.MasterTemplate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdData, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtCariData.Properties, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Root, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LayoutControlItem2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LayoutControl1 As DevExpress.XtraLayout.LayoutControl
    Friend WithEvents Root As DevExpress.XtraLayout.LayoutControlGroup
    Friend WithEvents grdData As Telerik.WinControls.UI.RadGridView
    Friend WithEvents txtCariData As DevExpress.XtraEditors.TextEdit
    Friend WithEvents LayoutControlItem1 As DevExpress.XtraLayout.LayoutControlItem
    Friend WithEvents LayoutControlItem2 As DevExpress.XtraLayout.LayoutControlItem
End Class

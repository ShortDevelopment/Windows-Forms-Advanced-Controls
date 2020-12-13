<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Knoten1")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Knoten2")
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Knoten0", New System.Windows.Forms.TreeNode() {TreeNode16, TreeNode17})
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ExplorerTreeView1 = New LKControlLibrary.ExplorerTreeView()
        Me.VistaLinkButton2 = New LKControlLibrary.VistaLinkButton()
        Me.VistaLinkButton1 = New LKControlLibrary.VistaLinkButton()
        Me.PlaceholderTextBox1 = New LKControlLibrary.PlaceholderTextBox()
        Me.ChartControl1 = New LKControlLibrary.ChartControl()
        Me.ProgressBar1 = New LKControlLibrary.ProgressBar()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(12, 27)
        Me.Button1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 10)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Set Progress"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 500
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(12, 88)
        Me.Button2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 10)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Clear"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(12, 361)
        Me.Button3.Margin = New System.Windows.Forms.Padding(3, 2, 3, 10)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 5
        Me.Button3.Text = "Add Point"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ExplorerTreeView1
        '
        Me.ExplorerTreeView1.HotTracking = True
        Me.ExplorerTreeView1.Location = New System.Drawing.Point(451, 12)
        Me.ExplorerTreeView1.Name = "ExplorerTreeView1"
        TreeNode16.Name = "Knoten1"
        TreeNode16.Text = "Knoten1"
        TreeNode17.Name = "Knoten2"
        TreeNode17.Text = "Knoten2"
        TreeNode18.Name = "Knoten0"
        TreeNode18.Text = "Knoten0"
        Me.ExplorerTreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode18})
        Me.ExplorerTreeView1.Size = New System.Drawing.Size(202, 236)
        Me.ExplorerTreeView1.TabIndex = 8
        '
        'VistaLinkButton2
        '
        Me.VistaLinkButton2.Location = New System.Drawing.Point(258, 397)
        Me.VistaLinkButton2.Name = "VistaLinkButton2"
        Me.VistaLinkButton2.NoticeText = "Test"
        Me.VistaLinkButton2.Size = New System.Drawing.Size(171, 50)
        Me.VistaLinkButton2.TabIndex = 7
        Me.VistaLinkButton2.Text = "VistaLinkButton2"
        Me.VistaLinkButton2.UseAdminShield = True
        Me.VistaLinkButton2.UseVisualStyleBackColor = True
        '
        'VistaLinkButton1
        '
        Me.VistaLinkButton1.Location = New System.Drawing.Point(12, 397)
        Me.VistaLinkButton1.Name = "VistaLinkButton1"
        Me.VistaLinkButton1.NoticeText = "Test"
        Me.VistaLinkButton1.Size = New System.Drawing.Size(171, 50)
        Me.VistaLinkButton1.TabIndex = 6
        Me.VistaLinkButton1.Text = "VistaLinkButton1"
        Me.VistaLinkButton1.UseVisualStyleBackColor = True
        '
        'PlaceholderTextBox1
        '
        Me.PlaceholderTextBox1.Location = New System.Drawing.Point(12, 63)
        Me.PlaceholderTextBox1.Name = "PlaceholderTextBox1"
        Me.PlaceholderTextBox1.PlaceHolder = "Test"
        Me.PlaceholderTextBox1.Size = New System.Drawing.Size(338, 20)
        Me.PlaceholderTextBox1.TabIndex = 3
        '
        'ChartControl1
        '
        Me.ChartControl1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(17, Byte), Integer), CType(CType(125, Byte), Integer), CType(CType(187, Byte), Integer))
        Me.ChartControl1.GraphPosition = New System.Drawing.Point(0, 0)
        Me.ChartControl1.Location = New System.Drawing.Point(12, 124)
        Me.ChartControl1.Name = "ChartControl1"
        Me.ChartControl1.Size = New System.Drawing.Size(417, 232)
        Me.ChartControl1.TabIndex = 1
        Me.ChartControl1.Text = "ChartControl1"
        Me.ChartControl1.XUnit = 40
        Me.ChartControl1.YUnit = 40
        '
        'ProgressBar1
        '
        Me.ProgressBar1.BackColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer))
        Me.ProgressBar1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(35, Byte), Integer), CType(CType(151, Byte), Integer), CType(CType(201, Byte), Integer))
        Me.ProgressBar1.Location = New System.Drawing.Point(12, 12)
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Orientation = LKControlLibrary.ProgressBar.ProgressBarOrientation.Horizontal
        Me.ProgressBar1.Size = New System.Drawing.Size(338, 10)
        Me.ProgressBar1.TabIndex = 0
        Me.ProgressBar1.TabStop = False
        Me.ProgressBar1.Text = "ProgressBar1"
        Me.ProgressBar1.Value = 50
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(451, 264)
        Me.Button4.Margin = New System.Windows.Forms.Padding(3, 2, 3, 10)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(202, 23)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Open Folder Dialog"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(746, 459)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.ExplorerTreeView1)
        Me.Controls.Add(Me.VistaLinkButton2)
        Me.Controls.Add(Me.VistaLinkButton1)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.PlaceholderTextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.ChartControl1)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ProgressBar1 As LKControlLibrary.ProgressBar
    Friend WithEvents ChartControl1 As LKControlLibrary.ChartControl
    Friend WithEvents Button1 As Button
    Friend WithEvents Timer1 As Timer
    Friend WithEvents PlaceholderTextBox1 As LKControlLibrary.PlaceholderTextBox
    Friend WithEvents Button2 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents VistaLinkButton1 As LKControlLibrary.VistaLinkButton
    Friend WithEvents VistaLinkButton2 As LKControlLibrary.VistaLinkButton
    Friend WithEvents ExplorerTreeView1 As LKControlLibrary.ExplorerTreeView
    Friend WithEvents Button4 As Button
End Class

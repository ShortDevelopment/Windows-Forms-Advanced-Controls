Imports System.ComponentModel
Imports LKControlLibrary.Animation

<ToolboxBitmap(GetType(System.Windows.Forms.ProgressBar))>
Public Class ProgressBar
    Inherits Control

    Public Sub New()
        DoubleBuffered = True
        BackColor = Color.FromArgb(229, 229, 229)
        ForeColor = Color.FromArgb(35, 151, 201)
    End Sub

    Private WithEvents Animator As Animator

    Dim buffervalue As Integer
    Dim _value As Integer = 0
    ''' <summary>
    ''' Gets or sets the current value
    ''' </summary>
    ''' <returns></returns>
    <Browsable(True), DefaultValue(0), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property Value As Integer
        Get
            Return _value
        End Get
        Set(value As Integer)
            If value < 0 Or value > Max Then Throw New ArgumentException("Value must be between 0 and max")
            If Not Animator Is Nothing Then Animator.Cancel()
            Animator = New Animator(Me.Value, value, 500)
            Animator.Start()
            _value = value
        End Set
    End Property
    Dim _max As Integer = 100
    ''' <summary>
    ''' Gets or sets the maximum value
    ''' </summary>
    ''' <returns></returns>
    <Browsable(True), DefaultValue(100), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property Max As Integer
        Get
            Return _max
        End Get
        Set(value As Integer)
            If value < 0 Or value < Me.Value Then Throw New ArgumentException("Max must be greater than 0 and value")
            _max = value
            Me.Refresh()
        End Set
    End Property
    Enum ProgressBarOrientation
        Horizontal
        Vertical
    End Enum
    ''' <summary>
    ''' Gets or sets the orientation of the ProgressBar
    ''' </summary>
    ''' <returns></returns>
    <Browsable(True), DefaultValue("Horizontal"), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property Orientation As ProgressBarOrientation = ProgressBarOrientation.Horizontal

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim percent = buffervalue / Max
        Dim rect As Rectangle
        If Orientation = ProgressBarOrientation.Vertical Then
            rect = New Rectangle(0, Me.Height - percent * Me.Height, Me.Width, percent * Me.Height)
        Else
            rect = New Rectangle(0, 0, percent * Me.Width, Me.Height)
        End If
        Using brush As New SolidBrush(ForeColor)
            e.Graphics.FillRectangle(brush, rect)
        End Using
    End Sub
    Protected Overrides Sub OnPaintBackground(pevent As PaintEventArgs)
        pevent.Graphics.Clear(BackColor)
    End Sub

    Private Sub Animator_ValueChanged(value As Integer) Handles Animator.ValueChanged
        buffervalue = value
        Try
            Me.Invoke(Sub()
                          Me.Refresh()
                          Application.DoEvents()
                      End Sub)
        Catch : End Try
    End Sub
End Class
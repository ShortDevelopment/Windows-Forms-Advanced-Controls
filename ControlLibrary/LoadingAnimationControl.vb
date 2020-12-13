Imports System.ComponentModel

Public Class LoadingAnimationControl
    Inherits Control

    Public Sub New()
        SetStyle(ControlStyles.ResizeRedraw Or ControlStyles.Opaque, True)
        ForeColor = Color.FromArgb(35, 151, 201)
    End Sub

    Dim currentpos As Integer = 0
    Dim _length As Integer = 90
    ''' <summary>
    ''' Angle between 0 and 180 degrees
    ''' </summary>
    ''' <returns></returns>
    <Browsable(True), DefaultValue(90), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)>
    Public Property LengthAngle As Integer
        Get
            Return _length
        End Get
        Set(value As Integer)
            If value < 0 Or value > 180 Then Throw New ArgumentException("Angle must be between 0 and 180 degrees")
            _length = value
        End Set
    End Property

    Protected Overrides Sub OnPaintBackground(pevent As PaintEventArgs)
        'Using brush As New SolidBrush(Color.Transparent)
        '    pevent.Graphics.FillRectangle(brush, New Rectangle(New Point(0, 0), Me.Size))
        'End Using
    End Sub
    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim params = MyBase.CreateParams
            params.Style = params.Style Or &H20
            Return params
        End Get
    End Property

    Dim waitingforpaint As Boolean = False

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        If waitingforpaint Then Exit Sub
        Using brush As New SolidBrush(Color.Transparent)
            e.Graphics.FillRectangle(brush, New Rectangle(New Point(0, 0), Me.Size))
        End Using
        If Not Parent Is Nothing Then
            waitingforpaint = True
            Me.Parent.Invalidate(New Rectangle(Me.Location, Me.Size), True)
            Me.Parent.Update()
            Application.DoEvents()
            waitingforpaint = False
        End If
        Dim g = e.Graphics
        Using pen As New Pen(ForeColor, 4)
            g.DrawArc(pen, New Rectangle(0, 0, Me.Width, Me.Height), currentpos, currentpos + LengthAngle)
        End Using
    End Sub

    Sub Redraw()
        'If Parent Is Nothing Then Exit Sub
        'Me.Invalidate()
        'Using g = CreateGraphics()
        '    Using brush As New SolidBrush(Color.Transparent)
        '        g.FillRectangle(brush, New Rectangle(New Point(0, 0), Me.Size))
        '    End Using
        'End Using
        'Me.Parent.Invalidate(New Rectangle(Me.Location, Me.Size))
        'Me.Parent.Update()
        Me.Refresh()
    End Sub
    Private Sub LoadingAnimationControl_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Redraw()
    End Sub
    Private Sub LoadingAnimationControl_Move(sender As Object, e As EventArgs) Handles Me.Move
        Redraw()
    End Sub
End Class
Imports LKControlLibrary

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        xcount = ChartControl1.Graph.Last().X
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'ChartControl1.GraphPosition = New Point(0, 10)
        ProgressBar1.Value = New Random().Next(0, 100)
    End Sub

    Dim xcount
    Private Sub Timer1_Tick() Handles Timer1.Tick, Button3.Click
        xcount += 1
        ChartControl1.Graph.Add(New Point(xcount, New Random().Next(1, 10)))
        ChartControl1.GraphPosition = New Point(ChartControl1.GraphPosition.X - 40, 0)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PlaceholderTextBox1.Text = Nothing
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click, VistaLinkButton1.Click
        Dim d As New SelectFolderDialog
        d.Title = "Title"
        If d.ShowDialog() = DialogResult.OK Then
            MsgBox($"Selected: {d.SelectedFolder}", MsgBoxStyle.Information)
        End If
    End Sub
End Class

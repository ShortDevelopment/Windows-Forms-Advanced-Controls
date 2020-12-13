Imports System.ComponentModel
Imports System.Runtime.InteropServices

''' <summary>
''' TextBox with placeholder
''' Credits: https://www.codeproject.com/Articles/18858/Fully-themed-Windows-Vista-Controls
''' </summary>
<ToolboxBitmap(GetType(TextBox))>
Public Class PlaceholderTextBox
    Inherits TextBox

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As IntPtr, lParam As String) As IntPtr : End Function

    Private Const ECM_FIRST = &H1500
    Private Const EM_SETCUEBANNER = ECM_FIRST + 1

    Dim _PlaceHolder As String = ""
    ''' <summary>
    ''' Gets or sets the placeholder of the textbox
    ''' </summary>
    ''' <returns></returns>
    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), DefaultValue(""), Description("Gets or sets the placeholder of the textbox"), Category("Appearance")>
    Public Property PlaceHolder As String
        Get
            Return _PlaceHolder
        End Get
        Set(value As String)
            _PlaceHolder = value
            Try
                SendMessage(Me.Handle, EM_SETCUEBANNER, IntPtr.Zero, value)
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End Set
    End Property

End Class

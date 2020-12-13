Imports System.ComponentModel
Imports System.Runtime.InteropServices
''' <summary>
''' Buttons used in System Control Panel
''' Credits: https://www.codeproject.com/Articles/18858/Fully-themed-Windows-Vista-Controls
''' </summary>
<ToolboxBitmap(GetType(Button))>
Public Class VistaLinkButton
    Inherits Button

    Private Const BS_COMMANDLINK = &HE

    Protected Overrides ReadOnly Property CreateParams As CreateParams
        Get
            Dim params = MyBase.CreateParams
            params.Style = params.Style Or BS_COMMANDLINK
            Return params
        End Get
    End Property

    Public Sub New()
        MyBase.FlatStyle = FlatStyle.System
    End Sub

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shadows Property FlatStyle As FlatStyle
        Get
            Return MyBase.FlatStyle
        End Get
        Set(value As FlatStyle)
            Throw New NotSupportedException()
        End Set
    End Property
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shadows Property Image As Bitmap
        Get
            Return MyBase.Image
        End Get
        Set(value As Bitmap)
            Throw New NotSupportedException()
        End Set
    End Property

    Private Const BCM_SETNOTE As UInteger = &H1609

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As IntPtr, lParam As String) As IntPtr : End Function

    Dim _NoticeText As String = ""
    ''' <summary>
    ''' Description text in second row
    ''' </summary>
    ''' <returns></returns>
    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), DefaultValue(""), Description("Description text in second row"), Category("Appearance")>
    Public Property NoticeText As String
        Get
            Return _NoticeText
        End Get
        Set(value As String)
            _NoticeText = value
            SendMessage(Me.Handle, BCM_SETNOTE, IntPtr.Zero, value)
        End Set
    End Property

    Private Const BCM_SETSHIELD = &H160C

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As IntPtr, lParam As Boolean) As IntPtr : End Function

    Dim _UseAdminShield As Boolean = False
    ''' <summary>
    ''' Gets or sets wether administrator shield should appear instead of arrow
    ''' </summary>
    ''' <returns></returns>
    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), DefaultValue(False), Description("Gets or sets wether administrator shield should appear instead of arrow"), Category("Appearance")>
    Public Property UseAdminShield As Boolean
        Get
            Return _UseAdminShield
        End Get
        Set(value As Boolean)
            _UseAdminShield = value
            SendMessage(Me.Handle, BCM_SETSHIELD, IntPtr.Zero, value)
        End Set
    End Property

End Class

Imports System.ComponentModel
Imports System.Runtime.InteropServices
''' <summary>
''' Explorer like treeview
''' </summary>
<ToolboxBitmap(GetType(TreeView))>
Public Class ExplorerTreeView
    Inherits TreeView

    Private Const TVS_EX_FADEINOUTEXPANDOS = &H40
    Private Const TVS_EX_NOSINGLECOLLAPSE = &H1
    Private Const TVS_EX_DOUBLEBUFFERED = &H4
    Private Const TVS_EX_RICHTOOLTIP = &H10
    Private Const TVS_EX_DRAWIMAGEASYNC = &H400

    Private Const TV_FIRST = &H1100
    Private Const TVM_SETEXTENDEDSTYLE = TV_FIRST + 44

    <DllImport("user32.dll", CharSet:=CharSet.Auto)>
    Private Shared Function SendMessage(hWnd As IntPtr, msg As Integer, wParam As IntPtr, lParam As Integer) As IntPtr : End Function

    <DllImport("uxtheme", CharSet:=CharSet.Unicode)>
    Private Shared Function SetWindowTheme(ByVal hWnd As IntPtr, ByVal textSubAppName As String, ByVal textSubIdList As String) As Int32 : End Function

    Public Sub New()
        SetWindowTheme(Me.Handle, "explorer", Nothing)
        SetStyle(ControlStyles.Selectable, False)
        MyBase.ShowLines = False
        MyBase.HotTracking = True
        SendMessage(Me.Handle, TVM_SETEXTENDEDSTYLE, 0, TVS_EX_FADEINOUTEXPANDOS Or TVS_EX_NOSINGLECOLLAPSE Or TVS_EX_DOUBLEBUFFERED Or TVS_EX_RICHTOOLTIP Or TVS_EX_DRAWIMAGEASYNC)
    End Sub

    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public Shadows Property ShowLines As Boolean
        Get
            Return MyBase.ShowLines
        End Get
        Set(value As Boolean)
            Throw New NotSupportedException()
        End Set
    End Property

End Class

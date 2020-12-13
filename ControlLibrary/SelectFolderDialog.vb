Imports System.ComponentModel
Imports System.Runtime.CompilerServices
Imports System.Runtime.InteropServices

''' <summary>
''' Windows 10 version of <see cref="FolderBrowserDialog"/>
''' </summary>
<ToolboxBitmap(GetType(FolderBrowserDialog))>
Public Class SelectFolderDialog
    Inherits CommonDialog

    Public Sub New()
        If Not (Environment.OSVersion.Platform = PlatformID.Win32NT AndAlso Environment.OSVersion.Version.Major >= 6) Then Throw New NotSupportedException()
    End Sub

    ''' <summary>
    ''' Title displayed in dialog
    ''' </summary>
    ''' <returns></returns>
    <Browsable(True), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), DefaultValue(""), Description("Title displayed in dialog"), Category("Appearance")>
    Public Property Title As String

    ''' <summary>
    ''' Gets selected Folder
    ''' </summary>
    ''' <returns></returns>
    <Browsable(False), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)>
    Public ReadOnly Property SelectedFolder As String

    Public Overrides Sub Reset()

    End Sub

    Private Const FOS_PICKFOLDERS = &H20
    Private Const FOS_FORCEFILESYSTEM = &H40
    Private Const FOS_FILEMUSTEXIST = &H1000
    Private Const ERROR_CANCELLED = &H800704C7
    Private Const SIGDN_FILESYSPATH = &H80058000

    Protected Overrides Function RunDialog(hwndOwner As IntPtr) As Boolean
        Dim dialog As IFileDialog = Activator.CreateInstance(Type.GetTypeFromCLSID(New Guid("DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7"), Nothing, True))
        If Not String.IsNullOrEmpty(Title) Then dialog.SetTitle(Title)
        dialog.SetOptions(FOS_PICKFOLDERS Or FOS_FORCEFILESYSTEM Or &H1000)
        Dim result As Integer = dialog.Show(hwndOwner)
        If result < 0 Then
            If result = ERROR_CANCELLED Then
                Return False
            Else
                Throw New Win32Exception(result)
            End If
        End If
        Dim res As IShellItem
        dialog.GetResult(res)
        res.GetDisplayName(SIGDN_FILESYSPATH, _SelectedFolder)
        Return True
    End Function

    <ComImport, Guid("DC1C5A9C-E88A-4dde-A5A1-60F82A20AEF7"), ClassInterface(ClassInterfaceType.None), TypeLibType(TypeLibTypeFlags.FCanCreate)>
    Private Class FileOpenDialogRCW
    End Class

    <ComImport(), Guid("b4db1657-70d7-485e-8e3e-6fcb5a5c1802"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Private Interface IModalWindow
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), PreserveSig>
        Function Show(<[In]> ByVal parent As IntPtr) As Integer
    End Interface

    <ComImport(), Guid("42f85136-db7e-439c-85f1-e4075d135fc8"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Private Interface IFileDialog
        Inherits IModalWindow

        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime), PreserveSig>
        Overloads Function Show(<[In]> ByVal parent As IntPtr) As Integer
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub SetFileTypes(<[In]> ByVal cFileTypes As UInteger, <[In], MarshalAs(UnmanagedType.LPArray)> ByVal rgFilterSpec As Object()) ' NativeMethods.COMDLG_FILTERSPEC
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub SetFileTypeIndex(<[In]> ByVal iFileType As UInteger)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub GetFileTypeIndex(<Out> ByRef piFileType As UInteger)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub Advise(<[In], MarshalAs(UnmanagedType.[Interface])> ByVal pfde As Object, <Out> ByRef pdwCookie As UInteger) ' IFileDialogEvents
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub Unadvise(<[In]> ByVal dwCookie As UInteger)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub SetOptions(<[In]> ByVal fos As FOS)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub GetOptions(<Out> ByRef pfos As FOS)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub SetDefaultFolder(<[In], MarshalAs(UnmanagedType.[Interface])> ByVal psi As IShellItem)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub SetFolder(<[In], MarshalAs(UnmanagedType.[Interface])> ByVal psi As IShellItem)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub GetFolder(<Out, MarshalAs(UnmanagedType.[Interface])> ByRef ppsi As IShellItem)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub GetCurrentSelection(<Out, MarshalAs(UnmanagedType.[Interface])> ByRef ppsi As IShellItem)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub SetFileName(<[In], MarshalAs(UnmanagedType.LPWStr)> ByVal pszName As String)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub GetFileName(<Out, MarshalAs(UnmanagedType.LPWStr)> ByRef pszName As String)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub SetTitle(<[In], MarshalAs(UnmanagedType.LPWStr)> ByVal pszTitle As String)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub SetOkButtonLabel(<[In], MarshalAs(UnmanagedType.LPWStr)> ByVal pszText As String)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub SetFileNameLabel(<[In], MarshalAs(UnmanagedType.LPWStr)> ByVal pszLabel As String)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub GetResult(<Out> <MarshalAs(UnmanagedType.[Interface])> ByRef ppsi As IShellItem)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub AddPlace(<[In], MarshalAs(UnmanagedType.[Interface])> ByVal psi As IShellItem, ByVal fdap As Object) ' FDAP
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub SetDefaultExtension(<[In], MarshalAs(UnmanagedType.LPWStr)> ByVal pszDefaultExtension As String)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub Close(<MarshalAs(UnmanagedType.[Error])> ByVal hr As Integer)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub SetClientGuid(<[In]> ByRef guid As Guid)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub ClearClientData()
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub SetFilter(<MarshalAs(UnmanagedType.[Interface])> ByVal pFilter As IntPtr)
    End Interface

    <ComImport, Guid("43826D1E-E718-42EE-BC55-A1E261C37BFE"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Private Interface IShellItem
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub BindToHandler(<[In], MarshalAs(UnmanagedType.[Interface])> ByVal pbc As IntPtr, <[In]> ByRef bhid As Guid, <[In]> ByRef riid As Guid, <Out> ByRef ppv As IntPtr)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub GetParent(<Out> <MarshalAs(UnmanagedType.[Interface])> ByRef ppsi As IShellItem)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub GetDisplayName(<[In]> ByVal sigdnName As SIGDN, <Out> <MarshalAs(UnmanagedType.LPWStr)> ByRef ppszName As String)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub GetAttributes(<[In]> ByVal sfgaoMask As UInteger, <Out> ByRef psfgaoAttribs As UInteger)
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub Compare(<[In], MarshalAs(UnmanagedType.[Interface])> ByVal psi As IShellItem, <[In]> ByVal hint As UInteger, <Out> ByRef piOrder As Integer)
    End Interface

    Private Enum SIGDN
        SIGDN_NORMALDISPLAY = &H0
        SIGDN_PARENTRELATIVEPARSING = &H80018001
        SIGDN_DESKTOPABSOLUTEPARSING = &H80028000
        SIGDN_PARENTRELATIVEEDITING = &H80031001
        SIGDN_DESKTOPABSOLUTEEDITING = &H8004C000
        SIGDN_FILESYSPATH = &H80058000
        SIGDN_URL = &H80068000
        SIGDN_PARENTRELATIVEFORADDRESSBAR = &H8007C001
        SIGDN_PARENTRELATIVE = &H80080001
    End Enum

    <Flags>
    Private Enum FOS
        FOS_OVERWRITEPROMPT = &H2
        FOS_STRICTFILETYPES = &H4
        FOS_NOCHANGEDIR = &H8
        FOS_PICKFOLDERS = &H20
        FOS_FORCEFILESYSTEM = &H40
        FOS_ALLNONSTORAGEITEMS = &H80
        FOS_NOVALIDATE = &H100
        FOS_ALLOWMULTISELECT = &H200
        FOS_PATHMUSTEXIST = &H800
        FOS_FILEMUSTEXIST = &H1000
        FOS_CREATEPROMPT = &H2000
        FOS_SHAREAWARE = &H4000
        FOS_NOREADONLYRETURN = &H8000
        FOS_NOTESTFILECREATE = &H10000
        FOS_HIDEMRUPLACES = &H20000
        FOS_HIDEPINNEDPLACES = &H40000
        FOS_NODEREFERENCELINKS = &H100000
        FOS_DONTADDTORECENT = &H2000000
        FOS_FORCESHOWHIDDEN = &H10000000
        FOS_DEFAULTNOMINIMODE = &H20000000
    End Enum

    <ComImport, Guid("8016b7b3-3d49-4504-a0aa-2a37494e606f"), InterfaceType(ComInterfaceType.InterfaceIsIUnknown)>
    Friend Interface IFileDialogCustomize
        <MethodImpl(MethodImplOptions.InternalCall, MethodCodeType:=MethodCodeType.Runtime)>
        Sub AddText(<[In]> ByVal dwIDCtl As Integer, <[In], MarshalAs(UnmanagedType.LPWStr)> ByVal pszText As String)
    End Interface


End Class

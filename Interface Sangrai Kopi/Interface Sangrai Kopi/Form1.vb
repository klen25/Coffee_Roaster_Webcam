Imports System.Runtime.InteropServices
Public Class Form1
    Const WM_CAP_START = &H400S
    Const WS_CHILD = &H40000000
    Const WS_VISIBLE = &H10000000

    Const WM_CAP_DRIVER_CONNECT = WM_CAP_START + 10
    Const WM_CAP_DRIVER_DISCONNECT = WM_CAP_START + 11
    Const WM_CAP_EDIT_COPY = WM_CAP_START + 30
    Const WM_CAP_SEQUENCE = WM_CAP_START + 62
    Const WM_CAP_FILE_SAVES = WM_CAP_START + 23

    Const WM_CAP_SET_SCALE = WM_CAP_START + 53
    Const WM_CAP_SET_PREVIEWRATE = WM_CAP_START + 52
    Const WM_CAP_SET_PREVIEW = WM_CAP_START + 50

    Const SWP_NOMOVE = &H2S
    Const SWP_NOSIZE = 1
    Const SWP_NOZORDER = &H4S
    Const HWND_BOTTOM = 1

    Declare Function capGetDriverDescriptionA Lib "avicap32.dll" (ByVal wDriverIndex As Short, ByVal lpszName As String, ByVal cbName As Integer, ByVal lpszVer As String, ByVal cbVer As Integer) As Boolean

    Declare Function capCreateCaptureWindowA Lib "avicap32.dll" (ByVal lpszWindowName As String, ByVal dwStyle As Integer, ByVal x As Integer, ByVal y As Integer, ByVal nWidth As Integer, ByVal nHeight As Short, ByVal hWnd As Integer, ByVal nID As Integer) As Integer

    Declare Function SendMessage Lib "user32" Alias "SendMessageA" (ByVal hwnd As Integer, ByVal Msg As Integer, ByVal wParam As Integer, <MarshalAs(UnmanagedType.AsAny)> ByVal lParam As Object) As Integer

    Declare Function SetWindowPos Lib "user32" Alias "SetWindowPos" (ByVal hwnd As Integer, ByVal hWndInsertAfter As Integer, ByVal x As Integer, ByVal y As Integer, ByVal cx As Integer, ByVal cy As Integer, ByVal wFlags As Integer) As Integer

    Declare Function DestroyWindow Lib "user32" (ByVal hndw As Integer) As Boolean

    Dim VideoSource As Integer
    Dim hWnd As Integer

    Private Declare Function GetPixel Lib "gdi32" (ByVal hdc As Long, ByVal X As Long, ByVal Y As Long) As Long
    Private Declare Function SetPixel Lib "gdi32" (ByVal hdc As Long, ByVal X As Long, ByVal Y As Long, ByVal crColor As Long) As Long

    Dim R As Integer, G As Integer, B As Integer
    Dim GradX As Long, GradY As Long, Grad As Long
    Dim PixelValue As Long

    Sub DecToRGB(ByVal Col As Long, R As Integer, G As Integer, B As Integer)
        R = Col Mod 256
        G = ((Col - R) Mod 65536) / 256
        B = (Col - R - G) / 65536
        If R < 0 Then
            R = 0
        End If
        If R >= 255 Then
            R = 255
        End If
        If G < 0 Then
            G = 0
        End If
        If G >= 255 Then
            G = 255
        End If
        If B < 0 Then
            B = 0
        End If
        If B >= 255 Then
            B = 255
        End If
    End Sub
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim DriverName As String = Space(80)
        Dim DriverVersion As String = Space(80)
        For i As Integer = 0 To 9
            If capGetDriverDescriptionA(i, DriverName, 80, DriverVersion, 80) Then
                ListBox1.Items.Add(DriverName.Trim)
            End If
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
        SendMessage(hWnd, WM_CAP_DRIVER_DISCONNECT, VideoSource, 0)
        DestroyWindow(hWnd)

        VideoSource = ListBox1.SelectedIndex
        hWnd = capCreateCaptureWindowA(VideoSource, WS_VISIBLE Or WS_CHILD, 0, 0, 0, 0, PictureBox1.Handle.ToInt32, 0)
        If SendMessage(hWnd, WM_CAP_DRIVER_CONNECT, VideoSource, 0) Then
            SendMessage(hWnd, WM_CAP_SET_SCALE, True, 0)
            SendMessage(hWnd, WM_CAP_SET_PREVIEWRATE, 30, 0)
            SendMessage(hWnd, WM_CAP_SET_PREVIEW, True, 0)
            SetWindowPos(hWnd, HWND_BOTTOM, 0, 0, PictureBox1.Width, PictureBox1.Height, SWP_NOMOVE Or SWP_NOZORDER)
            '            TextBox1.Text = 
        Else
            DestroyWindow(hWnd)
        End If
    End Sub

    Private Sub BtnCapture_Click(sender As Object, e As EventArgs) Handles btncapture.Click
        Dim data As IDataObject
        Dim bmap As Image

        SendMessage(hWnd, WM_CAP_EDIT_COPY, 0, 0)

        data = Clipboard.GetDataObject()

        If data.GetDataPresent(GetType(System.Drawing.Bitmap)) Then
            bmap = CType(data.GetData(GetType(System.Drawing.Bitmap)), Image)

            PictureBox2.Image = bmap
            PictureBox2.Height = PictureBox1.Height
            PictureBox2.Width = PictureBox1.Width
            '            TextBox1.Text = bmap.Height.ToString + ", " + bmap.Width.ToString
            '            SendMessage(hWnd, WM_CAP_DRIVER_DISCONNECT, VideoSource, 0)
            '            DestroyWindow(hWnd)
            MsgBox("Capture Berhasil")
        End If
    End Sub

    Private Sub BtnSave_Click(sender As Object, e As EventArgs) Handles btnsave.Click
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            PictureBox2.Image.Save(SaveFileDialog1.FileName)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim Op_X(-1 To 0, -1 To 0) As Integer 
        'Dim Op_Y(-1 To 0, -1 To 0) As Integer 
        'Dim X As Integer, Y As Integer, I As Integer, J As Integer

        'Grad = 0
        'Op_X(-1, -1) = 1 : Op_X(0, -1) = 0
        'Op_X(-1, 0) = 0 : Op_X(0, 0) = -1

    End Sub
End Class

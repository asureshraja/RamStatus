Imports System.Runtime.InteropServices

Public Class Form1
    Dim ms As MEMORYSTATUS
    Dim flag As Integer
    Public Structure MEMORYSTATUS
        Public dwLength As Int32
       
        Public dwMemoryLoad As Int32
       
        Public dwTotalPhys As Int32
       
        Public dwAvailPhys As Int32
        
        Public dwTotalPageFile As Int32
       
        Public dwAvailPageFile As Int32
     
        Public dwTotalVirtual As Int32
       
        Public dwAvailVirtual As Int32
    End Structure
    <DllImport("kernel32.dll")> Private Shared Function GlobalMemoryStatus(ByRef ms As MEMORYSTATUS) As Int32
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        TransparencyKey = Color.Blue
        Me.BackColor = Color.Blue
        Timer1.Enabled = True
        Timer1.Interval = 1000
        Dim ms As MEMORYSTATUS
        ms.dwLength = Marshal.SizeOf(ms)
        GlobalMemoryStatus(ms)
        ProgressBar1.Maximum = ms.dwTotalPhys
        Me.SetDesktopLocation(600, 400)
    End Sub

    Private Sub ProgressBar1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ProgressBar1.Click
    End Sub

    Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles Timer1.Tick

        ms.dwLength = Marshal.SizeOf(ms)
        GlobalMemoryStatus(ms)
        ProgressBar1.Value = ms.dwAvailPhys
        If (flag = 1) Then
            ProgressBar1.Increment(10000)
            flag = flag + 1
        ElseIf flag = 5 Then
            ProgressBar1.Increment(-50000)
            flag = 1
        End If
    End Sub
End Class

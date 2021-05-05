Imports System.Runtime.InteropServices

Public Class Form1
    ReadOnly tenmin As New TimeSpan(0, 10, 0)
    ReadOnly thirtymin As New TimeSpan(0, 30, 0)
    ReadOnly onehour As New TimeSpan(1, 0, 0)
    ReadOnly fourhour As New TimeSpan(4, 0, 0)

    <Flags()>
    Public Enum EXECUTION_STATE As UInteger
        ES_SYSTEM_REQUIRED = &H1
        ES_DISPLAY_REQUIRED = &H2
        ES_CONTINUOUS = &H80000000UI
    End Enum

    <DllImport("Kernel32.DLL", CharSet:=CharSet.Auto, SetLastError:=True)>
    Private Shared Function SetThreadExecutionState(ByVal state As EXECUTION_STATE) As EXECUTION_STATE
    End Function

    Private Shared Sub SuspendSleep()
        SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS Or EXECUTION_STATE.ES_DISPLAY_REQUIRED Or EXECUTION_STATE.ES_SYSTEM_REQUIRED)
    End Sub

    Private Shared Sub BackToNormal()
        SetThreadExecutionState(EXECUTION_STATE.ES_CONTINUOUS)
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        BackToNormal()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        BackToNormal()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
    End Sub

    Private Sub ToolStripMenuItem7_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem7.Click
        My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).SetValue(Application.ProductName, Application.ExecutablePath)
    End Sub

    Private Sub ToolStripMenuItem8_Click(sender As Object, e As EventArgs)
        My.Computer.Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True).DeleteValue(Application.ProductName)
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click
        SuspendSleep()
    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Timer1.Stop()
        SuspendSleep()
        Timer1.Interval = tenmin.TotalMilliseconds
        Timer1.Start()
    End Sub

    Private Sub ToolStripMenuItem3_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem3.Click
        Timer1.Stop()
        SuspendSleep()
        Timer1.Interval = thirtymin.TotalMilliseconds
        Timer1.Start()
    End Sub

    Private Sub ToolStripMenuItem4_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem4.Click
        Timer1.Stop()
        SuspendSleep()
        Timer1.Interval = onehour.TotalMilliseconds
        Timer1.Start()
    End Sub

    Private Sub ToolStripMenuItem5_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem5.Click
        Timer1.Stop()
        SuspendSleep()
        Timer1.Interval = fourhour.TotalMilliseconds
        Timer1.Start()
    End Sub

    Private Sub ToolStripMenuItem9_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem9.Click
        End
    End Sub

End Class
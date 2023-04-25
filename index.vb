Imports NAudio.Wave
Imports NAudio.CoreAudioApi
Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.ToolBar

Public Class Form1
    Dim score As Integer = 0
    Dim en As New MMDeviceEnumerator
    Dim voices As Integer
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim recorder = New WaveIn()
        recorder.StartRecording()
        Dim device = en.EnumerateAudioEndPoints(DataFlow.All, DeviceState.Active)
        ComboBox1.Items.AddRange(device.ToArray)
        ComboBox1.SelectedIndex = My.Settings.Setting

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If ComboBox1.Text <> Nothing Then
            Dim selected As MMDevice = ComboBox1.SelectedItem
            voices = selected.AudioMeterInformation.MasterPeakValue * 100
            ProgressBar1.Value = voices
        End If
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Start()
        balltmr.Start()
        blktimr.Start()
        ballimg.Image = My.Resources.basketball
        My.Settings.Setting = ComboBox1.SelectedIndex

    End Sub
    Private Sub balltmr_Tick(sender As Object, e As EventArgs) Handles balltmr.Tick
        If voices > 25 Then
            ballimg.Top += -2
        Else
            ballimg.Top += +2
        End If
        If ballimg.Top >= 394 Then
            ballimg.Top += -2
        End If
        If ballimg.Top <= 24 Then
            ballimg.Top += +2
        End If
    End Sub
    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub blktimr_Tick(sender As Object, e As EventArgs) Handles blktimr.Tick
        PictureBox1.Left += -2
        PictureBox2.Left += -2
        PictureBox3.Left += -2
        If PictureBox1.Left <= -67 Then
            PictureBox1.Left = 615
            PictureBox1.Top = Int(Rnd() * 230) + 103
            score += 1
            scorelbl.Text = score
        End If
        If PictureBox2.Left <= -67 Then
            PictureBox2.Left = 615
            PictureBox2.Top = Int(Rnd() * 230) + 103
            score += 1
            scorelbl.Text = score
        End If
        If PictureBox3.Left <= -67 Then
            PictureBox3.Left = 615
            PictureBox3.Top = Int(Rnd() * 230) + 103
            score += 1
            scorelbl.Text = score
        End If
        If ballimg.Bounds.IntersectsWith(PictureBox1.Bounds) Then
            Label1.Visible = True
            Button2.Visible = True
            blktimr.Stop()
            balltmr.Stop()
            Timer1.Stop()
            ballimg.Image = My.Resources.basketball2
        End If
        If ballimg.Bounds.IntersectsWith(PictureBox2.Bounds) Then
            Label1.Visible = True
            Button2.Visible = True
            blktimr.Stop()
            balltmr.Stop()
            Timer1.Stop()
            ballimg.Image = My.Resources.basketball2
        End If
        If ballimg.Bounds.IntersectsWith(PictureBox3.Bounds) Then
            Label1.Visible = True
            Button2.Visible = True
            blktimr.Stop()
            balltmr.Stop()
            Timer1.Stop()
            ballimg.Image = My.Resources.basketball2
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Controls.Clear()
        InitializeComponent()
        Form1_Load(e, e)
        blktimr.Start()
        Timer1.Start()
        balltmr.Start()

        ballimg.Image = My.Resources.basketball
        score = 0
    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub
End Class



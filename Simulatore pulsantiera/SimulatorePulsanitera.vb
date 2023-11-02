Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmSim
    Public connesso As Boolean
    Public shift As Integer
    Public states(16) As Integer
    Public dataFromSerial As String
    Public msgList As New Queue(Of String)

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        ImpostazioniPorta.Location = New Point(Location.X + Size.Width, Location.Y)
        ImpostazioniPorta.Show()
    End Sub
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        If connesso = True Then
            Serial.Location = New Point(Location.X + Size.Width, Location.Y + ImpostazioniPorta.Size.Height)
            Serial.Show()
            'Timer1.Stop()
        Else
            Serial.Location = New Point(Location.X + Size.Width, Location.Y + ImpostazioniPorta.Size.Height)
            Serial.Show()
            MsgBox("Porta seriale non connessa, apertura in debug!", vbInformation + vbOKOnly, "Info")
        End If
    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click

        If states(16) = 0 Then
            states(16) = 1
            Label11.Text = "vero"
            Label11.BackColor = Color.Green
        Else
            states(16) = 0
            Label11.Text = "falso"
            Label11.BackColor = Color.Red
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim toSend, toSendint As String
        dataFromSerial = ricevi()

        If msgList.Count > 0 Then
            toSend = msgList.Dequeue()
            toSendint = toSend
            If toSend.Contains(vbLf) Then
                toSendint += " + LF"
            ElseIf toSend.Contains(vbCr) Then
                toSendint += " + CR"
            ElseIf toSend.Contains(vbCrLf) Then
                toSendint += " + CR LF"
            End If
            Serial.TextBox2.Text += "Sended " + toSendint + vbCrLf
            If connesso Then
                SerialPort1.Write(toSend)
            End If
        Else
            toSend = ""
            For i = 0 To states.Length - 2
                toSend += CStr(states(i)) + "."
            Next
            toSend += CStr(states(16))
            If connesso Then
                'Writing on Serial
                SerialPort1.WriteLine(toSend)

                'Writing recived data to Serial Form
                If dataFromSerial <> "" And Serial.Visible = True Then
                    Serial.TextBox2.Text += dataFromSerial
                End If
            Else
                toSend += vbLf
                Serial.TextBox2.Text += toSend
            End If
        End If
        Serial.TextBox2.SelectionStart = Len(Serial.TextBox2.Text)
        Serial.TextBox2.ScrollToCaret()
    End Sub
    Function ricevi() As String
        Dim dati As String
        Try
            dati = SerialPort1.ReadExisting
            If dati <> Nothing Then
                Return dati
            End If
            Return ""
        Catch ex As Exception
            Return "Errore: " & ex.Message
        End Try
    End Function
    Private Sub frmSim_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For Each i In states
            i = 0
        Next
    End Sub

    Private Sub Button1_MouseDown(sender As Object, e As MouseEventArgs) Handles Button1.MouseDown
        states(0) = 1
    End Sub

    Private Sub Button1_MouseUp(sender As Object, e As MouseEventArgs) Handles Button1.MouseUp
        states(0) = 0
    End Sub

    Private Sub Button17_MouseDown(sender As Object, e As MouseEventArgs) Handles Button17.MouseDown
        states(1) = 1
    End Sub

    Private Sub Button17_MouseUp(sender As Object, e As MouseEventArgs) Handles Button17.MouseUp
        states(1) = 0
    End Sub

    Private Sub Button18_MouseDown(sender As Object, e As MouseEventArgs) Handles Button18.MouseDown
        states(2) = 1
    End Sub

    Private Sub Button18_MouseUp(sender As Object, e As MouseEventArgs) Handles Button18.MouseUp
        states(2) = 0
    End Sub

    Private Sub Button7_MouseDown(sender As Object, e As MouseEventArgs) Handles Button7.MouseDown
        states(3) = 1
    End Sub

    Private Sub Button7_MouseUp(sender As Object, e As MouseEventArgs) Handles Button7.MouseUp
        states(3) = 0
    End Sub

    Private Sub Button4_MouseDown(sender As Object, e As MouseEventArgs) Handles Button4.MouseDown
        states(4) = 1
    End Sub

    Private Sub Button4_MouseUp(sender As Object, e As MouseEventArgs) Handles Button4.MouseUp
        states(4) = 0
    End Sub

    Private Sub Button6_MouseDown(sender As Object, e As MouseEventArgs) Handles Button6.MouseDown
        states(5) = 1
    End Sub

    Private Sub Button6_MouseUp(sender As Object, e As MouseEventArgs) Handles Button6.MouseUp
        states(5) = 0
    End Sub

    Private Sub Button5_MouseDown(sender As Object, e As MouseEventArgs) Handles Button5.MouseDown
        states(6) = 1
    End Sub

    Private Sub Button5_MouseUp(sender As Object, e As MouseEventArgs) Handles Button5.MouseUp
        states(6) = 0
    End Sub

    Private Sub Button8_MouseDown(sender As Object, e As MouseEventArgs) Handles Button8.MouseDown
        states(7) = 1
    End Sub

    Private Sub Button8_MouseUp(sender As Object, e As MouseEventArgs) Handles Button8.MouseUp
        states(7) = 0
    End Sub

    Private Sub Button11_MouseDown(sender As Object, e As MouseEventArgs) Handles Button11.MouseDown
        states(8) = 1
    End Sub

    Private Sub Button11_MouseUp(sender As Object, e As MouseEventArgs) Handles Button11.MouseUp
        states(8) = 0
    End Sub

    Private Sub Button10_MouseDown(sender As Object, e As MouseEventArgs) Handles Button10.MouseDown
        states(9) = 1
    End Sub

    Private Sub Button10_MouseUp(sender As Object, e As MouseEventArgs) Handles Button10.MouseUp
        states(9) = 0
    End Sub

    Private Sub Button14_MouseDown(sender As Object, e As MouseEventArgs) Handles Button14.MouseDown
        states(10) = 1
    End Sub

    Private Sub Button14_MouseUp(sender As Object, e As MouseEventArgs) Handles Button14.MouseUp
        states(10) = 0
    End Sub

    Private Sub Button13_MouseDown(sender As Object, e As MouseEventArgs) Handles Button13.MouseDown
        states(11) = 1
    End Sub

    Private Sub Button13_MouseUp(sender As Object, e As MouseEventArgs) Handles Button13.MouseUp
        states(11) = 0
    End Sub
    Private Sub Button12_MouseDown(sender As Object, e As MouseEventArgs) Handles Button12.MouseDown
        states(12) = 1
    End Sub

    Private Sub Button12_MouseUp(sender As Object, e As MouseEventArgs) Handles Button12.MouseUp
        states(12) = 0
    End Sub

    Private Sub Button2_MouseDown(sender As Object, e As MouseEventArgs) Handles Button2.MouseDown
        states(13) = 1
    End Sub

    Private Sub Button2_MouseUp(sender As Object, e As MouseEventArgs) Handles Button2.MouseUp
        states(13) = 0
    End Sub

    Private Sub Button15_MouseDown(sender As Object, e As MouseEventArgs) Handles Button15.MouseDown
        states(14) = 1
    End Sub

    Private Sub Button15_MouseUp(sender As Object, e As MouseEventArgs) Handles Button15.MouseUp
        states(14) = 0
    End Sub

    Private Sub Button3_MouseDown(sender As Object, e As MouseEventArgs) Handles Button3.MouseDown
        states(15) = 1
    End Sub

    Private Sub Button3_MouseUp(sender As Object, e As MouseEventArgs) Handles Button3.MouseUp
        states(15) = 0
    End Sub

    Private Sub Button20_MouseDown(sender As Object, e As MouseEventArgs) Handles Button20.MouseDown
        states(13) = 1
        states(14) = 1
        states(15) = 1
    End Sub

    Private Sub Button20_MouseUp(sender As Object, e As MouseEventArgs) Handles Button20.MouseUp
        states(13) = 0
        states(14) = 0
        states(15) = 0
    End Sub
End Class

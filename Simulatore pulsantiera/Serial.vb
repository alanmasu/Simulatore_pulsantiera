Public Class Serial
    Private Sub Serial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1.Start()
        If frmSim.connesso = True Then
            Text = "Serial - ON " & frmSim.SerialPort1.PortName
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If frmSim.connesso Then
            'Dim data As String = ImpostazioniPorta.ricevi()
            'frmSim.Timer1.Stop()
            If frmSim.connesso = True Then
                If frmSim.dataFromSerial <> "" Then
                    TextBox2.Text += frmSim.dataFromSerial & vbLf
                    TextBox2.SelectionStart = Len(TextBox2.Text)
                    TextBox2.ScrollToCaret()
                End If
            End If
            'Else
            '    'Timer1.Stop()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If frmSim.connesso = True Then
            frmSim.msgList.Enqueue(TextBox1.Text & getTerm())
        End If
    End Sub

    Private Sub Serial_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Timer1.Stop()
        frmSim.Timer1.Start()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        If frmSim.connesso = True Then
            frmSim.msgList.Enqueue("serialOFF" + getTerm())
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If frmSim.connesso = True Then
            frmSim.msgList.Enqueue("serialON" & getTerm())
        End If
    End Sub

    Private Function getTerm() As String
        Dim term As String

        term = ComboBox1.SelectedItem
        If term = "\n" Then
            term = vbLf
        ElseIf term = "\r" Then
            term = vbCr
        ElseIf term = "\rn" Then
            term = vbCrLf
        ElseIf term = "none" Then
            term = ""
        End If
        getTerm = term
    End Function
End Class
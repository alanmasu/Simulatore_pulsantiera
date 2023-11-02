Public Class Serial
    Private Sub Serial_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frmSim.connesso = True Then
            Text = "Serial - ON " & frmSim.SerialPort1.PortName
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If frmSim.connesso = True Then
            frmSim.msgList.Enqueue(TextBox1.Text & getTerm())
        End If
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
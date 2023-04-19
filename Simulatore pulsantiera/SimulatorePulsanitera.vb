Public Class frmSim
    Public connesso As Boolean
    Public shift As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim name As String = "pt1_p"
        If connesso = True Then
            SerialPort1.Write(name & ".1" & "." & shift & vbLf)
        End If
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        Dim name As String = "pt1_m"
        If connesso = True Then
            SerialPort1.Write(name & ".1" & "." & shift & vbLf)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim name As String = "pt_r"
        If connesso = True Then
            SerialPort1.Write(name & ".1" & "." & shift & vbLf)
        End If
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        Dim name As String = "pt2_p"
        If connesso = True Then
            SerialPort1.Write(name & ".1" & "." & shift & vbLf)
        End If
    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Dim name As String = "pt2_m"
        If connesso = True Then
            SerialPort1.Write(name & ".1" & "." & shift & vbLf)
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim name As String = "p"
        If connesso = True Then
            SerialPort1.Write(name & ".1" & "." & shift & vbLf)
        End If
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        Dim name As String = "s"
        If connesso = True Then
            SerialPort1.Write(name & ".1" & "." & shift & vbLf)
        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Dim name As String = "t_p"
        If connesso = True Then
            SerialPort1.Write(name & ".1" & "." & shift & vbLf)
        End If
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        Dim name As String = "t_r"
        If connesso = True Then
            SerialPort1.Write(name & ".1" & "." & shift & vbLf)
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim name As String = "t_m"
        If connesso = True Then
            SerialPort1.Write(name & ".1" & "." & shift & vbLf)
        End If
    End Sub

    Private Sub Button11_Click(sender As Object, e As EventArgs) Handles Button11.Click
        Dim name As String = "min_p"
        If connesso = True Then
            SerialPort1.Write(name & ".1" & "." & shift & vbLf)
        End If
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs)
        Dim name As String = "min_r"
        If connesso = True Then
            SerialPort1.Write(name & ".1" & "." & shift & vbLf)
        End If
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        Dim name As String = "min_m"
        If connesso = True Then
            SerialPort1.Write(name & ".1" & "." & shift & vbLf)
        End If
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        Dim name As String = "sec_p"
        If connesso = True Then
            SerialPort1.Write(name & ".1" & "." & shift & vbLf)
        End If
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        Dim name As String = "sec_r"
        If connesso = True Then
            SerialPort1.Write(name & ".1" & "." & shift & vbLf)
        End If
    End Sub

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        Dim name As String = "sec_m"
        If connesso = True Then
            SerialPort1.Write(name & ".1" & "." & shift & vbLf)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim name As String = "r"
        If connesso = True Then
            SerialPort1.Write(name & ".1" & "." & shift & vbLf)
        End If
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        ImpostazioniPorta.Location = New Point(Location.X + Size.Width, Location.Y)
        ImpostazioniPorta.Show()
    End Sub
    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        If connesso = True Then
            Serial.Location = New Point(Location.X + Size.Width, Location.Y + ImpostazioniPorta.Size.Height)
            Serial.Show()
            Timer1.Stop()
        Else
            MsgBox("Porta seriale non connessa!!!", vbCritical + vbOKOnly, "Err")
        End If
    End Sub

    Private Sub Button9_Click_1(sender As Object, e As EventArgs) Handles Button9.Click

        If shift = 0 Then
            shift = 1
            Label11.Text = "vero"
            Label11.BackColor = Color.Green
        Else
            shift = 0
            Label11.Text = "falso"
            Label11.BackColor = Color.Red
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

    End Sub
End Class

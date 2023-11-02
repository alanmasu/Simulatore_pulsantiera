Imports System.ComponentModel

Public Class ImpostazioniPorta
    'All'avvio aggiunge items alla combo
    Private Sub ImpostazioniPorta_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ComboBox1.Items.AddRange(IO.Ports.SerialPort.GetPortNames())
    End Sub
    'btnAggiorna
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ComboBox1.Items.Clear()
        ComboBox1.Items.AddRange(IO.Ports.SerialPort.GetPortNames())
    End Sub
    'btnConnetti
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmSim.SerialPort1.Close()
        Serial.Timer1.Stop()
        If ComboBox1.Text Is "" Then
            MsgBox("La porta non può essere vuota!!!", MsgBoxStyle.Critical, "Errore")
        Else
            Try
                'inizializzo la porta seriale
                'frmSim.SerialPort1.Encoding = System.Text.Encoding.UTF8
                frmSim.SerialPort1.Encoding = System.Text.Encoding.Default
                frmSim.SerialPort1.PortName = ComboBox1.Text
                frmSim.SerialPort1.NewLine = vbLf
                frmSim.SerialPort1.Open()
                'invio un messaggio di verifica
                frmSim.SerialPort1.Write("Sei Arduino?" & vbLf)
                TimerSerial.Start()
                scaduta = False
                Timer1.Start()
            Catch ex As Exception
                frmSim.SerialPort1.Close()
                MsgBox("Errore: " & ex.Message, MsgBoxStyle.Critical)
            End Try
        End If

    End Sub
    'btnChiudi
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frmSim.SerialPort1.Close()
        frmSim.connesso = False
        Button2.Enabled = True
        Button3.Enabled = True
        ComboBox1.Enabled = True
        Button4.Enabled = False
        scaduta = False
        Label3.Text = "Disconnesso"
        Label3.ForeColor = Color.Red
        frmSim.Text = "Simulatore pulsantiera"
    End Sub

    Dim scaduta As Boolean = False
    Private Sub TimerSerial_Tick(sender As Object, e As EventArgs) Handles TimerSerial.Tick
        Dim str As String
        str = frmSim.ricevi()
        'If str <> "" Then
        'If scaduta = False Then
        'If str = "Si sono Arduino!" & vbLf Then
        If Serial.Visible = True Then
            Serial.Timer1.Start()
        End If
        frmSim.connesso = True
        Label3.Text = "Connesso"
        Label3.ForeColor = Color.Green
        Button4.Enabled = True
        Button2.Enabled = False
        Button3.Enabled = False
        frmSim.Text = "Simulatore pulsantiera - ON " & frmSim.SerialPort1.PortName
        TimerSerial.Stop()
        'MsgBox("Connessione avvenuta con successo!!", vbInformation)
        'Hide()
        'End If
        'Else
        'TimerSerial.Stop()
        'End If
        'End If
    End Sub
    Sub WaitSeconds(ByVal gapToWait As Integer)
        Dim o As DateTime = DateTime.Now ' adesso
        Dim istanteFinale As New DateTime(o.Year, o.Month, o.Day,
                                          o.Hour, o.Minute,
                                          o.Second + gapToWait)
        Do While istanteFinale.Subtract(DateTime.Now).Milliseconds > 0
            Application.DoEvents()
        Loop
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If frmSim.connesso = False Then
            Timer1.Stop()
            MsgBox("Connessione non avvenuta con successo!!", vbCritical + vbOKOnly, "Err")
            frmSim.SerialPort1.Close()
            scaduta = True
        Else
            Timer1.Stop()
        End If
        Timer1.Stop()
    End Sub
End Class
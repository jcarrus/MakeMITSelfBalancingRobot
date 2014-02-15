Public Class Form1

    Dim buffer(2) As Byte
    Dim value As Single
    Dim ax_adc, as_adc, gz_adc As Integer
    Dim ax_deg, as_deg, gz_vel As Single
    Dim ae_deg As Integer
    Dim dtmr0 As Integer
    Dim dt As Single
    Dim lmotor, rmotor As Integer
    Dim samples As Long = 0
    Dim starttime As System.DateTime = System.DateTime.Now
    Dim prevtime As System.DateTime = System.DateTime.Now
    Dim nowtime As System.DateTime = System.DateTime.Now
    Dim samplerate As Single = 0

    Dim datafile As System.IO.StreamWriter

    Dim conntime As Integer = 0


    Const ESC1 = &H80
    Const ESC2 = &H40
    Const TX_START = &HFF
    Const TX_ESC = &HFE
    Const TX_LT = &H1
    Const TX_AX = &H2
    Const TX_AS = &H3
    Const TX_GZ = &H4
    Const TX_AE = &H5
    Const TX_ML = &H6
    Const TX_MR = &H7

    Private Sub cmbCOMPort_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCOMPort.SelectedIndexChanged
        Try
            If serCOM.IsOpen Then
                serCOM.Close()
            End If
            datafile = System.IO.File.CreateText("seg_data.txt")
            serCOM.PortName = cmbCOMPort.SelectedItem
            serCOM.Open()
            starttime = System.DateTime.Now
            nowtime = starttime
            samples = 0
        Catch ex As Exception
            MsgBox(ex.Message)
            datafile.Close()
            datafile.Dispose()
        End Try
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            serCOM.Close()
            serCOM.Dispose()
            datafile.Close()
            datafile.Dispose()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try

    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        System.Windows.Forms.Form.CheckForIllegalCrossThreadCalls = False
    End Sub

    Private Sub serCOM_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles serCOM.DataReceived
        Dim i As Integer
        Dim idx As Integer
        Dim rx As Byte

        For i = 1 To serCOM.BytesToRead
            rx = serCOM.ReadByte
            If rx = 255 Then
                idx = 0
            Else
                buffer(idx) = rx
                idx = idx + 1
            End If
            If idx = 3 Then
                If (buffer(2) And ESC1) = ESC1 Then
                    buffer(0) = 255
                End If
                If (buffer(2) And ESC2) = ESC2 Then
                    buffer(1) = 255
                End If
                Select Case buffer(2) And (Not (ESC1 Or ESC2))
                    Case TX_AX
                        ax_adc = buffer(0) * 256 + buffer(1)
                        ax_deg = ((buffer(0) * 256 + buffer(1)) - nudAXOff.Value) * nudAXScale.Value
                        Exit Select
                    Case TX_AS
                        as_adc = buffer(0) * 256 + buffer(1)
                        as_deg = ((buffer(0) * 256 + buffer(1)) - nudASOff.Value) * nudASScale.Value
                        Exit Select
                    Case TX_GZ
                        gz_adc = buffer(0) * 256 + buffer(1)
                        gz_vel = ((buffer(0) * 256 + buffer(1)) - nudGZOff.Value) * nudGZScale.Value

                        datafile.Write(Format((System.DateTime.Now - starttime).TotalSeconds, "###.###") + ", ")
                        datafile.Write(Format(ax_adc, "0.000") + ", ")
                        datafile.Write(Format(as_adc, "0.000") + ", ")
                        datafile.Write(Format(gz_adc, "00.00") + ", ")
                        datafile.Write(Format(ae_deg, "00.00") + ", ")
                        datafile.Write(Format(lmotor, "0000") + ", ")
                        datafile.Write(Format(rmotor, "0000") + vbCrLf)

                        conntime = 0
                        Exit Select
                    Case TX_LT
                        dtmr0 = buffer(1)
                        dt = dtmr0 * 0.000128
                        Exit Select
                    Case TX_AE
                        ae_deg = buffer(0) * 256 + buffer(1)
                        Exit Select
                    Case TX_ML
                        lmotor = buffer(0) * 256 + buffer(1)
                        Exit Select
                    Case TX_MR
                        rmotor = buffer(0) * 256 + buffer(1)
                        Exit Select
                End Select
                idx = 0
            End If

        Next
        serCOM.DiscardInBuffer()
    End Sub

    Private Sub tmrPaint_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPaint.Tick

        Dim gfx As System.Drawing.Graphics
        Dim x1, y1, x2, y2 As Integer

        conntime = conntime + 1

        If conntime >= 5 Then
            cmbCOMPort.BackColor = Color.Red
            conntime = 5
        Else
            cmbCOMPort.BackColor = Color.Green
        End If

        'fake data
        'ax_adc = 603
        'ax_deg = (ax_adc - nudAXOff.Value) * nudAXScale.Value
        'as_adc = 516
        'as_deg = (as_adc - nudASOff.Value) * nudASScale.Value
        'gz_adc = 786
        'gz_vel = (gz_adc - nudGZOff.Value) * nudGZScale.Value
        'ae_deg = 516
        'lmotor = 678
        'rmotor = 615
        'dtmr0 = 68
        'dt = dtmr0 * 0.000128

        lblAX.Text = Format(ax_deg, "0.000") + " deg [" + Format(ax_adc, "0000") + "]"
        lblAS.Text = Format(as_deg, "0.000") + " deg [" + Format(as_adc, "0000") + "]"
        lblGZ.Text = Format(gz_vel, "00.00") + " deg/sec [" + Format(gz_adc, "0000") + "]"
        lblML.Text = Format(lmotor, "0000") + " (512 neutral)"
        lblMR.Text = Format(rmotor, "0000") + " (512 neutral)"
        lblAngle.Text = Format(ae_deg - 512, "000") + " deg"

        lblTimer.Text = Format(dtmr0 * 128, "00000") + " usec"
        lblRate.Text = Format(1 / dt, "000.0") + " Hz"

        picAX.Width = lblAX.Width * ax_adc / 1023
        picAS.Width = lblAS.Width * as_adc / 1023
        picGZ.Width = lblGZ.Width * gz_adc / 1023
        picML.Width = lblML.Width * lmotor / 1023
        picMR.Width = lblMR.Width * rmotor / 1023

        gfx = picAngle.CreateGraphics
        gfx.Clear(Color.Black)
        x1 = picAngle.Width / 2
        y1 = picAngle.Height / 2
        x2 = picAngle.Width / 2 * (1 + 0.75 * Math.Sin((ae_deg - 512) * Math.PI / 180))
        y2 = picAngle.Width / 2 * (1 - 0.75 * Math.Cos((ae_deg - 512) * Math.PI / 180))
        gfx.DrawLine(Pens.GreenYellow, x1, y1, x2, y2)

    End Sub

    Private Sub lblAnglel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblAnglel.Click

    End Sub
End Class

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.serCOM = New System.IO.Ports.SerialPort(Me.components)
        Me.cmbCOMPort = New System.Windows.Forms.ComboBox
        Me.lblAX = New System.Windows.Forms.Label
        Me.lblAS = New System.Windows.Forms.Label
        Me.tmrPaint = New System.Windows.Forms.Timer(Me.components)
        Me.lblRate = New System.Windows.Forms.Label
        Me.lblAXl = New System.Windows.Forms.Label
        Me.lblASl = New System.Windows.Forms.Label
        Me.lblRatel = New System.Windows.Forms.Label
        Me.lblGZl = New System.Windows.Forms.Label
        Me.lblGZ = New System.Windows.Forms.Label
        Me.lblTimerl = New System.Windows.Forms.Label
        Me.lblTimer = New System.Windows.Forms.Label
        Me.nudAXOff = New System.Windows.Forms.NumericUpDown
        Me.nudASOff = New System.Windows.Forms.NumericUpDown
        Me.nudGZOff = New System.Windows.Forms.NumericUpDown
        Me.lblOff = New System.Windows.Forms.Label
        Me.lblScale = New System.Windows.Forms.Label
        Me.nudAXScale = New System.Windows.Forms.NumericUpDown
        Me.nudASScale = New System.Windows.Forms.NumericUpDown
        Me.nudGZScale = New System.Windows.Forms.NumericUpDown
        Me.picGZ = New System.Windows.Forms.PictureBox
        Me.picAS = New System.Windows.Forms.PictureBox
        Me.picAX = New System.Windows.Forms.PictureBox
        Me.lblMLl = New System.Windows.Forms.Label
        Me.lblML = New System.Windows.Forms.Label
        Me.picML = New System.Windows.Forms.PictureBox
        Me.picMR = New System.Windows.Forms.PictureBox
        Me.lblMR = New System.Windows.Forms.Label
        Me.lblMRl = New System.Windows.Forms.Label
        Me.lblAnglel = New System.Windows.Forms.Label
        Me.lblAngle = New System.Windows.Forms.Label
        Me.picAngle = New System.Windows.Forms.PictureBox
        CType(Me.nudAXOff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudASOff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudGZOff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudAXScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudASScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.nudGZScale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picGZ, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAS, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAX, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picML, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picMR, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picAngle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'serCOM
        '
        Me.serCOM.BaudRate = 19200
        '
        'cmbCOMPort
        '
        Me.cmbCOMPort.BackColor = System.Drawing.Color.Red
        Me.cmbCOMPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCOMPort.ForeColor = System.Drawing.Color.White
        Me.cmbCOMPort.FormattingEnabled = True
        Me.cmbCOMPort.Items.AddRange(New Object() {"COM1", "COM2", "COM3", "COM4", "COM5", "COM6", "COM7", "COM8", "COM9"})
        Me.cmbCOMPort.Location = New System.Drawing.Point(21, 20)
        Me.cmbCOMPort.Margin = New System.Windows.Forms.Padding(5)
        Me.cmbCOMPort.Name = "cmbCOMPort"
        Me.cmbCOMPort.Size = New System.Drawing.Size(219, 33)
        Me.cmbCOMPort.TabIndex = 0
        Me.cmbCOMPort.Text = "Select COM Port"
        '
        'lblAX
        '
        Me.lblAX.BackColor = System.Drawing.Color.White
        Me.lblAX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAX.Font = New System.Drawing.Font("Courier New", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAX.Location = New System.Drawing.Point(200, 74)
        Me.lblAX.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblAX.Name = "lblAX"
        Me.lblAX.Size = New System.Drawing.Size(337, 30)
        Me.lblAX.TabIndex = 4
        Me.lblAX.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAS
        '
        Me.lblAS.BackColor = System.Drawing.Color.White
        Me.lblAS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAS.Font = New System.Drawing.Font("Courier New", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAS.Location = New System.Drawing.Point(200, 166)
        Me.lblAS.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblAS.Name = "lblAS"
        Me.lblAS.Size = New System.Drawing.Size(337, 30)
        Me.lblAS.TabIndex = 5
        Me.lblAS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tmrPaint
        '
        Me.tmrPaint.Enabled = True
        Me.tmrPaint.Interval = 50
        '
        'lblRate
        '
        Me.lblRate.BackColor = System.Drawing.Color.White
        Me.lblRate.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblRate.Font = New System.Drawing.Font("Courier New", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRate.Location = New System.Drawing.Point(570, 516)
        Me.lblRate.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblRate.Name = "lblRate"
        Me.lblRate.Size = New System.Drawing.Size(208, 30)
        Me.lblRate.TabIndex = 7
        Me.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblAXl
        '
        Me.lblAXl.AutoSize = True
        Me.lblAXl.Location = New System.Drawing.Point(54, 77)
        Me.lblAXl.Name = "lblAXl"
        Me.lblAXl.Size = New System.Drawing.Size(138, 27)
        Me.lblAXl.TabIndex = 11
        Me.lblAXl.Text = "X Accel.:"
        '
        'lblASl
        '
        Me.lblASl.AutoSize = True
        Me.lblASl.Location = New System.Drawing.Point(54, 169)
        Me.lblASl.Name = "lblASl"
        Me.lblASl.Size = New System.Drawing.Size(138, 27)
        Me.lblASl.TabIndex = 12
        Me.lblASl.Text = "Steering:"
        '
        'lblRatel
        '
        Me.lblRatel.AutoSize = True
        Me.lblRatel.Location = New System.Drawing.Point(410, 516)
        Me.lblRatel.Name = "lblRatel"
        Me.lblRatel.Size = New System.Drawing.Size(152, 27)
        Me.lblRatel.TabIndex = 14
        Me.lblRatel.Text = "Loop Rate:"
        '
        'lblGZl
        '
        Me.lblGZl.AutoSize = True
        Me.lblGZl.Location = New System.Drawing.Point(12, 120)
        Me.lblGZl.Name = "lblGZl"
        Me.lblGZl.Size = New System.Drawing.Size(180, 27)
        Me.lblGZl.TabIndex = 16
        Me.lblGZl.Text = "Z Gyroscope:"
        '
        'lblGZ
        '
        Me.lblGZ.BackColor = System.Drawing.Color.White
        Me.lblGZ.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblGZ.Font = New System.Drawing.Font("Courier New", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGZ.Location = New System.Drawing.Point(200, 120)
        Me.lblGZ.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblGZ.Name = "lblGZ"
        Me.lblGZ.Size = New System.Drawing.Size(337, 30)
        Me.lblGZ.TabIndex = 15
        Me.lblGZ.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblTimerl
        '
        Me.lblTimerl.AutoSize = True
        Me.lblTimerl.Location = New System.Drawing.Point(438, 479)
        Me.lblTimerl.Name = "lblTimerl"
        Me.lblTimerl.Size = New System.Drawing.Size(124, 27)
        Me.lblTimerl.TabIndex = 18
        Me.lblTimerl.Text = "Timer 0:"
        '
        'lblTimer
        '
        Me.lblTimer.BackColor = System.Drawing.Color.White
        Me.lblTimer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblTimer.Font = New System.Drawing.Font("Courier New", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTimer.Location = New System.Drawing.Point(570, 477)
        Me.lblTimer.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblTimer.Name = "lblTimer"
        Me.lblTimer.Size = New System.Drawing.Size(208, 30)
        Me.lblTimer.TabIndex = 17
        Me.lblTimer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'nudAXOff
        '
        Me.nudAXOff.Location = New System.Drawing.Point(570, 74)
        Me.nudAXOff.Maximum = New Decimal(New Integer() {1023, 0, 0, 0})
        Me.nudAXOff.Name = "nudAXOff"
        Me.nudAXOff.Size = New System.Drawing.Size(82, 34)
        Me.nudAXOff.TabIndex = 19
        Me.nudAXOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudAXOff.Value = New Decimal(New Integer() {512, 0, 0, 0})
        '
        'nudASOff
        '
        Me.nudASOff.Location = New System.Drawing.Point(570, 166)
        Me.nudASOff.Maximum = New Decimal(New Integer() {1023, 0, 0, 0})
        Me.nudASOff.Name = "nudASOff"
        Me.nudASOff.Size = New System.Drawing.Size(82, 34)
        Me.nudASOff.TabIndex = 20
        Me.nudASOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudASOff.Value = New Decimal(New Integer() {512, 0, 0, 0})
        '
        'nudGZOff
        '
        Me.nudGZOff.Location = New System.Drawing.Point(570, 120)
        Me.nudGZOff.Maximum = New Decimal(New Integer() {1023, 0, 0, 0})
        Me.nudGZOff.Name = "nudGZOff"
        Me.nudGZOff.Size = New System.Drawing.Size(82, 34)
        Me.nudGZOff.TabIndex = 21
        Me.nudGZOff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudGZOff.Value = New Decimal(New Integer() {516, 0, 0, 0})
        '
        'lblOff
        '
        Me.lblOff.AutoSize = True
        Me.lblOff.Location = New System.Drawing.Point(542, 44)
        Me.lblOff.Name = "lblOff"
        Me.lblOff.Size = New System.Drawing.Size(110, 27)
        Me.lblOff.TabIndex = 22
        Me.lblOff.Text = "Offset:"
        '
        'lblScale
        '
        Me.lblScale.AutoSize = True
        Me.lblScale.Location = New System.Drawing.Point(682, 44)
        Me.lblScale.Name = "lblScale"
        Me.lblScale.Size = New System.Drawing.Size(96, 27)
        Me.lblScale.TabIndex = 26
        Me.lblScale.Text = "Scale:"
        '
        'nudAXScale
        '
        Me.nudAXScale.DecimalPlaces = 4
        Me.nudAXScale.Increment = New Decimal(New Integer() {1, 0, 0, 262144})
        Me.nudAXScale.Location = New System.Drawing.Point(658, 74)
        Me.nudAXScale.Maximum = New Decimal(New Integer() {1023, 0, 0, 0})
        Me.nudAXScale.Name = "nudAXScale"
        Me.nudAXScale.Size = New System.Drawing.Size(122, 34)
        Me.nudAXScale.TabIndex = 27
        Me.nudAXScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudAXScale.Value = New Decimal(New Integer() {44, 0, 0, 131072})
        '
        'nudASScale
        '
        Me.nudASScale.DecimalPlaces = 4
        Me.nudASScale.Increment = New Decimal(New Integer() {1, 0, 0, 262144})
        Me.nudASScale.Location = New System.Drawing.Point(658, 166)
        Me.nudASScale.Maximum = New Decimal(New Integer() {1023, 0, 0, 0})
        Me.nudASScale.Name = "nudASScale"
        Me.nudASScale.Size = New System.Drawing.Size(122, 34)
        Me.nudASScale.TabIndex = 28
        Me.nudASScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudASScale.Value = New Decimal(New Integer() {44, 0, 0, 131072})
        '
        'nudGZScale
        '
        Me.nudGZScale.DecimalPlaces = 4
        Me.nudGZScale.Increment = New Decimal(New Integer() {1, 0, 0, 196608})
        Me.nudGZScale.Location = New System.Drawing.Point(658, 120)
        Me.nudGZScale.Maximum = New Decimal(New Integer() {1023, 0, 0, 0})
        Me.nudGZScale.Name = "nudGZScale"
        Me.nudGZScale.Size = New System.Drawing.Size(122, 34)
        Me.nudGZScale.TabIndex = 29
        Me.nudGZScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.nudGZScale.Value = New Decimal(New Integer() {33, 0, 0, 131072})
        '
        'picGZ
        '
        Me.picGZ.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.picGZ.Location = New System.Drawing.Point(200, 153)
        Me.picGZ.Name = "picGZ"
        Me.picGZ.Size = New System.Drawing.Size(337, 10)
        Me.picGZ.TabIndex = 30
        Me.picGZ.TabStop = False
        '
        'picAS
        '
        Me.picAS.BackColor = System.Drawing.Color.Blue
        Me.picAS.Location = New System.Drawing.Point(200, 199)
        Me.picAS.Name = "picAS"
        Me.picAS.Size = New System.Drawing.Size(337, 10)
        Me.picAS.TabIndex = 31
        Me.picAS.TabStop = False
        '
        'picAX
        '
        Me.picAX.BackColor = System.Drawing.Color.Red
        Me.picAX.Location = New System.Drawing.Point(200, 107)
        Me.picAX.Name = "picAX"
        Me.picAX.Size = New System.Drawing.Size(337, 10)
        Me.picAX.TabIndex = 32
        Me.picAX.TabStop = False
        '
        'lblMLl
        '
        Me.lblMLl.AutoSize = True
        Me.lblMLl.Location = New System.Drawing.Point(26, 253)
        Me.lblMLl.Name = "lblMLl"
        Me.lblMLl.Size = New System.Drawing.Size(166, 27)
        Me.lblMLl.TabIndex = 33
        Me.lblMLl.Text = "Left Motor:"
        '
        'lblML
        '
        Me.lblML.BackColor = System.Drawing.Color.White
        Me.lblML.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblML.Font = New System.Drawing.Font("Courier New", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblML.Location = New System.Drawing.Point(200, 250)
        Me.lblML.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblML.Name = "lblML"
        Me.lblML.Size = New System.Drawing.Size(337, 30)
        Me.lblML.TabIndex = 34
        Me.lblML.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picML
        '
        Me.picML.BackColor = System.Drawing.Color.Cyan
        Me.picML.Location = New System.Drawing.Point(200, 283)
        Me.picML.Name = "picML"
        Me.picML.Size = New System.Drawing.Size(337, 10)
        Me.picML.TabIndex = 35
        Me.picML.TabStop = False
        '
        'picMR
        '
        Me.picMR.BackColor = System.Drawing.Color.Yellow
        Me.picMR.Location = New System.Drawing.Point(200, 329)
        Me.picMR.Name = "picMR"
        Me.picMR.Size = New System.Drawing.Size(337, 10)
        Me.picMR.TabIndex = 38
        Me.picMR.TabStop = False
        '
        'lblMR
        '
        Me.lblMR.BackColor = System.Drawing.Color.White
        Me.lblMR.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblMR.Font = New System.Drawing.Font("Courier New", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblMR.Location = New System.Drawing.Point(200, 296)
        Me.lblMR.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblMR.Name = "lblMR"
        Me.lblMR.Size = New System.Drawing.Size(337, 30)
        Me.lblMR.TabIndex = 37
        Me.lblMR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblMRl
        '
        Me.lblMRl.AutoSize = True
        Me.lblMRl.Location = New System.Drawing.Point(12, 299)
        Me.lblMRl.Name = "lblMRl"
        Me.lblMRl.Size = New System.Drawing.Size(180, 27)
        Me.lblMRl.TabIndex = 36
        Me.lblMRl.Text = "Right Motor:"
        '
        'lblAnglel
        '
        Me.lblAnglel.AutoSize = True
        Me.lblAnglel.Location = New System.Drawing.Point(18, 393)
        Me.lblAnglel.Name = "lblAnglel"
        Me.lblAnglel.Size = New System.Drawing.Size(222, 27)
        Me.lblAnglel.TabIndex = 39
        Me.lblAnglel.Text = "Angle Estimate:"
        '
        'lblAngle
        '
        Me.lblAngle.BackColor = System.Drawing.Color.White
        Me.lblAngle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.lblAngle.Font = New System.Drawing.Font("Courier New", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAngle.Location = New System.Drawing.Point(248, 393)
        Me.lblAngle.Margin = New System.Windows.Forms.Padding(5, 0, 5, 0)
        Me.lblAngle.Name = "lblAngle"
        Me.lblAngle.Size = New System.Drawing.Size(242, 30)
        Me.lblAngle.TabIndex = 40
        Me.lblAngle.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picAngle
        '
        Me.picAngle.BackColor = System.Drawing.Color.Black
        Me.picAngle.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.picAngle.Location = New System.Drawing.Point(597, 273)
        Me.picAngle.Name = "picAngle"
        Me.picAngle.Size = New System.Drawing.Size(150, 150)
        Me.picAngle.TabIndex = 41
        Me.picAngle.TabStop = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(14.0!, 27.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(792, 555)
        Me.Controls.Add(Me.picAngle)
        Me.Controls.Add(Me.lblAngle)
        Me.Controls.Add(Me.lblAnglel)
        Me.Controls.Add(Me.picMR)
        Me.Controls.Add(Me.lblMR)
        Me.Controls.Add(Me.lblMRl)
        Me.Controls.Add(Me.picML)
        Me.Controls.Add(Me.lblML)
        Me.Controls.Add(Me.lblMLl)
        Me.Controls.Add(Me.picAX)
        Me.Controls.Add(Me.picAS)
        Me.Controls.Add(Me.picGZ)
        Me.Controls.Add(Me.nudGZScale)
        Me.Controls.Add(Me.nudASScale)
        Me.Controls.Add(Me.nudAXScale)
        Me.Controls.Add(Me.lblScale)
        Me.Controls.Add(Me.lblOff)
        Me.Controls.Add(Me.nudGZOff)
        Me.Controls.Add(Me.nudASOff)
        Me.Controls.Add(Me.nudAXOff)
        Me.Controls.Add(Me.lblTimerl)
        Me.Controls.Add(Me.lblTimer)
        Me.Controls.Add(Me.lblGZl)
        Me.Controls.Add(Me.lblGZ)
        Me.Controls.Add(Me.lblRatel)
        Me.Controls.Add(Me.lblASl)
        Me.Controls.Add(Me.lblAXl)
        Me.Controls.Add(Me.lblRate)
        Me.Controls.Add(Me.lblAS)
        Me.Controls.Add(Me.lblAX)
        Me.Controls.Add(Me.cmbCOMPort)
        Me.Font = New System.Drawing.Font("Courier New", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(5)
        Me.Name = "Form1"
        Me.Text = "Segway Dashboard"
        CType(Me.nudAXOff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudASOff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudGZOff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudAXScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudASScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.nudGZScale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picGZ, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAS, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAX, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picML, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picMR, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picAngle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents serCOM As System.IO.Ports.SerialPort
    Friend WithEvents cmbCOMPort As System.Windows.Forms.ComboBox
    Friend WithEvents lblAX As System.Windows.Forms.Label
    Friend WithEvents lblAS As System.Windows.Forms.Label
    Friend WithEvents tmrPaint As System.Windows.Forms.Timer
    Friend WithEvents lblRate As System.Windows.Forms.Label
    Friend WithEvents lblAXl As System.Windows.Forms.Label
    Friend WithEvents lblASl As System.Windows.Forms.Label
    Friend WithEvents lblRatel As System.Windows.Forms.Label
    Friend WithEvents lblGZl As System.Windows.Forms.Label
    Friend WithEvents lblGZ As System.Windows.Forms.Label
    Friend WithEvents lblTimerl As System.Windows.Forms.Label
    Friend WithEvents lblTimer As System.Windows.Forms.Label
    Friend WithEvents nudAXOff As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudASOff As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudGZOff As System.Windows.Forms.NumericUpDown
    Friend WithEvents lblOff As System.Windows.Forms.Label
    Friend WithEvents lblScale As System.Windows.Forms.Label
    Friend WithEvents nudAXScale As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudASScale As System.Windows.Forms.NumericUpDown
    Friend WithEvents nudGZScale As System.Windows.Forms.NumericUpDown
    Friend WithEvents picGZ As System.Windows.Forms.PictureBox
    Friend WithEvents picAS As System.Windows.Forms.PictureBox
    Friend WithEvents picAX As System.Windows.Forms.PictureBox
    Friend WithEvents lblMLl As System.Windows.Forms.Label
    Friend WithEvents lblML As System.Windows.Forms.Label
    Friend WithEvents picML As System.Windows.Forms.PictureBox
    Friend WithEvents picMR As System.Windows.Forms.PictureBox
    Friend WithEvents lblMR As System.Windows.Forms.Label
    Friend WithEvents lblMRl As System.Windows.Forms.Label
    Friend WithEvents lblAnglel As System.Windows.Forms.Label
    Friend WithEvents lblAngle As System.Windows.Forms.Label
    Friend WithEvents picAngle As System.Windows.Forms.PictureBox

End Class

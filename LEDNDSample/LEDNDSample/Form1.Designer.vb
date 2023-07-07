<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class LEDNDSample
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.BtnDisp = New System.Windows.Forms.Button()
        Me.BtnClear = New System.Windows.Forms.Button()
        Me.RadioUSB = New System.Windows.Forms.RadioButton()
        Me.RadioWiFi = New System.Windows.Forms.RadioButton()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BtnDisp
        '
        Me.BtnDisp.Location = New System.Drawing.Point(28, 86)
        Me.BtnDisp.Name = "BtnDisp"
        Me.BtnDisp.Size = New System.Drawing.Size(75, 37)
        Me.BtnDisp.TabIndex = 0
        Me.BtnDisp.Text = "表示"
        Me.BtnDisp.UseVisualStyleBackColor = True
        '
        'BtnClear
        '
        Me.BtnClear.Location = New System.Drawing.Point(113, 86)
        Me.BtnClear.Name = "BtnClear"
        Me.BtnClear.Size = New System.Drawing.Size(75, 37)
        Me.BtnClear.TabIndex = 1
        Me.BtnClear.Text = "クリア"
        Me.BtnClear.UseVisualStyleBackColor = True
        '
        'RadioUSB
        '
        Me.RadioUSB.AutoSize = True
        Me.RadioUSB.Checked = True
        Me.RadioUSB.Location = New System.Drawing.Point(17, 30)
        Me.RadioUSB.Name = "RadioUSB"
        Me.RadioUSB.Size = New System.Drawing.Size(75, 16)
        Me.RadioUSB.TabIndex = 2
        Me.RadioUSB.TabStop = True
        Me.RadioUSB.Text = "USB COM"
        Me.RadioUSB.UseVisualStyleBackColor = True
        '
        'RadioWiFi
        '
        Me.RadioWiFi.AutoSize = True
        Me.RadioWiFi.Location = New System.Drawing.Point(102, 30)
        Me.RadioWiFi.Name = "RadioWiFi"
        Me.RadioWiFi.Size = New System.Drawing.Size(69, 16)
        Me.RadioWiFi.TabIndex = 3
        Me.RadioWiFi.Text = "無線LAN"
        Me.RadioWiFi.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.RadioWiFi)
        Me.GroupBox1.Controls.Add(Me.RadioUSB)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 14)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(188, 63)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "接続方法"
        '
        'LEDNDSample
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(220, 136)
        Me.Controls.Add(Me.BtnClear)
        Me.Controls.Add(Me.BtnDisp)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "LEDNDSample"
        Me.Text = "LEDND"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnDisp As Button
    Friend WithEvents BtnClear As Button
    Friend WithEvents RadioUSB As RadioButton
    Friend WithEvents RadioWiFi As RadioButton
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents SerialPort1 As IO.Ports.SerialPort
End Class

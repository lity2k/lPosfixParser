<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBox_输入 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox_输出 = New System.Windows.Forms.TextBox()
        Me.TextBox_计算结果 = New System.Windows.Forms.TextBox()
        Me.Button_解析 = New System.Windows.Forms.Button()
        Me.Button_计算 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'TextBox_输入
        '
        Me.TextBox_输入.Location = New System.Drawing.Point(12, 33)
        Me.TextBox_输入.Multiline = True
        Me.TextBox_输入.Name = "TextBox_输入"
        Me.TextBox_输入.Size = New System.Drawing.Size(666, 83)
        Me.TextBox_输入.TabIndex = 0
        Me.TextBox_输入.Text = "东莞+(莞城|南城|东城|万江|石碣|石龙|茶山|石排|企石|横沥|桥头|谢岗|东坑|常平|寮步|大朗|黄江|清溪|塘厦|凤岗|长安|虎门|厚街|沙田|道滘|洪梅" &
    "|麻涌|中堂|高埗|樟木头|大岭山|望牛墩)"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 12)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "输入表达式"
        '
        'TextBox_输出
        '
        Me.TextBox_输出.Location = New System.Drawing.Point(12, 187)
        Me.TextBox_输出.Multiline = True
        Me.TextBox_输出.Name = "TextBox_输出"
        Me.TextBox_输出.Size = New System.Drawing.Size(320, 296)
        Me.TextBox_输出.TabIndex = 0
        '
        'TextBox_计算结果
        '
        Me.TextBox_计算结果.Location = New System.Drawing.Point(351, 187)
        Me.TextBox_计算结果.Multiline = True
        Me.TextBox_计算结果.Name = "TextBox_计算结果"
        Me.TextBox_计算结果.Size = New System.Drawing.Size(327, 296)
        Me.TextBox_计算结果.TabIndex = 0
        '
        'Button_解析
        '
        Me.Button_解析.Location = New System.Drawing.Point(14, 122)
        Me.Button_解析.Name = "Button_解析"
        Me.Button_解析.Size = New System.Drawing.Size(75, 23)
        Me.Button_解析.TabIndex = 2
        Me.Button_解析.Text = "解析"
        Me.Button_解析.UseVisualStyleBackColor = True
        '
        'Button_计算
        '
        Me.Button_计算.Location = New System.Drawing.Point(112, 122)
        Me.Button_计算.Name = "Button_计算"
        Me.Button_计算.Size = New System.Drawing.Size(75, 23)
        Me.Button_计算.TabIndex = 2
        Me.Button_计算.Text = "计算"
        Me.Button_计算.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 172)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "输出"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 495)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button_计算)
        Me.Controls.Add(Me.Button_解析)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TextBox_计算结果)
        Me.Controls.Add(Me.TextBox_输出)
        Me.Controls.Add(Me.TextBox_输入)
        Me.Name = "Form1"
        Me.Text = "表达式解析器 by lity2k@gmail.com"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBox_输入 As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox_输出 As TextBox
    Friend WithEvents Button_解析 As Button
    Friend WithEvents Button_计算 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox_计算结果 As TextBox
End Class

Imports lPosfixParser

Public Class Form1
    Private Sub Button_解析_Click(sender As Object, e As EventArgs) Handles Button_解析.Click
        Dim pp As New PosfixParser
        Me.TextBox_输出.Text = pp.Parse(Me.TextBox_输入.Text)
    End Sub

    Private Sub Button_计算_Click(sender As Object, e As EventArgs) Handles Button_计算.Click
        Dim words As String = ""

        Me.TextBox_计算结果.Clear()
        Dim pp As New PosfixParser
        For Each l As String In pp.Calculate（Me.TextBox_输出.Text）
            TextBox_计算结果.AppendText(l & vbCrLf)
        Next
    End Sub
End Class

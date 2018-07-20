Imports System.Text

Public Class PosfixParser

    Function Parse(input As String) As String
        Dim i As Integer = 0
        Dim j As Integer = 0

        Dim ch, ch1 As String
        Dim A() As String = input2word(input)  '将字符串转成字符数组，要注意的是，不能有大于10的数存在
        Dim B(A.Length) As String  '最后生成的后缀表达式会小于这个长度，因为有括号
        Dim myStack As Stack = New Stack()

        For i = 0 To A.Length - 1
            ch = A(i)

            If IsOperand(ch) Then   '如果为操作数，直接存入B中
                B(j) = ch
                j += 1
            Else
                If ch = "(" Then    '如果为(，入栈。
                    myStack.Push(ch)
                ElseIf ch = ")" Then
                    While Not IsEmpty(myStack)        '弹出堆栈里的内容，直到找到"("
                        ch = myStack.Pop
                        If ch = "(" Then
                            Exit While
                        Else
                            B(j) = ch   '将从堆栈弹跳出的内容存到B中
                            j += 1
                        End If
                    End While
                Else    '如果ch既不是"("也不是")"，是其它操作符，比如+, -, *, /之类的
                    If Not IsEmpty(myStack) Then
                        Do
                            ch1 = myStack.Pop   '弹出栈顶元素
                            If Priority(ch) > Priority(ch1) Then    '如果栈顶元素的优先级小于读取到的操作符
                                myStack.Push(ch1)   '将栈顶元素放回堆栈
                                myStack.Push(ch)    '将读取到的操作符放回堆栈

                                Exit Do '跳出do循环
                            Else    '如果栈顶元素的优先级比较高或者两者相等时
                                B(j) = ch1   '将栈顶元素，放入B中
                                j += 1

                                If IsEmpty(myStack) Then
                                    myStack.Push(ch)    '将读取到的操作符压入堆栈中
                                    Exit Do '跳出do循环
                                End If
                            End If
                        Loop Until IsEmpty(myStack)
                    Else    '如果堆栈为空，就把操作符放入堆栈中
                        myStack.Push(ch)
                    End If
                End If
            End If
        Next

        While Not IsEmpty(myStack)
            B(j) = myStack.Pop   '将堆栈中剩下的操作符输出到B中
            j += 1
        End While

        Dim posfixExpression As New StringBuilder()
        For Each ch_b As String In B
            If String.Concat(ch_b).Length > 0 Then posfixExpression.Append(ch_b & ",")
        Next

        Return posfixExpression.ToString
    End Function

    ''' <summary>
    ''' ;计算后缀表达式的值
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    Public Function Calculate(input As String) As String()
        Dim A() As String = input.Split(",")

        Dim Operand1, Operand2 As Object     '操作数

        Dim myStack As Stack = New Stack()
        For i As Integer = 0 To A.GetUpperBound(0)
            Dim ch As String = A(i)

            If IsOperand(ch) Then   '如果是操作数，直接压入栈
                myStack.Push(ch)
            Else '如果是操作符，就弹出两个操作数来进行运算
                Operand2 = myStack.Pop
                If Not IsArray(Operand2) Then Operand2 = CStr(Operand2).Split("|")
                Operand1 = myStack.Pop
                If Not IsArray(Operand1) Then Operand1 = CStr(Operand1).Split("|")

                myStack.Push(GetValue(ch, Operand1, Operand2))   '把运算结果入栈
            End If
        Next

        Dim ret As New ArrayList  ' 运算结果
        Do Until IsEmpty(myStack)
            Dim p As Object
            p = myStack.Pop()
            If IsArray(p) Then
                For Each j As String In p
                    If String.Concat(j).Trim.Length > 0 Then ret.Add(j)
                Next
            Else
                If String.Concat(p).Trim.Length > 0 Then ret.Add(CStr(p))
            End If
        Loop

        If ret.Count > 0 Then
            Dim value(ret.Count - 1) As String
            ret.CopyTo(value)
            Return value
        Else
            Return Nothing
        End If
    End Function

    ''' <summary>
    ''' 根据操作符进行运算，返回值为String()
    ''' </summary>
    ''' <param name="op"></param>
    ''' <param name="Operand1"></param>
    ''' <param name="Operand2"></param>
    ''' <returns></returns>
    Function GetValue(op As String, Operand1() As String, Operand2() As String) As String()
        Dim op1, op2 As String()
        Dim ret As New ArrayList
        op1 = Operand1
        op2 = Operand2

        Select Case op
            Case "+"
                For Each op1s As String In op1
                    If op1s.Length > 0 Then
                        For Each op2s As String In op2
                            If op2s.Length > 0 Then
                                ret.Add(op1s & "&" & op2s)
                            End If
                        Next
                    End If
                Next
            Case "|"
                For Each op1s As String In op1
                    ret.Add(op1s)
                Next
                For Each op2s As String In op2
                    ret.Add(op2s)
                Next
            Case Else

        End Select

        Dim value(ret.Count - 1) As String
        ret.CopyTo(value)
        Return value
        'Return ret
    End Function

    ''' <summary>
    ''' 把输入文本分割成由操作符、操作数组成的字串数组
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    Function input2word(input As String) As String()
        Dim charArray As New ArrayList
        Dim wordTemp As New StringBuilder
        For Each c As Char In input.ToCharArray
            If Not IsOperand(c) Then    '如果c为操作符，把操作符增加到数组。如果wordTemp不为空，也增加到数组并清空wordTemp变量
                If wordTemp.Length > 0 Then
                    charArray.Add(wordTemp.ToString)
                    wordTemp.Clear()
                End If
                charArray.Add(CStr(c))
            Else    '如果不为操作符，把当前字符增加到 wordTemp变量中
                wordTemp.Append(c)
            End If
        Next

        If wordTemp.Length > 0 Then '如果wordTemp不为空，也增加到数组
            charArray.Add(wordTemp.ToString)
            wordTemp.Clear()
        End If

        Dim value(charArray.Count - 1) As String
        charArray.CopyTo(value)
        Return value
    End Function

    ''' <summary>
    ''' 判定是否为操作数
    ''' </summary>
    ''' <param name="ch"></param>
    ''' <returns></returns>
    Function IsOperand(ch As String) As Boolean
        Dim operators As String() = {"+", "-", "*", "|", "(", ")"}  '操作符列表。不在操作符表中的就是操作数。
        For Each o As String In operators
            If ch = o Then Return False
        Next
        Return True
    End Function

    ''' <summary>
    ''' 返回运算符优先级。
    ''' </summary>
    ''' <param name="input"></param>
    ''' <returns></returns>
    Function Priority(input As String) As Integer
        Dim value As Integer = 0
        Select Case input
            Case "+"
                value = 2
            Case "-"
                value = 1
            Case "*"
                value = 2
            Case "|"
                value = 1
            Case Else
                value = 0
        End Select

        Return value
    End Function

    ''' <summary>
    ''' 判断堆栈是否为空
    ''' </summary>
    ''' <param name="st"></param>
    ''' <returns></returns>
    Function IsEmpty(st As Stack) As Boolean
        If IsNothing(st) Then Return True
        If st.Count = 0 Then Return True

        Return False
    End Function

End Class

Imports System
Imports System.Drawing

Module Program
    Sub Main(args As String())
        Do
            caculate()
        Loop
    End Sub

    Public Sub caculate()
        ' 定义颜色A和颜色B（RGB格式）
        Console.WriteLine("请输入被改变颜色，依次R\G\B，输入一个数字回车一次")
        Dim colorA As Color = Color.FromArgb(Console.ReadLine(), Console.ReadLine(), Console.ReadLine()) 
        Console.WriteLine("请输入目标颜色，依次R\G\B，输入一个数字回车一次")
        Dim colorB As Color = Color.FromArgb(Console.ReadLine(), Console.ReadLine(), Console.ReadLine())

        ' 将RGB颜色转换为HSL颜色
        Dim hslA As HSL = RGBToHSL(colorA)
        Dim hslB As HSL = RGBToHSL(colorB)

        ' 计算HSL变化量
        Dim hueDiff As Double = hslA.H - hslB.H
        Dim satDiff As Double = hslA.S - hslB.S
        Dim lightDiff As Double = hslA.L - hslB.L

        ' 输出HSL变化值
        Console.WriteLine("HSL变化值: ({0}, {1}, {2})", hueDiff, satDiff, lightDiff)
        Console.WriteLine("注意，这个是HSL的变化值！如果你的HSL改变操作中0.5,1是不改颜色，那么就在此基础上加减即可！")
    End Sub

    ' 定义HSL结构体
    Public Structure HSL
        Public H As Double
        Public S As Double
        Public L As Double
    End Structure

    ' 将RGB转换为HSL
    Public Function RGBToHSL(ByVal color As Color) As HSL
        Dim r As Double = color.R / 255.0
        Dim g As Double = color.G / 255.0
        Dim b As Double = color.B / 255.0

        Dim max As Double = Math.Max(r, Math.Max(g, b))
        Dim min As Double = Math.Min(r, Math.Min(g, b))
        Dim delta As Double = max - min

        Dim h As Double = 0
        Dim s As Double = 0
        Dim l As Double = (max + min) / 2.0

        If delta <> 0 Then
            If max = r Then
                h = (g - b) / delta
            ElseIf max = g Then
                h = 2.0 + (b - r) / delta
            ElseIf max = b Then
                h = 4.0 + (r - g) / delta
            End If

            h *= 60.0
            If h < 0 Then
                h += 360.0
            End If

            If l < 0.5 Then
                s = delta / (max + min)
            Else
                s = delta / (2.0 - max - min)
            End If
        End If

        ' 将H值转换为0-1范围
        h /= 360.0

        Return New HSL With {.H = h, .S = s, .L = l}
    End Function
End Module

Imports System
Imports System.Drawing

Module Program
    Sub Main(args As String())
        Do
            caculate()
        Loop
    End Sub

    Public Sub caculate()
        ' ������ɫA����ɫB��RGB��ʽ��
        Console.WriteLine("�����뱻�ı���ɫ������R\G\B������һ�����ֻس�һ��")
        Dim colorA As Color = Color.FromArgb(Console.ReadLine(), Console.ReadLine(), Console.ReadLine()) ' ���磬��ɫ
        Console.WriteLine("������Ŀ����ɫ������R\G\B������һ�����ֻس�һ��")
        Dim colorB As Color = Color.FromArgb(Console.ReadLine(), Console.ReadLine(), Console.ReadLine()) ' ���磬��ɫ

        ' ��RGB��ɫת��ΪHSL��ɫ
        Dim hslA As HSL = RGBToHSL(colorA)
        Dim hslB As HSL = RGBToHSL(colorB)

        ' ����HSL�仯��
        Dim hueDiff As Double = hslA.H - hslB.H
        Dim satDiff As Double = hslA.S - hslB.S
        Dim lightDiff As Double = hslA.L - hslB.L

        ' ���HSL�仯ֵ
        Console.WriteLine("HSL�仯ֵ: ({0}, {1}, {2})", hueDiff, satDiff, lightDiff)
        Console.WriteLine("ע�⣬�����HSL�ı仯ֵ��������HSL�ı������0.5,1�ǲ�����ɫ����ô���ڴ˻����ϼӼ����ɣ�")
    End Sub

    ' ����HSL�ṹ��
    Public Structure HSL
        Public H As Double
        Public S As Double
        Public L As Double
    End Structure

    ' ��RGBת��ΪHSL
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

        ' ��Hֵת��Ϊ0-1��Χ
        h /= 360.0

        Return New HSL With {.H = h, .S = s, .L = l}
    End Function
End Module

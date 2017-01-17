
Imports Emgu.CV
Imports Emgu.CV.Structure
Imports Emgu.Util
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Runtime.InteropServices

Module Module1
    Sub Main()
        'Load the image from file
        Dim img As New Image(Of Bgr, Byte)("C:\Users\mpashkevych\Desktop\66CELLS\EL_EL_EL_EL\lines_test\1212.png")
        Dim imgGray As Image(Of Gray, Byte) = img.Convert(Of Gray, Byte)()
        ' Dim imgGray2 As Image(Of Gray, Byte) = img.Canny(10, 40)
        Dim imgGray2 As Image(Of Gray, Byte) = img.Canny(100, 60)
        Dim RhoRes As Double = 2
        Dim Threshold As Double = 100
        Dim MinLineWidth As Double = 20     '20 - best
        Dim linegap As Integer = 20          '20 - best
        Dim ThetaRes As Double = Math.PI / 180
        Dim Linez()() As LineSegment2D = imgGray2.HoughLinesBinary(RhoRes, ThetaRes, Threshold, MinLineWidth, linegap)
        If Linez(0).Length >= 0 Then 'Greater than or equal to
            For i As Integer = 0 To Linez(0).Length - 1
                If Linez(0)(i).Length >= 20 And Linez(0)(i).Length < 60 Then 'Greater than and less than or equal to
                    img.Draw(Linez(0)(i), New Bgr(0, 255, 200), 2) 'New Gray(60), 1) '
                End If
                If Linez(0)(i).Length >= 60 And Linez(0)(i).Length < 120 Then 'Greater than and less than or equal to
                    img.Draw(Linez(0)(i), New Bgr(255, 0, 0), 3) 'New Gray(100), 2) '
                End If
                If Linez(0)(i).Length >= 120 Then
                    img.Draw(Linez(0)(i), New Bgr(0, 0, 255), 3) 'New Gray(150), 3) '
                End If
            Next
        End If
        'Form1.Pic1.Image = imgGray2.ToBitmap
        UI.ImageViewer.Show(img)
    End Sub
End Module

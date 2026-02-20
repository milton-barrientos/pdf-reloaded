Imports System.Drawing
Imports FastReport
Imports FastReport.Table

Public Class PdfGenerator

    Shared Sub GenerarPdf()
        Dim report As New Report()

        ' 1. Cargar el reporte
        report.Load("reportes/reporteDePrueba.frx")

        Dim tabla As TableObject = TryCast(report.FindObject("Table1"), TableObject)
        If tabla IsNot Nothing Then

            tabla.RowCount = 3
            tabla.ColumnCount = 2

            tabla(0, 0).Text = "Nombre"
            tabla(1, 0).Text = "Edad"

            tabla(0, 1).Text = "Juan Alejandro Perez Coello Constanza"
            tabla(1, 1).Text = "21"

            tabla(0, 2).Text = "Milton Alejandro Barrientos Hernández"
            tabla(1, 2).Text = "23"

            For i As Integer = 0 To tabla.ColumnCount - 1
                For j As Integer = 0 To tabla.RowCount - 1
                    tabla(i, j).Border.Lines = BorderLines.All
                    tabla(i, j).Border.Color = Color.Black
                    tabla(i, j).Border.Width = 1.0F

                    If j Mod 2 = 0 Then
                        tabla(i, j).Fill = New SolidFill(Color.White)
                    Else
                        tabla(i, j).Fill = New SolidFill(Color.AliceBlue)
                    End If
                Next
            Next

            tabla(0, 0).Fill = New SolidFill(Color.Gray)
            tabla(1, 0).Fill = New SolidFill(Color.Gray)
            tabla(0, 0).TextColor = Color.White
            tabla(1, 0).TextColor = Color.White

            'Bold
            tabla(0, 0).Font = New Font(tabla(0, 0).Font, FontStyle.Bold)
            tabla(1, 0).Font = New Font(tabla(0, 0).Font, FontStyle.Bold)
        End If



        report.SetParameterValue("nombrePersona", "Milton Barrientos")
        report.SetParameterValue("edad", 23)

        ' 3. Preparar y Exportar
        report.Prepare()

        Using export As New Export.PdfSimple.PDFSimpleExport()
            Dim absolutePath As String = IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "reportes/reporteDePrueba.pdf")
            report.Export(export, absolutePath)
            'Open the generated PDF file
            Process.Start(absolutePath)
        End Using
    End Sub

End Class
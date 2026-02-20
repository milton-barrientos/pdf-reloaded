Imports System.Data
Imports System.Drawing
Imports System.IO
Imports FastReport
Imports FastReport.Table
Imports Stimulsoft.Report

Public Class PdfGenerator

    Shared Sub GenerarPdfFastReports()
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

    Shared Function GenerarPdfStimulsoft() As StiReport
        Dim report As New StiReport()
        Dim rutaMrt As String = "reportes/reporteStimulsoft.mrt"
        report.Load(rutaMrt)

        ' --- 1. REEMPLAZO DE VARIABLES (CAMPOS SUELTOS) ---
        ' Esto llena los campos entre llaves como {InvoiceNo}, {CompanyName}, etc.
        report.Dictionary.Variables("InvoiceNo").Value = "FAC-0001"
        report.Dictionary.Variables("CompanyName").Value = "Mi Empresa S.A."
        report.Dictionary.Variables("CompanyAddress").Value = "Barrio El Centro"
        report.Dictionary.Variables("CompanyCity").Value = "Tegucigalpa"

        ' Datos del cliente
        report.Dictionary.Variables("BillToCompanyName").Value = "Cliente de Prueba"
        report.Dictionary.Variables("BillToAdress").Value = "Col. Miraflores"

        ' --- 2. LLENADO DE LA TABLA (DATABAND) ---
        ' Creamos la tabla con el nombre EXACTO que pusiste en el Designer: "Products"
        Dim dt As New DataTable("Products")
        dt.Columns.Add("ProductName", GetType(String))
        dt.Columns.Add("UnitsInStock", GetType(Decimal))
        dt.Columns.Add("UnitPrice", GetType(Decimal))

        ' Metemos datos de ejemplo para que veas la tabla llena
        dt.Rows.Add("Laptop Dell XPS", 1, 1200.0)
        dt.Rows.Add("Monitor 24 Pulgadas", 2, 250.0)
        dt.Rows.Add("Mouse Inalámbrico", 5, 15.75)

        report.RegData(dt)

        report.Render(False)

        Dim carpetaExportacion As String = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "reportes")
        If Not Directory.Exists(carpetaExportacion) Then Directory.CreateDirectory(carpetaExportacion)

        Dim rutaPdf As String = Path.Combine(carpetaExportacion, "reporteDePrueba.pdf")

        report.ExportDocument(StiExportFormat.Pdf, rutaPdf)

        Process.Start(rutaPdf)

        Return report
    End Function

End Class
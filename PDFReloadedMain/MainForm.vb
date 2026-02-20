Public Class MainForm

    Private Sub CmdGenerar_Click(sender As Object, e As EventArgs) Handles cmdGenerarFastReport.Click
        PdfReloaded.PdfGenerator.GenerarPdfFastReports()
    End Sub

    Private Sub cmdGenerarStimulsoft_Click(sender As Object, e As EventArgs) Handles cmdGenerarStimulsoft.Click
        PdfReloaded.PdfGenerator.GenerarPdfStimulsoft()
    End Sub

End Class
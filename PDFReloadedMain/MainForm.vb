Public Class MainForm

    Private Sub CmdGenerar_Click(sender As Object, e As EventArgs) Handles cmdGenerar.Click
        PdfReloaded.PdfGenerator.GenerarPdf()
    End Sub

End Class
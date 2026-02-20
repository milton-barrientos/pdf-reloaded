<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainForm
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.cmdGenerarFastReport = New System.Windows.Forms.Button()
        Me.cmdGenerarStimulsoft = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'cmdGenerarFastReport
        '
        Me.cmdGenerarFastReport.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdGenerarFastReport.Location = New System.Drawing.Point(12, 12)
        Me.cmdGenerarFastReport.Name = "cmdGenerarFastReport"
        Me.cmdGenerarFastReport.Size = New System.Drawing.Size(210, 56)
        Me.cmdGenerarFastReport.TabIndex = 0
        Me.cmdGenerarFastReport.Text = "Generar (FastReport)"
        Me.cmdGenerarFastReport.UseVisualStyleBackColor = True
        '
        'cmdGenerarStimulsoft
        '
        Me.cmdGenerarStimulsoft.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.cmdGenerarStimulsoft.Location = New System.Drawing.Point(12, 74)
        Me.cmdGenerarStimulsoft.Name = "cmdGenerarStimulsoft"
        Me.cmdGenerarStimulsoft.Size = New System.Drawing.Size(210, 56)
        Me.cmdGenerarStimulsoft.TabIndex = 1
        Me.cmdGenerarStimulsoft.Text = "Generar (Stimulsoft)"
        Me.cmdGenerarStimulsoft.UseVisualStyleBackColor = True
        '
        'MainForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(234, 141)
        Me.Controls.Add(Me.cmdGenerarStimulsoft)
        Me.Controls.Add(Me.cmdGenerarFastReport)
        Me.Name = "MainForm"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents cmdGenerarFastReport As Button
    Friend WithEvents cmdGenerarStimulsoft As Button
End Class

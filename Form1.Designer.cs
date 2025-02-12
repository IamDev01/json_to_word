//Copyright (c) 2025 Héricles França da Silva. Todos os direitos reservados. 

namespace relatorio_medico
{
    partial class Form1
    {
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Forms Designer

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtJsonInput = new System.Windows.Forms.TextBox();
            this.btnGerarRelatorio = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // txtJsonInput
            // 
            this.txtJsonInput.AccessibleDescription = "Campo de entrada de dados JSON do paciente.";
            this.txtJsonInput.Font = new System.Drawing.Font("Arial", 10F);
            this.txtJsonInput.Location = new System.Drawing.Point(15, 16);
            this.txtJsonInput.Margin = new System.Windows.Forms.Padding(2);
            this.txtJsonInput.Multiline = true;
            this.txtJsonInput.Name = "txtJsonInput";
            this.txtJsonInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtJsonInput.Size = new System.Drawing.Size(385, 200);
            this.txtJsonInput.TabIndex = 0;
            this.toolTip.SetToolTip(this.txtJsonInput, "Insira os dados JSON do paciente aqui.");
            // 
            // btnGerarRelatorio
            // 
            this.btnGerarRelatorio.AccessibleDescription = "Botão para gerar o relatório médico a partir do JSON inserido.";
            this.btnGerarRelatorio.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnGerarRelatorio.Location = new System.Drawing.Point(72, 230);
            this.btnGerarRelatorio.Margin = new System.Windows.Forms.Padding(2);
            this.btnGerarRelatorio.Name = "btnGerarRelatorio";
            this.btnGerarRelatorio.Size = new System.Drawing.Size(270, 40);
            this.btnGerarRelatorio.TabIndex = 1;
            this.btnGerarRelatorio.Text = "Gerar Relatório Médico";
            this.toolTip.SetToolTip(this.btnGerarRelatorio, "Clique para gerar o relatório médico a partir do JSON inserido.");
            this.btnGerarRelatorio.UseVisualStyleBackColor = true;
            this.btnGerarRelatorio.Click += new System.EventHandler(this.btnGerarRelatorio_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AccessibleDescription = "Exibe o status da geração do relatório.";
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Italic);
            this.lblStatus.Location = new System.Drawing.Point(127, 280);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 15);
            this.lblStatus.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 335);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnGerarRelatorio);
            this.Controls.Add(this.txtJsonInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gerador de Relatório Médico";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.TextBox txtJsonInput;
        private System.Windows.Forms.Button btnGerarRelatorio;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.ToolTip toolTip;
        private System.ComponentModel.IContainer components;
    }
}

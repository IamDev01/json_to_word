//Copyright (c) 2025 Héricles França da Silva. Todos os direitos reservados. 

using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using Newtonsoft.Json;
using relatorio_medico.Models;
using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Threading.Tasks;
using System.Windows.Forms;
using DrawingColor = System.Drawing.Color;


namespace relatorio_medico
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            ConfigureStatusLabel();
            ConfigureToolTips();
        }

        private void ConfigureStatusLabel()
        {
            lblStatus.AutoSize = false;
            lblStatus.Size = new Size(385, 40);
            lblStatus.Location = new Point(btnGerarRelatorio.Location.X, btnGerarRelatorio.Location.Y + btnGerarRelatorio.Height + 10);
        }

        private void ConfigureToolTips()
        {
            toolTip.SetToolTip(txtJsonInput, "Cole aqui os dados do paciente em formato JSON");
            toolTip.SetToolTip(btnGerarRelatorio, "Clique para gerar o relatório médico em formato Word");
        }

        private async void btnGerarRelatorio_Click(object sender, EventArgs e)
        {
            try
            {
                string jsonContent = txtJsonInput.Text.Trim();
                if (!ValidateJsonInput(jsonContent)) return;

                Paciente paciente = DeserializePaciente(jsonContent);
                if (!ValidatePaciente(paciente)) return;

                using (SaveFileDialog saveDialog = CreateSaveDialog(paciente))
                {
                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        await GenerateReportAsync(paciente, saveDialog.FileName);
                    }
                }
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private bool ValidateJsonInput(string jsonContent)
        {
            if (string.IsNullOrWhiteSpace(jsonContent))
            {
                ShowStatusMessage("Insira um JSON válido!", DrawingColor.Red);
                return false;
            }
            return true;
        }

        private Paciente DeserializePaciente(string jsonContent)
        {
            try
            {
                return JsonConvert.DeserializeObject<Paciente>(jsonContent);
            }
            catch (JsonException ex)
            {
                ShowStatusMessage($"Erro no JSON: {ex.Message}", DrawingColor.Red);
                return null;
            }
        }

        private bool ValidatePaciente(Paciente paciente)
        {
            if (paciente == null)
            {
                ShowStatusMessage("Dados do paciente inválidos.", DrawingColor.Red);
                return false;
            }
            
            if (string.IsNullOrWhiteSpace(paciente.Nome))
            {
                ShowStatusMessage("O nome do paciente é obrigatório.", DrawingColor.Red);
                return false;
            }

            if (paciente.Idade <= 0)
            {
                ShowStatusMessage("A idade deve ser maior que zero.", DrawingColor.Red);
                return false;
            }

            return true;
        }

        private SaveFileDialog CreateSaveDialog(Paciente paciente)
        {
            return new SaveFileDialog
            {
                Filter = "Documentos Word (*.docx)|*.docx",
                Title = "Salvar Relatório Médico",
                FileName = $"Relatorio_{SanitizeFileName(paciente.Nome)}"
            };
        }

        private string SanitizeFileName(string name)
        {
            var invalidChars = Path.GetInvalidFileNameChars();
            return new string(name.Select(c => invalidChars.Contains(c) ? '_' : c).ToArray());
        }

        private async Task GenerateReportAsync(Paciente paciente, string filePath)
        {
            try
            {
                ShowStatusMessage("Gerando relatório...", DrawingColor.Blue);
                await Task.Run(() => CriarRelatorioWord(paciente, filePath));

                txtJsonInput.Clear();
                ShowStatusMessage("Relatório gerado com sucesso!", DrawingColor.Green);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }

        private void CriarRelatorioWord(Paciente paciente, string filePath)
        {
            using (WordprocessingDocument doc = WordprocessingDocument.Create(filePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = doc.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = new Body();

                // Título principal
                body.AppendChild(CriarParagrafo("Relatório Médico", true, 24, JustificationValues.Center));

                // Dados do paciente
                body.AppendChild(CriarParagrafo($"Nome: {paciente.Nome}", false, 14, JustificationValues.Left));
                body.AppendChild(CriarParagrafo($"Idade: {paciente.Idade} anos", false, 14, JustificationValues.Left));
                body.AppendChild(CriarParagrafo($"Diagnóstico: {paciente.Diagnostico}", false, 14, JustificationValues.Left));
                body.AppendChild(CriarParagrafo($"Prescrição Médica: {paciente.Prescricao}", false, 14, JustificationValues.Left));

                // Seção de Exames
                body.AppendChild(CriarParagrafo("Exames Realizados:", true, 16, JustificationValues.Left));
                if (paciente.Exames != null && paciente.Exames.Count > 0)
                {
                    foreach (var exame in paciente.Exames)
                    {
                        body.AppendChild(CriarParagrafo($"- {exame.Tipo}: {exame.Resultado}", false, 12, JustificationValues.Left));
                    }
                }
                else
                {
                    body.AppendChild(CriarParagrafo("Nenhum exame registrado.", false, 12, JustificationValues.Left));
                }

                mainPart.Document.AppendChild(body);
                mainPart.Document.Save();
            }
        }

        private Paragraph CriarParagrafo(string texto, bool negrito, int tamanho, JustificationValues alinhamento)
        {
            var runProperties = new RunProperties(
                new RunFonts() { Ascii = "Arial", HighAnsi = "Arial", EastAsia = "Arial" },
                new FontSize() { Val = (tamanho * 2).ToString() }
            );
            
            if (negrito) runProperties.Append(new Bold());

            return new Paragraph(
                new ParagraphProperties(new Justification() { Val = alinhamento }),
                new Run(runProperties, new Text(SecurityElement.Escape(texto)))
            );
        }

        private void ShowStatusMessage(string message, DrawingColor color)
        {
            lblStatus.Text = message;
            lblStatus.ForeColor = color;
        }

        private void HandleError(Exception ex)
        {
            // Log para depuração (implementar conforme necessidade)
            // File.AppendAllText("erros.log", $"[{DateTime.Now}] {ex}\n\n");
            
            ShowStatusMessage($"Erro: {ex.Message}", DrawingColor.Red);
        }
    }
}
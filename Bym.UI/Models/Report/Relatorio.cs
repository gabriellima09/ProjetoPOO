using Bym.UI.Builder;
using Bym.UI.Models.Domain;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;

namespace Bym.UI.Models.Report
{
    public class Relatorio : ReportBuilder
    {
        private string _ValorArrecadado { get; set; }
        private string _TotalReservas { get; set; }
        private string _TotalSalas { get; set; }
        private string _SalaMaiorCapacidade { get; set; }
        private string _UltimaSala { get; set; }
        private string _UltimaReserva { get; set; }

        public Relatorio(Dashboard dashboard)
        {
            SetarInformacoesRelatorio(dashboard);
        }

        private string RetornarNomeUltimaSala(Dashboard dashboard)
        {
            return string.Concat(dashboard.UltimaSalaCadastrada.Nome,
                                            " - ",
                                            dashboard.UltimaSalaCadastrada.CapacidadeMaxima, " Lugares",
                                            " - ",
                                            dashboard.UltimaSalaCadastrada.ValorHora.ToString("C"), "/h",
                                            " - ",
                                            dashboard.UltimaSalaCadastrada.Endereco.Logradouro,
                                            ", ",
                                            dashboard.UltimaSalaCadastrada.Endereco.Numero,
                                            " ",
                                            dashboard.UltimaSalaCadastrada.Endereco.Complemento);
        }

        private string RetornarNomeUltimaReserva(Dashboard dashboard)
        {
            return string.Concat(dashboard.UltimaReserva.Sala.Nome,
                                            " - ",
                                            dashboard.UltimaReserva.Sala.CapacidadeMaxima, " Lugares",
                                            " - ",
                                            dashboard.UltimaReserva.Sala.ValorHora.ToString("C"), "/h",
                                            " - ",
                                            dashboard.UltimaReserva.DataHora,
                                            " - ",
                                            dashboard.UltimaReserva.HorasReservadas, "h");
        }

        private void MontarInformacoesUltimaSala(XFont boldSubtitleFont, XFont boldDefaultFont, XFont defaultFont, XTextFormatter textFormatter, XBrush defaultBrush)
        {
            textFormatter.Alignment = XParagraphAlignment.Left;
            textFormatter.DrawString("Última Sala Cadastrada", boldSubtitleFont, defaultBrush, new XRect(50, 340, 550, 340));
            textFormatter.DrawString("Sala: ", boldDefaultFont, defaultBrush, new XRect(50, 360, 550, 360));
            textFormatter.DrawString(_UltimaSala, defaultFont, defaultBrush, new XRect(85, 360, 550, 360));
        }

        private void MontarInformacoesUltimaReserva(XFont boldSubtitleFont, XFont boldDefaultFont, XFont defaultFont, XTextFormatter textFormatter, XBrush defaultBrush)
        {
            textFormatter.Alignment = XParagraphAlignment.Left;
            textFormatter.DrawString("Última Reserva", boldSubtitleFont, defaultBrush, new XRect(50, 280, 550, 280));
            textFormatter.DrawString("Reserva: ", boldDefaultFont, defaultBrush, new XRect(50, 300, 550, 300));
            textFormatter.DrawString(_UltimaReserva, defaultFont, defaultBrush, new XRect(105, 300, 550, 300));
        }

        private void MontarInformacoesSalas(XFont boldSubtitleFont, XFont boldDefaultFont, XFont defaultFont, XTextFormatter textFormatter, XBrush defaultBrush)
        {
            textFormatter.Alignment = XParagraphAlignment.Left;
            textFormatter.DrawString("Salas", boldSubtitleFont, defaultBrush, new XRect(50, 200, 550, 200));
            textFormatter.DrawString("Salas Cadastradas: ", boldDefaultFont, defaultBrush, new XRect(50, 220, 550, 220));
            textFormatter.DrawString(_TotalSalas, defaultFont, defaultBrush, new XRect(165, 220, 550, 220));
            textFormatter.DrawString("Sala Maior Capacidade: ", boldDefaultFont, defaultBrush, new XRect(50, 240, 550, 240));
            textFormatter.DrawString(_SalaMaiorCapacidade, defaultFont, defaultBrush, new XRect(190, 240, 550, 240));
        }

        private void MontarInformacoesReservas(XFont boldSubtitleFont, XFont boldDefaultFont, XFont defaultFont, XTextFormatter textFormatter, XBrush defaultBrush)
        {
            textFormatter.Alignment = XParagraphAlignment.Left;
            textFormatter.DrawString("Reservas", boldSubtitleFont, defaultBrush, new XRect(50, 120, 550, 120));
            textFormatter.DrawString("Total de Reservas: ", boldDefaultFont, defaultBrush, new XRect(50, 140, 550, 140));
            textFormatter.DrawString(_TotalReservas, defaultFont, defaultBrush, new XRect(160, 140, 550, 140));
            textFormatter.DrawString("Valor Arrecadado: ", boldDefaultFont, defaultBrush, new XRect(50, 160, 550, 160));
            textFormatter.DrawString(_ValorArrecadado, defaultFont, defaultBrush, new XRect(160, 160, 550, 160));
        }

        private void MontarHeader(PdfPage page, XFont titleFont, XBrush defaultBrush, XGraphics graphics, XTextFormatter textFormatter)
        {
            textFormatter.Alignment = XParagraphAlignment.Center;
            textFormatter.DrawString("Relatório - Book Your Meeting", titleFont, defaultBrush, new XRect(30, 60, page.Width - 60, page.Height - 60));
            graphics.DrawLine(XPens.Black, 50, 100, 550, 100);
        }

        public override void GerarRelatorio()
        {
            using (PdfDocument doc = new PdfDocument())
            {
                PdfPage page = doc.AddPage();

                XFont titleFont = new XFont("Arial", 18);
                XFont boldSubtitleFont = new XFont("Arial", 14, XFontStyle.Bold);
                XFont boldDefaultFont = new XFont("Arial", 12, XFontStyle.Bold);
                XFont defaultFont = new XFont("Arial", 12);

                XBrush defaultBrush = XBrushes.Black;
                XGraphics graphics = XGraphics.FromPdfPage(page);
                XTextFormatter textFormatter = new XTextFormatter(graphics);

                MontarHeader(page, titleFont, defaultBrush, graphics, textFormatter);
                MontarInformacoesReservas(boldSubtitleFont, boldDefaultFont, defaultFont, textFormatter, defaultBrush);
                MontarInformacoesSalas(boldSubtitleFont, boldDefaultFont, defaultFont, textFormatter, defaultBrush);
                MontarInformacoesUltimaReserva(boldSubtitleFont, boldDefaultFont, defaultFont, textFormatter, defaultBrush);
                MontarInformacoesUltimaSala(boldSubtitleFont, boldDefaultFont, defaultFont, textFormatter, defaultBrush);

                NomeArquivo = GerarNomeArquivo();

                doc.Save(RetornarCaminhoArquivo());

                VisualizarArquivo(RetornarCaminhoArquivo());
            }
        }

        protected override void SetarInformacoesRelatorio(Dashboard dashboard)
        {
            _ValorArrecadado = dashboard.ValorArrecadado.ToString("C");
            _TotalReservas = dashboard.TotalReservas.ToString();
            _TotalSalas = dashboard.TotalSalas.ToString();
            _SalaMaiorCapacidade = dashboard.SalaMaiorCapacidade.ToString();
            _UltimaReserva = RetornarNomeUltimaReserva(dashboard);
            _UltimaSala = RetornarNomeUltimaSala(dashboard);
        }

        protected override string RetornarCaminhoArquivo()
        {
            return GerarCaminhoArquivo(NomeArquivo);
        }

        protected override string GerarNomeArquivo()
        {
            return string.Concat("RelatorioBym",
                DateTime.Now.Year,
                DateTime.Now.Month,
                DateTime.Now.Day,
                DateTime.Now.Hour,
                DateTime.Now.Minute,
                DateTime.Now.Second,
                DateTime.Now.Millisecond,
                ".pdf"
                );
        }

        protected override string GerarCaminhoArquivo(string nomeArquivo)
        {
            return string.Concat(@"C:\Users\Public\Documents\", nomeArquivo);
        }

        protected override void VisualizarArquivo(string caminhoArquivo)
        {
            Process.Start(caminhoArquivo);
        }
    }
}
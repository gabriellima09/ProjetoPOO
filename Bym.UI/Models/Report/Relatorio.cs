using Bym.UI.Models.Domain;
using PdfSharp.Drawing;
using PdfSharp.Drawing.Layout;
using PdfSharp.Pdf;
using System;
using System.Diagnostics;

namespace Bym.UI.Models.Report
{
    public class Relatorio
    {
        private string _NomeArquivo { get; set; }

        public Relatorio(Dashboard dashboard)
        {
            using (PdfDocument doc = new PdfDocument())
            {
                PdfPage page = doc.AddPage();
                XFont titleFont = new XFont("Arial", 18);
                XBrush defaultBrush = XBrushes.Black;
                XGraphics graphics = XGraphics.FromPdfPage(page);
                XTextFormatter textFormatter = new XTextFormatter(graphics);

                textFormatter.Alignment = XParagraphAlignment.Center;
                textFormatter.DrawString("Relatório - Book Your Meeting", titleFont, defaultBrush, new XRect(30, 60, page.Width - 60, page.Height - 60));
                graphics.DrawLine(XPens.Black, 50, 100, 550, 100);

                _NomeArquivo = GerarNomeArquivo();

                doc.Save(CaminhoArquivo());
                Process.Start(CaminhoArquivo());
            }
        }

        private string CaminhoArquivo()
        {
            return GerarCaminhoArquivo(_NomeArquivo);
        }

        private string GerarCaminhoArquivo(string nomeArquivo)
        {
            return string.Concat(@"C:\Users\Public\Documents\", nomeArquivo);
        }

        private string GerarNomeArquivo()
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
    }
}
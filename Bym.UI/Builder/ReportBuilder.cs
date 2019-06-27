using Bym.UI.Models.Domain;

namespace Bym.UI.Builder
{
    public abstract class ReportBuilder
    {
        protected string NomeArquivo { get; set; }
        
        public abstract void GerarRelatorio();

        protected abstract void SetarInformacoesRelatorio(Dashboard dashboard);
        protected abstract string GerarNomeArquivo();
        protected abstract string GerarCaminhoArquivo(string nomeArquivo);
        protected abstract string RetornarCaminhoArquivo();
        protected abstract void VisualizarArquivo(string caminhoArquivo);
    }
}
using System.IO;
using System.Threading.Tasks;
using TesteTecnico.NetCore.Domain.DTO;
using TesteTecnico.NetCore.Domain.Entities;
using TesteTecnico.NetCore.Domain.Interfaces.Services;

namespace TesteTecnico.NetCore.Domain.Services.Infra
{
    public class HistoricoEscolarPDF : IHistoricoEscolarPDF
    {
            private readonly string _basePath;
            private readonly IHistoricoEscolarDomainService _historicoEscolarDomainService;


            public HistoricoEscolarPDF (IHistoricoEscolarDomainService historicoEscolarDomainService)
            {
                _basePath = Directory.GetCurrentDirectory() + "\\UploadDir\\";
                _historicoEscolarDomainService = historicoEscolarDomainService;
            }

            public async Task<HistoricoEscolar> Salvar(HistoricoEscolarDTO historicoEscolarDTO)
            {
                var NomeHistoricoEscola = GerarRelatorio(historicoEscolarDTO.Nome);

                await _historicoEscolarDomainService.AdicionarHistoricoEscolar(NomeHistoricoEscola);

                return NomeHistoricoEscola;
            }


            public HistoricoEscolar GerarRelatorio(string nomeHistoricoEscola)
            {
                using (var doc = new PdfSharpCore.Pdf.PdfDocument())
                {
                    var page = doc.AddPage();
                    page.Size = PdfSharpCore.PageSize.A4;
                    page.Orientation = PdfSharpCore.PageOrientation.Portrait;
                    var graphics = PdfSharpCore.Drawing.XGraphics.FromPdfPage(page);
                    var corFonte = PdfSharpCore.Drawing.XBrushes.Black;

                    var textFormatter = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
                    var fonteOrganzacao = new PdfSharpCore.Drawing.XFont("Arial", 10);
                    var fonteDescricao = new PdfSharpCore.Drawing.XFont("Arial", 8, PdfSharpCore.Drawing.XFontStyle.BoldItalic);
                    var titulodetalhes = new PdfSharpCore.Drawing.XFont("Arial", 14, PdfSharpCore.Drawing.XFontStyle.Bold);
                    var fonteDetalhesDescricao = new PdfSharpCore.Drawing.XFont("Arial", 7);


                    var qtdPaginas = doc.PageCount;
                    textFormatter.DrawString(qtdPaginas.ToString(), new PdfSharpCore.Drawing.XFont("Arial", 10), corFonte, new PdfSharpCore.Drawing.XRect(578, 825, page.Width, page.Height));


                    // Titulo Exibição
                    textFormatter.DrawString("Nome :", fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(20, 75, page.Width, page.Height));
                    textFormatter.DrawString("Valdir Ferreira ", fonteOrganzacao, corFonte, new PdfSharpCore.Drawing.XRect(80, 75, page.Width, page.Height));

                    textFormatter.DrawString("Profissão :", fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(20, 95, page.Width, page.Height));
                    textFormatter.DrawString("Programador", fonteOrganzacao, corFonte, new PdfSharpCore.Drawing.XRect(80, 95, page.Width, page.Height));

                    textFormatter.DrawString("Tempo :", fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(20, 115, page.Width, page.Height));
                    textFormatter.DrawString("10 anos", fonteOrganzacao, corFonte, new PdfSharpCore.Drawing.XRect(80, 115, page.Width, page.Height));


                    // Titulo maior 
                    var tituloDetalhes = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);
                    tituloDetalhes.Alignment = PdfSharpCore.Drawing.Layout.XParagraphAlignment.Center;
                    tituloDetalhes.DrawString("Detalhes ", titulodetalhes, corFonte, new PdfSharpCore.Drawing.XRect(0, 120, page.Width, page.Height));


                    // titulo das colunas
                    var alturaTituloDetalhesY = 140;
                    var detalhes = new PdfSharpCore.Drawing.Layout.XTextFormatter(graphics);

                    detalhes.DrawString("Descrição", fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(20, alturaTituloDetalhesY, page.Width, page.Height));

                    detalhes.DrawString("Atendimento", fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(144, alturaTituloDetalhesY, page.Width, page.Height));

                    detalhes.DrawString("Operação", fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(220, alturaTituloDetalhesY, page.Width, page.Height));

                    detalhes.DrawString("Quantidade", fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(290, alturaTituloDetalhesY, page.Width, page.Height));

                    detalhes.DrawString("Status", fonteDescricao, corFonte, new PdfSharpCore.Drawing.XRect(337, alturaTituloDetalhesY, page.Width, page.Height));


                    //dados do relatório 
                    var alturaDetalhesItens = 160;
                    for (int i = 1; i < 30; i++)
                    {

                        textFormatter.DrawString("Descrição" + " : " + i.ToString(), fonteDetalhesDescricao, corFonte, new PdfSharpCore.Drawing.XRect(21, alturaDetalhesItens, page.Width, page.Height));
                        textFormatter.DrawString("Atendimento" + " : " + i.ToString(), fonteDetalhesDescricao, corFonte, new PdfSharpCore.Drawing.XRect(145, alturaDetalhesItens, page.Width, page.Height));
                        textFormatter.DrawString("Operação" + " : " + i.ToString(), fonteDetalhesDescricao, corFonte, new PdfSharpCore.Drawing.XRect(215, alturaDetalhesItens, page.Width, page.Height));
                        textFormatter.DrawString("Quantidade" + " : " + i.ToString(), fonteDetalhesDescricao, corFonte, new PdfSharpCore.Drawing.XRect(290, alturaDetalhesItens, page.Width, page.Height));
                        textFormatter.DrawString("Status" + " : " + i.ToString(), fonteDetalhesDescricao, corFonte, new PdfSharpCore.Drawing.XRect(332, alturaDetalhesItens, page.Width, page.Height));

                        alturaDetalhesItens += 20;
                    }

                    var docName = nomeHistoricoEscola;
                    DetalheArquivo detalheArquivo = new DetalheArquivo();
                    detalheArquivo.DocumentName = docName;
                    detalheArquivo.DocType = ".pdf";
                    detalheArquivo.DocUrl = Path.Combine("localhost:44385" + "/api/file/" + detalheArquivo.DocumentName);

                    var destination = Path.Combine(_basePath, "", docName + detalheArquivo.DocType);


                var historicoEscolar = new HistoricoEscolar
                {
                    Nome = docName,
                    Formato = detalheArquivo.DocType.Replace(".","")
                };

                     doc.Save(destination);                   

                    return historicoEscolar;
                }
            }
    
    }
}


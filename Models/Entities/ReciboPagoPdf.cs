using FinancieraConsumo.Web.Models.Entities;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using FinancieraConsumo.Web.Models.Entities;

public class ReciboPagoPdf
{
    public static byte[] Generar(Cuota cuota, int copias)
    {
        var total = cuota.Capital + cuota.Interes + cuota.MoraAcumulada;

        var document = Document.Create(container =>
        {
            for (int i = 0; i < copias; i++)
            {
                container.Page(page =>
                {
                    page.Margin(30);

                    page.Header()
                        .Text("RECIBO DE PAGO")
                        .FontSize(20)
                        .Bold()
                        .AlignCenter();

                    page.Content().Column(col =>
                    {
                        col.Item().Text($"Crédito: #{cuota.IdCredito}");
                        col.Item().Text($"Cuota: #{cuota.NumeroCuota}");
                        col.Item().Text($"Capital: {cuota.Capital:N2}");
                        col.Item().Text($"Interés: {cuota.Interes:N2}");
                        col.Item().Text($"Mora: {cuota.MoraAcumulada:N2}");
                        col.Item().Text($"TOTAL: {total:N2}").Bold();

                        col.Item().Text($"Fecha: {DateTime.Now:dd/MM/yyyy}");
                    });
                });
            }
        });

        return document.GeneratePdf();
    }
}
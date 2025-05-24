using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Rotativa.AspNetCore;
using System.IO;

namespace MyDownloadApp.Controllers
{
    public class DownloadController : Controller
    {
        // Download Excel dengan ClosedXML
        public IActionResult DownloadExcel()
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Sheet1");

            worksheet.Cell(1, 1).Value = "Nama";
            worksheet.Cell(1, 2).Value = "Umur";
            worksheet.Cell(2, 1).Value = "Budi";
            worksheet.Cell(2, 2).Value = 30;
            worksheet.Cell(3, 1).Value = "Sari";
            worksheet.Cell(3, 2).Value = 25;

            using var stream = new MemoryStream();
            workbook.SaveAs(stream);
            stream.Position = 0;

            return File(stream.ToArray(),
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                "Data.xlsx");
        }

        // Download PDF dengan Rotativa, render dari view sederhana
        public IActionResult DownloadPdf()
        {
            return new ViewAsPdf("PdfTemplate")
            {
                FileName = "Data.pdf"
            };
        }
    }
}

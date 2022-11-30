using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using Org.BouncyCastle.Utilities;
using RealEstate.DataAccessLayer.Concrete;
using RealEstate.PresentationLayer.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RealEstate.PresentationLayer.Controllers
{
    [AllowAnonymous]
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult StaticExcelList()
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var workSheet = excelPackage.Workbook.Worksheets.Add("Sayfa1");



            workSheet.Cells[1, 1].Value = "Personel ID";
            workSheet.Cells[1, 2].Value = "Personel Adı";
            workSheet.Cells[1, 3].Value = "Personel Soyadı";
            workSheet.Cells[1, 4].Value = "Personel Şehri";



            workSheet.Cells[2, 1].Value = "0001";
            workSheet.Cells[2, 2].Value = "Ezgi";
            workSheet.Cells[2, 3].Value = "Pektaş";
            workSheet.Cells[2, 4].Value = "Tekirdağ";



            workSheet.Cells[3, 1].Value = "0002";
            workSheet.Cells[3, 2].Value = "Emre";
            workSheet.Cells[3, 3].Value = "Ulusoy";
            workSheet.Cells[3, 4].Value = "Bursa";



            workSheet.Cells[4, 1].Value = "0003";
            workSheet.Cells[4, 2].Value = "Melek";
            workSheet.Cells[4, 3].Value = "Sungur";
            workSheet.Cells[4, 4].Value = "Ankara";


            var bytes = excelPackage.GetAsByteArray(); 
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "akademi.xlsx");
        }

        public List<ProductReportModel> ProductList()
        {

            List<ProductReportModel> reportModels = new List<ProductReportModel>();

            using(var c= new Context())
            {
                reportModels = c.Products.Select(x=> new ProductReportModel
                {
                    ProductDate = x.Date.ToString(),
                    ProductPrice = x.Price,
                    ProductTitle = x.Title
                }).ToList();
            }

            return reportModels;

        }
        public IActionResult ExcelDynamic()
        {
            using(var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("İlan Raporu");
                worksheet.Cell(1, 1).Value = "İlan Başlığı";
                worksheet.Cell(1, 2).Value = "İlan Fiyatı";
                worksheet.Cell(1, 3).Value = "İlan Tarihi";

                var Products = ProductList();

                int rowCount = 2;
                foreach (var item in Products)
                {
                    worksheet.Cell(rowCount, 1).Value = item.ProductTitle;
                    worksheet.Cell(rowCount, 2).Value = item.ProductPrice;
                    worksheet.Cell(rowCount, 3).Value = item.ProductDate;
                    rowCount++;
                }
                using(var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "İlan Raporu.xlsx");
                }
            }
        }

        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" +
                "yenipdf.pdf");
            var stream = new FileStream(path,FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            Paragraph paragraph = new Paragraph("Asp .Net Core Real Estate Projesi");
            document.Add(paragraph);
            document.Close();
            return File("/PdfReports/yenipdf.pdf","application/pdf","yenidosya.pdf");
        }
    }
}

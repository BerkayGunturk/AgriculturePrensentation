using AgriculturePrensentation.Models;
using ClosedXML.Excel;
using DataAccessLayer.Contexts;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AgriculturePrensentation.Controllers
{
    public class ReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //Static report
        public IActionResult StaticReport()
        {
            ExcelPackage excelPackage = new ExcelPackage();
            var workbook = excelPackage.Workbook.Worksheets.Add("Dosya1");

            workbook.Cells[1, 1].Value = "Ürün Adı";
            workbook.Cells[1, 2].Value = "Ürün Kategorisi";
            workbook.Cells[1, 3].Value = "Ürün Stok";

            workbook.Cells[2, 1].Value = "Mercimek";
            workbook.Cells[2, 2].Value = "Bakliyat";
            workbook.Cells[2, 3].Value = "785 kg";

            workbook.Cells[3, 1].Value = "Buğday";
            workbook.Cells[3, 2].Value = "Bakliyat";
            workbook.Cells[3, 3].Value = "1.352 kg";

            workbook.Cells[4, 1].Value = "Havuç";
            workbook.Cells[4, 2].Value = "Sebze";
            workbook.Cells[4, 3].Value = "64 kg";

            var bytes = excelPackage.GetAsByteArray();
            return File(bytes, "application/vdn.openxmlformats-officedocument.spreadsheetml.sheet", "BakliyatRaporu.xlsx");

        }

        //Dynamic message report

        public List<ContactModel> ContactList()
        {
            List<ContactModel> contactModels = new List<ContactModel> ();
            using (var context = new AgricultureContext())
            {
                contactModels = context.Contacts.Select(x => new ContactModel
                {
                    ContactID = x.ContactID,
                    ContactName = x.Name,
                    ContactMail = x.Mail,
                    ContactDate = x.Date,
                    ContactMessage = x.Message


                }).ToList();
            }
            return contactModels;
        }
        public IActionResult ContactReport()
        {
            using(var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Mesaj Listesi");
                workSheet.Cell(1, 1).Value = "Mesaj ID";
                workSheet.Cell(1, 2).Value = "Mesaj Gönderen";
                workSheet.Cell(1, 3).Value = "Mesaj Adresi";
                workSheet.Cell(1, 4).Value = "Mesaj İçeriği";
                workSheet.Cell(1, 5).Value = "Mesaj Tarihi";


                int contactRowCount = 2;
                foreach(var item in ContactList())
                {
                    workSheet.Cell(contactRowCount, 1).Value = item.ContactID;
                    workSheet.Cell(contactRowCount, 2).Value = item.ContactName;
                    workSheet.Cell(contactRowCount, 3).Value = item.ContactMail;
                    workSheet.Cell(contactRowCount, 4).Value = item.ContactMessage;
                    workSheet.Cell(contactRowCount, 5).Value = item.ContactDate;
                    contactRowCount++;

                }
                using(var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    
                    var content = stream.ToArray();

                    return File(content, "application/vdn.openxmlformats-officedocument.spreadsheetml.sheet", "MesajRapor.xlsx");
                }

            }


            
        }


        //Dynamic Announcement report
        public List<AnnouncementModel> AnnouncementList()
        {
            List<AnnouncementModel> announcementModels = new List<AnnouncementModel>();
            using (var context = new AgricultureContext())
            {
                announcementModels = context.Announcements.Select(x => new AnnouncementModel
                {
                    Id = x.AnnouncementID,
                    Description = x.Description,
                    Date = x.Date,
                    Title = x.Title


                }).ToList();
            }
            return announcementModels;
        }
        public IActionResult AnnouncementReport()
        {
            using (var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Mesaj Listesi");
                workSheet.Cell(1, 1).Value = "Duyuru ID";
                workSheet.Cell(1, 2).Value = "Duyuru Başlığı";
                workSheet.Cell(1, 3).Value = "Duyuru Tarihi";
                workSheet.Cell(1, 4).Value = "Duyuru İçeriği";
                

                int announcementRowCount = 2;
                foreach (var item in AnnouncementList())
                {
                    workSheet.Cell(announcementRowCount, 1).Value = item.Id;
                    workSheet.Cell(announcementRowCount, 2).Value = item.Title;
                    workSheet.Cell(announcementRowCount, 3).Value = item.Date;
                    workSheet.Cell(announcementRowCount, 4).Value = item.Description;
                    announcementRowCount++;

                }
                using (var stream = new MemoryStream())
                {
                    workBook.SaveAs(stream);

                    var content = stream.ToArray();

                    return File(content, "application/vdn.openxmlformats-officedocument.spreadsheetml.sheet", "DuyuruRapor.xlsx");
                }

            }



        }
    }
}

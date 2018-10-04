using Bogus;
using ExcelDataReader;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        [HttpGet]
        public ActionResult GetExcel()
        {
            using (var excel = new ExcelPackage())
            {
                var wks = excel.Workbook.Worksheets.Add("Products");
                wks.Cells[1, 1].LoadFromCollection(FillExcel(), PrintHeaders: false);
                return File(excel.GetAsByteArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "products.xlsx");
            }
        }
        public List<ProductModel> FillExcel()
        {
            List<ProductModel> products = new List<ProductModel>();
            var faker = new Faker("ru");
                for (int i = 0; i < 400000; i++)
                {
                 
                 products.Add(new ProductModel {ProductName= faker.Commerce.Product(),Color=faker.Commerce.Color(),CompanyName=faker.Company.CompanyName(),OwnerName=faker.Name.FirstName(), OwnerSurname=faker.Name.LastName(), Country = faker.Address.Country(),City=faker.Address.City(), Price = float.Parse(faker.Commerce.Price(10, 500)) });
                }
            return products;
        }
        [HttpPost]
        public ActionResult FillTable(HttpPostedFileBase postedFile)
        {
            string filePath = string.Empty;
            if (postedFile != null)
            {
               
                string conString = string.Empty;
            
                DataTable dt = new DataTable();
                using (var reader = ExcelReaderFactory.CreateReader(postedFile.InputStream))
                {
                    dt = reader.AsDataSet().Tables[0];                   
                }
              
                conString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=WebApplication1.Model;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
               
                    using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(conString))
                    {
                        
                     
                    sqlBulkCopy.ColumnMappings.Add(0, 1);
                    sqlBulkCopy.ColumnMappings.Add(1, 2);
                    sqlBulkCopy.ColumnMappings.Add(2, 3);
                    sqlBulkCopy.ColumnMappings.Add(3, 4);
                    sqlBulkCopy.ColumnMappings.Add(4, 5);
                    sqlBulkCopy.ColumnMappings.Add(5,6);
                    sqlBulkCopy.ColumnMappings.Add(6, 7);
                    sqlBulkCopy.ColumnMappings.Add(7, 8);
                    sqlBulkCopy.DestinationTableName = "dbo.tblProducts";
                     
                        sqlBulkCopy.WriteToServer(dt);
                      
                    }
           
            }
            return View();

        }
    }
}
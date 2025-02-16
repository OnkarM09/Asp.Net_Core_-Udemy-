/*using _15._EntityFramerworkCore.Models;
using OfficeOpenXml;

namespace _15._EntityFramerworkCore.Services
{
    public class PersonsGetterServiceWithFiewExcelFields : IPersonGetterService
    {
        private readonly PersonsDbContext _db;
        private readonly IPersonGetterService _personsGetservice;
        public PersonsGetterServiceWithFiewExcelFields(PersonsDbContext db, IPersonGetterService personsGetservice)
        {
            _db = db;
            _personsGetservice = personsGetservice;
        }
        public async Task<MemoryStream> GerPersonCSV()
        {
            return await _personsGetservice.GerPersonCSV();
        }

        public async Task<MemoryStream> GerPersonExcel()
        {
            MemoryStream memoryStream = new MemoryStream();
            using (ExcelPackage excelPackage = new ExcelPackage(memoryStream))
            {

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("PersonsSheet");
                worksheet.Cells["A1"].Value = "Person Name";
                worksheet.Cells["B1"].Value = "Person Email";

                using (ExcelRange headerCells = worksheet.Cells["A1:B1"])
                {
                    headerCells.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    headerCells.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    headerCells.Style.Font.Bold = true;
                }

                int row = 2;
                List<Person> persons = _db.Persons.ToList();

                foreach (Person person in persons)
                {
                    worksheet.Cells[row, 1].Value = person.Name;
                    worksheet.Cells[row, 2].Value = person.Email;
                    row++;
                }

                worksheet.Cells[$"A1:B{row}"].AutoFitColumns();
                await excelPackage.SaveAsync();
            }
            memoryStream.Position = 0;
            return memoryStream;
        }

        public async Task<Person> GetPersonById(int id)
        {
           return await _personsGetservice.GetPersonById(id);
        }

        public async Task<List<Person>> GetPersons()
        {
           return await _personsGetservice.GetPersons();
        }
    }
}
*/
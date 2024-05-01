using _15._EntityFramerworkCore.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using OfficeOpenXml;

namespace _15._EntityFramerworkCore.Services
{
    public class PersonService : IPersonService
    {
        private readonly PersonsDbContext _db;

        public PersonService(PersonsDbContext personsDbContext)
        {
            _db = personsDbContext;
        }
        public async Task<List<Person>> GetPersons()
        {
            //SELECT * FROM Persons
            var persons = _db.Persons.Include("JobDetails").ToList();
            return await _db.Persons.ToListAsync();
            //  return _db._spGetAllPersons();   //Calling SP from PersonDbContext
        }

        public async Task<Person?> GetPersonById(int id)
        {
            Person? person = await _db.Persons.Where(person => person.Id == id).FirstOrDefaultAsync();
            return person;
        }
        public async Task AddPersonToDb(Person person)
        {
            _db.Persons.Add(person);
            await _db.SaveChangesAsync();
            //_db.sp_InsertPerson(person);  from stored procedure
        }

        public async Task<MemoryStream> GerPersonCSV()
        {
            MemoryStream memoryStream = new MemoryStream();
            StreamWriter streamWriter = new StreamWriter(memoryStream);

            CsvConfiguration csvConfiguration = new CsvConfiguration(CultureInfo.InvariantCulture);

            //CsvWriter csvWriter = new CsvWriter(streamWriter, CultureInfo.InvariantCulture, leaveOpen: true);
            CsvWriter csvWriter = new CsvWriter(streamWriter, csvConfiguration);

            //csvWriter.WriteHeader<Person>();

            csvWriter.WriteField(nameof(Person.Name));
            csvWriter.WriteField(nameof(Person.Email));
            csvWriter.WriteField(nameof(Person.BirthDate));
            csvWriter.WriteField(nameof(Person.Age));
            csvWriter.NextRecord();

            List<Person> persons = _db.Persons.Include("JobDetails").ToList();
          

            foreach(Person person in persons)
            {
                csvWriter.WriteField(person.Name);
                csvWriter.WriteField(person.Email);
                csvWriter.WriteField(person.BirthDate.ToString("dd/MMM/yyyy").Replace("-", "/"));
                csvWriter.WriteField(person.Age);
                csvWriter.NextRecord();
                csvWriter.Flush();
            }
          //  await csvWriter.WriteRecordsAsync(persons);
            memoryStream.Position = 0;
            return memoryStream;
        }

        public async Task<MemoryStream> GerPersonExcel()
        {
            MemoryStream memoryStream = new MemoryStream();
            using(ExcelPackage excelPackage = new ExcelPackage(memoryStream)) {

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("PersonsSheet");
                worksheet.Cells["A1"].Value = "Person Name";
                worksheet.Cells["B1"].Value = "Person Email";
                worksheet.Cells["C1"].Value = "Person Job Title";
                worksheet.Cells["D1"].Value = "Person Age";

                using (ExcelRange headerCells = worksheet.Cells["A1:D1"])
                {
                    headerCells.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    headerCells.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.LightGray);
                    headerCells.Style.Font.Bold = true;
                }

                    int row = 2;
                List<Person> persons = _db.Persons.ToList();

                foreach(Person person in persons) {
                    worksheet.Cells[row, 1].Value = person.Name;
                    worksheet.Cells[row, 2].Value = person.Email;
                    worksheet.Cells[row, 3].Value = person.JobTitle;
                    worksheet.Cells[row, 4].Value = person.Age;
                    row++;
                }

                worksheet.Cells[$"A1:D{row}"].AutoFitColumns();
                await excelPackage.SaveAsync();
            }
            memoryStream.Position = 0;
            return memoryStream;
        }
    }
}

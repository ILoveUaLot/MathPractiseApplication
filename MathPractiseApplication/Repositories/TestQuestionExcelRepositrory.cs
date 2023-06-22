using MathPractiseApplication.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MathPractiseApplication.Repositories
{
    public class TestQuestionExcelRepositrory
    {
        //ExcelPackage testQuestionPackage;
        //string filePath = "Data/TestQuestions.xmlx";

        //public TestQuestionExcelRepositrory()
        //{
        //    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        //    if (File.Exists(filePath))
        //    {
        //        testQuestionPackage = new ExcelPackage(new FileInfo(filePath));
        //    }
        //    else
        //    {
        //        testQuestionPackage = new ExcelPackage();
        //        var worksheetTest = testQuestionPackage.Workbook.Worksheets.Add("TestQuestions");
        //        worksheetTest.Cells[1, 1].Value = "Id";
        //        worksheetTest.Cells[1, 2].Value = "Question";
        //        worksheetTest.Cells[1, 3].Value = "Answer";
        //        worksheetTest.Cells[1, 4].Value = "RightAnswer";
        //        testQuestionPackage.SaveAs(new FileInfo(filePath));
        //    }
        //}
        //public void Add(TestModel test)
        //{
        //    var worksheetTest = testQuestionPackage.Workbook.Worksheets["TestQuestions"];
        //    int lastUsedRow = worksheetTest.Dimension.End.Row;
        //    worksheetTest.Cells[lastUsedRow + 1, 1].Value = lastUsedRow;
        //    worksheetTest.Cells[lastUsedRow + 1, 2].Value = test.Question;
        //    worksheetTest.Cells[lastUsedRow + 1, 3].Value = test.Answers[0];
        //    worksheetTest.Cells[lastUsedRow + 2, 3].Value = test.Answers[1];
        //    worksheetTest.Cells[lastUsedRow + 3, 3].Value = test.Answers[2];
        //    worksheetTest.Cells[lastUsedRow + 4, 3].Value = test.Answers[3];
        //    worksheetTest.Cells[lastUsedRow + 1, 4].Value = test.RightAnswer;
        //    testQuestionPackage.SaveAs(new FileInfo(filePath));
        //}

        //public void Edit(TestModel question)
        //{
        //    using (var package = new ExcelPackage(new FileInfo(filePath)))
        //    {
        //        var worksheetTest = package.Workbook.Worksheets["TestQuestions"];
        //        int totalRows = worksheetTest.Dimension.End.Row;

        //        for (int row = 2; row <= totalRows; row++)
        //        {
        //            int id = Convert.ToInt32(worksheetTest.Cells[row, 1].Value);
        //            if (id == question.Id)
        //            {
        //                worksheetTest.Cells[row, 2].Value = question.Question;
        //                worksheetTest.Cells[row, 3].Value = question.Answers;
        //                worksheetTest.Cells[row, 4].Value = question.RightAnswer;
        //                break;
        //            }
        //        }
        //        package.Save();
        //    }
        //}

        //public List<TestModel> GetQuestions()
        //{
        //    using (var package = new ExcelPackage(new FileInfo(filePath)))
        //    {
        //        var worksheetTest = package.Workbook.Worksheets["TestQuestions"];
        //        int totalRows = worksheetTest.Dimension.End.Row;

        //        for (int row = 2; row <= totalRows; row++)
        //        {
        //            string question = worksheetTest.Cells[row, 2].Value.ToString();
        //            string answers[4] = 
        //            if (question == username)
        //            {
        //                int id = Convert.ToInt32(worksheetUsers.Cells[row, 1].Value);
        //                string password = worksheetUsers.Cells[row, 3].Value.ToString();
        //                return new User { Id = id, Name = name, Password = password };
        //            }
        //        }
        //    }
        //    return null;
        //}

        //public void Remove(int id)
        //{
        //    using (var package = new ExcelPackage(new FileInfo(filePath)))
        //    {
        //        var worksheetTest = package.Workbook.Worksheets["TestQuestions"];
        //        int totalRows = worksheetTest.Dimension.End.Row;

        //        for (int row = 2; row <= totalRows; row++)
        //        {
        //            int questionId = Convert.ToInt32(worksheetTest.Cells[row, 1].Value);
        //            if (questionId == id)
        //            {
        //                worksheetTest.DeleteRow(row);
        //                break;
        //            }
        //        }
        //        package.Save();
        //    }
        //}
    }
}

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
    public class TestQuestionExcelRepository : ITestQuestionsRepository
    {
        private ExcelPackage testQuestionPackage;
        private string filePath = "Data/TestQuestions.xlsx";

        public TestQuestionExcelRepository()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            if (File.Exists(filePath))
            {
                testQuestionPackage = new ExcelPackage(new FileInfo(filePath));
            }
            else
            {
                testQuestionPackage = new ExcelPackage();
                var worksheetTest = testQuestionPackage.Workbook.Worksheets.Add("TestQuestions");
                worksheetTest.Cells[1, 1].Value = "Id";
                worksheetTest.Cells[1, 2].Value = "Question";
                worksheetTest.Cells[1, 3].Value = "Answer1";
                worksheetTest.Cells[1, 4].Value = "Answer2";
                worksheetTest.Cells[1, 5].Value = "Answer3";
                worksheetTest.Cells[1, 6].Value = "Answer4";
                worksheetTest.Cells[1, 7].Value = "RightAnswer";
                testQuestionPackage.SaveAs(new FileInfo(filePath));
            }
        }

        public void Add(TestModel test)
        {
            var worksheetTest = testQuestionPackage.Workbook.Worksheets["TestQuestions"];
            int lastUsedRow = worksheetTest.Dimension.End.Row;
            worksheetTest.Cells[lastUsedRow + 1, 1].Value = lastUsedRow;
            worksheetTest.Cells[lastUsedRow + 1, 2].Value = test.Question;
            worksheetTest.Cells[lastUsedRow + 1, 3].Value = test.Answers[0];
            worksheetTest.Cells[lastUsedRow + 1, 4].Value = test.Answers[1];
            worksheetTest.Cells[lastUsedRow + 1, 5].Value = test.Answers[2];
            worksheetTest.Cells[lastUsedRow + 1, 6].Value = test.Answers[3];
            worksheetTest.Cells[lastUsedRow + 1, 7].Value = test.RightAnswer;
            testQuestionPackage.SaveAs(new FileInfo(filePath));
        }

        public void Edit(TestModel test)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheetTest = package.Workbook.Worksheets["TestQuestions"];
                int totalRows = worksheetTest.Dimension.End.Row;

                for (int row = 2; row <= totalRows; row++)
                {
                    int id = Convert.ToInt32(worksheetTest.Cells[row, 1].Value);
                    if (id == test.Id)
                    {
                        worksheetTest.Cells[row, 2].Value = test.Question;
                        worksheetTest.Cells[row, 3].Value = test.Answers[0];
                        worksheetTest.Cells[row, 4].Value = test.Answers[1];
                        worksheetTest.Cells[row, 5].Value = test.Answers[2];
                        worksheetTest.Cells[row, 6].Value = test.Answers[3];
                        worksheetTest.Cells[row, 7].Value = test.RightAnswer;
                        break;
                    }
                }
                package.Save();
            }
        }

        public List<TestModel> GetQuestions()
        {
            var questions = new List<TestModel>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheetTest = package.Workbook.Worksheets["TestQuestions"];
                int totalRows = worksheetTest.Dimension.End.Row;

                for (int row = 2; row <= totalRows; row++)
                {
                    string question = worksheetTest.Cells[row, 2].Value.ToString();
                    List<string> answers = new List<string>
                {
                    worksheetTest.Cells[row, 3].Value.ToString(),
                    worksheetTest.Cells[row, 4].Value.ToString(),
                    worksheetTest.Cells[row, 5].Value.ToString(),
                    worksheetTest.Cells[row, 6].Value.ToString()
                };
                    int rightAnswer = Convert.ToInt32(worksheetTest.Cells[row, 7].Value);

                    TestModel test = new TestModel
                    {
                        Id = row - 1,
                        Question = question,
                        Answers = answers,
                        RightAnswer = rightAnswer
                    };

                    questions.Add(test);
                }
            }

            return questions;
        }

        public void Remove(int id)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheetTest = package.Workbook.Worksheets["TestQuestions"];
                int totalRows = worksheetTest.Dimension.End.Row;

                for (int row = 2; row <= totalRows; row++)
                {
                    int questionId = Convert.ToInt32(worksheetTest.Cells[row, 1].Value);
                    if (questionId == id)
                    {
                        worksheetTest.DeleteRow(row);
                        break;
                    }
                }
                package.Save();
            }
        }
    }
}

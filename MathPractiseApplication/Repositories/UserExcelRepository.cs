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
    public class UserExcelRepository : IUserRepository
    {
        ExcelPackage userPackage;
        string filePath = "Data/Users.xlsx";

        public UserExcelRepository()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            if (File.Exists(filePath))
            {
                userPackage = new ExcelPackage(new FileInfo(filePath));
            }
            else
            {
                userPackage = new ExcelPackage();
                var worksheetUsers = userPackage.Workbook.Worksheets.Add("Users");
                worksheetUsers.Cells[1, 1].Value = "Id";
                worksheetUsers.Cells[1, 2].Value = "Name";
                worksheetUsers.Cells[1, 3].Value = "Password";
                worksheetUsers.Cells[1, 4].Value = "CompletedExercises";  // new column for completed exercises
                worksheetUsers.Cells[1, 5].Value = "TestResults";  // new column for test results
                userPackage.SaveAs(new FileInfo(filePath));
            }
        }

        public void Add(User user)
        {
            var worksheetUsers = userPackage.Workbook.Worksheets["Users"];
            int lastUsedRow = worksheetUsers.Dimension.End.Row;
            worksheetUsers.Cells[lastUsedRow + 1, 1].Value = lastUsedRow;
            worksheetUsers.Cells[lastUsedRow + 1, 2].Value = user.Name;
            worksheetUsers.Cells[lastUsedRow + 1, 3].Value = user.Password;
            worksheetUsers.Cells[lastUsedRow + 1, 4].Value = user.CompletedExercises;  // save completed exercises
            worksheetUsers.Cells[lastUsedRow + 1, 5].Value = user.TestResults;  // save test results
            userPackage.SaveAs(new FileInfo(filePath));
        }

        public User UserGetById(int id)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheetUsers = package.Workbook.Worksheets["Users"];
                int totalRows = worksheetUsers.Dimension.End.Row;

                for (int row = 2; row <= totalRows; row++)
                {
                    int userId = Convert.ToInt32(worksheetUsers.Cells[row, 1].Value);
                    if (userId == id)
                    {
                        string name = worksheetUsers.Cells[row, 2].Value.ToString();
                        string password = worksheetUsers.Cells[row, 3].Value.ToString();
                        int completedExercises = Convert.ToInt32(worksheetUsers.Cells[row, 4].Value); // load completed exercises
                        string testResults = worksheetUsers.Cells[row, 5].Value.ToString();  // load test results
                        return new User
                        {
                            Id = userId,
                            Name = name,
                            Password = password,
                            CompletedExercises = completedExercises,
                            TestResults = testResults
                        };
                    }
                }
            }
            return null;
        }

        public bool AuthenticateUser(NetworkCredential credential)
        {
            bool validUser = false;
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheetUsers = package.Workbook.Worksheets["Users"];
                int totalRows = worksheetUsers.Dimension.End.Row;

                for (int row = 2; row <= totalRows; row++)
                {
                    string name = worksheetUsers.Cells[row, 2].Value.ToString();
                    string password = worksheetUsers.Cells[row, 3].Value.ToString();

                    if (name == credential.UserName && password == credential.Password)
                    {
                        validUser = true;
                        break;
                    }
                }
            }
            return validUser;
        }

        public void Edit(User user)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheetUsers = package.Workbook.Worksheets["Users"];
                int totalRows = worksheetUsers.Dimension.End.Row;

                for (int row = 2; row <= totalRows; row++)
                {
                    int id = Convert.ToInt32(worksheetUsers.Cells[row, 1].Value);
                    if (id == user.Id)
                    {
                        worksheetUsers.Cells[row, 2].Value = user.Name;
                        worksheetUsers.Cells[row, 3].Value = user.Password;
                        worksheetUsers.Cells[row, 4].Value = user.CompletedExercises;
                        worksheetUsers.Cells[row, 5].Value = user.TestResults;
                        break;
                    }
                }
                package.Save();
            }
        }

        public void Remove(int id)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheetUsers = package.Workbook.Worksheets["Users"];
                int totalRows = worksheetUsers.Dimension.End.Row;

                for (int row = 2; row <= totalRows; row++)
                {
                    int userId = Convert.ToInt32(worksheetUsers.Cells[row, 1].Value);
                    if (userId == id)
                    {
                        worksheetUsers.DeleteRow(row);
                        break;
                    }
                }
                package.Save();
            }
        }

        public User UserGetByName(string username)
        {
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheetUsers = package.Workbook.Worksheets["Users"];
                int totalRows = worksheetUsers.Dimension.End.Row;

                for (int row = 2; row <= totalRows; row++)
                {
                    string name = worksheetUsers.Cells[row, 2].Value.ToString();
                    if (name == username)
                    {
                        int id = Convert.ToInt32(worksheetUsers.Cells[row, 1].Value);
                        string password = worksheetUsers.Cells[row, 3].Value.ToString();
                        int exersizeStat = int.Parse(worksheetUsers.Cells[row,4].Value.ToString());
                        string testStat = 
                        return new User { Id = id, Name = name, Password = password, CompletedExercises = exersizeStat,};
                    }
                }
            }
            return null;
        }

        public List<User> GetAllUsers()
        {
            var users = new List<User>();

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheetUsers = package.Workbook.Worksheets["Users"];
                int totalRows = worksheetUsers.Dimension.End.Row;

                for (int row = 2; row <= totalRows; row++)
                {
                    int id = Convert.ToInt32(worksheetUsers.Cells[row, 1].Value);
                    string name = worksheetUsers.Cells[row, 2].Value.ToString();
                    string password = worksheetUsers.Cells[row, 3].Value.ToString();
                    int practiceTasksCount = Convert.ToInt32(worksheetUsers.Cells[row, 4].Value);
                    string testScore = worksheetUsers.Cells[row, 5].Value.ToString();

                    var user = new User
                    {
                        Id = id,
                        Name = name,
                        Password = password,
                        CompletedExercises = practiceTasksCount,
                        TestResults = testScore
                    };

                    users.Add(user);
                }
            }

            return users;
        }
    }
}

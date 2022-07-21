using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class EmployeeData : IEmployeeData
    {
        private readonly ISqlAccess _db;

        public EmployeeData(ISqlAccess db)
        {
            _db = db;
        }
        public Task<List<EmployeeModel>> GetEmployee()
        {
            string sql = "select * from dbo.Employee";
            return _db.LoadData<EmployeeModel, dynamic>(sql, new { });
        }
        public Task InsertEmployee(EmployeeModel employee)
        {
            string sql = @"insert into dbo.Employee(FirstName,LastName,Gender,Department,MiddleName,Number,EmailAddress)
                                values (@FirstName,@LastName,@Gender,@Department,@MiddleName,@Number,@EmailAddress);";

            return _db.SaveData(sql, employee);
        }


    }
}

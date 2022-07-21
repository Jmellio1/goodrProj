using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary.Models
{
 public  class EmployeeModel
    {
        //Blazor_12_16_2021Context
        public int ID { get; set; }
    
        public string FirstName { get; set; }
      
        public string LastName { get; set; }
      
        public string Gender { get; set; }
       
        public string Department { get; set; }
        public string MiddleName { get; set; }
       
        public string Number { get; set; }
        public string EmailAddress { get; set; }
    }
}

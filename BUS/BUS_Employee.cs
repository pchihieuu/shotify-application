using DAL;
using DTO;
using System;
using System.Data;
using System.Security.Cryptography;
using System.Text;

namespace BUS
{
    public class BUS_Employee
    {
        DAL_Employee dalEmployee = new DAL_Employee();

        private string Encrytion(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);
                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public bool Login(string email, string password)
        {
            
            password = Encrytion(password);
            return dalEmployee.Login(email, password);
        }

        public bool IsExistEmail(string email)
        {
            return dalEmployee.IsExistEmail(email);
        }

        public bool UpdatePassword(string email, string password)
        {
            password = Encrytion(password);
            return dalEmployee.UpdatePassword(email, password);
        }

        public bool GetEmployeeRole(string email)
        {
            return dalEmployee.GetEmployeeRole(email);
        }

        public bool ChangePassword(string email, string oldPassword, string newPassword)
        {
            oldPassword = Encrytion(oldPassword);
            newPassword = Encrytion(newPassword);
            return dalEmployee.ChangePassword(email, oldPassword, newPassword);
        }

        public DataTable ListOfEmployees()
        {
            return dalEmployee.ListOfEmployees();
        }

        public bool InsertEmployee(DTO_Employee employee)
        {
            employee.Password = Encrytion(employee.Password);
            return dalEmployee.InsertEmployee(employee);
        }

        public bool UpdateEmployee(DTO_Employee employee)
        {
            return dalEmployee.UpdateEmployee(employee);
        }

        public bool UpdateEmployeeAddressPhoneNumber(DTO_Employee employee)
        {
            return dalEmployee.UpdateEmployeeAddressPhoneNumber(employee);
        }

        public bool DeleteEmployee(int id)
        {
            return dalEmployee.DeleteEmployee(id);
        }

        public DataTable SearchEmployee(string name)
        {
            return dalEmployee.SearchEmployee(name);
        }

        public string GetEmployeeIdName(string email)
        {
            return dalEmployee.GetEmployeeIdName(email);
        }

        public string GetEmployeeAddressPhoneNumber(string email)
        {
            return dalEmployee.GetEmployeeAddressPhoneNumber(email);
        }

        public string GetRandomPassword()
        {
            Random r = new Random();
            StringBuilder builder = new StringBuilder();
            builder.Append(RandomString(4, true));
            builder.Append(r.Next(1000, 9999));
            builder.Append(RandomString(2, false));
            return builder.ToString();
        }

        private string RandomString(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random r = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * r.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
            {
                return builder.ToString().ToUpper();
            }
            else return builder.ToString().ToLower();
        }
    }
}

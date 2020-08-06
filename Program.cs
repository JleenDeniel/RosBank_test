using System;
using System.Collections.Generic;
using System.Text;

namespace Rosbank_test {
    class Program {
        static void Main(string[] args){
            Department It = new Department(1, "It department");
            Department Bookkeeping = new Department(2, "Bookkeeping department");
            
            Employee empIt1 = new Employee(1, 0, "Ivanov Ivan", It);
            Employee empIt2 = new Employee(2, 1, "Petrov Petr", It);
            Employee empIt3 = new Employee(3, 1, "Sidirov Sidr", It);
            
            It.AddEmployee(empIt1);
            It.AddEmployee(empIt2);
            It.AddEmployee(empIt3);
            
            Employee empBK1 = new Employee(4, 0, "Ivanka Trump", Bookkeeping);
            Employee empBK2 = new Employee(5, 4, "Angela Merkel", Bookkeeping);
            Employee empBK3 = new Employee(6, 4, "Tatiana Putina", Bookkeeping);
            
            Bookkeeping.AddEmployee(empBK1);
            Bookkeeping.AddEmployee(empBK2);
            Bookkeeping.AddEmployee(empBK3);
            
            
            foreach (var employee in It.GetEmployeeList()) {
                Console.WriteLine(employee);
            }
            foreach (var employee in Bookkeeping.GetEmployeeList()) {
                Console.WriteLine(employee);
            }
            
        }
    }
    
    public class Department
    {
        private int DepId;
        private string DepName;
        private List<Employee> Employees = new List<Employee>();
        public Department(int id, string name){
            DepId = id;
            DepName = name;
        }

        public void AddEmployee(Employee newbie){
            Employees.Add(newbie);
        }

        public List<Employee> GetEmployeeList(){
            return Employees;
        }

        public override string ToString(){
            return DepName;
        }
    }
    public class Employee
    {
        private int UserID;
        private int ManagerId;
        private string FIO;
        private Department UserDepartment;

        public int GetUserId(){
            return UserID;
        }
        
        public Employee(){}
        
        public Employee(int id, int manId, string name, Department department){
            UserID = id;
            ManagerId = manId;
            FIO = name;
            UserDepartment = department;
        }

        public Employee GetManager(){
            var result = new Employee();
            foreach (var employee in UserDepartment.GetEmployeeList()) {
                if (employee.GetUserId() == ManagerId) {
                    result = employee;
                }
                
            }

            return result;
        }

        public override string ToString(){
            StringBuilder result = new StringBuilder();
            if (ManagerId == 0) {
                result.Append(UserDepartment).Append("-").Append(FIO).Append("-")
                    .Append("Сотрудник - начальник отдела");
            }
            else {
                result.Append(UserDepartment).Append("-").Append(FIO).Append("-")
                    .Append(GetManager().FIO);
            }

            return result.ToString();
        }
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul11
{
    public struct Employee
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public int Salary { get; set; }
        public DateTime DateOfRecruit { get; set; }
        public Positions Position { get; set; }

        public void ShowInfo() //Так как это не класс, думаю разрешено использовать подобные методы внутри структур. По крайней мере, в Метаните именно так. 
        {
            Console.WriteLine($"ФИО сотрудника: {FirstName} {LastName}\n" +
                $"Возраст: {Age}\n" +
                $"Должность: {Position}\n" +
                $"Зарплата: {Salary}\n" +
                $"Дата приема на работу: {DateOfRecruit}\n\n");
        }

        public double AverageSalaryOfClerc(Employee[] employees)
        {
            int total = 0;
            int countOfClerc = 0;
            foreach(var employee in employees)
            {
                if(employee.Position == Positions.Clerk)
                {
                    total += employee.Salary;
                    countOfClerc++;
                }
            }
            return total / countOfClerc;
        }
    }
}

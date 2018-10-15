using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul11
{
    public struct Employee
    {
        public string firstName;
        public string lastName;
        public int age;
        public int salary;
        public DateTime dateOfRecruit;
        public Positions position;

        public void ShowInfo() //Так как это не класс, думаю разрешено использовать подобные методы внутри структур. По крайней мере, в Метаните именно так. 
        {
            Console.WriteLine($"ФИО сотрудника: {firstName} {lastName}\n" +
                $"Возраст: {age}\n" +
                $"Должность: {position}\n" +
                $"Зарплата: {salary}\n" +
                $"Дата приема на работу: {dateOfRecruit}\n\n");
        }

        public double AverageSalaryOfClerc(Employee[] employees)
        {
            int total = 0;
            int countOfClerc = 0;
            foreach(var employee in employees)
            {
                if(employee.position == Positions.Clerk)
                {
                    total += employee.salary;
                    countOfClerc++;
                }
            }
            return total / countOfClerc;
        }

       

    }
}

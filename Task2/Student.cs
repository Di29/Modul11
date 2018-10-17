using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public struct Student
    { 
        const double MIN_POINT = 2.0;
        const double MAX_POINT = 5.0;
        const int MIN = 2;
        const int MAX = 10;
        const int MINIMAL_PER_CAPITA_INCOME = 45000;
        const int MAXIMAL_PER_CAPITA_INCOME = 60000;

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string LastName { get; set; }

        public string Group { get; set; }

        public double AveragePoint { get; set; }

        public int MembersOfFamily { get; set; }

        public double PerCapitaIncome { get; set; }

        public Gender Gender { get; set; }

        public FormOfStudy FormOfStudy { get; set; }

        public double GenerateAveragePoint()
        {
            return new Random().NextDouble() * (MAX_POINT - MIN_POINT) + MIN_POINT;
        }

        public int GenerateMembersOfFamily()
        {
            return new Random().Next(MIN, MAX);
        }

        public int GeneratePerCapitaIncome()
        {
            return new Random().Next(MINIMAL_PER_CAPITA_INCOME, MAXIMAL_PER_CAPITA_INCOME);
        }

        public void ShowInfo()  
        {
            double average = AveragePoint;
            string format = string.Format("{0:F1}", average);
            Console.WriteLine($"ФИО студента: {FirstName} {LastName} {MiddleName}\n" +
                $"Пол: {Gender}\n" +
                $"Форма обучения: {FormOfStudy}\n" +
                $"Группа: {Group}\n" +
                $"Средний балл: {format}\n" +
                $"Доход на члена семьи: {PerCapitaIncome}\n" +
                $"Количество членов семьи: {MembersOfFamily}\n");
                
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            const int MINIMAL_SALARY = 28284;
            const int REQUIRED_MINIMAL_SALARY = 2 * MINIMAL_SALARY;

            int count = 0;
            int input = 0;
            int countMember = 0;
            int perCapitaIncome = 0;
            double average = 0;
            bool success = false;

            while (!success)
            {
                Console.WriteLine("Введите количество студентов: ");
                string countText = Console.ReadLine();
                if (!int.TryParse(countText, out count))
                {
                    Console.WriteLine("Не корректный ввод!");
                }
                else
                {
                    Console.WriteLine($"Количество студентов равна: {count}");
                    Student[] students = new Student[count + 1];
                    Student student = new Student();

                    for (int i = 1; i < students.Length; i++)
                    {
                        Console.WriteLine($"\nВведите имя {i} студента: ");
                        students[i].LastName = Console.ReadLine();

                        Console.WriteLine($"Введите фамилию {i} студента: ");
                        students[i].FirstName = Console.ReadLine();

                        Console.WriteLine($"Введите отчество {i} студента: ");
                        students[i].MiddleName = Console.ReadLine();

                        Console.WriteLine($"Введите пол {i} студента: ");
                        Console.WriteLine("1. Мужской\n2. Женский");
                        string inputText = Console.ReadLine();
                        if(int.TryParse(inputText, out input))
                        {
                            switch (input)
                            {
                                case 1:
                                    students[i].Gender = Gender.Boy;
                                    break;
                                case 2:
                                    students[i].Gender = Gender.Girl;
                                    break;
                            }
                        }

                        Console.WriteLine($"Введите форму обучения {i} студента: ");
                        Console.WriteLine("1. Очное\n2. Заочное\n3. Дистанционное");
                        string inputText2 = Console.ReadLine();
                        if(int.TryParse(inputText2, out input))
                        {
                            switch (input)
                            {
                                case 1:
                                    students[i].FormOfStudy = FormOfStudy.FullTime;
                                    break;
                                case 2:
                                    students[2].FormOfStudy = FormOfStudy.Correspondence;
                                    break;
                                case 3:
                                    students[i].FormOfStudy = FormOfStudy.Remote;
                                    break;
                            }
                        }
                                
                        Console.WriteLine($"Введите группу {i} студента: ");
                        students[i].Group = Console.ReadLine();

                        Console.WriteLine($"Введите средний балл {i} студента: ");
                        string averageInput = Console.ReadLine();
                        if(double.TryParse(averageInput, out average))
                        {
                            students[i].AveragePoint = average;
                        }
                        else
                        {
                            double temp = student.GenerateAveragePoint();
                            string tempFormat = string.Format("{0:F1}", temp);
                            Console.WriteLine("Не корректный ввод! Средний балл студента равна " + tempFormat);
                            students[i].AveragePoint = temp;
                        }

                        Console.WriteLine($"Введите количество членов семьи {i} студента: ");
                        string countMemberInput = Console.ReadLine();
                        if(int.TryParse(countMemberInput, out countMember))
                        {
                            students[i].MembersOfFamily = countMember;
                        }
                        else
                        {
                            int temp = student.GenerateMembersOfFamily();
                            Console.WriteLine("Не корректный ввод! Количество членов семьи равна " + temp);
                            students[i].MembersOfFamily = temp;
                        }

                        Console.WriteLine($"Введите доход на члена семьи {i} студента: ");
                        string capitaIncomeInput = Console.ReadLine();
                        if(int.TryParse(capitaIncomeInput, out perCapitaIncome))
                        {
                            students[i].PerCapitaIncome = perCapitaIncome;
                        }
                        else
                        {
                            int temp = student.GeneratePerCapitaIncome();
                            Console.WriteLine("Не корректный ввод! Доход на члена семьи равна " + temp + " тг");
                            students[i].PerCapitaIncome = temp;
                        }
                    }
                    Console.WriteLine("Press any key...");
                    Console.ReadLine();
                    Console.Clear();

                    Array.Sort(students, new Comparison<Student>((a, b) => a.AveragePoint.CompareTo(b.AveragePoint)));

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Список студентов");
                    Console.ResetColor();
                    for (int i = 1; i < students.Length; i++)
                    {
                        students[i].ShowInfo();
                    }
                }
            }
        }
    }
}

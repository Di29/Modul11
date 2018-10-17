using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul11
{

    class Program
    {
        static void Main(string[] args)
        {
            int count = 0;
            int input = 0;
            int age = 0;
            int defaultAge = 20;
            int salary = 0;
            int defaultSalary = 70000;
            DateTime dateTimeOut;
            bool succes = false;

            while (!succes)
            {
                Console.WriteLine("Введите количество сотрудников: ");
                string countText = Console.ReadLine();
                if(!int.TryParse(countText, out count))
                {
                    Console.WriteLine("Не корректный ввод!");
                }
                else
                {
                    Console.WriteLine($"Количество сотрудников равна: {count}");
                    Employee[] employees = new Employee[count+1];
                    Employee employee = new Employee();
                    for(int i=1; i<employees.Length; i++)
                    {
                        Console.WriteLine($"\nВведите имя {i} сотрудника: ");
                        employees[i].LastName = Console.ReadLine();

                        Console.WriteLine($"Введите фамилию {i} сотрудника: ");
                        employees[i].FirstName = Console.ReadLine();

                        Console.WriteLine($"Введите возраст {i} сотрудника: ");
                        string ageText = Console.ReadLine();
                        if(int.TryParse(ageText, out age))
                        {
                            employees[i].Age = age;
                        }
                        else
                        {
                            Console.WriteLine("Не корректный ввод. Возраст по умолчанию 20");
                            employees[i].Age = defaultAge;
                        }
                        
                        Console.WriteLine($"\nВыберите должность {i} сотрудника: ");
                        Console.WriteLine("1. Клерк\n2. Менеджер\n3. Босс");
                        string inputText = Console.ReadLine();
                        if(!int.TryParse(inputText, out input))
                        {
                            Console.WriteLine("Не корректный ввод. По умолчанию выбрано 'Клекр' \n");
                        }
                        else
                        {
                            switch (input)
                            {
                                case 1:
                                    employees[i].position = Positions.Clerk;
                                    break;
                                case 2:
                                    employees[i].position = Positions.Manager;
                                    break;
                                case 3:
                                    employees[i].position = Positions.Boss;
                                    break;
                            }
                        }
                        
                        Console.WriteLine($"\nВведите зарплату {i} сотрудника: ");
                        string salaryText = Console.ReadLine();
                        if(!int.TryParse(salaryText, out salary))
                        {
                            Console.WriteLine("Не корректный ввод! Зарплата сотрудника по умолчанию 70000");
                            employees[i].Salary = defaultSalary;
                        }
                        else
                        {
                            employees[i].Salary = salary;
                        }

                        Console.WriteLine($"\nВведите дату приема {i} сотрудника в формате:"+" {0:d}", DateTime.Today);
                        if(!DateTime.TryParse(Console.ReadLine(), out dateTimeOut))
                        {
                            Console.WriteLine("Не корректный ввод! По умолчанию дата приема - текущая дата");
                            employees[i].DateOfRecruit = DateTime.Today;
                        }
                        else
                        {
                            employees[i].DateOfRecruit = dateTimeOut;
                        }
                    }
                    Console.WriteLine("Press any key...");
                    Console.ReadLine();
                    Console.Clear();

                    Array.Sort(employees, new Comparison<Employee>((a, b) => a.FirstName.CompareTo(b.FirstName)));

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("Список всех сотрудников");
                    Console.ResetColor();
                    for(int i=1; i < employees.Length; i++)
                    {
                        employees[i].ShowInfo();
                    }

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Средняя зарплата всех клерков равна: {employee.AverageSalaryOfClerc(employees)}");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\nСписок менеджеров, зарплата которых больше чем средняя зарплата всех клерков");
                    Console.ResetColor();
                    foreach (var employe in employees)
                    {
                        if (employe.position == Positions.Manager && employe.Salary > employee.AverageSalaryOfClerc(employees))
                        {
                            Array.Sort(employees, new Comparison<Employee>((a, b) => a.FirstName.CompareTo(b.FirstName)));
                            employe.ShowInfo();
                             
                        }                     
                    }

                    foreach (var employe in employees)
                    {
                        Employee boss = new Employee();
                        if (employe.position == Positions.Boss)
                        {
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("\nBoss");
                            Console.ResetColor();
                            employe.ShowInfo();
                            boss = employe;
                        }

                        if (employe.position != Positions.Boss && employe.DateOfRecruit > boss.DateOfRecruit)
                        {
                            Array.Sort(employees, new Comparison<Employee>((a, b) => a.FirstName.CompareTo(b.FirstName)));
                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                            Console.WriteLine("Список сотрудников, принятых на работу после босса");
                            Console.ResetColor();
                            employe.ShowInfo();

                        }
                    }
                }
            }
            Console.ReadLine();          
        }
    }
}

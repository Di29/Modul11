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
                    for(int i=0; i<employees.Length; i++)
                    {
                        Console.WriteLine($"\nВведите имя {i} сотрудника: ");
                        employees[i].lastName = Console.ReadLine();

                        Console.WriteLine($"Введите фамилию {i} сотрудника: ");
                        employees[i].firstName = Console.ReadLine();

                        Console.WriteLine($"Введите возраст {i} сотрудника: ");
                        string ageText = Console.ReadLine();
                        if(int.TryParse(ageText, out age))
                        {
                            employees[i].age = age;
                        }
                        else
                        {
                            Console.WriteLine("Не корректный ввод. Возраст по умолчанию 20");
                            employees[i].age = defaultAge;
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
                            employees[i].salary = defaultSalary;
                        }
                        else
                        {
                            employees[i].salary = salary;
                        }

                        Console.WriteLine($"\nВведите дату приема {i} сотрудника в формате:"+" {0:d}", DateTime.Today);
                        if(!DateTime.TryParse(Console.ReadLine(), out dateTimeOut))
                        {
                            Console.WriteLine("Не корректный ввод! По умолчанию дата приема - текущая дата");
                            employees[i].dateOfRecruit = DateTime.Today;
                        }
                        else
                        {
                            employees[i].dateOfRecruit = dateTimeOut;
                        }
                    }
                    Console.WriteLine("Press any key...");
                    Console.ReadLine();
                    Console.Clear();

                    for(int i=1; i < employees.Length; i++)
                    {
                        employees[i].ShowInfo();
                    }


                    Console.WriteLine($"Средняя зарплата всех клерков равна: {employee.AverageSalaryOfClerc(employees)}");

                    Console.WriteLine(Array.Sort(employees, new Comparison<Employee>((a, b) => a.firstName.CompareTo(b.firstName))));

                    Employee[] managers;
                    int countOfManagers = 0;
                    foreach (var employe in employees)
                    {
                        if (employe.position == Positions.Manager && employe.salary > employee.AverageSalaryOfClerc(employees))
                        {
                            //countOfManagers++;
                            //managers = new Employee[countOfManagers];
                            //for(int i = 0; i < managers.Length; i++)
                            //{
                            //    managers[i] = employe;
                            //}
                            /*foreach(Employee manager in employees.OrderBy(mng => mng.firstName))
                            {
                                Console.WriteLine(manager.firstName);
                                //System.Diagnostics.Trace.WriteLine(manager.firstName);
                            }*/

                            
                        }
                        
                    }

                    
                }
            }
            Console.ReadLine();          
        }
    }
}

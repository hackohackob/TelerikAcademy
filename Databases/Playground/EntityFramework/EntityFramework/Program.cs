namespace EntityFramework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    public class Program
    {
        static void Main()
        {
            using(var db = new TelerikAcademyEntities())
            {
                PrintEmployeesGroupedByDeparmtmentAndTown(db);
                //PrintEmployeesGroupedByDeparmtmentAndTown2(db);
            }
        }

        static void PrintEmployeesGroupedByDeparmtmentAndTown(TelerikAcademyEntities db)
        {
            var groups = db.Employees
                    .OrderBy(e => e.FirstName)
                    .ThenBy(e => e.LastName)
                    .GroupBy(e => new { Department = e.Department.Name, Town = e.Address.Town.Name })
                    .OrderBy(g => new { Count = -g.Count(), g.Key.Department, g.Key.Town })
                    .ToList();

            foreach (var departmentGroup in groups)
            {
                Console.WriteLine("Department: {0}\nTown: {1}\nEmployees: {2}", 
                    departmentGroup.Key.Department, departmentGroup.Key.Town, departmentGroup.Count());
                Console.WriteLine("====================\n");

                var sortedDepartmentGroup = departmentGroup
                    //.OrderBy(e => e.FirstName)
                    .ToList();


                foreach (var employee in sortedDepartmentGroup)
                {
                    Console.WriteLine("{0} {1}",employee.FirstName, employee.LastName);
                    //Console.WriteLine("{0} {1} - Bonus: {2}", employee.FirstName, employee.LastName);
                }
                Console.WriteLine("\n\n");
            }
        }

        static void PrintEmployeesGroupedByDeparmtmentAndTown2(TelerikAcademyEntities db)
        {
            var employees = db.Employees
                    .Select(e =>new
                    {
                        FirstName = e.FirstName,
                        LastName = e.LastName,
                        Department = e.Department.Name,
                        Address = e.Address.AddressText,
                        Town = e.Address.Town.Name,
                        Projects = e.Projects.Count
                    })
                    .Where(e =>  e.Projects < 4 )
                    .OrderBy(e => e.Projects)
                    .ToList();

            foreach (var employee in employees)
            {
                Console.WriteLine("=============\nName: {0} {1}\nDepartment: {2}\nAddress: {3}, {4}\nProjects: {5}\n",
                    employee.FirstName,employee.LastName,employee.Department,employee.Address,employee.Town, employee.Projects);
            }
            
        }
    }
}

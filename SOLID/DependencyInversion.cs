using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLID
{

    /*
     * The basic idea behind this principle is that we should create our higher level module with its complex logic in such a way that
     * that it should be reusable and unaffected by the changes in the lower level module in our application
     * To achieve this we have abstraction which decouple higher modules from lower level module
     * 
     * having this idea in mind, Dependeny Principle states thata
     * 1. Higher level and lower level modules should depend on abstractions
     * 2. Abstractions should not depend on details, but details should depend on abstraction    
     * https://code-maze.com/dependency-inversion-principle/
     */


    //According to me :
    //Low level Modules : Those classes which deals with Models directly
    //High level modules : Those classes which deals with Low level modules

    #region Models

    public enum Gender
    {
        MALE,
        FEMALE
    }

    public enum Position
    {
        ADMIN,
        EXECUTIVE,
        MANGER
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Gender Gender { get; set; }
        public Position Position { get; set; }
    }

    #endregion

    #region Low Level Module (Deals with the models classes)

    public class EmployeeManager : IEmployeeSearchable
    {
        private List<Employee> employees;

        public EmployeeManager()
        {

        }

        public EmployeeManager(List<Employee> _employees)
        {
            employees = _employees;
            //Employees = employees;
        }

        //not needed not as we have GetEmployees method implented, abstracted from high level module
        //public List<Employee> Employees { get; set; }

        public void AddEmployee(Employee employee) => employees.Add(employee);

        public IEnumerable<Employee> GetEmployees(Gender gender, Position position)
        {
            return employees.Where(x => x.Gender == gender && x.Position == position);
        }
    }
    #endregion

    #region high level module  (one which deals with low level modules)
    public class EmployeeStatistics
    {
        private EmployeeManager employeeManager;
        public EmployeeStatistics(EmployeeManager manager)
        {
            employeeManager = manager;
        }

        //Say in this class i want get the headcount of female managers
        //In order to do that, employees must be made public
        public int CountFemaleManager()
        {
            //Below line is not possible as we now have a new abstracted method to get employees
            //return employeeManager.Employees.Where(x => x.Gender == Gender.FEMALE && x.Position == Position.MANGER).Count();

            return employeeManager.GetEmployees(Gender.FEMALE, Position.MANGER).Count();
        }

        //the above method completely violated the DIP, were accessing a lower level modules property in higher level

    }
    #endregion

    #region Implementing the DIP

    public interface IEmployeeSearchable
    {
        IEnumerable<Employee> GetEmployees(Gender gender, Position position);
    }

    //implement this interace in lower level module
    #endregion

    class DependencyInversion
    {
        public static void Driver()
        {
            var empManager = new EmployeeManager();
            empManager.AddEmployee(new Employee { Name = "Leen", Gender = Gender.FEMALE, Position = Position.MANGER});
            empManager.AddEmployee(new Employee { Name = "Mike", Gender = Gender.MALE, Position = Position.ADMIN });

            var stats = new EmployeeStatistics(empManager);
            Console.WriteLine($"Number of female managers in our company is: {stats.CountFemaleManager()}");
        }
    }
}

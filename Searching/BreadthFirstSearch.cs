using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class Employee
    {
        public Employee(string name) => Name = name;

        public string Name { get; set; }

        public List<Employee> Employees { get; } = new List<Employee>();

        public void IsEmployerOf(Employee employee) => Employees.Add(employee);

        public override string ToString() => Name;
    }

    public class BFSAlgo
    {
        public Employee BuildEmployeeGraph()
        {
            Employee Eva = new Employee("Eva");
            Employee Sophia = new Employee("Sophia");
            Employee Brian = new Employee("Brian");

            Eva.IsEmployerOf(Sophia);
            Eva.IsEmployerOf(Brian);

            Employee Lisa = new Employee("Lisa");
            Employee John = new Employee("John");

            Sophia.IsEmployerOf(Lisa);
            Sophia.IsEmployerOf(John);

            Employee Tina = new Employee("Tina");
            Employee Mika = new Employee("Mika");

            Brian.IsEmployerOf(Tina);
            Brian.IsEmployerOf(Mika);

            return Eva;
        }

        public Employee Search(Employee root, string nameToSearch)
        {
            Queue<Employee> Q = new Queue<Employee>();
            Q.Enqueue(root);

            while(Q.Count > 0)
            {
                Employee employee = Q.Dequeue();
                if (employee.Name == nameToSearch)
                    return employee;

                foreach(var empl in employee.Employees)                
                    Q.Enqueue(empl);
            }
            return null;
        }

        //Just to print the name in Tree
        public void Traverse(Employee root)
        {
            Queue<Employee> Q = new Queue<Employee>();
            Q.Enqueue(root);

            while(Q.Count > 0)
            {
                Employee employee = Q.Dequeue();
                Console.WriteLine(employee);
                foreach(var empl in employee.Employees)
                    Q.Enqueue(empl);
            }
        }
    }

    public class BreadthFirstSearch
    {
        public static void Driver()
        {
            BFSAlgo bFSAlgo = new BFSAlgo();
            var rootEmployee =  bFSAlgo.BuildEmployeeGraph();

            Console.WriteLine("Travese Graph\n-----------------");
            bFSAlgo.Traverse(rootEmployee);

            Console.WriteLine("Searching in Graph\n---------------");
            var emp = bFSAlgo.Search(rootEmployee, "Eva");
            Console.WriteLine(emp == null ? "Employee not found" : emp.Name);

            emp = bFSAlgo.Search(rootEmployee, "Sunny");
            Console.WriteLine(emp == null ? "Employee not found" : emp.Name);

            emp = bFSAlgo.Search(rootEmployee, "Rambo");
            Console.WriteLine(emp == null ? "Employee not found" : emp.Name);

            emp = bFSAlgo.Search(rootEmployee, "Brian");
            Console.WriteLine(emp == null ? "Employee not found" : emp.Name);
        }
    }
}

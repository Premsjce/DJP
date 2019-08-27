using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Searching
{
    public class DepthFirstSearch
    {
        public static void Driver()
        {
            DFSAlgo DFSAlgo = new DFSAlgo();
            var rootEmployee = DFSAlgo.BuildEmployeeGraph();

            Console.WriteLine("Travese Graph\n-----------------");
            DFSAlgo.Traverse(rootEmployee);

            Console.WriteLine("Searching in Graph\n---------------");
            var emp = DFSAlgo.Search(rootEmployee, "Eva");
            Console.WriteLine(emp == null ? "Employee not found" : emp.Name);

            emp = DFSAlgo.Search(rootEmployee, "Sunny");
            Console.WriteLine(emp == null ? "Employee not found" : emp.Name);

            emp = DFSAlgo.Search(rootEmployee, "Rambo");
            Console.WriteLine(emp == null ? "Employee not found" : emp.Name);

            emp = DFSAlgo.Search(rootEmployee, "Brian");
            Console.WriteLine(emp == null ? "Employee not found" : emp.Name);
        }
    }

    public class DFSAlgo
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
            Stack<Employee> stack = new Stack<Employee>();
            stack.Push(root);

            while(stack.Count > 0)
            {
                var emp = stack.Pop();
                if (emp.Name == nameToSearch)
                    return emp;

                foreach (var employee in emp.Employees)
                    stack.Push(employee);
            }
            return null;
        }    
        
        public void Traverse(Employee root)
        {
            Stack<Employee> Stack = new Stack<Employee>();
            Stack.Push(root);

            while (Stack.Count > 0)
            {
                Employee employee = Stack.Pop();
                Console.WriteLine(employee);
                foreach (var empl in employee.Employees)
                    Stack.Push(empl);
            }
        }
    }
}

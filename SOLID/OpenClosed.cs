using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{

    /*
     * The Open Closed Principle (OCP) is the SOLID principle which states that the software entities (classes or methods) 
     * should be open for extension but closed for modification.
     * 
     * But what does this really mean?
     * Basically, we should strive to write a code that doesn’t require modification every time a customer changes its request. 
     * Providing such a solution where we can extend the behavior of a class (with that additional customer’s request) and not modify that class, 
     * should be our goal most of the time.
     * https://code-maze.com/open-closed-principle/
     */


    public enum DeveloperType
    {
        SENIOR,
        JUNIOR,
        INTERN
    }

    public class DeveloperReport
    {
        public DeveloperReport()
        {
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double HourlyCharge { get; set; }
        public int TotalHoursWorked { get; set; }
        public DeveloperType DeveloperType { get; set; }
    }


    public class SalaryReport
    {
        private List<DeveloperReport> developerReports;

        public SalaryReport(List<DeveloperReport> _developerReports)
        {
            developerReports = _developerReports;
        }

        public double CalculateSalary()
        {
            double totalSalary = 0D;

            foreach (var dev in developerReports)
                totalSalary += dev.HourlyCharge * dev.TotalHoursWorked;

            return totalSalary;
        }


        //Now if manager asks to consider 20% bonus for senior developers then we have to modify the existing class to method
        //Which goes again the Open Closed principle
        public double CalculateSalaryModified()
        {
            double totalSalary = 0D;

            foreach (var dev in developerReports)
            {
                if (dev.DeveloperType == DeveloperType.SENIOR)
                    totalSalary += dev.HourlyCharge * dev.TotalHoursWorked * 1.2;
                else
                    totalSalary += dev.HourlyCharge * dev.TotalHoursWorked;
            }

            return totalSalary;
        }
    }

    //This can be solved by having a base abstrat class
    public abstract class BaseSalaryReport
    {
        public DeveloperReport DeveloperReport;

        public BaseSalaryReport(DeveloperReport developerReport)
        {
            DeveloperReport = developerReport;
        }

        public abstract double CalculateSalary();
    }

    public class SeniorSalaryReport : BaseSalaryReport
    {
        public SeniorSalaryReport(DeveloperReport developerReports) : base(developerReports)
        {
        }

        public override double CalculateSalary() => DeveloperReport.HourlyCharge + DeveloperReport.TotalHoursWorked * 1.2;
    }

    public class JuniorSalaryReport : BaseSalaryReport
    {
        public JuniorSalaryReport(DeveloperReport developerReport) : base(developerReport)
        {
        }

        public override double CalculateSalary() => DeveloperReport.HourlyCharge + DeveloperReport.TotalHoursWorked;
    }

    public class InternSalaryReport : BaseSalaryReport
    {
        public InternSalaryReport(DeveloperReport developerReport) : base(developerReport)
        {

        }

        public override double CalculateSalary() => DeveloperReport.HourlyCharge + DeveloperReport.TotalHoursWorked * 0.5;
    }

    public class SalaryCalculator
    {
        private List<BaseSalaryReport> baseSalaryReports;

        public SalaryCalculator(List<BaseSalaryReport> _baseSalaryReports)
        {
            baseSalaryReports = _baseSalaryReports;
        }

        public double CalculateSalary()
        {
            double totalSalary = 0D;

            foreach (var dev in baseSalaryReports)
            {
                totalSalary += dev.CalculateSalary();
            }

            return totalSalary;
        }
    }

    class OpenClosed
    {
        public static void Drvier()
        {
            var devReports = new List<BaseSalaryReport>
            {
                new SeniorSalaryReport(new DeveloperReport(){  Id = 1, Name = "Dev1", DeveloperType = DeveloperType.SENIOR, HourlyCharge= 30.5, TotalHoursWorked= 160 }),
                new JuniorSalaryReport(new DeveloperReport {Id = 2, Name = "Dev2", DeveloperType = DeveloperType.JUNIOR, HourlyCharge  = 20, TotalHoursWorked= 150 }),
                new SeniorSalaryReport(new DeveloperReport {Id = 3, Name = "Dev3", DeveloperType = DeveloperType.SENIOR, HourlyCharge= 30.5, TotalHoursWorked= 180 })
            };


            var calculator = new SalaryCalculator(devReports);
            Console.WriteLine($"Sum of all the developer salaries is {calculator.CalculateSalary()}");
        }
    }
}

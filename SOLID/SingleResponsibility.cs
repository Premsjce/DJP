using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID
{
    /*
     * We are going to start with a simple console application.
     * Imagine if we have a task to create a WorkReport feature that, 
     * once created, can be saved to a file and perhaps uploaded to the cloud or used for some other purpose.
     * https://code-maze.com/single-responsibility-principle/
     */

    public class WorkReportEntry
    {
        public string ProjectCode { get; set; }
        public string ProjectName { get; set; }
        public int SpentHours { get; set; }
    }

    public class WorkReport
    {
        private List<WorkReportEntry> entries;

        public WorkReport()
        {
            entries = new List<WorkReportEntry>();
        }

        public void AddEntry(WorkReportEntry workReportEntry) => entries.Add(workReportEntry);

        public void RemoveEntry(int index) => entries.RemoveAt(index);

        //Moved this responsibility to new FileSaver class
        //public void SaveToFile(string dirPath, string fileName)
        //{
        //    if (!Directory.Exists(dirPath))
        //        Directory.CreateDirectory(dirPath);

        //    File.WriteAllText(Path.Combine(dirPath, fileName), ToString());
        //}

        public override string ToString()
        {
            return string.Join(Environment.NewLine, entries.Select(x => $"Code  :  {x.ProjectCode}, Name : {x.ProjectName}, Hours : {x.SpentHours}"));
        }
    }
        

    public class FileSaver
    {
        public void SaveToFile(string dirPath, string fileName, WorkReport workReport)
        {
            if (!Directory.Exists(dirPath))
                Directory.CreateDirectory(dirPath);

            File.WriteAllText(Path.Combine(dirPath, fileName), workReport.ToString());
        }
    }

    /*
     * It has more than one responsibility.
     * Its job is not only to keep track of our work report entries but to save the entire work report to a file. 
     * This means that we are violating the SRP and our class has more than one reason to change in the future. 
     */

    class SingleResponsibility
    {
        public static void Driver()
        {
            var report = new WorkReport();
            report.AddEntry(new WorkReportEntry { ProjectCode = "123Ds", ProjectName = "Project1", SpentHours = 5 });
            report.AddEntry(new WorkReportEntry { ProjectCode = "987Fc", ProjectName = "Project2", SpentHours = 3 });

            Console.WriteLine(report.ToString());

            var saver = new FileSaver();
            saver.SaveToFile(@"Reports", "WorkReport.txt", report);
        }
    }

    //Making code even better
    public interface IEntryManager<T>
    {
        void AddEntry(T entry);
        void RemoveEntry(int index);
    }

    //Now the changes looks something like this
    public class WorkReporty : IEntryManager<WorkReportEntry>
    {
        public void AddEntry(WorkReportEntry entry)
        {
            throw new NotImplementedException();
        }

        public void RemoveEntry(int index)
        {
            throw new NotImplementedException();
        }
    }

    //FileSaver class will have following method
    //public void SaveToFile<T>(string dirPath, string fileName, IEntryManager<T> workReport);



}

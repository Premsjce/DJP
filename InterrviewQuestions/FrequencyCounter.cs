using System.Collections.Generic;

namespace InterviewQuestions
{
    public class FrequencyCounter
    {
        public static void Driver()
        {
            List<List<int>> queries = new List<List<int>>();

            queries.Add(new List<int>() { 1, 1 });
            queries.Add(new List<int>() { 2, 2 });
            queries.Add(new List<int>() { 3, 2 });
            queries.Add(new List<int>() { 1, 1 });
            queries.Add(new List<int>() { 1, 1 });
            queries.Add(new List<int>() { 2, 1 });
            queries.Add(new List<int>() { 3, 2 });

            var result = Count(queries);

            foreach (var num in result)
                System.Console.WriteLine(num);
        }


        private static List<int> Count(List<List<int>> queries)
        {
            var result = new List<int>();

            Dictionary<int, int> map = new Dictionary<int, int>();

            foreach (var qu in queries)
            {
                int operation = qu[0];
                int dataItem = qu[1];

                if (operation == 1)
                {
                    if (!map.ContainsKey(dataItem))
                        map.Add(dataItem, 0);

                    map[dataItem] += 1;

                }
                else if (operation == 2)
                {
                    if (map.ContainsKey(dataItem) && map[dataItem] > 0)
                        map[dataItem] -= 1;
                }
                else
                {
                    if (map.ContainsValue(dataItem))
                        result.Add(1);
                    else
                        result.Add(0);
                }
            }
            return result;

            /*
             SELECT (EMployeeName) in Employee OrderBy EmployeeName
             employeLsit =  employees.Gropby(emp=>empl.Name) ;
             */
        }
    }
}
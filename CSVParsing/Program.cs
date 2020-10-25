using System;
using System.Collections.Generic;
using System.Linq;

namespace CSVParsing
{
    class Program
    {
        static void Main(string[] args)
        {
            /*************************
            * read CSV with embedded commas
            * parse CSV into separate fields and
            * ignore commas within quoted string
            * ***********************/

            Console.WriteLine("Reading CSV with embedded commas");
            List<string> myList = new List<string>();
            string input1 = "\"a,b\",c";
            string input2 = "\"Obama, Barack\",\"August 4, 1961\",\"Washington, D.C.\"";
            string input3 = "\"Ft. Benning, Georgia\",32.3632N,84.9493W," +
                            "\"Ft. Stewart, Georgia\",31.8691N,81.6090W," +
                            "\"Ft. Gordon, Georgia\",33.4302N,82.1267W";
            //Used to add imported txt document
            //string text = System.IO.File.ReadAllText(@" REF TXT FILE HERE ");

            myList.Add(input1);
            myList.Add(input2);
            myList.Add(input3);

            //Used to add imported txt document
            //myList.Add(text);

            foreach (string s in myList)
            {
                Console.WriteLine($"Current input is {s}");
                List<string> output = getCSV(s);
                int len = output.Count;
                Console.WriteLine($"This line has {len} fields. They are:");
                foreach (string s1 in output)
                    Console.WriteLine(s1);
            }
        }

        static List<string> getCSV(string inputString)
        {
            List<string> newList = inputString.Split('\"', StringSplitOptions.RemoveEmptyEntries).ToList();
            List<string> result = new List<string>();
            for (int i = 0; i < newList.Count; i++)
            {
                if (newList[i].StartsWith(','))
                {
                    newList[i] = newList[i].Trim(',');
                    foreach (var j in newList[i].Split(',', StringSplitOptions.RemoveEmptyEntries))
                    {
                        result.Add(j);
                    }
                }
                else
                    result.Add(newList[i]);
            }
            return result;
        }
    }
}

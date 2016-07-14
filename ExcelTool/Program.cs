using ExcelTool.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTool
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string path = @"c:\users\bryan\documents\visual studio 2015\Projects\ExcelTool\ExcelTool\ExcelFiles\SamplePortfolios.xlsx";
                DataReader readInData = new DataReader(path, "Sheet1");
                IEnumerable<Portfolio> portfolios = readInData.GetData();

                // TODO: Json serialization into own class, possibly override ToString() for custom format
                var json = JsonConvert.SerializeObject(portfolios, Formatting.Indented);
                Console.Write(json);
            }
            catch (Exception ex)
            {
                if (!(ex is System.IO.FileNotFoundException || ex is ArgumentException || ex is FileToBeProcessedIsNotInTheCorrectFormatException))
                    throw;
                Console.WriteLine(ex.Message);
            }
            Console.Write("\n\nPress any key to continue...");
            Console.ReadKey(true);
        }
    }
}

using ExcelTool.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTool
{
    public class DataReader
    {
        private string path;
        private string worksheetName;

        public DataReader(string path, string worksheetName)
        {
            this.path = path;
            this.worksheetName = worksheetName;
        }

        public IEnumerable<Portfolio> GetData(bool isFirstRowAsColumnNames = true)
        {
            var excelData = new ExcelData(path);
            var dataRows = excelData.GetData(worksheetName, isFirstRowAsColumnNames);

            return dataRows.Select(dataRow => new Portfolio()
            {
                ID = dataRow["ID"].ToString(),
                StartDate = dataRow["Start"].ToString(),
                Value = dataRow["Value"].ToString()
            });
        }
    }
}
using Excel;
using ExcelTool.Exceptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTool
{
    class ExcelDataHelper
    {
        private static IExcelDataReader GetExcelDataReader(string path, bool isFirstRowAsColumnNames)
        {
            using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                IExcelDataReader dataReader;

                if (path.EndsWith(".xls"))
                    dataReader = ExcelReaderFactory.CreateBinaryReader(fileStream);
                else if (path.EndsWith(".xlsx"))
                    dataReader = ExcelReaderFactory.CreateOpenXmlReader(fileStream);
                else
                    throw new FileToBeProcessedIsNotInTheCorrectFormatException("The file to be processed is not an Excel file");

                dataReader.IsFirstRowAsColumnNames = isFirstRowAsColumnNames;
                return dataReader;
            }
        }

        private static DataSet GetExcelDataAsDataSet(string path, bool isFirstRowAsColumnNames)
        {
            return GetExcelDataReader(path, isFirstRowAsColumnNames).AsDataSet();
        }

        private static DataTable GetExcelWorkSheet(string path, string workSheetName, bool isFirstRowAsColumnNames)
        {
            DataTable workSheet = GetExcelDataAsDataSet(path, isFirstRowAsColumnNames).Tables[workSheetName];
            if (workSheet == null)
                throw new WorksheetDoesNotExistException(string.Format("The worksheet {0} does not exist, has an incorrect name, or does not have any data in the worksheet", workSheetName));
            return workSheet;
        }

        private static IEnumerable<DataRow> GetData(string path, string workSheetName, bool isFirstRowAsColumnNames = true)
        {
            return from DataRow row in GetExcelWorkSheet(path, workSheetName, isFirstRowAsColumnNames).Rows select row;
        }
    }
}

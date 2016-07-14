using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelTool.Exceptions
{
    internal class WorksheetDoesNotExistException : Exception
    {
        public WorksheetDoesNotExistException()
        {
        }
        public WorksheetDoesNotExistException(string message) 
            : base(message)
        {
        }
        public WorksheetDoesNotExistException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}

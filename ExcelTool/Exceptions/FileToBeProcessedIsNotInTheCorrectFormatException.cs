using System;

namespace ExcelTool
{
    internal class FileToBeProcessedIsNotInTheCorrectFormatException : Exception
    {
        public FileToBeProcessedIsNotInTheCorrectFormatException()
        {
        }
        public FileToBeProcessedIsNotInTheCorrectFormatException(string message) 
            : base(message)
        {
        }
        public FileToBeProcessedIsNotInTheCorrectFormatException(string message, Exception inner)
            :base(message, inner)
        {
        }
    }
}
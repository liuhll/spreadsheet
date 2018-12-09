using System;

namespace SpreadSheet.Exceptions
{
    public class SpreadSheetException : Exception
    {
        public SpreadSheetException(string exceptionMessage) : base(exceptionMessage)
        {

        }
    }
}

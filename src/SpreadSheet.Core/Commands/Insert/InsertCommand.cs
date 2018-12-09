using SpreadSheet.Exceptions;
using System;

namespace SpreadSheet.Commands.Insert
{
    public class InsertCommand : ICommand
    {
        public SpreadSheet Operate(string input, SpreadSheet spreadSheet = null)
        {
            if (spreadSheet != null)
            {
                throw new SpreadSheetException("您还未创建spreadSheet表,无法对其进行插入操作");
            }
            // :todo 通过输入查询将值插入指定的Cell
            return spreadSheet;
        }
    }
}

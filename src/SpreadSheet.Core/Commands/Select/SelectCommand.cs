using SpreadSheet.Exceptions;
using System;

namespace SpreadSheet.Commands.Select
{
    public class SelectCommand : ICommand
    {
        public SpreadSheet Operate(string input, SpreadSheet spreadSheet = null)
        {
            if (spreadSheet != null)
            {
                throw new SpreadSheetException("您还未创建spreadSheet表,无法对其进行查询操作");
            }
            // :todo 通过输入查询指定Cell中的数据
            return spreadSheet;
        }
    }
}

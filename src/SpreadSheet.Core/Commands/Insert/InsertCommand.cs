using SpreadSheet.Exceptions;

namespace SpreadSheet.Commands.Insert
{
    public class InsertCommand : ICommand
    {
        private readonly IInsertSheetCellParser _insertSheetCellParser;

        public InsertCommand()
        {
            _insertSheetCellParser = new InsertSheetCellParser();
        }

        public SpreadSheet Operate(string input, SpreadSheet spreadSheet = null)
        {
            if (spreadSheet == null)
            {
                throw new SpreadSheetException("您还未创建spreadSheet表,无法对其进行插入操作");
            }
            var cells = _insertSheetCellParser.GetSheetCells(input);
            foreach (var cell in cells)
            {
                spreadSheet.SetVal(cell);
            }
            return spreadSheet;
        }
    }
}
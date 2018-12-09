using SpreadSheet.Exceptions;

namespace SpreadSheet.Commands.Select
{
    public class SelectCommand : ICommand
    {
        private readonly ISelectSheetCellParser _selectSheetCellParser;

        public SelectCommand()
        {
            _selectSheetCellParser = new SelectSheetCellParser();
        }

        public SpreadSheet Operate(string input, SpreadSheet spreadSheet = null)
        {
            if (spreadSheet == null)
            {
                throw new SpreadSheetException("您还未创建spreadSheet表,无法对其进行查询操作");
            }
            var selectPoints = _selectSheetCellParser.GetSelectPoints(input);
            var selectCells = spreadSheet.GetCells(selectPoints);
            var selectedSheet = SpreadSheet.CreateSheet(spreadSheet.Width, spreadSheet.Height, selectCells);
            return selectedSheet;
        }
    }
}
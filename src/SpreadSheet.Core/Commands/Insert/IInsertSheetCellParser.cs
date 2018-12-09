using System.Collections.Generic;

namespace SpreadSheet.Commands.Insert
{
    public interface IInsertSheetCellParser
    {
        IEnumerable<SpreadSheetCell> GetSheetCells(string input);
    }
}
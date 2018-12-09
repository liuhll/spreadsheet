using System;
using System.Collections.Generic;

namespace SpreadSheet.Commands.Select
{
    public interface ISelectSheetCellParser
    {
        IEnumerable<CellPoint> GetSelectPoints(string input);
    }
}

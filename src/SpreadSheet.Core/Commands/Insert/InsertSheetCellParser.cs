using SpreadSheet.Exceptions;
using SpreadSheet.Extensions;
using System.Collections.Generic;

namespace SpreadSheet.Commands.Insert
{
    public class InsertSheetCellParser : IInsertSheetCellParser
    {
        public IEnumerable<SpreadSheetCell> GetSheetCells(string input)
        {
            var cellVals = input.Split(" ");
            if (cellVals.Length % 3 != 0)
            {
                throw new SpreadSheetException("字符串的格式不正确，插入的值必须为3的备注");
            }
            var result = new List<SpreadSheetCell>();
            var cellGroups = cellVals.CutArrayForAppointCount(3);
            foreach (var group in cellGroups)
            {
                if (!int.TryParse(group[0], out int x))
                {
                    throw new SpreadSheetException("插入的cell的x坐标必须为整数");
                }

                if (!int.TryParse(group[1], out int y))
                {
                    throw new SpreadSheetException("插入的cell的y坐标必须为整数");
                }
                var cell = new SpreadSheetCell(x, y, group[2]);
                result.Add(cell);
            }
            return result;
        }
    }
}
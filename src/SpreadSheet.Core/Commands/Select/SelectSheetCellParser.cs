using SpreadSheet.Exceptions;
using SpreadSheet.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpreadSheet.Commands.Select
{
    public class SelectSheetCellParser : ISelectSheetCellParser
    {
        public IEnumerable<CellPoint> GetSelectPoints(string input)
        {
            var cellVals = input.Split(" ");
            if (cellVals.Length % 2 != 0)
            {
                throw new SpreadSheetException("字符串的格式不正确，插入的值必须为2的备注");
            }
            var result = new List<CellPoint>();
            var pointGroups = cellVals.CutArrayForAppointCount(2);
            foreach (var group in pointGroups)
            {
                if (!int.TryParse(group[0], out int x))
                {
                    throw new SpreadSheetException("cell的x坐标必须为整数");
                }

                if (!int.TryParse(group[1], out int y))
                {
                    throw new SpreadSheetException("cell的y坐标必须为整数");
                }
                var point = new CellPoint(x, y);
                result.Add(point);
            }
            return result;
        }
    }
}

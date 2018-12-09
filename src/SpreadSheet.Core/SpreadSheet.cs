using SpreadSheet.Exceptions;
using SpreadSheet.Extensions;
using System;
using System.Collections.Generic;

namespace SpreadSheet
{
    public class SpreadSheet
    {
        private readonly int _w;
        private readonly int _h;
        private readonly string[,] _sheetData;

        private SpreadSheet(int w, int h)
        {
            _w = w;
            _h = h;
            _sheetData = new string[_w, _h];
        }

        public static SpreadSheet CreateSheet(int w, int h)
        {
            return new SpreadSheet(w, h);
        }

        public static SpreadSheet CreateSheet(int w, int h, IEnumerable<SpreadSheetCell> items)
        {
            var sheet = CreateSheet(w, h);
            sheet.SetVal(items);
            return sheet;
        }

        public int Width
        {
            get
            {
                return _w;
            }
        }

        public int Height
        {
            get
            {
                return _h;
            }
        }

        public void SetVal(int x, int y, string val)
        {
            VerifyVal(x, y, val);
            _sheetData[x - 1, y - 1] = val;
        }

        public void SetVal(SpreadSheetCell item)
        {
            VerifyVal(item.X, item.Y, item.Val);
            SetVal(item.X, item.Y, item.Val);
        }

        public string GetVal(int x, int y)
        {
            if (x > _w || y > _h)
            {
                throw new SpreadSheetException("要获取表格的Cell位置的值溢出");
            }
            var itemVal = _sheetData[x - 1, y - 1];
            return itemVal;
        }

        public SpreadSheetCell GetCell(CellPoint point)
        {
            return new SpreadSheetCell(point, GetVal(point.X, point.Y));
        }

        public IEnumerable<SpreadSheetCell> GetCells(IEnumerable<CellPoint> points)
        {
            var cells = new List<SpreadSheetCell>();
            foreach (var point in points)
            {
                cells.Add(GetCell(point));
            }
            return cells;
        }

        public void SetVal(IEnumerable<SpreadSheetCell> items)
        {
            foreach (var item in items)
            {
                _sheetData[item.X - 1, item.Y - 1] = item.Val;
            }
        }

        public void Out()
        {
            Console.WriteLine(" ---".Repeat(_w));
            for (var i = 1; i <= _h; i++)
            {
                Console.Write("|");
                for (var j = 1; j <= _w; j++)
                {
                    var item = GetVal(i, j);
                    if (item == null)
                    {
                        item = string.Empty;
                    }
                    Console.Write(item.PadRight(4, ' '));
                }
                Console.WriteLine("|");
            }
            Console.WriteLine(" ---".Repeat(_w));
        }

        private void VerifyVal(int x, int y, string val)
        {
            if (x > _w || y > _h)
            {
                throw new SpreadSheetException("指定的cell位置溢出");
            }
            if (val.Length > 3)
            {
                throw new SpreadSheetException("设值不合法");
            }
        }
    }
}
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
            _sheetData = new string[_w,_h];
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

        public void SetVal(int x,int y, string val)
        {

            _sheetData[x - 1,y - 1] = val;
        }


        public void SetVal(SpreadSheetCell item)
        {

            _sheetData[item.X -1, item.Y - 1] = item.Val;
        }

        public string GetVal(int x, int y)
        {
            var itemVal = _sheetData[x, y];
            if (itemVal == null)
            {
                return string.Empty;
            }
            return itemVal;
        }

        public SpreadSheetCell GetCell(CellPoint point)
        {
            return new SpreadSheetCell(point,GetVal(point.X - 1,point.Y - 1));
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
            Console.WriteLine("---".Repeat(_w, " "));
            for (var i = 0; i < _h; i++)
            {
                Console.Write("|");
                for (var j = 0; j < _w; j++)
                {
                    var item = GetVal(i, j);
                    Console.Write(item);
                }
                Console.WriteLine("|");
            }
            Console.WriteLine("---".Repeat(_w," "));
        }
    }
}

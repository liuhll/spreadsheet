using System;

namespace SpreadSheet
{
    public class SpreadSheetCell
    {
        private readonly int _x;
        private readonly int _y;
        private readonly string _val;

        public SpreadSheetCell(int x, int y, string val)
        {
            _x = x;
            _y = y;
            _val = val;
        }

        public int X
        {
            get
            {
                return _x;
            }
        }

        public int Y
        {
            get
            {
                return _y;
            }
        }

        public string Val
        {
            get
            {
                return _val;
            }
        }
    }
}

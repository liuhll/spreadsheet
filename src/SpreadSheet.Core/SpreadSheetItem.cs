using System;
using System.Collections.Generic;
using System.Text;

namespace SpreadSheet
{
    public class SpreadSheetItem
    {
        private readonly int _x;
        private readonly int _y;
        private readonly string _val;

        public SpreadSheetItem(int x, int y, string val)
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

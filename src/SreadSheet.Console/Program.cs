using System;
using System.Collections.Generic;

namespace SreadSheet
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var list = new List<SpreadSheet.SpreadSheetItem>()
            {
                new SpreadSheet.SpreadSheetItem(1,1,"121"),
                new SpreadSheet.SpreadSheetItem(2,1,"2323"),
                new SpreadSheet.SpreadSheetItem(6,2,"232")
            };
            var sheet = SpreadSheet.SpreadSheet.CreateSheet(11, 11, list);
            sheet.SetVal(1,3,"2323");
            sheet.Out();
            Console.ReadLine();
        }
    }
}

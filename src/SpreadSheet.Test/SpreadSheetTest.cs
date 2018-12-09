using SpreadSheet.Commands;
using SpreadSheet.Exceptions;
using System;
using System.Collections.Generic;
using Xunit;

namespace SpreadSheet.Test
{
    public class SpreadSheetTest
    {
        private readonly ICommandParser _commandParser;

        public SpreadSheetTest()
        {
            _commandParser = new CommandParser();
        }

        [Fact]
        public void CreateSpreadSheetTest()
        {
            var w = 10;
            var h = 10;
            var sheet = SpreadSheet.CreateSheet(w, h);
            Assert.True(w == sheet.Width && h == sheet.Height, $"成功创建了一个宽为{w},高为{h}的表格");
        }

        [Fact]
        public void CreateForSetDefaultSpreadSheetTest()
        {
            var w = 10;
            var h = 10;
            var cells = new List<SpreadSheetCell>()
            {
                new SpreadSheetCell(1, 1, "10"),
                new SpreadSheetCell(1,2, "20")
            };
            var sheet = SpreadSheet.CreateSheet(w, h,cells);
            Assert.True(w == sheet.Width && h == sheet.Height, $"成功创建了一个宽为{w},高为{h}的表格");
            var pont1x1yVal = sheet.GetVal(1, 1);
            var pont1x2yVal = sheet.GetVal(1, 2);
            Assert.True("10" == pont1x1yVal);
            Assert.True("20" == pont1x2yVal);
        }

        [Fact]
        public void InsertSpreadSheetTest()
        {
            var w = 10;
            var h = 10;
            var sheet = CreateSpreadSheet(w, h);
            var insertCommad = _commandParser.PaserCommand("N");
            insertCommad.Operate("1 1 10",sheet);
            insertCommad.Operate("10 1 20", sheet);
            insertCommad.Operate("10 10 30", sheet);
            var insertVal1x1y = sheet.GetVal(1, 1);
            var insertVal10x1y = sheet.GetVal(10, 1);
            var insertVal10x10y = sheet.GetVal(10, 10);
            Assert.True("10" == insertVal1x1y && "20" == insertVal10x1y && "30" == insertVal10x10y);

            Assert.Throws<SpreadSheetException>(() => {
                insertCommad.Operate("11 1 10", sheet);
            });

            Assert.Throws<SpreadSheetException>(() => {
                insertCommad.Operate("2 1 1234", sheet);
            });

            Assert.Throws<SpreadSheetException>(() => {
                insertCommad.Operate("2 1 1 2", sheet);
            });
        }

        [Fact]
        public void SelectSpreadSheetTest()
        {
            var w = 10;
            var h = 10;
            var cells = new List<SpreadSheetCell>()
            {
                new SpreadSheetCell(1,1, "10"),
                new SpreadSheetCell(1,2, "20"),
                new SpreadSheetCell(1,3, "30")
            };
            var sheet = SpreadSheet.CreateSheet(w, h, cells);
            var selectCommad = _commandParser.PaserCommand("S");
            var selectSheet = selectCommad.Operate("1 1 1 2",sheet);
            var cell1x1yVal = selectSheet.GetVal(1, 1);
            var cell1x2yVal = selectSheet.GetVal(1, 2);
            var cell1x3yVal = selectSheet.GetVal(1, 3);
            Assert.True("10" == cell1x1yVal && "20" == cell1x2yVal && null == cell1x3yVal);

            Assert.Throws<SpreadSheetException>(() => {
                selectCommad.Operate("11 11", sheet);
            });

            Assert.Throws<SpreadSheetException>(() => {
                selectCommad.Operate("1 2 2", sheet);
            });
        }

        private SpreadSheet CreateSpreadSheet(int w, int h)
        {
            return SpreadSheet.CreateSheet(w, h);
        }

    }
}

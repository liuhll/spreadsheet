using SpreadSheet.Exceptions;

namespace SpreadSheet.Commands.Create
{
    public class CreateCommand : ICommand
    {
        public SpreadSheet Operate(string input, SpreadSheet spreadSheet = null)
        {
            var points = input.Split(" ");
            if (points.Length != 2)
            {
                throw new SpreadSheetException("创建SpreadSheet参数的个数不正确");
            }
            if (!int.TryParse(points[0], out int w))
            {
                throw new SpreadSheetException("创建SpreadSheet宽度的参数数据格式不正确，数据格式必须为整数类型");
            }

            if (!int.TryParse(points[0], out int h))
            {
                throw new SpreadSheetException("创建SpreadSheet高度的参数数据格式不正确，数据格式必须为整数类型");
            }
            return SpreadSheet.CreateSheet(w, h);
        }
    }
}
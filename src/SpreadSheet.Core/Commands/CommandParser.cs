using System;
using SpreadSheet.Commands.Create;
using SpreadSheet.Commands.Insert;
using SpreadSheet.Commands.Select;
using SpreadSheet.Exceptions;

namespace SpreadSheet.Commands
{
    public class CommandParser : ICommandParser
    {
        public ICommand PaserCommand(string input)
        {
            var instruct = input.Substring(0, 1).ToUpper();
            ICommand command = null;
            switch (instruct)
            {
                case "C":
                    command = new CreateCommand();
                    break;
                case "N":
                    command = new InsertCommand();
                    break;
                case "S":
                    command = new SelectCommand();
                    break;
                default:
                    throw new SpreadSheetException("不存在该类型的指令，请重新输入");
            }
            return command;

        }
    }
}

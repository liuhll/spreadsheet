using System;
using System.Collections.Generic;
using System.Text;

namespace SpreadSheet.Commands
{
    public interface ICommandParser
    {
        ICommand PaserCommand(string input);
    }
}

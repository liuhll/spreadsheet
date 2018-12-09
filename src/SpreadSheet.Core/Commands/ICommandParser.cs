namespace SpreadSheet.Commands
{
    public interface ICommandParser
    {
        ICommand PaserCommand(string input);
    }
}
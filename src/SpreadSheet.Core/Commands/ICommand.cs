namespace SpreadSheet.Commands
{
    public interface ICommand
    {
        SpreadSheet Operate(string input, SpreadSheet spreadSheet = null);
    }
}
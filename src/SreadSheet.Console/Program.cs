using SpreadSheet.Commands;
using SpreadSheet.Commands.Create;
using SpreadSheet.Exceptions;
using System;
using System.Threading;

namespace SreadSheet
{
    internal class Program
    {
        private static ICommandParser commandParser = new CommandParser();
        private static SpreadSheet.SpreadSheet globalSpreadSheet;

        private static void Main(string[] args)
        {
            do
            {
                Console.Write("Enter command: ");
                var inputLine = Console.ReadLine();
                if ("Q".Equals(inputLine, StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("Quit the program");
                    Thread.Sleep(1000);
                    break;
                }
                else
                {
                    try
                    {
                        HandleInputCommand(inputLine);
                    }
                    catch (SpreadSheetException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Application error," + ex.Message);
                        Console.WriteLine("Quit the program");
                        Thread.Sleep(1000);
                        break;
                    }
                }
            } while (true);
        }

        private static void HandleInputCommand(string inputLine)
        {
            var handleInput = PreHanleInputLine(inputLine);
            var command = commandParser.PaserCommand(handleInput.Item1);
            if (command is CreateCommand)
            {
                globalSpreadSheet = command.Operate(handleInput.Item2);
                globalSpreadSheet.Out();
            }
            else
            {
                var handleSpreadSheet = command.Operate(handleInput.Item2, globalSpreadSheet);
                handleSpreadSheet.Out();
            }
        }

        private static Tuple<string, string> PreHanleInputLine(string inputLine)
        {
            var command = inputLine.Substring(0, 1);
            var val = inputLine.Substring(2);
            return new Tuple<string, string>(command, val);
        }
    }
}
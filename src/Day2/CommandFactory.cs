using Day2.Commands;
using System;

namespace Day2
{
    public class CommandFactory
    {
        public AbstractCommand CreateCommand(string stringCommand)
        {
            var commandComponents = stringCommand.Split(" ");

            var direction = commandComponents[0];
            var magnitude = int.Parse(commandComponents[1]);

            switch (direction)
            {
                case "up":
                    return new UpCommand(magnitude);
                case "down":
                    return new DownCommand(magnitude);
                case "forward":
                    return new ForwardCommand(magnitude);
            }

            throw new InvalidOperationException();
        }

        public AbstractCommand CreateImprovedCommand(string stringCommand)
        {
            var commandComponents = stringCommand.Split(" ");

            var direction = commandComponents[0];
            var magnitude = int.Parse(commandComponents[1]);

            switch (direction)
            {
                case "up":
                    return new ImprovedUpCommand(magnitude);
                case "down":
                    return new ImprovedDownCommand(magnitude);
                case "forward":
                    return new ImprovedForwardCommand(magnitude);
            }

            throw new InvalidOperationException();
        }
    }
}

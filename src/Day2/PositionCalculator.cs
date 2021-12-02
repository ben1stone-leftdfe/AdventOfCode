using Day2.Commands;
using System.Collections.Generic;

namespace Day2
{
    public class PositionCalculator
    {
        private int _depth = 0;
        private int _horizontal = 0;
        private int _aim = 0;

        private Queue<AbstractCommand> _commands = new Queue<AbstractCommand>();

        public int Area => _depth * _horizontal;

        public void AddCommands(IList<AbstractCommand> commands)
        {
            foreach (var command in commands)
            {
                _commands.Enqueue(command);
            }
        }

        public void ProcessCommands()
        {
            while (_commands.Count > 0)
            {
                var command = _commands.Dequeue();

                ApplyChange(command.CalculateChange(_aim));
            }
        }

        private void ApplyChange(ChangeResult change)
        {
            _depth += change.Depth;
            _horizontal += change.Horizontal;
            _aim += change.Aim;
        }
    }
}

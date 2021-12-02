namespace Day2.Commands
{
    public abstract class AbstractCommand
    {
        public int Magnitude { get; set; }

        public AbstractCommand(int magnitude)
        {
            Magnitude = magnitude;
        }

        public abstract ChangeResult CalculateChange(int? aim);
    }
}

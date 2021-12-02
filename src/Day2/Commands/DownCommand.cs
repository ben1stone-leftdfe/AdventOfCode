namespace Day2.Commands
{
    public class DownCommand : AbstractCommand
    {
        public DownCommand(int magnitude) : base(magnitude)
        {
            Magnitude = magnitude;
        }

        public override ChangeResult CalculateChange(int? aim)
        {
            return new ChangeResult
            {
                Depth = Magnitude
            };
        }
    }
}

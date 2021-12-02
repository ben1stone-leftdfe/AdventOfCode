namespace Day2.Commands
{
    public class ForwardCommand : AbstractCommand
    {
        public ForwardCommand(int magnitude) : base (magnitude)
        {
            Magnitude = magnitude;
        }

        public override ChangeResult CalculateChange(int? aim)
        {
            return new ChangeResult
            {
                Horizontal = Magnitude
            };
        }
    }
}

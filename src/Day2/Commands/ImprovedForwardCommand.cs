namespace Day2.Commands
{
    public class ImprovedForwardCommand : AbstractCommand
    {
        public ImprovedForwardCommand(int magnitude) : base(magnitude)
        {
            Magnitude = magnitude;
        }

        public override ChangeResult CalculateChange(int? aim)
        {
            return new ChangeResult
            {
                Horizontal = Magnitude,
                Depth = aim.Value * Magnitude
            };
        }
    }
}

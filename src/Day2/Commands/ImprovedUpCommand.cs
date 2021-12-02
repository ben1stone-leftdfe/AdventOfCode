namespace Day2.Commands
{
    public class ImprovedUpCommand : AbstractCommand
    {
        public ImprovedUpCommand(int magnitude) : base(magnitude)
        {
            Magnitude = magnitude;
        }

        public override ChangeResult CalculateChange(int? aim)
        {
            return new ChangeResult
            {
                Aim = Magnitude * -1
            };
        }
    }
}

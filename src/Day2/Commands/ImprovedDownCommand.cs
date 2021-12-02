namespace Day2.Commands
{
    public class ImprovedDownCommand : AbstractCommand
    {
        public ImprovedDownCommand(int magnitude) : base(magnitude)
        {
            Magnitude = magnitude;
        }

        public override ChangeResult CalculateChange(int? aim)
        {
            return new ChangeResult
            {
                Aim = Magnitude
            };
        }
    }
}

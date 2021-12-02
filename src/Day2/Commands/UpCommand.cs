namespace Day2.Commands
{
    public class UpCommand : AbstractCommand 
    { 
        public UpCommand(int magnitude) : base(magnitude)
        {
            Magnitude = magnitude;
        }

        public override ChangeResult CalculateChange(int? aim)
        {
            return new ChangeResult
            {
                Depth = Magnitude * -1
            };
        }
    }
}

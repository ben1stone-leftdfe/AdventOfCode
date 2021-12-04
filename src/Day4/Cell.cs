namespace Day4
{
    public class Cell
    {
        public int Value { get; private set; }
        public bool Checked { get; private set; }

        public Cell(int value, bool isChecked)
        {
            Value = value;
            Checked = isChecked;
        }

        public void CheckCell() => Checked = true;
    }
}

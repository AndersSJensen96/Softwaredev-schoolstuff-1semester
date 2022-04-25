namespace calculatorlib
{
	public class Calculator
	{
		public List<object> Values { get; set; } = new List<object> { };
		public int FirstNumber { get; set; }
		public int SecondNumber { get; set; }

		public int Add()
		{
			return FirstNumber + SecondNumber;
		}
		public int Subtract()
		{
			return FirstNumber - SecondNumber;
		}
	}
}
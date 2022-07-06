namespace MultiValueDictionary.Utilities
{
    public class ConsoleUtil : IConsoleUtil
    {
		public void WriteLine(string s)
		{
            Console.WriteLine(s);
		}

		public string? ReadLine()
		{
			Console.Write("> ");
			return Console.ReadLine();
		}
	}
}
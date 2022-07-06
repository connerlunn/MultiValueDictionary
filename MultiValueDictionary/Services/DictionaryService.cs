namespace MultiValueDictionary.Services
{
    using MultiValueDictionary.Managers;
    using MultiValueDictionary.Utilities;
    using System.Collections.Generic;

    public class DictionaryService : IDictionaryService
    {
        public DictionaryService(IDictionaryManager dictionaryManager, IConsoleUtil console)
        {
            DictionaryManager = dictionaryManager;
            Console = console;
        }

        private IConsoleUtil Console { get; }
        private IDictionaryManager DictionaryManager { get; }

        private readonly Dictionary<string, int> commands = new()
        {
            // { <command> , <number of cli arguments> }
            { "add", 3 },
            { "allmembers", 1 },
            { "clear", 1 },
            { "exit", 1 },
            { "items", 1 },
            { "keys", 1 },
            { "keyexists", 2 },
            { "members", 2 },
            { "memberexists", 3 },
            { "remove", 3 },
            { "removeall", 2 },
        };

        private string HowToUseCommand(string command, int argumentCount)
        {
            var output = $"How to use: {command}";
            output = (argumentCount == 2) ? output += " <key>" : output;
            output = (argumentCount == 3) ? output += " <key> <member>" : output;
            return output;
        }

        private List<string>? ValidateInputAndGetResponse(string[] args)
        {
            List<string>? output = new();

            // Check input is not empty and has a command as first argument
            if (args[0] != null && commands.ContainsKey(args[0].ToLower()))
            {
                string command = args[0].ToLower();

                // Check command has correct number of inputs
                if (args.Length == commands[command])
                {
                    // Get Response
                    switch (command)
                    {
                        case "exit":
                            output = null;
                            break;
                        case "add":
                            output = DictionaryManager.Add(args[1], args[2]);
                            break;
                        case "members":
                            output = DictionaryManager.Members(args[1]);
                            break;
                        case "allmembers":
                            output = DictionaryManager.AllMembers();
                            break;
                        case "remove":
                            output = DictionaryManager.Remove(args[1], args[2]);
                            break;
                        case "removeall":
                            output = DictionaryManager.RemoveAll(args[1]);
                            break;
                        case "clear":
                            output = DictionaryManager.Clear();
                            break;
                        case "items":
                            output = DictionaryManager.Items();
                            break;
                        case "keys":
                            output = DictionaryManager.Keys();
                            break;
                        case "memberexists":
                            output = new List<string>() { DictionaryManager.MemberExists(args[1], args[2]).ToString() };
                            break;
                        case "keyexists":
                            output = new List<string>() { DictionaryManager.KeyExists(args[1]).ToString() };
                            break;
                    }
                }
                else
                {
                    output.Add(HowToUseCommand(command, commands[command]));
                }
            }
            else
            {
                output.Add("Use one of the following commands.");
                foreach (string commands in commands.Keys.ToList())
                {
                    output.Add(commands);
                }
            }

            return output;
        }

        public void Run(bool singleLoop = false)
        {
            bool proceed = true;

            while (proceed)
            {
                // Optional way to run the program with only a single loop
                proceed = !singleLoop;

                // Gather input
                string[] consoleArguments = Console.ReadLine()!.Trim().Split(" ");

                // Compute result
                List<string>? output = ValidateInputAndGetResponse(consoleArguments);

                // Display result if output otherwise end program
                if (output != null)
                {
                    foreach (string line in output)
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    proceed = false;
                }
            }
        }
    }
}
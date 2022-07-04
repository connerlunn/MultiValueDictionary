namespace MultiValueDictionary.Services
{
    using MultiValueDictionary.Managers;
    using MultiValueDictionary.DataTypes;
    using System;
    using System.Collections.Generic;

    public class DictionaryService : IDictionaryService
    {
        public DictionaryService(IDictionaryManager dictionaryManager)
        {
            DictionaryManager = dictionaryManager;
        }

        private IDictionaryManager DictionaryManager { get; }

        public void Run()
        {
            bool proceed = true;

            while (proceed)
            {
                //Gather input
                string[] consoleArguments = Console.ReadLine()!.Trim().Split(" ");

                //Compute result
                List<string>? output = ValidateInputAndGetResponse(consoleArguments);

                //Display result if output otherwise end program
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

        private List<string>? ValidateInputAndGetResponse(string[] args)
        {
            List<string>? output = new List<string>();

            //Validate command
            if (args.Length > 0 && Enum.TryParse(args[0].ToUpper(), out Commands command))
            {
                // Validate command inputs and collect output
                switch (command)
                {
                    case Commands.ADD:
                        output = (args.Length == 3) ? DictionaryManager.Add(args[1], args[2])
                            : new List<string> { "Invalid input.", "How to use: ADD <key> <member>" };
                        break;
                    case Commands.MEMBERS:
                        output = (args.Length == 2) ? DictionaryManager.Members(args[1])
                            : new List<string> { "Invalid input.", "How to use: MEMBERS <key>" };
                        break;
                    case Commands.ALLMEMBERS:
                        output = (args.Length == 1) ? DictionaryManager.AllMembers()
                            : new List<string> { "Invalid input.", "How to use: ALLMEMBERS" };
                        break;
                    case Commands.REMOVE:
                        output = (args.Length == 3) ? DictionaryManager.Remove(args[1], args[2])
                            : new List<string> { "Invalid input.", "How to use: REMOVE <key> <member>" };
                        break;
                    case Commands.REMOVEALL:
                        output = (args.Length == 2) ? DictionaryManager.RemoveAll(args[1])
                            : new List<string> { "Invalid input.", "How to use: REMOVEALL <key>" };
                        break;
                    case Commands.CLEAR:
                        output = (args.Length == 1) ? DictionaryManager.Clear()
                            : new List<string> { "Invalid input.", "How to use: CLEAR" };
                        break;
                    case Commands.ITEMS:
                        output = (args.Length == 1) ? DictionaryManager.Items()
                            : new List<string> { "Invalid input.", "How to use: ITEMS" };
                        break;
                    case Commands.KEYS:
                        output = (args.Length == 1) ? DictionaryManager.Keys()
                            : new List<string> { "Invalid input.", "How to use: KEYS" };
                        break;
                    case Commands.KEYEXISTS:
                        output = (args.Length == 2) ? new List<string>() { DictionaryManager.KeyExists(args[1]).ToString() }
                            : new List<string> { "Invalid input.", "How to use: KEYEXISTS <key>" };
                        break;
                    case Commands.MEMBEREXISTS:
                        output = (args.Length == 3) ? new List<string>() { DictionaryManager.MemberExists(args[1], args[2]).ToString() }
                            : new List<string> { "Invalid input.", "How to use: MEMBEREXISTS <key> <member>" };
                        break;
                    case Commands.EXIT:
                        //Trigger exit condition
                        output = null;
                        break;
                    default:
                        break;
                }
            }
            else
            {
                output.Add("Invalid input. Please use one of the following commands.");
                foreach (Commands commands in Enum.GetValues(typeof(Commands)))
                {
                    output.Add(commands.ToString());
                }
            }

            return output;
        }
    }
}
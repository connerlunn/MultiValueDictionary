namespace MultiValueDictionary.Managers
{
    public class DictionaryManager : IDictionaryManager
    {
        public Dictionary<string, List<string>> Dict = new Dictionary<string, List<string>>();

        public List<string> Add(string key, string member)
        {
            var output = new List<string>();

            if (!KeyExists(key))
            {
                Dict.Add(key, new List<string>() { member });
                output.Add("Added");
            }
            else if (!MemberExists(key, member))
            {
                //var members = Dict[key];
                //members.Add(member);
                //Dict.Add(key, members);
                Dict[key].Add(member);
                output.Add("Added");
            }
            else
            {
                output.Add("ERROR, member already exists for key");
            }
            return output;
        }

        public List<string> Remove(string key, string member)
        {
            var output = new List<string>();


            if (!KeyExists(key))
            {
                output.Add("ERROR, key does not exist");
            }
            else if (!MemberExists(key, member))
            {
                output.Add("ERROR, member does not exist");
            }
            else
            {
                Dict[key].Remove(member);

                if (Dict[key].Count == 0)
                {
                    return RemoveAll(key);
                }
            }

            return output;
        }

        public List<string> RemoveAll(string key)
        {
            var output = new List<string>();

            if (KeyExists(key))
            {
                Dict.Remove(key);
                output.Add("Removed");
            }
            else
            {
                output.Add("ERROR, key does not exist");
            }
            return output;
        }

        public List<string> Clear()
        {
            Dict = new Dictionary<string, List<string>>();
            return new List<string>() { "Cleared" };
        }

        public List<string> Keys()
        {
            bool count = (Dict.Keys.Count > 0);
            List<string> keys = Dict.Keys.ToList();

            return (Dict.Keys.Count > 0) ? Dict.Keys.ToList() : new List<string>() { "(empty set)" };
        }

        public bool KeyExists(string key)
        {
            return Dict.ContainsKey(key);
        }

        public List<string> Members(string key)
        {
            var output = new List<string>();

            if (KeyExists(key))
            {
                output.AddRange(Dict[key]);
            }
            else
            {
                output.Add("ERROR, key does not exist");
            }

            return output;
        }

        public bool MemberExists(string key, string member)
        {
            return (KeyExists(key) && Dict[key].Contains(member));
        }

        public List<string> AllMembers()
        {
            var output = new List<string>();

            var dictKeys = Dict.Keys.ToList();

            if (dictKeys.Count > 0)
            {
                foreach (var key in dictKeys)
                {
                    output.AddRange(Dict[key]);
                }
            }
            else
            {
                output.Add("(empty set)");
            }

            return output;
        }

        public List<string> Items()
        {
            var output = new List<string>();

            var dictKeys = Dict.Keys.ToList();

            if (dictKeys.Count > 0)
            {
                output.AddRange(dictKeys);
                foreach (var key in dictKeys)
                {
                    output.AddRange(Dict[key]);
                }
            }
            else
            {
                output.Add("(empty set)");
            }

            return output;
        }
    }
}
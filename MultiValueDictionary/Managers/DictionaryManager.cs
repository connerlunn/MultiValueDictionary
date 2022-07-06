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
                output.Add(") Added");
            }
            else if (!MemberExists(key, member))
            {
                Dict[key].Add(member);
                output.Add(") Added");
            }
            else
            {
                output.Add(") ERROR, member already exists for key");
            }
            return output;
        }

        public List<string> Remove(string key, string member)
        {
            var output = new List<string>();


            if (!KeyExists(key))
            {
                output.Add(") ERROR, key does not exist");
            }
            else if (!MemberExists(key, member))
            {
                output.Add(") ERROR, member does not exist");
            }
            else
            {
                Dict[key].Remove(member);

                if (Dict[key].Count == 0)
                {
                    return RemoveAll(key);
                }

                output.Add(") Removed");
            }

            return output;
        }

        public List<string> RemoveAll(string key)
        {
            var output = new List<string>();

            if (KeyExists(key))
            {
                Dict.Remove(key);
                output.Add(") Removed");
            }
            else
            {
                output.Add(") ERROR, key does not exist");
            }
            return output;
        }

        public List<string> Clear()
        {
            Dict = new Dictionary<string, List<string>>();
            return new List<string>() { ") Cleared" };
        }

        public List<string> Keys()
        {
            var output = new List<string>();

            if (Dict.Keys.Count > 0)
            {
                int i = 1;
                foreach (string key in Dict.Keys.ToList())
                {
                    output.Add($"{i}) {key}");
                    i++;
                }
            }
            else
            {
                output.Add("(empty set)");
            }
            return output;
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
                int i = 1;
                foreach (string member in Dict[key])
                {
                    output.Add($"{i}) {member}");
                    i++;
                }
            }
            else
            {
                output.Add(") ERROR, key does not exist");
            }

            return output;
        }

        public bool MemberExists(string key, string member)
        {
            return KeyExists(key) && Dict[key].Contains(member);
        }

        public List<string> AllMembers()
        {
            var output = new List<string>();

            var dictKeys = Dict.Keys.ToList();

            if (dictKeys.Count > 0)
            {
                int i = 1;
                foreach (var key in dictKeys)
                {
                    foreach (string member in Dict[key])
                    {
                        output.Add($"{i}) {member}");
                        i++;
                    }
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
                int i = 1;
                foreach (var key in dictKeys)
                {
                    foreach (string member in Dict[key])
                    {
                        output.Add($"{i}) {key}: {member}");
                        i++;
                    }
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
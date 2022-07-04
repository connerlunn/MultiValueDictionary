namespace MultiValueDictionary.Managers
{
    public interface IDictionaryManager
    {
        /// <summary>
        /// Adds a member to a collection for a given key. Displays an error if the member already exists for the key.
        /// </summary>
        /// <returns></returns>
        public List<string> Add(string key, string member);

        /// <summary>
        /// Removes a member from a key. If the last member is removed from the key, the key is removed from the dictionary. If the key or member does not exist, displays an error.
        /// </summary>
        /// <returns></returns>
        public List<string> Remove(string key, string member);

        /// <summary>
        /// Removes all members for a key and removes the key from the dictionary. Returns an error if the key does not exist.
        /// </summary>
        /// <returns></returns>
        public List<string> RemoveAll(string key);

        /// <summary>
        /// Removes all keys and all members from the dictionary.
        /// </summary>
        /// <returns></returns>
        public List<string> Clear();

        /// <summary>
        /// Returns all the keys in the dictionary. Order is not guaranteed.
        /// </summary>
        /// <returns></returns>
        public List<string> Keys();

        /// <summary>
        /// Returns whether a key exists or not.
        /// </summary>
        /// <returns></returns>
        public bool KeyExists(string key);

        /// <summary>
        /// Returns the collection of strings for the given key. Return order is not guaranteed. Returns an error if the key does not exist.
        /// </summary>
        /// <returns></returns>
        public List<string> Members(string key);

        /// <summary>
        /// Returns whether a member exists within a key. Returns false if the key does not exist.
        /// </summary>
        /// <returns></returns>
        public bool MemberExists(string key, string member);

        /// <summary>
        /// Returns all the members in the dictionairy. Returns nothing if there are none. Order is not guaranteed.
        /// </summary>
        /// <returns></returns>
        public List<string> AllMembers();

        /// <summary>
        /// Returns all keys in the dictionary and all of their members. Returns nothing if there are none. Order is not guarenteed.
        /// </summary>
        /// <returns></returns>
        public List<string> Items();
    }
}
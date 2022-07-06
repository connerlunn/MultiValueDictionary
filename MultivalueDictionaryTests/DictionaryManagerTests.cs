namespace MultiValueDIctionaryTests
{
    using MultiValueDictionary.Managers;
    using System.Diagnostics.CodeAnalysis;

    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DictionaryManagerTests
    {
        [TestMethod]
        public void Add_Succeeds()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();

            //Act
            var response1 = dictionaryManager.Add("a", "b");
            var response2 = dictionaryManager.Add("a", "c");
            var response3 = dictionaryManager.Add("b", "a");

            //Assert
            Assert.IsTrue(dictionaryManager.Dict.ContainsKey("a"));
            Assert.IsTrue(dictionaryManager.Dict.ContainsKey("b"));
            Assert.IsTrue(dictionaryManager.Dict["a"].Contains("b"));
            Assert.IsTrue(dictionaryManager.Dict["a"].Contains("c"));
            Assert.IsTrue(response1[0] == ") Added");
            Assert.IsTrue(response2[0] == ") Added");
            Assert.IsTrue(response3[0] == ") Added");
        }

        [TestMethod]
        public void Add_MemberExists()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();

            //Act
            var response1 = dictionaryManager.Add("a", "b");
            var response2 = dictionaryManager.Add("a", "b");

            //Assert
            Assert.IsTrue(response1[0] == ") Added");
            Assert.IsTrue(response2[0] == ") ERROR, member already exists for key");
        }

        [TestMethod]
        public void Keys_Succeeds()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();
            dictionaryManager.Dict.Add("a", new List<string>() { "b" });
            dictionaryManager.Dict.Add("b", new List<string>() { "a" });

            //Act
            var response = dictionaryManager.Keys();

            //Assert
            Assert.IsTrue(response[0] == "1) a" && response[1] == "2) b");
        }

        [TestMethod]
        public void Keys_EmptySet()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();

            //Act
            var response = dictionaryManager.Keys();

            //Assert
            Assert.IsTrue(response[0] == "(empty set)");
        }

        [TestMethod]
        public void Members_Succeeds()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();
            dictionaryManager.Dict.Add("a", new List<string>() { "a", "b" });

            //Act
            var response = dictionaryManager.Members("a");

            //Assert
            Assert.IsTrue(response.Contains("1) a") && response.Contains("2) b"));
        }

        [TestMethod]
        public void Members_KeyDoesNotExist()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();

            //Act
            var response = dictionaryManager.Members("a");

            //Assert
            Assert.IsTrue(response[0] == ") ERROR, key does not exist");
        }

        [TestMethod]
        public void Remove_Succeeds()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();
            dictionaryManager.Dict.Add("a", new List<string>() { "a", "b" });

            //Act
            var response = dictionaryManager.Remove("a", "a");

            //Assert
            Assert.IsTrue(response[0] == ") Removed");
        }

        [TestMethod]
        public void Remove_RemovesKeyIfLastMember()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();
            dictionaryManager.Dict.Add("a", new List<string>() { "a" });

            //Act
            var response = dictionaryManager.Remove("a", "a");

            //Assert
            Assert.IsTrue(response[0] == ") Removed");
            Assert.IsFalse(dictionaryManager.Dict.ContainsKey("a"));
        }

        [TestMethod]
        public void Remove_KeyDoesNotExist()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();

            //Act
            var response = dictionaryManager.Remove("a", "a");

            //Assert
            Assert.IsTrue(response[0] == ") ERROR, key does not exist");
        }

        [TestMethod]
        public void Remove_MemberDoesNotExist()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();
            dictionaryManager.Dict.Add("a", new List<string>() { "b" });

            //Act
            var response = dictionaryManager.Remove("a", "a");

            //Assert
            Assert.IsTrue(response[0] == ") ERROR, member does not exist");
        }

        [TestMethod]
        public void RemoveAll_Succeeds()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();
            dictionaryManager.Dict.Add("a", new List<string>() { "a", "b" });

            //Act
            var response = dictionaryManager.RemoveAll("a");

            //Assert
            Assert.IsTrue(response[0] == ") Removed");
            Assert.IsTrue(dictionaryManager.Dict.Keys.Count == 0);
        }

        [TestMethod]
        public void RemoveAll_KeyDoesNotExist()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();

            //Act
            var response = dictionaryManager.RemoveAll("a");

            //Assert
            Assert.IsTrue(response[0] == ") ERROR, key does not exist");
        }

        [TestMethod]
        public void Clear_Succeeds()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();
            dictionaryManager.Dict.Add("a", new List<string>() { "b" });
            dictionaryManager.Dict.Add("b", new List<string>() { "a" });

            //Act
            var response = dictionaryManager.Clear();

            //Assert
            Assert.IsTrue(response[0] == ") Cleared");
            Assert.IsTrue(dictionaryManager.Dict.Keys.Count == 0);
        }

        [TestMethod]
        public void KeyExists_Returns_True()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();
            dictionaryManager.Dict.Add("a", new List<string>() { "b" });

            //Act
            var response = dictionaryManager.KeyExists("a");

            //Assert
            Assert.IsTrue(response);
        }

        [TestMethod]
        public void KeyExists_Returns_False()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();
            dictionaryManager.Dict.Add("a", new List<string>() { "b" });

            //Act
            var response = dictionaryManager.KeyExists("b");

            //Assert
            Assert.IsFalse(response);
        }

        [TestMethod]
        public void MemberExists_Returns_True()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();
            dictionaryManager.Dict.Add("a", new List<string>() { "b" });

            //Act
            var response = dictionaryManager.MemberExists("a", "b");

            //Assert
            Assert.IsTrue(response);
        }

        [TestMethod]
        public void MemberExists_Returns_False()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();
            dictionaryManager.Dict.Add("a", new List<string>() { "b" });

            //Act
            var response = dictionaryManager.MemberExists("a", "a");

            //Assert
            Assert.IsFalse(response);
        }

        [TestMethod]
        public void AllMembers_Succeeds()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();
            dictionaryManager.Dict.Add("a", new List<string>() { "a", "b" });
            dictionaryManager.Dict.Add("b", new List<string>() { "c" });

            //Act
            var response = dictionaryManager.AllMembers();

            //Assert
            Assert.IsTrue(response.Contains("1) a") && response.Contains("2) b") && response.Contains("3) c"));
        }


        [TestMethod]
        public void AllMembers_EmptySet()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();

            //Act
            var response = dictionaryManager.AllMembers();

            //Assert
            Assert.IsTrue(response[0] == "(empty set)");
        }

        [TestMethod]
        public void Items_Succeeds()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();
            dictionaryManager.Dict.Add("a", new List<string>() { "b", "c" });

            //Act
            var response = dictionaryManager.Items();

            //Assert
            Assert.IsTrue(response.Contains("1) a: b"));
            Assert.IsTrue(response.Contains("2) a: c"));
        }


        [TestMethod]
        public void Items_EmptySet()
        {
            //Arrange
            var dictionaryManager = new DictionaryManager();

            //Act
            var response = dictionaryManager.Items();

            //Assert
            Assert.IsTrue(response[0] == "(empty set)");
        }
    }
}
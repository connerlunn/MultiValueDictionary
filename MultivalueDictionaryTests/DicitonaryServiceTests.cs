using MultiValueDictionary.Services;
using System.Diagnostics.CodeAnalysis;
using MultiValueDictionary.Managers;
using Moq;
using MultiValueDictionary.Utilities;

namespace MultivalueDictionaryTests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class DicitonaryServiceTests
    {
        [TestMethod]
        public void Run_ExitCommandStopsRun()
        {
            // Arrange
            var mockConsoleUtil = new Mock<IConsoleUtil>();
            mockConsoleUtil.Setup(t => t.ReadLine()).Returns("exit");

            // Assert
            var dictionaryService = new DictionaryService(new DictionaryManager(), mockConsoleUtil.Object);

            dictionaryService.Run(false);

            // Assert
            // This may seem like a pointless test but if EXIT command
            // is not working properly then dictionaryService.Run(false) will
            // not finish and never reach this Assert
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void Run_CommandDoesNotExist()
        {
            // Arrange
            var mockConsoleUtil = new Mock<IConsoleUtil>();
            mockConsoleUtil.Setup(t => t.ReadLine()).Returns("");

            // Assert
            var dictionaryService = new DictionaryService(new DictionaryManager(), mockConsoleUtil.Object);

            dictionaryService.Run(true);

            // Assert
            mockConsoleUtil.Verify(t => t.WriteLine("Use one of the following commands."), Times.Once());
            mockConsoleUtil.Verify(t => t.WriteLine($"add"), Times.Once());
            mockConsoleUtil.Verify(t => t.WriteLine($"allmembers"), Times.Once());
            mockConsoleUtil.Verify(t => t.WriteLine($"clear"), Times.Once());
            mockConsoleUtil.Verify(t => t.WriteLine($"exit"), Times.Once());
            mockConsoleUtil.Verify(t => t.WriteLine($"items"), Times.Once());
            mockConsoleUtil.Verify(t => t.WriteLine($"keys"), Times.Once());
            mockConsoleUtil.Verify(t => t.WriteLine($"keyexists"), Times.Once());
            mockConsoleUtil.Verify(t => t.WriteLine($"members"), Times.Once());
            mockConsoleUtil.Verify(t => t.WriteLine($"memberexists"), Times.Once());
            mockConsoleUtil.Verify(t => t.WriteLine($"remove"), Times.Once());
            mockConsoleUtil.Verify(t => t.WriteLine($"removeall"), Times.Once());
        }

        [TestMethod]
        public void Run_HowToUseCommands()
        {
            // Arrange
            var mockConsoleUtil = new Mock<IConsoleUtil>();
            mockConsoleUtil.SetupSequence(t => t.ReadLine())
                .Returns("add")
                .Returns("allmembers a")
                .Returns("keyexists")
                .Returns("exit");

            // Assert
            var dictionaryService = new DictionaryService(new DictionaryManager(), mockConsoleUtil.Object);

            dictionaryService.Run(false);

            // Assert
            mockConsoleUtil.Verify(t => t.WriteLine($"How to use: add <key> <member>"), Times.Once());
            mockConsoleUtil.Verify(t => t.WriteLine($"How to use: allmembers"), Times.Once());
            mockConsoleUtil.Verify(t => t.WriteLine($"How to use: keyexists <key>"), Times.Once());
        }
    }
}
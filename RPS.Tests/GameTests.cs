using System;
using NUnit.Framework;
using Moq;

using RPS.Classes;
using RPS.Enums;
using RPS.Interfaces;

namespace RPS.Tests
{
    public class GameTests
    {        
        private Mock<IMessageWriter> _mockMessageWriter;
        private Mock<IMenuResponder> _mockMenuResponder;
        private Mock<IPlayAgainResponder> _mockPlayAgainResponder;

        [SetUp]
        public void Setup()
        {
            _mockMessageWriter = new Mock<IMessageWriter>();

            _mockMenuResponder = new Mock<IMenuResponder>();
            _mockMenuResponder.Setup(x => x.GetMenuChoice())
                .Returns(MenuChoices.StartGame);                

            _mockPlayAgainResponder = new Mock<IPlayAgainResponder>();
            _mockPlayAgainResponder.Setup(x => x.GetResponse()).Returns(false);
        }

        [Test]
        public void VerifyTwoNilAndGameOver()
        {
            var mockHumanPlayer = new Mock<IPlayer>();
            mockHumanPlayer.Setup(p => p.GetChoice()).Returns(RoundChoices.Paper);

            var mockAutoPlayer = new Mock<IPlayer>();
            mockAutoPlayer.Setup(p => p.GetChoice()).Returns(RoundChoices.Rock);

            var game = new Game(_mockMessageWriter.Object, _mockMenuResponder.Object, new RoundAssessor(), mockHumanPlayer.Object, mockAutoPlayer.Object, _mockPlayAgainResponder.Object);

            game.ShowMenu();

            Assert.AreEqual(0, game.Ties);
            Assert.AreEqual(2, game.P1Score);
            Assert.AreEqual(0, game.P2Score);
            Assert.AreEqual(true, game.GameOver);
        }

        [Test]
        public void VerifyNilNilAndGameOver()
        {
            var mockPlayer = new Mock<IPlayer>();
            mockPlayer.Setup(p => p.GetChoice()).Returns(RoundChoices.Paper);

            var game = new Game(_mockMessageWriter.Object, _mockMenuResponder.Object, new RoundAssessor(), mockPlayer.Object, mockPlayer.Object, _mockPlayAgainResponder.Object);

            game.ShowMenu();

            Assert.AreEqual(3, game.Ties);
            Assert.AreEqual(0, game.P1Score);
            Assert.AreEqual(0, game.P2Score);
            Assert.AreEqual(true, game.GameOver);
        }
    }
}

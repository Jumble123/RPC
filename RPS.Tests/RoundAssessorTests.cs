using NUnit.Framework;

using RPS.Classes;
using RPS.Enums;

namespace RPS.Tests
{
    public class RoundAssessorTests
    {
        private RoundAssessor assessor;

        [SetUp]
        public void Setup()
        {
            assessor = new RoundAssessor();
        }

        [Test]
        public void P1RockBeatsP2Scissors()
        {            
            var actual = assessor.Assess(RoundChoices.Rock, RoundChoices.Scissors);
            Assert.AreEqual(RoundOutcomes.Player1Win, actual);
        }

        [Test]
        public void P2RockBeatsP1Scissors()
        {            
            var actual = assessor.Assess(RoundChoices.Scissors, RoundChoices.Rock);
            Assert.AreEqual(RoundOutcomes.Player2Win, actual);
        }

        [Test]
        public void P1PaperBeatsP2Rock()
        {            
            var actual = assessor.Assess(RoundChoices.Paper, RoundChoices.Rock);
            Assert.AreEqual(RoundOutcomes.Player1Win, actual);
        }

        [Test]
        public void P2PaperBeatsP1Rock()
        {            
            var actual = assessor.Assess(RoundChoices.Rock, RoundChoices.Paper);
            Assert.AreEqual(RoundOutcomes.Player2Win, actual);
        }

        [Test]
        public void P1ScissorsBeatsP2Paper()
        {            
            var actual = assessor.Assess(RoundChoices.Scissors, RoundChoices.Paper);
            Assert.AreEqual(RoundOutcomes.Player1Win, actual);
        }

        [Test]
        public void P2ScissorsBeatsP1Paper()
        {            
            var actual = assessor.Assess(RoundChoices.Paper, RoundChoices.Scissors);
            Assert.AreEqual(RoundOutcomes.Player2Win, actual);
        }

        [Test]
        public void RockTied()
        {            
            var actual = assessor.Assess(RoundChoices.Rock, RoundChoices.Rock);
            Assert.AreEqual(RoundOutcomes.Tie, actual);
        }

        [Test]
        public void PaperTied()
        {            
            var actual = assessor.Assess(RoundChoices.Paper, RoundChoices.Paper);
            Assert.AreEqual(RoundOutcomes.Tie, actual);
        }

        [Test]
        public void ScissorsTied()
        {            
            var actual = assessor.Assess(RoundChoices.Scissors, RoundChoices.Scissors);
            Assert.AreEqual(RoundOutcomes.Tie, actual);
        }

        [Test]
        public void Player1QuitInvalidatesRound()
        {
            var actual = assessor.Assess(RoundChoices.Quit, RoundChoices.Scissors);
            Assert.AreEqual(RoundOutcomes.Invalid, actual);
        }

        [Test]
        public void Player2QuitInvalidatesRound()
        {
            var actual = assessor.Assess(RoundChoices.Scissors, RoundChoices.Quit);
            Assert.AreEqual(RoundOutcomes.Invalid, actual);
        }

        [Test]
        public void BothPlayersQuitInvalidatesRound()
        {
            var actual = assessor.Assess(RoundChoices.Quit, RoundChoices.Quit);
            Assert.AreEqual(RoundOutcomes.Invalid, actual);
        }

    }
}
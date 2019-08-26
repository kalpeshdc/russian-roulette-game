using RussianRoulette;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestWins()
        {
            GamePlay.TotalWins = 1;
            GamePlay.Win();

            Assert.AreEqual(2, GamePlay.TotalWins);
        }

        [TestMethod]
        public void TestLoss()
        {
            GamePlay.TotalLosses = 1;
            GamePlay.Loss();

            Assert.AreEqual(2, GamePlay.TotalLosses);
        }

        [TestMethod]
        public void TestTotalShots()
        {
            GamePlay gamePlay = new GamePlay();
            gamePlay.LoadGun();
            gamePlay.SpinGun();

            int totalShots = 0;

            while (true)
            {
                totalShots++;
                if (gamePlay.IsShotFired())
                {
                    break;
                }
            }

            bool result = totalShots <= 6 && totalShots > 0;

            Assert.IsTrue(result);
        }
    }
}

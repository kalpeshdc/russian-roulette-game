using System;
using DSD_01;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DsdUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            RussianRoulette russianRoulette = new RussianRoulette();
            russianRoulette.SpinChamber();
            russianRoulette.LoadGun();
            Assert.IsTrue(russianRoulette.IsGunSpunAndLoaded());
        }

        [TestMethod]
        public void TestMaxAwayChoices()
        {
            RussianRoulette russianRoulette = new RussianRoulette();
            russianRoulette.SpinChamber();
            russianRoulette.LoadGun();
            russianRoulette.PlayArea = new DSD_01.view.PlayArea();

            int awayChoices = 0;

            while (true)
            {
                awayChoices++;
                if (russianRoulette.FireShot(true))
                {
                    break;
                }
            }

            bool result = awayChoices <= 2;

            Assert.IsTrue(result);
        }
    }
}

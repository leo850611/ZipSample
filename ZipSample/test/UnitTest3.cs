using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework.Internal.Commands;

namespace ZipSample.test
{
    [TestClass]
    public class UnitTest3
    {
        [TestMethod]
        public void BetToBetDtoPass()
        {
            var bet = new Bet()
            {
                ID = 1,
                Stake = 2,
                CreateDate = DateTime.MaxValue
            };
            var betDto = ToBetDto(bet, (x) => new BetDto(){
                BetId = x.ID,
                Amonut = (int)x.Stake,
                Date = x.CreateDate.ToString()
            });

            Assert.AreEqual(1, betDto.BetId);
            Assert.AreEqual(2, betDto.Amonut);
            Assert.AreEqual(DateTime.MaxValue.ToString(), betDto.Date);
        }

        private BetDto ToBetDto(Bet bet, Func<Bet, BetDto>func)
        {
            return func(bet);
        }
    }

    public class BetDto
    {
        public int BetId { get; set; }
        public string Date { get; set; }
        public int Amonut { get; set; }
    }

    public class Bet
    {
        public int ID { get; set; }
        public decimal Stake { get; set; }
        public DateTime CreateDate { get; set; }
    }
}

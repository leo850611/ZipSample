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
                CreateDate = DateTime.MaxValue,
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

        [TestMethod]
        public void BetToBetDtoPass2()
        {
            var bet = new Bet()
            {
                ID = 1,
                Stake = 2,
                CreateDate = DateTime.MaxValue
            };
            var betDto = ToBetDto(bet, new BetMapper());

            Assert.AreEqual(1, betDto.BetId);
            Assert.AreEqual(2, betDto.Amonut);
            Assert.AreEqual(DateTime.MaxValue.ToString(), betDto.Date);
        }

        [TestMethod]
        public void BetToBetDtoPass3()
        {
            var bet = new Bet()
            {
                ID = 1,
                Stake = 2,
                CreateDate = DateTime.MaxValue,
                Status = "R",
            };
            var betDto = ToBetDto<Bet, BetDto>(bet);

            Assert.AreEqual(1, betDto.BetId);
            Assert.AreEqual(2, betDto.Amonut);
            Assert.AreEqual(DateTime.MaxValue.ToString(), betDto.Date);
        }



        private TResult ToBetDto<TSource, TResult>(TSource source)
        {
            foreach (var propertyInfo in source.GetType().GetProperties())
            {
                source.GetType().GetProperty(propertyInfo.Name).SetValue(source, null);
            }

            return ;
        }

        private TResult ToBetDto<TSource, TResult>(TSource bet, IBetMapper<TSource, TResult> betMapper)
        {
            return betMapper.Translate(bet);
        }

        private TResult ToBetDto<TSource, TResult>(TSource bet, Func<TSource, TResult>func)
        {
            return func(bet);
        }
    }

    public class BetMapper : IBetMapper<Bet, BetDto>
    {
        public BetDto Translate(Bet bet)
        {
            return new BetDto()
            {
                BetId = bet.ID,
                Amonut = (int) bet.Stake,
                Date = bet.CreateDate.ToString()
            };
        }
    }

    public interface IBetMapper<TSource, TResult>
    {
        TResult Translate(TSource bet);
    }

    public class BetDto
    {
        public int BetId { get; set; }
        public string Date { get; set; }
        public int Amonut { get; set; }
        public string Status { get; set; }
    }

    public class Bet
    {
        public int ID { get; set; }
        public decimal Stake { get; set; }
        public DateTime CreateDate { get; set; }
        public string Status { get; set; }
    }
}

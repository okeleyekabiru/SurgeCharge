using System;
using System.Collections.Generic;
using Xunit;
using TransactionSurgeFee.BusinessLogic;
using TransactionSurgeFee.Model;

namespace SurChargeTest
{
    public class SurChargeTransaction
    {
        public readonly FeesCharges _actual;
        public readonly Func<FeesCharges> _actualFunc;
        public SurChargeTransaction()
        {
            _actual = Configuration.GetFeeSection();
            _actualFunc = Configuration.GetFeeSection;
        }
        [Fact]
        public void ConfigurationReaderTest()
        {
       
            Assert.Collection(_actual.Fees,
                item =>
                {
                    Assert.Equal( 1, item.MinAmount);
                    Assert.Equal(5000, item.MaxAmount);
                    Assert.Equal( 10, item.FeeAmount);
                },
                item =>
                {
                    Assert.Equal(5001, item.MinAmount);
                    Assert.Equal(50000, item.MaxAmount);
                    Assert.Equal(25, item.FeeAmount);
                },
                item =>
                {
                    Assert.Equal(50001, item.MinAmount);
                    Assert.Equal(999999999, item.MaxAmount);
                    Assert.Equal(50, item.FeeAmount);
                });
        }

        [Fact]
        public void ChargesTestBelowFiveThousand()
        {
            var actual = ApplyCharges.AmountToPay(_actualFunc, 4990);
            var expected = 5000;
            Assert.Equal(expected,actual);
        }

        [Fact]
        public void ChargesTestBelowFiftyThousand()
        {
            var actual = ApplyCharges.AmountToPay(_actualFunc, 44975);
            var expected = 45000;
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void ChargesTestAboveFiftyThousand()
        {
            var actual = ApplyCharges.AmountToPay(_actualFunc,49980);
            var expected = 50030;
            Assert.Equal(expected, actual);
        }
    }
    }

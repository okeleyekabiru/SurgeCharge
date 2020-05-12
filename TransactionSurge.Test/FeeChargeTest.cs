using System;
using Xunit;

namespace TransactionSurge.Test
{
    public class FeeChargeTest
    {
     
            private readonly FeesCharges _configuration;

            public FeeChargeTest()
            {
                _configuration
            }

            [Theory, InlineData(5000), InlineData(4990), InlineData(1), InlineData(3000), InlineData(2230),
             InlineData(3200)]
            public void TestForChargesBelowFiveThousand(double value)
            {
                var result = ApplyCharges.AmountToPay(_configuration, value);
                var expected = 10;
                Assert.Equal(expected, result);

            }
        }
    }

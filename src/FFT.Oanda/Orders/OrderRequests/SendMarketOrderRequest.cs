using FFT.Oanda.Orders.OrderRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WalkerBrokerFftV2018.Orders.OrderRequests
{
    public class SendMarketOrderRequest
    {
        public MarketOrderRequest order { get; private set; }

        public SendMarketOrderRequest (MarketOrderRequest orderIn)
        {
            order = orderIn;
        }
    }
}

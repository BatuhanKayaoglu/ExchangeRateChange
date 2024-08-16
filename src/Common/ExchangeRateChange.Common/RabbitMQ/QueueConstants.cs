using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExchangeRateChange.Common.RabbitMQ
{
    public class QueueConstants
    {
        public const string RabbitMQHost = "amqps://yjmbpqsn:omJw2L1EuhX1D2JVvfneg_ZC8W1mqkBz@fish.rmq.cloudamqp.com/yjmbpqsn";
        //public const string RabbitMQHost = "amqp://guest:guest@localhost:5672/";
        public const string RabbitMQHostUri = "localhost";
        public const string DefaultExchangeType = "direct";

        // for push exchange event  
        public const string ExchangeRateExchangeName = "ExchangeRateExchange";
        public const string CreateExchangeRateQueueName = "CreateExchangeRateQueue";

        // for consume exchange event   
        public const string InstantCurrencyRateQueueName = "instant_currency_rate_queue";     

    }
}

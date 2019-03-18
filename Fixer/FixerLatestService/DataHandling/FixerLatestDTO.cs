using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fixer.FixerLatestService.DataHandling;
using Newtonsoft.Json;

namespace Fixer.FixerLatestService.DataHandiling
{
    public class FixerLatestDTO
    {
        public LatestRatesRoot LatestRates { get; set; }
        public Rates rates { get; set; }

        public void DeserializeLatestRates(string LatestRatesResponse)
        {
            LatestRates = JsonConvert.DeserializeObject<LatestRatesRoot>(LatestRatesResponse);
            rates = LatestRates.rates;
        }

    }
}

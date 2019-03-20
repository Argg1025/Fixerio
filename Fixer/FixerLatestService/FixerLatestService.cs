using System;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using Fixer.FixerLatestService.HTTPManager;
using Fixer.FixerLatestService.DataHandiling;
using Fixer.FixerLatestService.DataHandling;
using System.Reflection;

namespace Fixer.FixerLatestServices
{
    public class FixerLatestService
    {
        // Call manager
        public FixerLatestCallManager fixerLatestCallManager = new FixerLatestCallManager();
        // Data Transfer Object (DTO)
        public FixerLatestDTO fixerLatestDTO = new FixerLatestDTO();
        public Rates ratesObject = new Rates();

        public JObject LatestRatesJson;
        public JObject AllRates;
        public FixerLatestService()
        {
            fixerLatestDTO.DeserializeLatestRates(fixerLatestCallManager.GetLatestRates());
            LatestRatesJson = JObject.Parse(fixerLatestCallManager.GetLatestRates());
            AllRates = JObject.Parse(LatestRatesJson["rates"].ToString());
        }
        public int RatesCount()
        {
            return AllRates.Count;
        }

        public bool CheckFloats()
        {
            foreach (PropertyInfo propertyInfo in ratesObject.GetType().GetRuntimeProperties())
            {
                if (propertyInfo.PropertyType != typeof(float)) return false;
            }
            return true;
        }

       
       

    }
}

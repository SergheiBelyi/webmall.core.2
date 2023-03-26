using System;
using System.Collections.Generic;
using System.Linq;

namespace ValmiStore.Model.Entities
{
    [Serializable]
    public class WareProperty
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public List<string> AvailableValues { get; set; }
        public int Importance { get; set; }
        public int ControlType { get; set; }

        public string AvailableValuesString
        {
            get { return AvailableValues.Aggregate("", (current, item) => current + (item + "|")); }
            set
            {
                if (value != null)
                {
                    // Снято по запросу П. Мельника от 14.02.2013
                    //var tmpAvailableValues = value.Split('|').Where(i => !String.IsNullOrEmpty(i)).Take(10).ToList();
                    var tmpAvailableValues = value.Split('|').Where(i => !string.IsNullOrEmpty(i)).ToList();
                    foreach (var item in tmpAvailableValues)
                        AvailableValues.Add(item.Trim());
                }
                else
                    AvailableValues = new List<string>();
            }
        }

        public WareProperty()
        {
            AvailableValues = new List<string>();
        }
    }
}
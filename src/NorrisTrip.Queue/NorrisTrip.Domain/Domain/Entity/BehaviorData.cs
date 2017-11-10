using System;
using System.Collections.Generic;

namespace NorrisTrip.Domain.Domain.Entity
{
    public class BehaviorData
    {
        public DateTime Created { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string UserAgent { get; set; }

        public string Referrer { get; set; }

        public string IP { get; set; }

        public IDictionary<string,string> DataBag { get; set; }
    }
}
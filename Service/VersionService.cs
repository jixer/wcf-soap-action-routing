using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using BBC.Practice.WCF.Routing.Contract;

namespace BBC.Practice.WCF.Routing
{
    public class VersionServiceV1 : IVersionServiceV1
    {
        public string GetVersion()
        {
            return "This is version 1.0";
        }
    }

    public class VersionServiceV2 : IVersionServiceV2
    {
        public string GetVersion()
        {
            return "This is version 2.0";
        }
    }
}

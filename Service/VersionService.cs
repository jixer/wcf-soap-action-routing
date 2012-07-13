using BBC.Practice.WCF.Routing.Contract;

namespace BBC.Practice.WCF.Routing
{
    /*  Here we are creating the logic behind our Version one service.  In a real world 
    *  scenario this service wouldn't actually be named V1.  It would be versioned using other mechanisms
    *  that would most likely include a source control system and .NET assembly versioning 
    *  Note that this service inherits from IVersionService1.  If you recall, this has a Namespace that contains the "v1" text */
    public class VersionServiceV1 : IVersionServiceV1
    {
        // To assist with this proof of concept, the service's main 
        // operation will return a text specifying that it is version 1
        public string GetVersion()
        {
            return "This is version 1.0";
        }
    }

    /*  Here we are creating the logic behind our Version two service.
    *  Note that this service inherits from IVersionService2.  IVersionService2 has a Namespace that contains the "v2" text */
    public class VersionServiceV2 : IVersionServiceV2
    {
        // This will simply return a text specifying that it is version 2
        public string GetVersion()
        {
            return "This is version 2.0";
        }
    }
}

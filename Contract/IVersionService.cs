using System.ServiceModel;

namespace BBC.Practice.WCF.Routing.Contract
{
    /*  This interface reflects the contract for version 1 of the service implementation.  In a real world 
     *  scenario this interface wouldn't actually be named V1.  It would be versioned using other mechanisms
     *  that would most likely include a source control system and .NET assembly versioning 
     *  Note that the Namespace contains the "v1" text.  This is what our routing service will use to route the request */
    [ServiceContract(Name = "Version", Namespace = "http://services.bloggedbychris.com/practice/routing/v1/")]
    public interface IVersionServiceV1
    {
        [OperationContract]
        string GetVersion();
    }

    /*  This interface reflects the contract for version 2 of the service implementation.
     *  Note that the Namespace contains the "v2" text.  This is what our routing service will use to route the request */
    [ServiceContract(Name = "Version", Namespace = "http://services.bloggedbychris.com/practice/routing/v2/")]
    public interface IVersionServiceV2
    {
        [OperationContract]
        string GetVersion();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;

namespace BBC.Practice.WCF.Routing.Contract
{
    [ServiceContract(Name = "Version", Namespace = "http://services.bloggedbychris.com/practice/routing/v1/")]
    public interface IVersionServiceV1
    {
        [OperationContract]
        string GetVersion();
    }

    [ServiceContract(Name = "Version", Namespace = "http://services.bloggedbychris.com/practice/routing/v2/")]
    public interface IVersionServiceV2
    {
        [OperationContract]
        string GetVersion();
    }
}

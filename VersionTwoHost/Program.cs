using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using BBC.Practice.WCF.Routing.Contract;

namespace BBC.Practice.WCF.Routing.Host
{
    class Program
    {
        // In this tutorial, the services are hosted using a console application to avoid over-complicating the routing 
        // proof of concept with complex IIS, hosting, and web.config configurations.
        static void Main(string[] args)
        {
            // note that the base address is provided to the service host.  This is necessary in order to implement
            // the ServiceMetadata behavior
            using (var host = new ServiceHost(typeof(VersionServiceV2), new Uri("http://localhost:9092/routing/")))
            {
                // In this step, we create an BasicHttp binding endpoint that will be used by the hosting interface to 
                // expose the version 2 service.  It will be hosted on port 9092 with the same relative path as our version 1
                // service
                ContractDescription contract = ContractDescription.GetContract(typeof(IVersionServiceV2));
                Binding binding = new BasicHttpBinding();
                var endpointAddress = new EndpointAddress("http://localhost:9092/routing/version/");
                var endpoint = new ServiceEndpoint(contract, binding, endpointAddress);
                host.AddServiceEndpoint(endpoint);


                // Here we add a ServiceMetaData behavior.  This enables us to reach the service's auto-gen'd WSDL via 
                // the base address + "?wsdl"   http://localhost:9092/routing/?wsdl
                var metaDataBehavior = new ServiceMetadataBehavior { HttpGetEnabled = true };
                host.Description.Behaviors.Add(metaDataBehavior);

                // Open the ServiceHost to create listeners         
                // and start listening for messages.
                host.Open();

                // The service can now be accessed.
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}

using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using BBC.Practice.WCF.Routing.Contract;

namespace BBC.Practice.WCF.Routing.Host
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var host = new ServiceHost(typeof(VersionServiceV1), new Uri("http://localhost:9091/routing/")))
            {
                ContractDescription contract = ContractDescription.GetContract(typeof(IVersionServiceV1));
                Binding binding = new BasicHttpBinding();
                var endpointAddress = new EndpointAddress("http://localhost:9091/routing/version/");
                var endpoint = new ServiceEndpoint(contract, binding, endpointAddress);
                host.AddServiceEndpoint(endpoint);

                var metaDataBehavior = new ServiceMetadataBehavior {HttpGetEnabled = true};
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

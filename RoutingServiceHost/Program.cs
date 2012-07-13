using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Routing;

namespace BBC.Practice.WCF.Routing.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(RoutingService)))
            {
                ContractDescription contract = ContractDescription.GetContract(typeof(IRequestReplyRouter));
                Binding binding = new BasicHttpBinding();
                var endpointAddress = new EndpointAddress("http://localhost:9093/routing/");
                var endpoint = new ServiceEndpoint(contract, binding, endpointAddress);
                host.AddServiceEndpoint(endpoint);

                var routingConfiguration = new RoutingConfiguration();

                var v1Filter = new ActionMessageFilter(@"http://services.bloggedbychris.com/practice/routing/v1/Version/GetVersion");
                var v1Endpoint = new [] {new ServiceEndpoint(contract, new BasicHttpBinding(), new EndpointAddress("http://localhost:9091/routing/version/"))};
                routingConfiguration.FilterTable.Add(v1Filter, v1Endpoint);

                var v2Filter = new ActionMessageFilter(@"http://services.bloggedbychris.com/practice/routing/v2/Version/GetVersion");
                var v2Endpoint = new[] {new ServiceEndpoint(contract, new BasicHttpBinding(), new EndpointAddress("http://localhost:9092/routing/version/"))};
                routingConfiguration.FilterTable.Add(v2Filter, v2Endpoint);
            
                                
                var routingBehavior = new RoutingBehavior(routingConfiguration);
                host.Description.Behaviors.Add(routingBehavior);

                var serviceBehavior = (ServiceDebugBehavior)host.Description.Behaviors[typeof (ServiceDebugBehavior)];
                serviceBehavior.IncludeExceptionDetailInFaults = true;

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

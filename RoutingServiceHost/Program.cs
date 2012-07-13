using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Routing;

namespace BBC.Practice.WCF.Routing.Host
{
    class Program
    {
        // In this tutorial, the routing service is hosted using a console application to avoid over-complicating the routing 
        // proof of concept with complex IIS, hosting, and web.config configurations.  The console hosts can be easily tested
        // without any configuration necessary
        static void Main(string[] args)
        {
            // I am sure that you realize that all of the following could be done in the web.config, but I opted to do it 
            // programmitically so that each individual component can be explained along the way
            using (var host = new ServiceHost(typeof(RoutingService)))
            {
                // In this step, we create an BasicHttp binding endpoint that will be used by the hosting interface to 
                // expose our routing service.
                // Note the use of the IRequestReplyRouter contract
                ContractDescription contract = ContractDescription.GetContract(typeof(IRequestReplyRouter));
                Binding binding = new BasicHttpBinding();
                var endpointAddress = new EndpointAddress("http://localhost:9093/routing/");
                var endpoint = new ServiceEndpoint(contract, binding, endpointAddress);
                host.AddServiceEndpoint(endpoint);


                // instantiate the routing config that we'll use
                var routingConfiguration = new RoutingConfiguration();


                // In this piece we create our first filter and add it to the routing configuration
                // Note that the filter looks for the versioned SOAP action that relates to the version 1 service's namespace
                // It then specifies that the route is the location of the version one service endpoint
                var v1Filter = new ActionMessageFilter(@"http://services.bloggedbychris.com/practice/routing/v1/Version/GetVersion");
                var v1Endpoint = new [] {new ServiceEndpoint(contract, new BasicHttpBinding(), new EndpointAddress("http://localhost:9091/routing/version/"))};
                routingConfiguration.FilterTable.Add(v1Filter, v1Endpoint);


                // In this piece we create our second filter and add it to the routing configuration
                // Note that the filter looks for the versioned SOAP action that relates to the version 2 service's namespace
                // It then specifies that the route is the location of the version 2 service endpoint
                var v2Filter = new ActionMessageFilter(@"http://services.bloggedbychris.com/practice/routing/v2/Version/GetVersion");
                var v2Endpoint = new[] {new ServiceEndpoint(contract, new BasicHttpBinding(), new EndpointAddress("http://localhost:9092/routing/version/"))};
                routingConfiguration.FilterTable.Add(v2Filter, v2Endpoint);
            
                
                // Here we add our routing configuration as a service behavior for our routing service
                var routingBehavior = new RoutingBehavior(routingConfiguration);
                host.Description.Behaviors.Add(routingBehavior);


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

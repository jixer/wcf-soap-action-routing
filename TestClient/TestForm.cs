using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;

namespace BBC.Practice.WCF.Routing.Test
{
    public partial class TestForm : Form
    {
        // The various service proxies are implemented globally for simplicity and reuse across the form
        private Version1Service.VersionClient _version1Client = new Version1Service.VersionClient();
        private Version2Service.VersionClient _version2Client = new Version2Service.VersionClient();
        private Version1Service.VersionClient _version1RoutingClient = new Version1Service.VersionClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:9093/routing/"));
        private Version2Service.VersionClient _version2RoutingClient = new Version2Service.VersionClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:9093/routing/"));

        public TestForm()
        {
            InitializeComponent();

            // The following inspector is added so that the request and response messages, as well as the endpoint can easily 
            // be written back to the client Test Form.  The implementation code is fairly dirty, so don't attempt to replicate
            // the logic for anything other than testing purposes.  Furthermore, custom EndpointBehaviors and MessageClientInspectors
            // are beyond the scope of this tutorial, so I will not go into the details of these
            IEndpointBehavior inspectorBehavior = new TextBoxMessageInspectorBehavior(txtRequest, txtResponse, txtEndpoint);
            _version1Client.Endpoint.Behaviors.Add(inspectorBehavior);
            _version1RoutingClient.Endpoint.Behaviors.Add(inspectorBehavior);
            _version2Client.Endpoint.Behaviors.Add(inspectorBehavior);
            _version2RoutingClient.Endpoint.Behaviors.Add(inspectorBehavior);
        }

        private void btnRoot_Click(object sender, EventArgs e)
        {
            // Call the root service (non-routed) of the service selected in the version drop down
            // Ignore the response message since it is captured via the message inspector
            if (ddlVersion.SelectedIndex == 0)
            {
                _version1Client.GetVersion();
            }
            else
            {
                _version2Client.GetVersion();
            }
        }

        // Call the routed service using the contract of the version selected in the drop down
        // Ignores the response message since it is captured via the message inspector
        private void btnRouting_Click(object sender, EventArgs e)
        {
            if (ddlVersion.SelectedIndex == 0)
            {
                _version1RoutingClient.GetVersion();
            }
            else
            {
                _version2RoutingClient.GetVersion();
            }
        }
    }
}

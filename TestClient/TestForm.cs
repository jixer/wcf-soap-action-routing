using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Windows.Forms;

namespace BBC.Practice.WCF.Routing.Test
{
    public partial class TestForm : Form
    {
        private static Version1Service.VersionClient _version1Client = new Version1Service.VersionClient();
        private static Version2Service.VersionClient _version2Client = new Version2Service.VersionClient();
        private static Version1Service.VersionClient _version1RoutingClient = new Version1Service.VersionClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:9093/routing/"));
        private static Version2Service.VersionClient _version2RoutingClient = new Version2Service.VersionClient(new BasicHttpBinding(), new EndpointAddress("http://localhost:9093/routing/"));

        public TestForm()
        {
            InitializeComponent();
            IEndpointBehavior inspectorBehavior = new TextBoxMessageInspectorBehavior(txtRequest, txtResponse, txtEndpoint);
            _version1Client.Endpoint.Behaviors.Add(inspectorBehavior);
            _version1RoutingClient.Endpoint.Behaviors.Add(inspectorBehavior);
            _version2Client.Endpoint.Behaviors.Add(inspectorBehavior);
            _version2RoutingClient.Endpoint.Behaviors.Add(inspectorBehavior);
        }

        private void btnRoot_Click(object sender, EventArgs e)
        {
            if (ddlVersion.SelectedIndex == 0)
            {
                _version1Client.GetVersion();
            }
            else
            {
                _version2Client.GetVersion();
            }
        }

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

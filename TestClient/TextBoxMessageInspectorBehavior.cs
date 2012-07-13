using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Windows.Forms;

namespace BBC.Practice.WCF.Routing.Test
{
    // The implementation code here is fairly dirty, so don't attempt to replicate the logic for anything other than 
    // testing purposes.  Furthermore, custom EndpointBehaviors and MessageClientInspectors
    // are beyond the scope of this tutorial, so I will not go into the details of these
    public class TextBoxMessageInspectorBehavior : IEndpointBehavior
    {
        private TextBox _requestTextBox;
        private TextBox _responseTextBox;
        private TextBox _endpointTextBox;

        public TextBoxMessageInspectorBehavior(TextBox request, TextBox reply, TextBox endpoint)
        {
            _requestTextBox = request;
            _responseTextBox = reply;
            _endpointTextBox = endpoint;
        }

        public void Validate(ServiceEndpoint endpoint) {}
        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters){}
        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher){}

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new TextBoxMessageInspector(_requestTextBox, _responseTextBox, _endpointTextBox));
        }
    }
}
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;
using System.Windows.Forms;

namespace BBC.Practice.WCF.Routing.Test
{
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

        public void Validate(ServiceEndpoint endpoint)
        {
            
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
            
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
            
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            clientRuntime.MessageInspectors.Add(new TextBoxMessageInspector(_requestTextBox, _responseTextBox, _endpointTextBox));
        }
    }
}
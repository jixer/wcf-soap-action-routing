using System.IO;
using System.ServiceModel;
using System.ServiceModel.Dispatcher;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Message = System.ServiceModel.Channels.Message;

namespace BBC.Practice.WCF.Routing.Test
{
    // The implementation code here is fairly dirty, so don't attempt to replicate the logic for anything other than 
    // testing purposes.  Furthermore, custom EndpointBehaviors and MessageClientInspectors
    // are beyond the scope of this tutorial, so I will not go into the details of these
    class TextBoxMessageInspector : IClientMessageInspector
    {
        private TextBox _requestTextBox;
        private TextBox _responseTextBox;
        private TextBox _endpointTextBox;

        public TextBoxMessageInspector(TextBox request, TextBox response, TextBox endpoint)
        {
            _requestTextBox = request;
            _responseTextBox = response;
            _endpointTextBox = endpoint;
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            _endpointTextBox.Text = channel.RemoteAddress.Uri.ToString();
            var sb = new StringBuilder();
            var stringWriter = new StringWriter(sb);
            XmlWriter writer = new XmlTextWriter(stringWriter);
            var messageBuffer = request.CreateBufferedCopy(int.MaxValue);
            messageBuffer.CreateMessage().WriteMessage(writer);
            _requestTextBox.Text = sb.ToString();
            request = messageBuffer.CreateMessage();
            return null;
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            var sb = new StringBuilder();
            var stringWriter = new StringWriter(sb);
            XmlWriter writer = new XmlTextWriter(stringWriter);
            var messageBuffer = reply.CreateBufferedCopy(int.MaxValue);
            messageBuffer.CreateMessage().WriteMessage(writer);
            reply = messageBuffer.CreateMessage();
            _responseTextBox.Text = sb.ToString();
        }
    }
}
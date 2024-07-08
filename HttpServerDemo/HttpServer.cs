using System.Diagnostics;
using System.Net;
using System.Text;

namespace HttpServerDemo
{
    internal class HttpServer
    {
        private readonly HttpListener _listener;
        private CancellationTokenSource _cts = new CancellationTokenSource();

        public HttpServer(string prefix)
        {
            _listener = new HttpListener();
            _listener.Prefixes.Add(prefix);
        }

        public void Start()
        {
            _listener.Start();
            Task.Run(() => ListenAsync(_cts.Token));
        }

        public void Stop()
        {
            _cts.Cancel();
            _listener.Stop();
        }

        private async Task ListenAsync(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                try
                {
                    var context = await _listener.GetContextAsync();
                    HandleRequest(context);
                }
                catch (HttpListenerException)
                {
                    // Handle listener exception if necessary
                }
                catch (OperationCanceledException)
                {
                    // Handle task cancellation
                }
            }
        }

        private void HandleRequest(HttpListenerContext context)
        {
            var request = context.Request;
            var response = context.Response;

            if ("GET" == request.HttpMethod)
            {
                if ("/shutdown" == request.Url?.AbsolutePath)
                {
                    Stop();
                    SendResponse(response, "HTTP server stopped");
                    Trace.WriteLine("HTTP server stopped");
                }
                else if ("/start" == request.Url?.AbsolutePath)
                {
                    SendResponse(response, "Started");
                    Trace.WriteLine("Started");
                }
                else if ("/stop" == request.Url?.AbsolutePath)
                {
                    SendResponse(response, "Stopped");
                    Trace.WriteLine("Stopped");
                }
                else if ("/get_contacts" == request.Url?.AbsolutePath)
                {
                    var contacts = GetContacts();
                    SendResponse(response, contacts);
                    Trace.WriteLine("Get contacts");
                }
                else if ("/get_members" == request.Url?.AbsolutePath)
                {
                    var userId = request.QueryString["user_id"];
                    var members = GetMembers(userId);
                    SendResponse(response, userId ?? members);
                    Trace.WriteLine("Get members");
                }
            }
            else if ("POST" == request.HttpMethod)
            {
                if ("/send" == request.Url?.AbsolutePath)
                {
                    using (var reader = new System.IO.StreamReader(request.InputStream, request.ContentEncoding))
                    {
                        var requestBody = reader.ReadToEnd();
                        SendResponse(response, "Message send");
                        Trace.WriteLine("Message send");
                    }
                }
            }
        }

        private string GetContacts()
        {
            var contacts = new List<object>
            {
                new { userid = "userid1", nickname = "Nickname1", type = "1" },
                new { userid = "userid2", nickname = "Nickname2", type = "2" }
            };
            return Newtonsoft.Json.JsonConvert.SerializeObject(contacts);
        }

        private string GetMembers(string? userId)
        {
            var members = new List<object>
            {
                new { userid = "userid1", nickname = "Nickname1", type = "3" },
                new { userid = "userid2", nickname = "Nickname2", type = "3" }
            };
            return Newtonsoft.Json.JsonConvert.SerializeObject(members);
        }

        private void SendResponse(HttpListenerResponse response, string responseString)
        {
            var buffer = Encoding.UTF8.GetBytes(responseString);
            response.ContentLength64 = buffer.Length;
            using (var output = response.OutputStream)
            {
                output.Write(buffer, 0, buffer.Length);
            }
        }
    }
}

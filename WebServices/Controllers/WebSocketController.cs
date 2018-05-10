using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.WebSockets;
using System.Web;
using System.Web.Http;
using System.Collections.Concurrent;
using wsep182.Domain;
using wsep182.services;

namespace WebServices.Controllers
{
    public class WebSocketController : ApiController
    {
        static readonly ConcurrentDictionary<string, WebSocket> _users = new ConcurrentDictionary<string, WebSocket>();
        public static Dictionary<string, LinkedList<String>> PendingMessages = new Dictionary<string, LinkedList<String>>(); 


        public HttpResponseMessage Get()
        {
            if (System.Web.HttpContext.Current.IsWebSocketRequest)
            {
                System.Web.HttpContext.Current.AcceptWebSocketRequest(Process);
            }
            return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
        }

        private async Task Process(AspNetWebSocketContext context)
        {
            WebSocket socket = context.WebSocket;
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[4096]);
            string hash = context.CookieCollection[0].Value;
            _users.AddOrUpdate(hash, socket, (p, w) => socket);

            while (socket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult result = await socket.ReceiveAsync(buffer, CancellationToken.None)
                                                            .ConfigureAwait(false);
                String userMessage = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);

                userMessage = "You sent: " + userMessage + " at " +
                    DateTime.Now.ToLongTimeString() + " from ip " + context.UserHostAddress.ToString();
                var sendbuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(userMessage));


                User newConnectedUser = hashServices.getUserByHash(hash);
                LinkedList<String> CurrentPendingMessages;
                PendingMessages.TryGetValue(newConnectedUser.getUserName(), out CurrentPendingMessages);
                if (CurrentPendingMessages != null)
                {
                    foreach (String message in CurrentPendingMessages)
                    {
                        sendMessageToClient(hash, message);
                    }
                    CurrentPendingMessages.Clear();
                }


                await socket.SendAsync(sendbuffer, WebSocketMessageType.Text, true, CancellationToken.None)
                            .ConfigureAwait(false);
            }
        }

        public static async void sendMessageToClient(string hash, String message)
        {
            WebSocket socket=null;
            _users.TryGetValue(hash, out socket);
            if (socket == null)
                return; //no such socket exists

            if (socket.State == WebSocketState.Open)
            {

                var sendbuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));

                await socket.SendAsync(sendbuffer, WebSocketMessageType.Text, true, CancellationToken.None)
                            .ConfigureAwait(false);
            }
            else
            {
                lock (_users) //make sure the socket wasn't reconnected so we won't lose the socket
                {
                    _users.TryRemove(hash, out socket);
                    User newConnectedUser = hashServices.getUserByHash(hash);
                    LinkedList<String> CurrentPendingMessages;
                    PendingMessages.TryGetValue(newConnectedUser.getUserName(), out CurrentPendingMessages);
                    if (CurrentPendingMessages == null)
                    {
                        CurrentPendingMessages = new LinkedList<String>();
                        CurrentPendingMessages.AddLast(message);
                        PendingMessages.Add(newConnectedUser.getUserName(), CurrentPendingMessages);
                    }
                    else
                    {
                        CurrentPendingMessages.AddLast(message);
                    }       
                }
                
            }
        }

    }
}
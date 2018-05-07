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

namespace WebServices.Controllers
{
    public class WebSocketController : ApiController
    {
        static readonly ConcurrentDictionary<string, WebSocket> _users = new ConcurrentDictionary<string, WebSocket>();

        public HttpResponseMessage Get()
        {
            if (System.Web.HttpContext.Current.IsWebSocketRequest)
            {
                System.Web.HttpContext.Current.AcceptWebSocketRequest(Process);
            }
            return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
        }
        /*
        private async Task ProcessWSChat(AspNetWebSocketContext context)
        {
            WebSocket socket = context.WebSocket;
            while (true)
            {
                ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
                WebSocketReceiveResult result = await socket.ReceiveAsync(
                    buffer, CancellationToken.None);
                if (socket.State == WebSocketState.Open)
                {
                    string userMessage = Encoding.UTF8.GetString(
                        buffer.Array, 0, result.Count);
                    userMessage = "You sent: " + userMessage + " at " +
                        DateTime.Now.ToLongTimeString();
                    buffer = new ArraySegment<byte>(
                        Encoding.UTF8.GetBytes(userMessage));
                    await socket.SendAsync(
                        buffer, WebSocketMessageType.Text, true, CancellationToken.None);
                }
                else
                {
                    break;
                }
            }
        }
        */

        private async Task Process(AspNetWebSocketContext context)
        {
            WebSocket socket = context.WebSocket;
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[4096]);

            //Identify user by cookie or whatever and create a user Object
            
            // Or uses the user that came from the ASP.NET authentication.
            //myUser = context.User;
            //string hash = System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value;
            string hash = "abcd23123sdasdsad";
            _users.AddOrUpdate(hash, socket, (p, w) => socket);

            while (socket.State == WebSocketState.Open)
            {
                WebSocketReceiveResult result = await socket.ReceiveAsync(buffer, CancellationToken.None)
                                                            .ConfigureAwait(false);
                String userMessage = Encoding.UTF8.GetString(buffer.Array, 0, result.Count);

                userMessage = "You sent: " + userMessage + " at " +
                    DateTime.Now.ToLongTimeString() + " from ip " + context.UserHostAddress.ToString();
                var sendbuffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(userMessage));

                await socket.SendAsync(sendbuffer, WebSocketMessageType.Text, true, CancellationToken.None)
                            .ConfigureAwait(false);
            }
/*
            // when the connection ends, try to remove the user
            WebSocket ows;
            if (_users.TryRemove(hash, out ows))
            {
                if (ows != socket)
                {
                    // whops! user reconnected too fast and you are removing
                    // the new connection, put it back
                    _users.AddOrUpdate(hash, ows, (p, w) => ows);
                }
            }
  */
        }

        public async void sendMessageToClient(string hash, String message)
        {
            WebSocket socket=null;
            _users.TryGetValue(hash,out socket);
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
                    _users.TryGetValue(hash, out socket);
                    if (socket.State == WebSocketState.Closed)
                        _users.TryRemove(hash, out socket);
                }
                
            }
        }

    }
}
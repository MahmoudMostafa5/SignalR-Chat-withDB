using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using SignalRChatDay1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SignalRChatDay1
{
    [HubName("chat")]
    public class ChatHub : Hub
    {
        chatContext db = new chatContext();
        public void sendMessage(string name, string msg)
        {
            Message m = new Message() { Name = name, Message1 = msg, Date = DateTime.Now };
            db.Messages.Add(m);
            db.SaveChanges();

            Clients.All.newMessage(name, msg);
            //Clients.All.newMessage(m);
        }
        public void joinGroup(string group, string name)
        {
            Groups.Add(Context.ConnectionId, group);
            Clients.OthersInGroup(group).newMember(name, group);
        }
        public void sentToGroup(string group, string name, string message)
        {
            Clients.Group(group).messageGroup(group, name, message);
        }
        public override Task OnConnected()
        {
            //string id = Context.ConnectionId;

            return base.OnConnected();
        }
    }
}
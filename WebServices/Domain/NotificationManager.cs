using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServices.Controllers;

namespace wsep182.Domain
{
    class NotificationManager
    { 
        private static NotificationManager instance;

        private NotificationManager()
        {
        }

        public static NotificationManager getInstance()
        {
            if (instance == null)
                instance = new NotificationManager();
            return instance;
        }

        public Boolean notifyUser(User u, String message)
        {
            String hash = HashArchive.getInstance().getHashByUserName(u.getUserName());
            if (hash != null)
            {
                WebSocketController.sendMessageToClient(hash, message);
                return true;
            }
            return false;
        }


    }
}

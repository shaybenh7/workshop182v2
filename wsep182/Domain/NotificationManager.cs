using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsep182.Domain
{
    class NotificationManager
    { 
        private static NotificationManager instance;

        private NotificationManager()
        {
            instance = new NotificationManager();
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
            return false;
        }


    }
}

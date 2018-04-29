using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wsep182.Domain;

namespace wsep182.services
{
    class hashServices
    {
        public Boolean configureUser(string hash, User user)
        {
            return HashArchive.getInstance().configureUser(hash, user);
        }

        public string generateID()
        {
            return HashArchive.getInstance().generateID();
        }


        public User getUserByHash(string hash)
        {
            return HashArchive.getInstance().getUserByHash(hash);
        }
    }
}

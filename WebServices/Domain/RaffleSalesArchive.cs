using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace wsep182.Domain
{
    public class RaffleSalesArchive
    {
        private LinkedList<RaffleSale> raffleSales;
        private static RaffleSalesArchive instance;
        System.Timers.Timer RaffelCollector;

        private RaffleSalesArchive()
        {
            raffleSales = new LinkedList<RaffleSale>();
            RaffelCollector = new System.Timers.Timer();
            RaffelCollector.Elapsed += new ElapsedEventHandler(CheckFinishedRaffelSales);
            RaffelCollector.Interval = 60*60*1000; // interval of one hour
            RaffelCollector.Enabled = true;
        }

        private void CheckFinishedRaffelSales(object source, ElapsedEventArgs e)
        {

            foreach (RaffleSale rs in raffleSales)
            {
                if (DateTime.Now.CompareTo(DateTime.Parse(rs.DueDate)) > 0 )
                {

                }
            }
        }

        public static RaffleSalesArchive getInstance()
        {
            if (instance == null)
                instance = new RaffleSalesArchive();
            return instance;
        }
        public static void restartInstance()
        {
            instance = new RaffleSalesArchive();
        }

        public Boolean addRaffleSale(int saleId, String userName, double offer, String dueDate)
        {
            RaffleSale toAdd = new RaffleSale(saleId, userName, offer, dueDate);
            raffleSales.AddLast(toAdd);
            return true;
        }
        public LinkedList<RaffleSale> getAllRaffleSalesBySaleId(int saleId)
        {
            LinkedList<RaffleSale> ans = new LinkedList<RaffleSale>();
            foreach (RaffleSale sale in raffleSales)
            {
                if (sale.SaleId == saleId)
                {
                    ans.AddLast(sale);
                }
            }
            return ans;
        }

        public LinkedList<RaffleSale> getAllRaffleSalesByUserName(String username)
        {
            LinkedList<RaffleSale> ans = new LinkedList<RaffleSale>();
            foreach (RaffleSale sale in raffleSales)
            {
                if (sale.UserName == username)
                {
                    ans.AddLast(sale);
                }
            }
            return ans;
        }

    }
}

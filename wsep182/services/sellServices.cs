using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using wsep182.Domain;

namespace wsep182.services
{
    public class sellServices
    {
        private static sellServices instance = null;

        private sellServices()
        {

        }
        public static sellServices getInstance()
        {
            if (instance == null)
            {
                instance = new sellServices();
            }
            return instance;
        }

        //req 1.3 d
        public LinkedList<Sale> viewSalesByProductInStoreId(int productInStore)
        {
            return User.viewSalesByProductInStoreId(productInStore);
        }

        //req 1.5 a
        public int addProductToCart(User user, int saleId, int amount)
        {
            if (user == null)
            {
                return -1; // user is null error
            }
            return user.addToCart(saleId, amount);
        }
        //req 1.5 b
        public int addRaffleProductToCart(User user, int saleId, double offer)
        {
            if (user == null)
            {
                return -1; // user is null error
            }
            return user.addToCartRaffle(saleId, offer);
        }

        // req 1.6 a
        public LinkedList<UserCart> viewCart(User user)
        {
            if (user == null)
                return null;
            return user.getShoppingCart();
        }
        // req 1.6 b
        public Boolean editCart(User user, Sale sale, int newAmount)
        {
            if (user == null||sale==null)
                return false;
            return user.editCart(sale.SaleId, newAmount);
        }

        //req 1.7 a
        public Boolean removeFromCart(User user, Sale sale)
        {
            if (user == null || sale == null)
                return false;
            return user.removeFromCart(sale);
        }

        //req 1.7.1 for all the user cart
        public Boolean buyProducts(User session, String creditCard, String couponId)
        {
            if (session == null)
                return false;
            return session.buyProducts(creditCard, couponId);
        }

    }
}

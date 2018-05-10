using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wsep182.Domain
{
    public class PurchasePolicyArchive
    {
        // 1-Product(system level) , 2- Store, 3-category, 4- product in store, 5-country
        private int productNUM = 1;
        private int storeNUM = 2;
        private int categoryNUM = 3;
        private int productInStoreNUM = 4;
        private int countryNUM = 5;

        private LinkedList<PurchasePolicy> policys;
        private static PurchasePolicyArchive instance;

        private PurchasePolicyArchive()
        {
            policys = new LinkedList<PurchasePolicy>();
        }
        public static PurchasePolicyArchive getInstance()
        {
            if (instance == null)
                instance = new PurchasePolicyArchive();
            return instance;
        }
        public static void restartInstance()
        {
            instance = new PurchasePolicyArchive();
        }

        private void appendLists(LinkedList<PurchasePolicy> first, LinkedList<PurchasePolicy> second)
        {
            foreach (PurchasePolicy p in second)
                first.AddLast(p);
        }
        public LinkedList<PurchasePolicy> getAllRelevantPolicysForProductInStore(int productInStoreId,string country)
        {
            // 1-Product(system level) , 2- Store, 3-category, 4- product in store, 5-country
            LinkedList<PurchasePolicy> ans = new LinkedList<PurchasePolicy>();
            ProductInStore pis = ProductArchive.getInstance().getProductInStore(productInStoreId);
            appendLists(ans, getAllStorePolicys(pis.store.storeId));
            appendLists(ans, getAllCategoryPolicys(pis.category, pis.store.storeId));
            appendLists(ans, getAllCountryPolicys(country, pis.store.storeId));
            appendLists(ans, getAllProductInStorePolicys(productInStoreId));
            appendLists(ans, getAllProductPolicys(pis.product.name));
            return ans;
        }

        public LinkedList<PurchasePolicy> getAllProductPolicys(string productName)
        {
            // 1-Product(system level) , 2- Store, 3-category, 4- product in store, 5-country
            LinkedList<PurchasePolicy> ans = new LinkedList<PurchasePolicy>();
            foreach(PurchasePolicy p in policys)
            {
                if(p.TypeOfPolicy == productNUM && p.ProductName.Equals(productName))
                {
                    ans.AddLast(p);
                }
            }
            return ans;
        }
        public LinkedList<PurchasePolicy> getAllStorePolicys(int storeId)
        {
            // 1-Product(system level) , 2- Store, 3-category, 4- product in store, 5-country
            LinkedList<PurchasePolicy> ans = new LinkedList<PurchasePolicy>();
            foreach (PurchasePolicy p in policys)
            {
                if (p.TypeOfPolicy == storeNUM && p.StoreId == storeId)
                {
                    ans.AddLast(p);
                }
            }
            return ans;
        }
        public LinkedList<PurchasePolicy> getAllCategoryPolicys(string category, int storeId)
        {
            // 1-Product(system level) , 2- Store, 3-category, 4- product in store, 5-country
            LinkedList<PurchasePolicy> ans = new LinkedList<PurchasePolicy>();
            foreach (PurchasePolicy p in policys)
            {
                if (p.TypeOfPolicy == categoryNUM && p.Category.Equals(category) && p.StoreId == storeId)
                {
                    ans.AddLast(p);
                }
            }
            return ans;
        }
        public LinkedList<PurchasePolicy> getAllProductInStorePolicys(int productInStoreId)
        {
            // 1-Product(system level) , 2- Store, 3-category, 4- product in store, 5-country
            LinkedList<PurchasePolicy> ans = new LinkedList<PurchasePolicy>();
            foreach (PurchasePolicy p in policys)
            {
                if (p.TypeOfPolicy == productInStoreNUM && p.ProductInStoreId == productInStoreId)
                {
                    ans.AddLast(p);
                }
            }
            return ans;
        }
        public LinkedList<PurchasePolicy> getAllCountryPolicys(string country,int storeId)
        {
            // 1-Product(system level) , 2- Store, 3-category, 4- product in store, 5-country
            LinkedList<PurchasePolicy> ans = new LinkedList<PurchasePolicy>();
            foreach (PurchasePolicy p in policys)
            {
                if (p.TypeOfPolicy == countryNUM && p.Country.Equals(country) && p.StoreId == storeId)
                {
                    ans.AddLast(p);
                }
            }
            return ans;
        }

        // ========================= AMOUNT CONSTRAINTS !!!! ================================================
        public int setAmountPolicyOnProduct(string productName, int minAmount, int maxAmount)
        {
            // 1-Product(system level) , 2- Store, 3-category, 4- product in store, 5-country
            PurchasePolicy toAdd = new PurchasePolicy();
            toAdd.TypeOfPolicy = 1;
            toAdd.ProductName = productName;
            toAdd.MinAmount = minAmount;
            toAdd.MaxAmount = maxAmount;
            toAdd.NoLimit = false;
            policys.AddLast(toAdd);
            return 1;
        }
        public int setAmountPolicyOnStore(int storeId, int minAmount, int maxAmount)
        {
            // 1-Product(system level) , 2- Store, 3-category, 4- product in store, 5-country
            PurchasePolicy toAdd = new PurchasePolicy();
            toAdd.TypeOfPolicy = 2;
            toAdd.StoreId = storeId;
            toAdd.MinAmount = minAmount;
            toAdd.MaxAmount = maxAmount;
            toAdd.NoLimit = false;
            policys.AddLast(toAdd);
            return 1;
        }
        public int setAmountPolicyOnCategory(int storeId, string category, int minAmount, int maxAmount)
        {
            // 1-Product(system level) , 2- Store, 3-category, 4- product in store, 5-country
            PurchasePolicy toAdd = new PurchasePolicy();
            toAdd.TypeOfPolicy = 3;
            toAdd.Category = category;
            toAdd.StoreId = storeId;
            toAdd.MinAmount = minAmount;
            toAdd.MaxAmount = maxAmount;
            toAdd.NoLimit = false;
            policys.AddLast(toAdd);
            return 1;
        }
        public int setAmountPolicyOnProductInStore(int productInStoreId, int minAmount, int maxAmount)
        {
            // 1-Product(system level) , 2- Store, 3-category, 4- product in store, 5-country
            PurchasePolicy toAdd = new PurchasePolicy();
            toAdd.TypeOfPolicy = 4;
            toAdd.ProductInStoreId = productInStoreId;
            toAdd.MinAmount = minAmount;
            toAdd.MaxAmount = maxAmount;
            toAdd.NoLimit = false;
            policys.AddLast(toAdd);
            return 1;
        }
        public int setAmountPolicyOnCountry(int storeId, string country, int minAmount, int maxAmount)
        {
            // 1-Product(system level) , 2- Store, 3-category, 4- product in store, 5-country
            PurchasePolicy toAdd = new PurchasePolicy();
            toAdd.TypeOfPolicy = 5;
            toAdd.Country = country;
            toAdd.StoreId = storeId;
            toAdd.MinAmount = minAmount;
            toAdd.MaxAmount = maxAmount;
            toAdd.NoLimit = false;
            policys.AddLast(toAdd);
            return 1;
        }

// ========================= DISCOUNT CONSTRAINTS !!!! ================================================
        public int setNoDiscountPolicyOnProduct(string productName)
        {
            // 1-Product(system level) , 2- Store, 3-category, 4- product in store, 5-country
            PurchasePolicy toAdd = new PurchasePolicy();
            toAdd.TypeOfPolicy = 1;
            toAdd.ProductName = productName;
            toAdd.NoDiscount = true;
            policys.AddLast(toAdd);
            return 1;
        }
        public int setNoDiscountPolicyOnStore(int storeId)
        {
            // 1-Product (system level) , 2- Store, 3-category, 4- product in store, 5-country
            PurchasePolicy toAdd = new PurchasePolicy();
            toAdd.TypeOfPolicy = 2;
            toAdd.StoreId = storeId;
            toAdd.NoDiscount = true;
            policys.AddLast(toAdd);
            return 1;
        }
        public int setNoDiscountPolicyOnCategoty(int storeId, String category)
        {
            // 1-Product (system level) , 2- Store, 3-category, 4- product in store, 5-country
            PurchasePolicy toAdd = new PurchasePolicy();
            toAdd.TypeOfPolicy = 3;
            toAdd.StoreId = storeId;
            toAdd.Category = category;
            toAdd.NoDiscount = true;
            policys.AddLast(toAdd);
            return 1;
        }
        public int setNoDiscountPolicyOnProductInStore(int productInStoreId)
        {
            // 1-Product (system level) , 2- Store, 3-category, 4- product in store, 5-country
            PurchasePolicy toAdd = new PurchasePolicy();
            toAdd.TypeOfPolicy = 4;
            toAdd.ProductInStoreId = productInStoreId;
            toAdd.NoDiscount = true;
            policys.AddLast(toAdd);
            return 1;
        }
        public int setNoDiscountPolicyOnCountry(int storeId, string country)
        {
            // 1-Product (system level) , 2- Store, 3-category, 4- product in store, 5-country
            PurchasePolicy toAdd = new PurchasePolicy();
            toAdd.TypeOfPolicy = 5;
            toAdd.StoreId = storeId;
            toAdd.Country = country;
            toAdd.NoDiscount = true;
            policys.AddLast(toAdd);
            return 1;
        }

// ========================= COUPONS CONSTRAINTS !!!! ================================================
        public int setNoCouponsPolicyOnProduct(string productName)
        {
            // 1-Product(system level) , 2- Store, 3-category, 4- product in store, 5-country
            PurchasePolicy toAdd = new PurchasePolicy();
            toAdd.TypeOfPolicy = 1;
            toAdd.ProductName = productName;
            toAdd.NoCoupons = true;
            policys.AddLast(toAdd);
            return 1;
        }
        public int setNoCouponsPolicyOnStore(int storeId)
        {
            // 1-Product (system level) , 2- Store, 3-category, 4- product in store, 5-country
            PurchasePolicy toAdd = new PurchasePolicy();
            toAdd.TypeOfPolicy = 2;
            toAdd.StoreId = storeId;
            toAdd.NoCoupons = true;
            policys.AddLast(toAdd);
            return 1;
        }
        public int setNoCouponPolicyOnCategoty(int storeId, String category)
        {
            // 1-Product (system level) , 2- Store, 3-category, 4- product in store, 5-country
            PurchasePolicy toAdd = new PurchasePolicy();
            toAdd.TypeOfPolicy = 3;
            toAdd.StoreId = storeId;
            toAdd.Category = category;
            toAdd.NoCoupons = true;
            policys.AddLast(toAdd);
            return 1;
        }
        public int setNoCouponPolicyOnProductInStore(int productInStoreId)
        {
            // 1-Product (system level) , 2- Store, 3-category, 4- product in store, 5-country
            PurchasePolicy toAdd = new PurchasePolicy();
            toAdd.TypeOfPolicy = 4;
            toAdd.ProductInStoreId = productInStoreId;
            toAdd.NoCoupons = true;
            policys.AddLast(toAdd);
            return 1;
        }
        public int setNoCouponPolicyOnCountry(int storeId, string country)
        {
            // 1-Product (system level) , 2- Store, 3-category, 4- product in store, 5-country
            PurchasePolicy toAdd = new PurchasePolicy();
            toAdd.TypeOfPolicy = 5;
            toAdd.StoreId = storeId;
            toAdd.Country = country;
            toAdd.NoCoupons = true;
            policys.AddLast(toAdd);
            return 1;
        }

















    }
}

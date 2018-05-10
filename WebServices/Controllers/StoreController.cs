using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using wsep182.Domain;
using wsep182.services;


namespace WebService.Controllers
{
    public class StoreController : ApiController
    {
        [Route("api/store/createStore")]
        [HttpGet]
        public string createStore(String storeName)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().createStore(storeName, session);
            if(ans>0)
                    return "store " + ans + " successfuly added";
            switch (ans)
            {
                case -1:
                    return "error: username is not login";
                case -2:
                    return "error: store name allready exist";
                case -3:
                    return "error: illegal store name";
            }
            return "server error: not suppose to happend";
        }


        [Route("api/store/getAllStores")]
        [HttpGet]
        public HttpResponseMessage getAllStores()
        {
            LinkedList<Store> stores = storeServices.getInstance().getAllStores();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, stores);
            return response;
        }

        [Route("api/store/setAmountPolicyOnStore")]
        [HttpGet]
        public String setAmountPolicyOnStore(int storeId, int minAmount, int maxAmount)
        {
            if (System.Web.HttpContext.Current.Request.Cookies["HashCode"] == null)
            {
                return "Not logged in";
            }
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().setAmountPolicyOnStore(session, storeId, minAmount, maxAmount);
            if (ans > 0)
                return "Policy added successfully";
            if (ans == -4)
                return "You dont have permissions";
            return "Policy failed";

        }

        [Route("api/store/setNoDiscountPolicyOnStore")]
        [HttpGet]
        public String setNoDiscountPolicyOnStore(int storeId)
        {
            if (System.Web.HttpContext.Current.Request.Cookies["HashCode"] == null)
            {
                return "Not logged in";
            }
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().setNoDiscountPolicyOnStore(session, storeId);
            if (ans > 0)
                return "Policy added successfully";
            if (ans == -4)
                return "You dont have permissions";
            return "Policy failed";

        }

        [Route("api/store/setNoDiscountPolicyOnCategoty")]
        [HttpGet]
        public String setNoDiscountPolicyOnCategoty(int storeId, String category)
        {
            if (System.Web.HttpContext.Current.Request.Cookies["HashCode"] == null)
            {
                return "Not logged in";
            }
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().setNoDiscountPolicyOnCategoty(session, storeId, category);
            if (ans > 0)
                return "Policy added successfully";
            if (ans == -4)
                return "You dont have permissions";
            return "Policy failed";

        }

        [Route("api/store/setNoDiscountPolicyOnCountry")]
        [HttpGet]
        public String setNoDiscountPolicyOnCountry(int storeId, String country)
        {
            if (System.Web.HttpContext.Current.Request.Cookies["HashCode"] == null)
            {
                return "Not logged in";
            }
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().setNoDiscountPolicyOnCountry(session, storeId, country);
            if (ans > 0)
                return "Policy added successfully";
            if (ans == -4)
                return "You dont have permissions";
            return "Policy failed";

        }

        [Route("api/store/setNoCouponsPolicyOnStore")]
        [HttpGet]
        public String setNoCouponsPolicyOnStore(int storeId)
        {
            if (System.Web.HttpContext.Current.Request.Cookies["HashCode"] == null)
            {
                return "Not logged in";
            }
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().setNoCouponsPolicyOnStore(session, storeId);
            if (ans > 0)
                return "Policy added successfully";
            if (ans == -4)
                return "You dont have permissions";
            return "Policy failed";

        }

        [Route("api/store/setNoCouponPolicyOnProductInStore")]
        [HttpGet]
        public String setNoCouponPolicyOnProductInStore(int storeId, int productInStoreId)
        {
            if (System.Web.HttpContext.Current.Request.Cookies["HashCode"] == null)
            {
                return "Not logged in";
            }
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().setNoCouponPolicyOnProductInStore(session, storeId, productInStoreId);
            if (ans > 0)
                return "Policy added successfully";
            if (ans == -4)
                return "You dont have permissions";
            return "Policy failed";

        }

        [Route("api/store/setNoDiscountPolicyOnProductInStore")]
        [HttpGet]
        public String setNoDiscountPolicyOnProductInStore(int storeId, int productInStoreId)
        {
            if (System.Web.HttpContext.Current.Request.Cookies["HashCode"] == null)
            {
                return "Not logged in";
            }
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().setNoDiscountPolicyOnProductInStore(session, storeId, productInStoreId);
            if (ans > 0)
                return "Policy added successfully";
            if (ans == -4)
                return "You dont have permissions";
            return "Policy failed";
        }

        [Route("api/store/setNoCouponPolicyOnCountry")]
        [HttpGet]
        public String setNoCouponPolicyOnCountry(int storeId, string country)
        {
            if (System.Web.HttpContext.Current.Request.Cookies["HashCode"] == null)
            {
                return "Not logged in";
            }
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().setNoCouponPolicyOnCountry(session, storeId, country);
            if (ans > 0)
                return "Policy added successfully";
            if (ans == -4)
                return "You dont have permissions";
            return "Policy failed";
        }


        [Route("api/store/setAmountPolicyOnCategory")]
        [HttpGet]
        public String setAmountPolicyOnCategory(int storeId, String category, int minAmount, int maxAmount)
        {
            if (System.Web.HttpContext.Current.Request.Cookies["HashCode"] == null)
            {
                return "Not logged in";
            }
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().setAmountPolicyOnCategory(session, storeId, category, minAmount, maxAmount);
            if (ans > 0)
                return "Policy added successfully";
            if (ans == -4)
                return "You dont have permissions";
            return "Policy failed";
        }

        [Route("api/store/setAmountPolicyOnProductInStore")]
        [HttpGet]
        public String setAmountPolicyOnProductInStore(int storeId, int productInStoreId, int minAmount, int maxAmount)
        {
            if (System.Web.HttpContext.Current.Request.Cookies["HashCode"] == null)
            {
                return "Not logged in";
            }
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().setAmountPolicyOnProductInStore(session, storeId, productInStoreId, minAmount, maxAmount);
            if (ans > 0)
                return "Policy added successfully";
            if (ans == -4)
                return "You dont have permissions";
            return "Policy failed";
        }

        [Route("api/store/setAmountPolicyOnCountry")]
        [HttpGet]
        public String setAmountPolicyOnCountry(int storeId, string country, int minAmount, int maxAmount)
        {
            if (System.Web.HttpContext.Current.Request.Cookies["HashCode"] == null)
            {
                return "Not logged in";
            }
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().setAmountPolicyOnCountry(session, storeId, country, minAmount, maxAmount);
            if (ans > 0)
                return "Policy added successfully";
            if (ans == -4)
                return "You dont have permissions";
            return "Policy failed";
        }



        [Route("api/store/addProductInStore")]
        [HttpGet]
        public string addProductInStore(String productName, Double price, int amount, int storeId)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().addProductInStore(productName, price, amount, session, storeId);
            if (ans > 0)
                return "product in store " + ans + " successfuly added";
            switch (ans)
            {
                case -1:
                    return "error: username is not login";
                case -2:
                    return "error: store name allready exist";
                case -3:
                    return "error: illegal product name";
                case -4:
                    return "error: don't have permission";
                case -5:
                    return "error: illegal amount";
                case -6:
                    return "error: illegal store id";
                case -7:
                    return "error: illegal price";
            }
            return "server error: not suppose to happend";
        }

        [Route("api/store/editProductInStore")]
        [HttpGet]
        public string editProductInStore(int productInStoreId, Double price, int amount, int storeId)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().editProductInStore(session, storeId, productInStoreId, amount, price);
            switch (ans)
            {
                case 0:
                    return "product edited successfuly";
                case -1:
                    return "error: username is not login";
                case -2:
                    return "error: store name allready exist";
                case -3:
                    return "error: illegal product name";
                case -4:
                    return "error: don't have permission";
                case -5:
                    return "error: illegal amount";
                case -6:
                    return "error: illegal store id";
                case -7:
                    return "error: illegal price";
                case -8:
                    return "error: illegal product in store Id";
                case -9:
                    return "error: database error";
            }
            return "server error: not suppose to happend";
        }
        
        [Route("api/store/getProductInStore")]
        [HttpGet]
        public HttpResponseMessage getProductInStore(int storeId)
        {
            LinkedList<ProductInStore> pis = storeServices.getInstance().getProductsInStore(storeId);
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.OK, pis);
            return response;
        }
        
        [Route("api/store/removeProductFromStore")]
        [HttpGet]
        public string removeProductFromStore(int storeId, int ProductInStoreId)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().removeProductFromStore(storeId, ProductInStoreId, session);  
            switch (ans)
            {
                case 0:
                    return "product removed successfuly";
                case -1:
                    return "error: username is not login";
                case -2:
                    return "error: store name allready exist";
                case -3:
                    return "error: illegal product name";
                case -4:
                    return "error: don't have permission";
                case -5:
                    return "error: illegal amount";
                case -6:
                    return "error: illegal store id";
                case -7:
                    return "error: illegal price";
                case -8:
                    return "error: illegal product in store Id";
                case -9:
                    return "error: database error";
            }
            return "server error: not suppose to happend";
        }

        [Route("api/store/addStoreOwner")]
        [HttpGet]
        public string addStoreOwner(int storeId, String newOwner)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            Boolean ans = storeServices.getInstance().addStoreOwner(storeId, newOwner, session);
            if (ans)
                return "the User "+ newOwner +" has been added as owner sussesfuly";
            return "server error: could not add this user as owner";
        }


        [Route("api/store/removeStoreOwner")]
        [HttpGet]
        public string removeStoreOwner(int storeId, String oldOwner)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().removeStoreOwner(storeId, oldOwner, session);
            switch (ans)
            {
                case 0:
                    return "owner removed successfuly";
                case -1:
                    return "error: username is not login";
                case -2:
                    return "error: store name allready exist";
                case -3:
                    return "error: illegal product name";
                case -4:
                    return "error: don't have permission";
                case -5:
                    return "error: illegal amount";
                case -6:
                    return "error: illegal store id";
                case -7:
                    return "error: illegal price";
                case -8:
                    return "error: illegal product in store Id";
                case -9:
                    return "error: database error";
                case -10:
                    return "error: try to remove himself";
                case -11:
                    return "error: not a owner";
                case -12:
                    return "error: can't dealet creator";
            }
            return "server error: not suppose to happend";
        }


        [Route("api/store/addStoreManager")]
        [HttpGet]
        public string addStoreManager(int storeId, String newManager)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().addStoreManager(storeId, newManager, session);
            switch (ans)
            {
                case 0:
                    return "manager added successfuly";
                case -1:
                    return "error: username is not login";
                case -2:
                    return "error: the manager doesn't exist";
                case -3:
                    return "error: illegal store id";
                case -4:
                    return "error: don't have permission";
                case -5:
                    return "error: database error";
                case -6:
                    return "error: the user is already owner or manneger";
            }
            return "server error: not suppose to happend";
        }

        [Route("api/store/removeStoreManager")]
        [HttpGet]
        public string removeStoreManager(int storeId, String oldManageruserName)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().removeStoreManager(storeId, oldManageruserName, session);
            switch (ans)
            {
                case 0:
                    return "Manager removed successfuly";
                case -1:
                    return "error: username is not login";
                case -3:
                    return "error: illegal store id";
                case -4:
                    return "error: don't have permission";
                case -5:
                    return "error: the user is not a manager";
                case -6:
                    return "error: database error";
                case -10:
                    return "error: try to remove himself";
            }
            return "server error: not suppose to happend";
        }

        [Route("api/store/addManagerPermission")]
        [HttpPut]
        public string addManagerPermission(int storeId, String ManageruserName,string permission)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().addManagerPermission(permission, storeId, ManageruserName, session);
            switch (ans)
            {
                case 0:
                    return "Added manager permission successfully";
                case -1:
                    return "Error: username is not login";
                case -3:
                    return "Error: illegal store id";
                case -4:
                    return "Error: don't have permission";
                case -5:
                    return "Error: database error";
                case -6:
                    return "Error: manager name doesn't exsist";
                case -7:
                    return "Error: no such permission";
            }
            return "Server error: not suppose to happen";
        }

        [Route("api/store/removeManagerPermission")]
        [HttpDelete]
        public string removeManagerPermission(int storeId, String ManageruserName, string permission)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().removeManagerPermission(permission, storeId, ManageruserName, session);
            switch (ans)
            {
                case 0:
                    return "Removed manager permission successfully";
                case -1:
                    return "Error: username is not login";
                case -3:
                    return "Error: illegal store id";
                case -4:
                    return "Error: don't have permission";
                case -5:
                    return "Error: database error";
                case -6:
                    return "Error: manager name doesn't exsist";
                case -7:
                    return "Error: no such permission";
            }
            return "Server error: not suppose to happen";
        }

        [Route("api/store/viewStoreHistory")]
        [HttpGet]
        public HttpResponseMessage viewStoreHistory(int storeId)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            Object history = storeServices.getInstance().viewStoreHistory(session,storeId);
            HttpResponseMessage response;
            if (history == null)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Errror: permissions or store not valid!");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, history);
            }
            return response;
        }

        [Route("api/store/viewUserHistory")]
        [HttpGet]
        public HttpResponseMessage viewUserHistory(String userToGet)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            Object history = storeServices.getInstance().viewUserHistory(session, userToGet);
            HttpResponseMessage response;
            if (history == null)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Errror: permissions or user not valid!");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, history);
            }
            return response;
        }

        [Route("api/store/addSaleToStore")]
        [HttpGet]
        public string addSaleToStore(int storeId, int pisId, int typeOfSale, int amount, String dueDtae)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["HashCode"].Value);
            int ans = storeServices.getInstance().addSaleToStore(session, storeId, pisId, typeOfSale, amount, dueDtae);
            if (ans > 0)
                return "sale " + ans + " successfuly added";
            switch (ans)
            { 
                case -1:
                    return "Error: username is not login";
                case -3:
                    return "Error: illegal product name";
                case -4:
                    return "Error: don't have permission";
                case -5:
                    return "Error: illegal amount bigger then amount in stock";
                case -6:
                    return "Error: illegal store id";
                case -7:
                    return "Error: illegal price";
                case -8:
                    return "Error: illegal product id";
                case -9:
                    return "Error: database error";
                case -10:
                    return "Error: illegal due date";
                case -11:
                    return "Error: illegal type of sale";
                case -12:
                    return "Error: illegal amount";
                case -13:
                    return "Error: product not in this store";

            }
            return "Server error: not suppose to happen";
        }

        [Route("api/store/removeSaleFromStore")]
        [HttpGet]
        public string removeSaleFromStore(int storeId, int saleId)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            int ans = storeServices.getInstance().removeSaleFromStore(session, storeId, saleId);
            
            switch (ans)
            {
                case 0:
                    return "sale successfully Removed";
                case -1:
                    return "Error: username is not login";
                case -4:
                    return "Error: don't have permission";
                case -5:
                    return "Error: illegal amount bigger then amount in stock";
                case -6:
                    return "Error: illegal store id";
                case -8:
                    return "Error: illegal sale id";
                case -9:
                    return "Error: database error";

            }
            return "Server error: not suppose to happen";
        }

        [Route("api/store/editSale")]
        [HttpGet]
        public string editSale(int storeId, int saleId, int amount, String dueDate)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            int ans = storeServices.getInstance().editSale(session, storeId, saleId, amount, dueDate);
            switch (ans)
            {
                case 0:
                    return "sale successfully edited";
                case -1:
                    return "Error: username is not login";
                case -4:
                    return "Error: don't have permission";
                case -5:
                    return "Error: illegal amount bigger then amount in stock";
                case -6:
                    return "Error: illegal store id";
                case -7:
                    return "Error: illegal price";
                case -8:
                    return "Error: illegal sale id";
                case -9:
                    return "Error: database error";
                case -10:
                    return "Error: illegal due date";

                case -12:
                    return "Error: illegal amount";
                 
            }
            return "Server error: not suppose to happen";
        }


        [Route("api/store/addCouponDiscount")]
        [HttpPut]
        public string addCouponDiscount(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }

        [Route("api/store/addDiscount")]
        [HttpPut]
        public string addDiscount(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }

        [Route("api/store/removeDiscount")]
        [HttpDelete]
        public string removeDiscount(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }

        [Route("api/store/removeCoupon")]
        [HttpDelete]
        public string removeCoupon(int storeId, String oldManageruserName, String session)
        {
            return "not implemented";
        }

        [Route("api/store/getOwners")]
        [HttpGet]
        public HttpResponseMessage getOwners(int storeId)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            Object owners = storeServices.getInstance().getOwners(storeId);
            HttpResponseMessage response;
            if (owners == null)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Errror: permissions or store not valid!");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, owners);
            }
            return response;
        }

        [Route("api/store/getManagers")]
        [HttpGet]
        public HttpResponseMessage getManagers(int storeId, String oldManageruserName)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            Object Managers = storeServices.getInstance().getManagers(storeId);
            HttpResponseMessage response;
            if (Managers == null)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Errror: permissions or store not valid!");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, Managers);
            }
            return response;
        }

        [Route("api/store/viewSalesByStore")]
        [HttpGet]
        public HttpResponseMessage viewSalesByStore(int storeId)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            Object sales = storeServices.getInstance().viewSalesByStore(storeId);
            HttpResponseMessage response;
            if (sales == null)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Errror: permissions or store not valid!");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, sales);
            }
            return response;
        }

        [Route("api/store/getProductInStoreById")]
        [HttpGet]
        public HttpResponseMessage getProductInStoreById(int id)
        {
            ProductInStore productInStore = ProductArchive.getInstance().getProductInStore(id);
            HttpResponseMessage response;
            if (productInStore == null)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Errror: permissions or store not valid!");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, productInStore);
            }
            return response;
             
        }


        [Route("api/store/checkPriceOfAProduct")]
        [HttpGet]
        public HttpResponseMessage checkPriceOfAProduct(int saleId)
        {
            Sale sale = SalesArchive.getInstance().getSale(saleId);
            HttpResponseMessage response;
            if (sale == null)
            {
                response = Request.CreateResponse(HttpStatusCode.OK, "Errror: permissions or store not valid!");
            }
            else
            {
                response = Request.CreateResponse(HttpStatusCode.OK, sale.getPriceAfterDiscount(1));
            }
            return response;

        }
    }
}
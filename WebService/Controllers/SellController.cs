using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using wsep182.Domain;
using wsep182.services;

namespace WebService.Controllers
{
    public class SellController : ApiController
    {
        [Route("api/store/viewSalesByProductInStoreId")]
        [HttpGet]
        public HttpResponseMessage viewSalesByProductInStoreId(int ProductInStoreId)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            Object sales = sellServices.getInstance().viewSalesByProductInStoreId(ProductInStoreId);
            HttpResponseMessage response;
            if (sales != null)
                response = Request.CreateResponse(HttpStatusCode.OK, sellServices.getInstance().viewSalesByProductInStoreId(ProductInStoreId));
            else
                response = Request.CreateResponse(HttpStatusCode.NotFound, "Error: no sales found for the entered product id");
            return response;
        }


        [Route("api/store/addProductToCart")]
        [HttpPut]
        public HttpResponseMessage addProductToCart(int saleId, int amount)
        {
            User session = hashServices.getUserByHash(System.Web.HttpContext.Current.Request.Cookies["Session"].Value);
            /* Confimation = 1
             * Errors:
             * -1 = user is null (should not ever happen)
             * -2 = amount can't be zero or lower
             * -3 = saleId entered doesn't exist
             * -4 = the date for the sale is no longer valid
             * -5 = trying to add a sale with type different from regular sale type
             * -6 = amount is bigger than the amount that exist in stock
             * -7 = amount is bigger than the amount currently up for sale
             */
            int added = session.addToCart(saleId, amount);
            HttpResponseMessage response;
            switch (added)
            {
                case 1:
                    response = Request.CreateResponse(HttpStatusCode.OK, "Product was added successfully!");
                    break;
                case -1:
                    response = Request.CreateResponse(HttpStatusCode.OK, "Error: user is not valid!");
                    break;
                case -2:
                    response = Request.CreateResponse(HttpStatusCode.OK, "Error: amount can't be zero or lower!");
                    break;
                case -3:
                    response = Request.CreateResponse(HttpStatusCode.OK, "Error: The sale id does not exist!");
                    break;
                case -4:
                    response = Request.CreateResponse(HttpStatusCode.OK, "Error: the sale has ended!");
                    break;
                case -5:
                    response = Request.CreateResponse(HttpStatusCode.OK, "Error: Trying to add to cart sale different than immediate sale!");
                    break;
                case -6:
                    response = Request.CreateResponse(HttpStatusCode.OK, "Error: Amount in bigger than currently exist in stock!");
                    break;
                case -7:
                    response = Request.CreateResponse(HttpStatusCode.OK, "Error: Amount in bigger than currently available for purchase!");
                    break;
                default:
                    response = Request.CreateResponse(HttpStatusCode.OK, "Error: Unkown error!");
                    break;
            }
            return response;
        }

        [Route("api/store/addRaffleProductToCart")]
        [HttpPut]
        public string addRaffleProductToCart(String storeName, int UserId)
        {
            return "not implemented";
        }

        [Route("api/store/viewCart")]
        [HttpGet]
        public string viewCart()
        {
            return "not implemented";
        }

        [Route("api/store/editCart")]
        [HttpPut]
        public string editCart(String storeName, int UserId)
        {
            return "not implemented";
        }

        [Route("api/store/removeFromCart")]
        [HttpDelete]
        public string removeFromCart(String storeName, int UserId)
        {
            return "not implemented";
        }

        [Route("api/store/buyProducts")]
        [HttpPost]
        public string buyProducts(String storeName, int UserId)
        {
            return "not implemented";
        }
    }
}
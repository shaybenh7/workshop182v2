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
        public string addProductToCart(String storeName, int UserId)
        {
            return "not implemented";
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
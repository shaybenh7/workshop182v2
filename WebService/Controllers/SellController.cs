using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers
{
    public class SellController : ApiController
    {
        [Route("api/store/viewSalesByProductInStoreId")]
        [HttpGet]
        public string viewSalesByProductInStoreId(String storeName, int UserId)
        {
            return "not implemented";
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
        public string viewCart(String storeName, int UserId)
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
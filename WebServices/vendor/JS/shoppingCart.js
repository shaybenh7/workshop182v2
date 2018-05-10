$(document).ready(function () {
    var mainDiv = document.getElementById('shoppingCart');
    jQuery.ajax({
        type: "GET",
        url: "http://localhost:53416/api/sell/viewCart",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log(response);
            console.log("here");
            var i;
            for (i = 0; i < response.length; i++) {
                element = response[i];
                var amount = element["Amount"];
                var saleId = element["SaleId"];
                var totalAfterDiscount = element["PriceAfterDiscount"];
                var price = totalAfterDiscount / amount;
                if (element["Offer"] != 0) {
                    price = element["Offer"];
                }
                if (element["Offer"] != 0) {
                    totalAfterDiscount = element["Offer"] * amount;
                }
                var string = "";
                string += "<tr class=\"table_row\">";
                string += "<td class=\"column-1\" >";
                //string += "<div class=\"how-itemcart1\">";
                string += "<input type=\"image\" onclick=\"RemoveProductFromCart(" + saleId +")\" src=\"images/removee.png\" id=\"remove" + i + "\" width=\"40\" height=\"40\">";
                //string += "</div>";
                string += "</td>";
                string += "<td class=\"column-2\" id=\"productName" + i + "\"></td>";
                string += "<td class=\"column-3\" id=\"price" + i + "\">" + price.toFixed(2) + "</td>";
                string += "<td class=\"column-4\" id=\"quantity" + i + "\">" + amount + "</td>";
                string += "<td class=\"column-5\" id=\"total" + i + "\">" + totalAfterDiscount.toFixed(2) + "</td>";
                string += "</tr>";
                mainDiv.innerHTML += string;

                (function (i, saleId) {
                    jQuery.ajax({
                        type: "GET",
                        url: "http://localhost:53416/api/user/viewSaleById?saleId=" + saleId,
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function (response) {

                            jQuery.ajax({
                                type: "GET",
                                url: "http://localhost:53416/api/store/getProductInStoreById?id=" + response["ProductInStoreId"],
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (response) {
                                    var productNameElement = document.getElementById("productName" + i);
                                    productNameElement.innerHTML += response["product"]["name"];
                                },
                                error: function (response) {
                                    console.log(response);
                                }
                            });

                        },
                        error: function (response) {
                            console.log(response);
                        }
                    });

                })(i, saleId);
            }
        },
        error: function (response) {
            console.log(response);
            window.location.href = "http://localhost:53416/error";
        }
    });
});

var RemoveProductFromCart = function (saleId) {
    jQuery.ajax({
        type: "GET",
        url: "http://localhost:53416/api/sell/removeFromCart?saleId=" + saleId,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log("response");

            console.log(response);
        },
        error: function (response) {
            console.log("responseeee");
            window.location.href = "http://localhost:53416/error";
        }
    });
}
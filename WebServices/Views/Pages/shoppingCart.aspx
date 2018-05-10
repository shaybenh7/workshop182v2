<%@ Page Title="Shopping Cart Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="shoppingCart.aspx.cs" Inherits="WebServices.Views.Pages.shoppingCart" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">



    <!-- Shoping Cart -->

    <div class="container">
        <div class="row">
            <div class="wrap-modal1 js-modal1 p-t-60 p-b-20" id="afterCheckoutModal">
                <div class="overlay-modal1 js-hide-modal1"></div>

                <div class="container">
                    <div class="bg0 p-t-60 p-b-30 p-lr-15-lg how-pos3-parent">

                        <button class="how-pos3 hov3 trans-04 js-hide-modal1">
                            <img src="images/icons/icon-close.png" alt="CLOSE">
                        </button>
                        <div class="row">
                            <div class="col-lg-10 col-xl-7 m-lr-auto m-b-50">
                                <div class="m-l-25 m-r--38 m-lr-0-xl">
                                    <div class="m-l-25 m-r--38 m-lr-0-xl">
                                        <div class="wrap-table-shopping-cart">
                                            <table id="shoppingCartModal" class="table-shopping-cart">
                                                <tr class="table_head">
                                                    <th class="column-1">Product</th>
                                                    <th class="column-2">Initial Price</th>
                                                    <th class="column-3">Final Price</th>
                                                    <th class="column-4">Quantity</th>
                                                    <th class="column-5">Total</th>
                                                </tr>
                                            </table>
                                        </div>

                                        <div class="flex-w flex-sb-m bor15 p-t-18 p-b-15 p-lr-40 p-lr-15-sm">
                                            <div class="flex-w flex-m m-r-20 m-tb-5">
                                                <input class="stext-104 cl2 plh4 size-117 bor13 p-lr-20 m-r-10 m-tb-5" type="text" name="coupon" placeholder="Coupon Code">

                                                <div class="flex-c-m stext-101 cl2 size-118 bg8 bor13 hov-btn3 p-lr-15 trans-04 pointer m-tb-5">
                                                    Apply coupon
                                                </div>
                                            </div>
                                            <input type="button" value="Purchase" id="purchase_btn" class="flex-c-m stext-101 cl2 size-119 bg8 bor13 hov-btn3 p-lr-15 trans-04 pointer m-tb-10" />

                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-10 col-xl-7 m-lr-auto m-b-50">
                <div class="m-l-25 m-r--38 m-lr-0-xl">
                    <div class="wrap-table-shopping-cart">
                        <table id="shoppingCart" class="table-shopping-cart">
                            <tr class="table_head">
                                <th class="column-1">Product</th>
                                <th class="column-2">Initial Price</th>
                                <th class="column-3">Price</th>
                                <th class="column-4">Quantity</th>
                                <th class="column-5">Total</th>
                            </tr>
                        </table>
                    </div>

                    <div class="flex-w flex-sb-m bor15 p-t-18 p-b-15 p-lr-40 p-lr-15-sm">
                        <div class="flex-w flex-m m-r-20 m-tb-5">
                            <input class="stext-104 cl2 plh4 size-117 bor13 p-lr-20 m-r-10 m-tb-5" type="text" name="coupon" placeholder="Coupon Code">

                            <div class="flex-c-m stext-101 cl2 size-118 bg8 bor13 hov-btn3 p-lr-15 trans-04 pointer m-tb-5">
                                Apply coupon
                            </div>
                        </div>

                        <div class="flex-c-m stext-101 cl2 size-119 bg8 bor13 hov-btn3 p-lr-15 trans-04 pointer m-tb-10">
                            Update Cart
                        </div>
                    </div>
                </div>
            </div>

            <div class="col-sm-10 col-lg-7 col-xl-5 m-lr-auto m-b-50">
                <div class="bor10 p-lr-40 p-t-30 p-b-40 m-l-63 m-r-40 m-lr-0-xl p-lr-15-sm">
                    <h4 class="mtext-109 cl2 p-b-30">Cart Totals
                    </h4>



                    <div class="flex-w flex-t bor12 p-t-15 p-b-30">
                        <div class="size-208 w-full-ssm">
                            <span class="stext-110 cl2">Shipping  (OPTIONAL):
                            </span>

                        </div>

                        <div class="size-209 p-r-18 p-r-0-sm w-full-ssm">

                            <div class="p-t-15">

                                <div class="bor8 bg0 m-b-12">
                                    <input class="stext-111 cl8 plh3 size-111 p-lr-15" type="text" id="country" name="state" placeholder="State /country">
                                </div>

                                <div class="bor8 bg0 m-b-12">
                                    <input class="stext-111 cl8 plh3 size-111 p-lr-15" type="text" id="address" name="address" placeholder="Address">
                                </div>


                            </div>
                        </div>
                    </div>
                    <div class="flex-w flex-t bor12 p-t-15 p-b-30">
                        <div class="size-208 w-full-ssm">
                            <span class="stext-110 cl2">Credit card number:
                            </span>

                        </div>
                        <div class="size-209 p-r-18 p-r-0-sm w-full-ssm">

                            <div class="p-t-15">

                                <div class="bor8 bg0 m-b-12">
                                    <input class="stext-111 cl8 plh3 size-111 p-lr-15" id="creditCard" type="text" name="cardNum" placeholder="XXXX-XXXX-XXXX-XXXX">
                                </div>


                            </div>
                        </div>

                    </div>
                    <div class="flex-w flex-t p-t-27 p-b-33">
                        <div class="size-208">
                            <span class="mtext-101 cl2">Total:
                            </span>
                        </div>

                        <div class="size-209 p-t-1">
                            <span class="mtext-110 cl2" id="total-price">TOTAL PRICE : 
                            </span>
                        </div>
                    </div>
                    <input type="button" value="Checkout" id="checkout_btn" onclick="checkoutFunc();" class="flex-c-m stext-101 cl0 size-116 bg3 bor14 hov-btn3 p-lr-15 trans-04 pointer" />
                </div>
            </div>

        </div>
    </div>





    <!-- Back to top -->
    <div class="btn-back-to-top" id="myBtn">
        <span class="symbol-btn-back-to-top">
            <i class="zmdi zmdi-chevron-up"></i>
        </span>
    </div>

    <!--===============================================================================================-->
    <script src="vendor/jquery/jquery-3.2.1.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/animsition/js/animsition.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/bootstrap/js/popper.js"></script>
    <script src="vendor/bootstrap/js/bootstrap.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/select2/select2.min.js"></script>
    <script>
        $(".js-select2").each(function () {
            $(this).select2({
                minimumResultsForSearch: 20,
                dropdownParent: $(this).next('.dropDownSelect2')
            });
        })
    </script>
    <!--===============================================================================================-->
    <script src="vendor/MagnificPopup/jquery.magnific-popup.min.js"></script>
    <!--===============================================================================================-->
    <script src="vendor/perfect-scrollbar/perfect-scrollbar.min.js"></script>
    <script>
        $('.js-pscroll').each(function () {
            $(this).css('position', 'relative');
            $(this).css('overflow', 'hidden');
            var ps = new PerfectScrollbar(this, {
                wheelSpeed: 1,
                scrollingThreshold: 1000,
                wheelPropagation: false,
            });

            $(window).on('resize', function () {
                ps.update();
            })
        });
    </script>
    <!--===============================================================================================-->
    <script src="js/main.js"></script>
    <script>

        function checkoutFunc() {
            var country = $("#country").val();
            var address = $("#address").val();;

            //now need to add stuff to the modal
            var mainDivModal = document.getElementById('shoppingCartModal');
            jQuery.ajax({
                type: "GET",
                url: "http://localhost:53416/api/sell/checkout?country=" + country + "&address=" + address,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    if (response instanceof String)
                        alert(response);
                    else {
                        console.log(response);
                        var i;
                        for (i = 0; i < response.length; i++) {
                            element = response[i];
                            var amount = element["Amount"];
                            var saleId = element["SaleId"];
                            var totalBeforeDiscount = element["Price"];
                            var totalAfterDiscount = element["PriceAfterDiscount"];
                            var price = totalAfterDiscount / amount;
                            var priceBeforeDiscount = totalBeforeDiscount / amount;
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
                            string += "<input type=\"image\" onclick=\"RemoveProductFromCart(" + saleId + ")\" src=\"images/removee.png\" id=\"remove" + i + "\" width=\"40\" height=\"40\">";
                            //string += "</div>";
                            string += "</td>";
                            string += "<td class=\"column-2\" id=\"InitialpriceModal" + i + "\">" + priceBeforeDiscount.toFixed(2) + "</td>";
                            string += "<td class=\"column-3\" id=\"FinalpriceModal" + i + "\">" + price.toFixed(2) + "</td>";
                            string += "<td class=\"column-4\" id=\"quantityModal" + i + "\">" + amount + "</td>";
                            string += "<td class=\"column-5\" id=\"totalModal" + i + "\">" + totalAfterDiscount.toFixed(2) + "</td>";
                            string += "</tr>";
                            mainDivModal.innerHTML += string;

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
                        var element = document.getElementById("afterCheckoutModal");
                        element.classList.add("show-modal1");
                    }
                },
                error: function (response) {
                    console.log("error");
                    console.log(response);
                    //window.location.href = "http://localhost:53416/error";
                }
            });

        }


        $("#purchase_btn").click(function () {
            console.log("in purchase_btn func");
            var country = $("#country").val();
            var address = $("#address").val();
            var creditcard = $("#creditCard").val();


            jQuery.ajax({
                type: "GET",
                url: "http://localhost:53416/api/sell/buyProductsInCart?country=" + country + "&address=" + address + "&creditcard=" + creditcard,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                                        console.log(response);

                    //alert(response);
                    //window.location.reload(false);

                },
                error: function (response) {
                    console.log(response);
                    //window.location.reload(false);
                }
            });
        });

    </script>
    <script src="vendor/JS/shoppingCart.js" type="text/javascript"></script>


</asp:Content>



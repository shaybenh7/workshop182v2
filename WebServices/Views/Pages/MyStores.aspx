<%@ Page Title="index Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyStores.aspx.cs" Inherits="WebServices.Views.Pages.MyStores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="allStoresComponent">
        <div class="p-t-50">
            <h4 class="mtext-112 cl2 p-b-27">Store1</h4>

            <div class="flex-w m-r--5">
                <a href="#" id="addProductInStore" class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Add Product</a>

                <a href="#" id="editProductInStore" class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Edit Product</a>

                <a href="#" id="removeProductFromStore" class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Remove Product
                </a>

                <a href="#" id="addStoreManager" class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Add Store Manager
                </a>

                <a href="#" id="removeStoreManager" class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Remove Store Manager
                </a>

                <a href="#" id="addStoreOwner" class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Add Store Owner
                </a>

                <a href="#" id="removeStoreOwner" class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Remove Store Owner
                </a>

                <a href="#" id="addManagerPermission" class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Add Manager Permission
                </a>

                <a href="#" id="removeManagerPermission" class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Remove Manager Permission
                </a>

                <a href="#" id="addSaleToStore" class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Add Sale
                </a>

                <a href="#" id="editSale" class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Edit Sale
                </a>

                <a href="#" id="removeSaleFromStore" class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Remove Sale
                </a>

                <a href="#" id="addDiscount" class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Add Discount
                </a>

                <a href="#" id="removeDiscount" class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Remove Discount
                </a>

                <a href="#" id="Add New Coupon" class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Add Coupon
                </a>

                <a href="#" id="removeCoupon" class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">Remove Coupon
                </a>

                <a href="#" id="viewPurchasesHistory" class="flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5">View History</a>
            </div>
        </div>
    </div>

    <script type="text/javascript">

        $(document).ready(function () {
            $(document).ready(function () {
                var mainDiv = document.getElementById('allStoresComponent');
                jQuery.ajax({
                    type: "GET",
                    url: "http://localhost:53416/api/user/getAllStoresUnderUser",
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        console.log(response);
                        var i;
                        for (i = 0; i < response.length; i++) {
                            storeRole = response[i];
                            if (storeRole["store"]["isActive"] == 1 && (storeRole["type"] == "Manager" || storeRole["type"] == "Owner")) {
                                var storeName = storeRole["store"]["name"];
                                var storeId = storeRole["store"]["storeId"];
                                var disabledLinksInitial = "disabledLink";
                                if (storeRole["type"] == "Owner")
                                    disabledLinksInitial = "";
                                var string = "";

                                string += "<div class=\"p-t-50\">";
                                string += "<h4 class=\"mtext-112 cl2 p-b-27\">" + storeName + "</h4>";
                                string += "<div class=\"flex-w m-r--5\">";
                                string += "<a href=\"#\" id=\"addProductInStore" + i + "\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Product</a>";
                                string += "<a href=\"#\" id=\"editProductInStore" + i + "\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Edit Product</a>";
                                string += "</div>";
                                string += "</div>";
                                mainDiv.innerHTML += string;
                                if (storeRole["type"] == "Manager") {
                                    (function (i, storeId) {
                                        jQuery.ajax({
                                            type: "GET",
                                            url: "http://localhost:53416/api/user/getPremissionsOfAManager?storeId=" + storeId,
                                            contentType: "application/json; charset=utf-8",
                                            dataType: "json",
                                            success: function (response) { //iterate through premissions and enable links
                                                response = response["privileges"];
                                                for (var key in response) {
                                                    if (response.hasOwnProperty(key) && response[key] == true) {
                                                        enableLink(key + i);
                                                    }
                                                }
                                            },
                                            error: function (response) {
                                                console.log(response);
                                            }
                                        });

                                    })(i, storeId);
                                }
                            }

                        }
                    },
                    error: function (response) {
                        console.log(response);
                        window.location.href = "http://localhost:53416/error";
                    }
                });
            });

        });

        function disableLink(id) {
            var element = document.getElementById(id);
            element.classList.add("disabledLink");
        }
        function enableLink(id) {
            var element = document.getElementById(id);
            element.classList.remove("disabledLink");
        }
    </script>
</asp:Content>


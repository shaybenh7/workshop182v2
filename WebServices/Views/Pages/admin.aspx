<%@ Page Title="index Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="WebServices.Views.Pages.admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="bor10 p-lr-40 p-t-30 p-b-40 m-l-63 m-r-40 m-lr-0-xl p-lr-15-sm " style="margin-left: 0px; margin-right: 0px">

                <h4 class="mtext-109 cl2 p-b-30">Remove User</h4>
                <div class="flex-w flex-t bor12 p-t-15 p-b-30">
                    <div class="size-208 w-full-ssm">
                        <span class="stext-110 cl2">Username:
                        </span>

                    </div>
                    <div class="size-209 p-r-18 p-r-0-sm w-full-ssm">

                        <div class="p-t-15">

                            <div class="bor8 bg0 m-b-12">
                                <input class="stext-111 cl8 plh3 size-111 p-lr-15" type="text" id="userName" name="userName" placeholder="Vadim">
                            </div>


                        </div>
                    </div>

                </div>
                <input type="button" value="Remove User" id="removeUserButton" onclick="removeUserFunc();" class="flex-c-m stext-101 cl0 size-116 bg3 bor14 hov-btn3 p-lr-15 trans-04 pointer" />
            </div>
            <div class="bor10 p-lr-40 p-t-30 p-b-40 m-l-63 m-r-40 m-lr-0-xl p-lr-15-sm" style="margin-left: 0px; margin-right: 0px">
                <h4 class="mtext-109 cl2 p-b-30">View History</h4>
                <div class="flex-w flex-t">
                    <input type="radio" name="optradio" checked="checked">User
                    <input type="radio" name="optradio">Store
                </div>
                <div class="flex-w flex-t bor12 p-t-15 p-b-30">

                    <div class="size-208 w-full-ssm">
                        <span class="stext-110 cl2">Name:
                        </span>

                    </div>
                    <div class="size-209 p-r-18 p-r-0-sm w-full-ssm">

                        <div class="p-t-15">

                            <div class="bor8 bg0 m-b-12">
                                <input class="stext-111 cl8 plh3 size-111 p-lr-15" type="text" id="nameInput" name="userName" placeholder="Vadim">
                            </div>


                        </div>
                    </div>

                </div>
                <input type="button" value="View Purchase History" id="viewHistoryButton" onclick="addProductFunct();" class="flex-c-m stext-101 cl0 size-116 bg3 bor14 hov-btn3 p-lr-15 trans-04 pointer" />
            </div>
            <div class="bor10 p-lr-40 p-t-30 p-b-40 m-l-63 m-r-40 m-lr-0-xl p-lr-15-sm" style="margin-left: 0px; margin-right: 0px">
                <h4 class="mtext-109 cl2 p-b-30">Change Policy</h4>
                <div class="flex-w flex-t bor12 p-t-15 p-b-30">
                    <div class="size-208 w-full-ssm">
                        <span class="stext-110 cl2">Username:
                        </span>

                    </div>
                    <div class="size-209 p-r-18 p-r-0-sm w-full-ssm">

                        <div class="p-t-15">

                            <div class="bor8 bg0 m-b-12">
                                <input class="stext-111 cl8 plh3 size-111 p-lr-15" type="text" id="addPolicyText" name="userName" placeholder="Vadim">
                            </div>


                        </div>
                    </div>

                </div>
                <input type="button" value="Add Policy" id="addPolicyButton" onclick="addProductFunct();" class="flex-c-m stext-101 cl0 size-116 bg3 bor14 hov-btn3 p-lr-15 trans-04 pointer" />
            </div>
        </div>
    </div>





    <script type="text/javascript">
        var removeUserFunc = function () {
            userName = $("#userName").val();

            jQuery.ajax({
                type: "GET",
                url: "http://localhost:53416/api/user/removeUser?userDeleted=" + userName,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    alert(response);
                    window.location.reload(false);

                },
                error: function (response) {
                    console.log(response);
                    // window.location.reload(false); 
                }
            });
        };
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

                            string += "<div class=\"p-t-50\" style=\"padding-left:50px\">";
                            string += "<h4 class=\"mtext-112 cl2 p-b-27\">" + storeName + "</h4>";
                            string += "<div class=\"flex-w m-r--5\">";
                            string += "<a href=\"#\" id=\"addProductInStore" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Product</a>";
                            string += "<a href=\"#\" id=\"editProductInStore" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Edit Product</a>";
                            string += "<a href=\"#\" id=\"removeProductFromStore" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Product</a>";
                            string += "<a href=\"#\" id=\"addStoreManager" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Store Manager</a>";
                            string += "<a href=\"#\" id=\"removeStoreManager" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Store Manager</a>";
                            string += "<a href=\"#\" id=\"addStoreOwner" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Store Owner</a>";
                            string += "<a href=\"#\" id=\"removeStoreOwner" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Store Owner</a>";
                            string += "<a href=\"#\" id=\"addManagerPermission" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Manager Permission</a>";
                            string += "<a href=\"#\" id=\"removeManagerPermission" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Manager Permission</a>";
                            string += "<a href=\"#\" id=\"addSaleToStore" + i + "\" data-id=\"" + storeId + "\" onclick=\"addSaleView(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Sale</a>";
                            string += "<a href=\"#\" id=\"editSale" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Edit Sale</a>";
                            string += "<a href=\"#\" id=\"removeSaleFromStore" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Sale</a>";
                            string += "<a href=\"#\" id=\"addDiscount" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Discount</a>";
                            string += "<a href=\"#\" id=\"removeDiscount" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Discount</a>";
                            string += "<a href=\"#\" id=\"addNewCoupon" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Coupon</a>";
                            string += "<a href=\"#\" id=\"removeCoupon" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Coupon</a>";
                            string += "<a href=\"#\" id=\"viewPurchasesHistory" + i + "\" data-id=\"" + storeId + "\" onclick=\"viewHistory(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">View History</a>";

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
                                                    //document.getElementById(key + i).onclick = modalLinkListener;
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

    </script>
</asp:Content>


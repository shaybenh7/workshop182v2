<%@ Page Title="index Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="MyStores.aspx.cs" Inherits="WebServices.Views.Pages.MyStores" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-lg-10 col-xl-7 m-lr-auto m-b-50" style="max-width: 67%; flex: 0 0 67%;">
            <div id="allStoresComponent">
                <div class="wrap-modal1 js-modal1 p-t-60 p-b-20" id="addProductInStoreModal">
                    <div class="overlay-modal1 js-hide-modal1"></div>

                    <div class="container">
                        <div class="bg0 p-t-60 p-b-30 p-lr-15-lg how-pos3-parent">

                            <button class="how-pos3 hov3 trans-04 js-hide-modal1">
                                <img src="images/icons/icon-close.png" alt="CLOSE">
                            </button>
                            <div class="row">
                                <div class="col-md-6 col-lg-7 p-b-30">
                                    <div class="p-l-25 p-r-30 p-lr-0-lg">
                                        <div class="wrap-slick3 flex-sb flex-w">

                                            <div class="size-204 flex-w flex-m respon6-next">
                                                <span class="mtext-106 cl2">Add product to store</span>
                                                <br />
                                                <br />
                                                <div class="wrap-input1 w-full p-b-4">
                                                    <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="product-name" placeholder="Enter product name">
                                                    <div class="focus-input1 trans-04"></div>
                                                </div>

                                                <div class="wrap-input1 w-full p-b-4">
                                                    <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="product-price" placeholder="Enter product price">
                                                    <div class="focus-input1 trans-04"></div>

                                                </div>

                                                <div class="wrap-input1 w-full p-b-4">
                                                    <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="product-amount" placeholder="Enter amount">
                                                    <div class="focus-input1 trans-04"></div>
                                                </div>


                                                <div class="flex-w flex-r-m p-b-10">
                                                    <div></div>

                                                    <div class="size-204 respon6-next">
                                                        <div>
                                                            <select name="time">
                                                                <option>Choose category</option>
                                                                <option>Chocolate</option>
                                                                <option>Clothing</option>
                                                            </select>
                                                            <div class="dropDownSelect2"></div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <button class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail">
                                                        Add product
                                                    </button>
                                                </div>



                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>



                <div class="wrap-modal1 js-modal1 p-t-60 p-b-20" id="editProductInStoreModal">
                    <div class="overlay-modal1 js-hide-modal1"></div>

                    <div class="container">
                        <div class="bg0 p-t-60 p-b-30 p-lr-15-lg how-pos3-parent">

                            <button class="how-pos3 hov3 trans-04 js-hide-modal1">
                                <img src="images/icons/icon-close.png" alt="CLOSE">
                            </button>
                            <div class="row">
                                <div class="col-md-6 col-lg-7 p-b-30">
                                    <div class="p-l-25 p-r-30 p-lr-0-lg">
                                        <div class="wrap-slick3 flex-sb flex-w">

                                            <div class="size-204 flex-w flex-m respon6-next">
                                                <span class="mtext-106 cl2">Edit product</span>
                                                <br />
                                                <br />
                                                <div class="size-204 respon6-next">
                                                    <div>
                                                        <select name="time">
                                                            <option>Choose product</option>
                                                            <option>Milk</option>
                                                            <option>Shawarma</option>
                                                        </select>
                                                        <div class="dropDownSelect2"></div>
                                                    </div>
                                                </div>

                                                <div class="wrap-input1 w-full p-b-4">
                                                    <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="product-price2" placeholder="Enter product price">
                                                    <div class="focus-input1 trans-04"></div>

                                                </div>

                                                <div class="wrap-input1 w-full p-b-4">
                                                    <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="product-amount2" placeholder="Enter amount">
                                                    <div class="focus-input1 trans-04"></div>
                                                </div>


                                                <div class="flex-w flex-r-m p-b-10">
                                                    <div></div>
                                                    <div class="size-204 respon6-next">
                                                        <div>
                                                            <select name="time">
                                                                <option>Choose category</option>
                                                                <option>Chocolate</option>
                                                                <option>Clothing</option>
                                                            </select>
                                                            <div class="dropDownSelect2"></div>
                                                        </div>
                                                    </div>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <button class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail">
                                                        Edit product
                                                    </button>
                                                </div>



                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>

                <div class="wrap-modal1 js-modal1 p-t-60 p-b-20" id="removeProductFromStoreModal">
                    <div class="overlay-modal1 js-hide-modal1"></div>

                    <div class="container">
                        <div class="bg0 p-t-60 p-b-30 p-lr-15-lg how-pos3-parent">

                            <button class="how-pos3 hov3 trans-04 js-hide-modal1">
                                <img src="images/icons/icon-close.png" alt="CLOSE">
                            </button>
                            <div class="row">
                                <div class="col-md-6 col-lg-7 p-b-30">
                                    <div class="p-l-25 p-r-30 p-lr-0-lg">
                                        <div class="wrap-slick3 flex-sb flex-w">

                                            <div class="size-204 flex-w flex-m respon6-next">
                                                <span class="mtext-106 cl2">Remove product</span>
                                                <br />
                                                <br />
                                                <div class="size-204 respon6-next">
                                                    <div>
                                                        <select name="time">
                                                            <option>Choose product</option>
                                                            <option>Milk</option>
                                                            <option>Shawarma</option>
                                                        </select>
                                                        <div class="dropDownSelect2"></div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <br />

                                                <button class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail">
                                                    Remove product
                                                </button>



                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>

                <div class="wrap-modal1 js-modal1 p-t-60 p-b-20" id="addStoreManagerModal">
                    <div class="overlay-modal1 js-hide-modal1"></div>

                    <div class="container">
                        <div class="bg0 p-t-60 p-b-30 p-lr-15-lg how-pos3-parent">

                            <button class="how-pos3 hov3 trans-04 js-hide-modal1">
                                <img src="images/icons/icon-close.png" alt="CLOSE">
                            </button>
                            <div class="row">
                                <div class="col-md-6 col-lg-7 p-b-30">
                                    <div class="p-l-25 p-r-30 p-lr-0-lg">
                                        <div class="wrap-slick3 flex-sb flex-w">

                                            <div class="size-204 flex-w flex-m respon6-next">
                                                <span class="mtext-106 cl2">Add store manager</span>

                                                <div class="wrap-input1 w-full p-b-4">
                                                    <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="new-manager-name" placeholder="Enter manager name">
                                                    <div class="focus-input1 trans-04"></div>

                                                </div>
                                                <br />
                                                <br />
                                                <br />
                                                <button class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail">
                                                    Add manager
                                                </button>



                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>

                <div class="wrap-modal1 js-modal1 p-t-60 p-b-20" id="removeStoreManagerModal">
                    <div class="overlay-modal1 js-hide-modal1"></div>

                    <div class="container">
                        <div class="bg0 p-t-60 p-b-30 p-lr-15-lg how-pos3-parent">

                            <button class="how-pos3 hov3 trans-04 js-hide-modal1">
                                <img src="images/icons/icon-close.png" alt="CLOSE">
                            </button>
                            <div class="row">
                                <div class="col-md-6 col-lg-7 p-b-30">
                                    <div class="p-l-25 p-r-30 p-lr-0-lg">
                                        <div class="wrap-slick3 flex-sb flex-w">

                                            <div class="size-204 flex-w flex-m respon6-next">
                                                <span class="mtext-106 cl2">Remove store manager</span>

                                                <div class="wrap-input1 w-full p-b-4">
                                                    <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="old-manager-name" placeholder="Enter manager name">
                                                    <div class="focus-input1 trans-04"></div>

                                                </div>
                                                <br />
                                                <br />
                                                <br />
                                                <button class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail">
                                                    Remove manager
                                                </button>



                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>

                <div class="wrap-modal1 js-modal1 p-t-60 p-b-20" id="addStoreOwnerModal">
                    <div class="overlay-modal1 js-hide-modal1"></div>

                    <div class="container">
                        <div class="bg0 p-t-60 p-b-30 p-lr-15-lg how-pos3-parent">

                            <button class="how-pos3 hov3 trans-04 js-hide-modal1">
                                <img src="images/icons/icon-close.png" alt="CLOSE">
                            </button>
                            <div class="row">
                                <div class="col-md-6 col-lg-7 p-b-30">
                                    <div class="p-l-25 p-r-30 p-lr-0-lg">
                                        <div class="wrap-slick3 flex-sb flex-w">

                                            <div class="size-204 flex-w flex-m respon6-next">
                                                <span class="mtext-106 cl2">Add store owner</span>

                                                <div class="wrap-input1 w-full p-b-4">
                                                    <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="new-owner-name" placeholder="Enter manager name">
                                                    <div class="focus-input1 trans-04"></div>

                                                </div>
                                                <br />
                                                <br />
                                                <br />
                                                <button class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail">
                                                    Add owner
                                                </button>



                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>

                <div class="wrap-modal1 js-modal1 p-t-60 p-b-20" id="removeStoreOwnerModal">
                    <div class="overlay-modal1 js-hide-modal1"></div>

                    <div class="container">
                        <div class="bg0 p-t-60 p-b-30 p-lr-15-lg how-pos3-parent">

                            <button class="how-pos3 hov3 trans-04 js-hide-modal1">
                                <img src="images/icons/icon-close.png" alt="CLOSE">
                            </button>
                            <div class="row">
                                <div class="col-md-6 col-lg-7 p-b-30">
                                    <div class="p-l-25 p-r-30 p-lr-0-lg">
                                        <div class="wrap-slick3 flex-sb flex-w">

                                            <div class="size-204 flex-w flex-m respon6-next">
                                                <span class="mtext-106 cl2">Remove store owner</span>

                                                <div class="wrap-input1 w-full p-b-4">
                                                    <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="old-owner-name" placeholder="Enter owner name">
                                                    <div class="focus-input1 trans-04"></div>

                                                </div>
                                                <br />
                                                <br />
                                                <br />
                                                <button class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail">
                                                    Remove owner
                                                </button>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>

                <div class="wrap-modal1 js-modal1 p-t-60 p-b-20" id="addManagerPermissionModal">
                    <div class="overlay-modal1 js-hide-modal1"></div>

                    <div class="container">
                        <div class="bg0 p-t-60 p-b-30 p-lr-15-lg how-pos3-parent">

                            <button class="how-pos3 hov3 trans-04 js-hide-modal1">
                                <img src="images/icons/icon-close.png" alt="CLOSE">
                            </button>
                            <div class="row">
                                <div class="col-md-6 col-lg-7 p-b-30">
                                    <div class="p-l-25 p-r-30 p-lr-0-lg">
                                        <div class="wrap-slick3 flex-sb flex-w">

                                            <div class="size-204 flex-w flex-m respon6-next">
                                                <span class="mtext-106 cl2">Add manager permissions</span>

                                                <div class="wrap-input1 w-full p-b-4">
                                                    <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="manager-to-change-permissions" placeholder="Enter manager name">
                                                    <div class="focus-input1 trans-04"></div>

                                                </div>
                                                <br />
                                                <br />
                                                <br />


                                                <div style="display: table; width: 100%;">
                                                    <div style="display:flex; margin-bottom:10px;">
                                                        <input type="checkbox" name="gender" value="male" style="margin-top:5px; margin-right:10px;"> addProductInStore
                                                    </div>
                                                
                                                    <div style="display:flex; margin-bottom:10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top:5px; margin-right:10px;"> editProductInStore
                                                    </div>
                                               <div style="display:flex; margin-bottom:10px;">
                                                <input type="checkbox" name="gender" value="female" style="margin-top:5px; margin-right:10px;"> 
                                                   removeProductFromStore  
                                                </div>
                                                <div style="display:flex; margin-bottom:10px;">
                                                <input type="checkbox" name="gender" value="female" style="margin-top:5px; margin-right:10px;"> 
                                                addStoreManager  
                                                </div>

                                                <div style="display:flex; margin-bottom:10px;">
                                                <input type="checkbox" name="gender" value="female" style="margin-top:5px; margin-right:10px;"> 
                                                removeStoreManager  
                                                </div>
                                                <div style="display:flex; margin-bottom:10px;">
                                                <input type="checkbox" name="gender" value="female" style="margin-top:5px; margin-right:10px;"> 
                                                addManagerPermission  
                                                </div>
                                                <div style="display:flex; margin-bottom:10px;">
                                                <input type="checkbox" name="gender" value="female" style="margin-top:5px; margin-right:10px;"> 
                                                removeManagerPermission  
                                                </div>
                                                <div style="display:flex; margin-bottom:10px;">
                                                <input type="checkbox" name="gender" value="female" style="margin-top:5px; margin-right:10px;"> 
                                                viewPurchasesHistory  
                                                </div>
                                                <div style="display:flex; margin-bottom:10px;">
                                                <input type="checkbox" name="gender" value="female" style="margin-top:5px; margin-right:10px;"> 
                                                removeSaleFromStore  
                                                </div>
                                                <div style="display:flex; margin-bottom:10px;">
                                                <input type="checkbox" name="gender" value="female" style="margin-top:5px; margin-right:10px;"> 
                                                editSale  
                                                </div>
                                                <div style="display:flex; margin-bottom:10px;">
                                                <input type="checkbox" name="gender" value="female" style="margin-top:5px; margin-right:10px;"> 
                                                addSaleToStore  
                                                </div>
                                                <div style="display:flex; margin-bottom:10px;">
                                                <input type="checkbox" name="gender" value="female" style="margin-top:5px; margin-right:10px;">
                                                addDiscount  
                                                </div>

                                                <div style="display:flex; margin-bottom:10px;">
                                                <input type="checkbox" name="gender" value="female" style="margin-top:5px; margin-right:10px;">
                                                addNewCoupon  
                                                </div>
                                                <div style="display:flex; margin-bottom:10px;">
                                                <input type="checkbox" name="gender" value="female" style="margin-top:5px; margin-right:10px;">
                                                removeDiscount  
                                                </div>
                                                 <div style="display:flex; margin-bottom:10px;">
                                                <input type="checkbox" name="gender" value="female" style="margin-top:5px; margin-right:10px;">
                                                removeCoupon  
                                                </div>
                                                    </div>
                                                <button class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail">
                                                    Add permissions
                                                </button>



                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>


            </div>
        </div>
        <div class="col-sm-10 col-lg-7 col-xl-5 m-lr-auto m-b-50" style="max-width: 33%; flex: 0 0 33%;">
            <div class="bor10 p-lr-40 p-t-30 p-b-40 m-l-63 m-r-40 m-lr-0-xl p-lr-15-sm">
                <h4 class="mtext-109 cl2 p-b-30">Create New Store
                </h4>




                <div class="flex-w flex-t bor12 p-t-15 p-b-30">
                    <div class="size-208 w-full-ssm">
                        <span class="stext-110 cl2">Store Name:
                        </span>

                    </div>
                    <div class="size-209 p-r-18 p-r-0-sm w-full-ssm">

                        <div class="p-t-15">

                            <div class="bor8 bg0 m-b-12">
                                <input class="stext-111 cl8 plh3 size-111 p-lr-15" type="text" id="storeName" name="storeName" placeholder="My store">
                            </div>


                        </div>
                    </div>

                </div>

                <button id="createStoreButton" class="flex-c-m stext-101 cl0 size-116 bg3 bor14 hov-btn3 p-lr-15 trans-04 pointer">
                    Create Store
                </button>
            </div>
        </div>
    </div>




    <script type="text/javascript">
        /*
        $(document).on("click", ".open-AddBookDialog", function () {
            console.log($(this).data('id'));
            document.getElementById('addBookDialog').style.display = "block";

            var myBookId = $(this).data('id');
            $(".modal-body #bookId").val(myBookId);
        });
        */

    </script>
    <script type="text/javascript">
        var lastClickedStoreId;
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
                                string += "<a href=\"#\" id=\"addProductInStore" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Product</a>";
                                string += "<a href=\"#\" id=\"editProductInStore" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Edit Product</a>";
                                string += "<a href=\"#\" id=\"removeProductFromStore" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Product</a>";
                                string += "<a href=\"#\" id=\"addStoreManager" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Store Manager</a>";
                                string += "<a href=\"#\" id=\"removeStoreManager" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Store Manager</a>";
                                string += "<a href=\"#\" id=\"addStoreOwner" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Store Owner</a>";
                                string += "<a href=\"#\" id=\"removeStoreOwner" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Store Owner</a>";
                                string += "<a href=\"#\" id=\"addManagerPermission" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Manager Permission</a>";
                                string += "<a href=\"#\" id=\"removeManagerPermission" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Manager Permission</a>";
                                string += "<a href=\"#\" id=\"addSaleToStore" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Sale</a>";
                                string += "<a href=\"#\" id=\"editSale" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Edit Sale</a>";
                                string += "<a href=\"#\" id=\"removeSaleFromStore" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Sale</a>";
                                string += "<a href=\"#\" id=\"addDiscount" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Discount</a>";
                                string += "<a href=\"#\" id=\"removeDiscount" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Discount</a>";
                                string += "<a href=\"#\" id=\"addNewCoupon" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Coupon</a>";
                                string += "<a href=\"#\" id=\"removeCoupon" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Coupon</a>";
                                string += "<a href=\"#\" id=\"viewPurchasesHistory" + i + "\" data-id=\"" + storeId + "\" onclick=\"modalLinkListener(event);\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">View History</a>";

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

        });
        function modalLinkListener(e) {
            lastClickedStoreId = e["srcElement"]["dataset"]["id"];
            key = e["srcElement"]["id"];
            key = key.replace(/[0-9]/g, '');
            openModal(key + "Modal");
            return false;
        }
        function enableLink(id) {
            var element = document.getElementById(id);
            element.classList.remove("disabledLink");
        }

        function openModal(id) {
            var element = document.getElementById(id);
            element.classList.add("show-modal1");
        }

    </script>
</asp:Content>


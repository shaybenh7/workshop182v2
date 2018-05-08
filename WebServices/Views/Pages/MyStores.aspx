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
                                                    <input type="button" value="Add product" id="add_product_btn" onclick="addProductFunct();" class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail"/>
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
                                                <div class="wrap-input1 w-full p-b-4">
                                                    <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="product-id2" placeholder="Enter product id">
                                                    <div class="focus-input1 trans-04"></div>

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
                                                    <input type="button" value="Edit product" onclick="editStoreProduct();" class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail"/>
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
                                                <div class="wrap-input1 w-full p-b-4">
                                                    <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="product-id3" placeholder="Enter product id">
                                                    <div class="focus-input1 trans-04"></div>

                                                </div>
                                                <br />
                                                <br />
                                                <br />

                                                <input type="button" value="Remove product" class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail" onclick="removeStoreProduct();"/>



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
                                                <input type="button" value="Add manager" class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail" onclick="addNewManager()"/>



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
                                                <input type="button" value="Remove manager" onclick="RemoveStoreManager();" class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail"/>



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
                                                <input type="button" value="Add Owner" onclick="addStoreOwner();" class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail"/>
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
                                                <input type="button" onclick="removeStoreOwner();" value="Remove owner" class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail"/>

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
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="male" style="margin-top: 5px; margin-right: 10px;">
                                                        addProductInStore
                                                    </div>

                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        editProductInStore
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        removeProductFromStore  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        addStoreManager  
                                                    </div>

                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        removeStoreManager  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        addManagerPermission  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        removeManagerPermission  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        viewPurchasesHistory  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        removeSaleFromStore  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        editSale  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        addSaleToStore  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        addDiscount  
                                                    </div>

                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        addNewCoupon  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        removeDiscount  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
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

                <div class="wrap-modal1 js-modal1 p-t-60 p-b-20" id="removeManagerPermissionModal">
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
                                                <span class="mtext-106 cl2">Remove manager permissions</span>

                                                <div class="wrap-input1 w-full p-b-4">
                                                    <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="manager-to-delete-permissions" placeholder="Enter manager name">
                                                    <div class="focus-input1 trans-04"></div>

                                                </div>
                                                <br />
                                                <br />
                                                <br />


                                                <div style="display: table; width: 100%;">
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="male" style="margin-top: 5px; margin-right: 10px;">
                                                        addProductInStore
                                                    </div>

                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        editProductInStore
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        removeProductFromStore  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        addStoreManager  
                                                    </div>

                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        removeStoreManager  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        addManagerPermission  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        removeManagerPermission  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        viewPurchasesHistory  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        removeSaleFromStore  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        editSale  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        addSaleToStore  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        addDiscount  
                                                    </div>

                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        addNewCoupon  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        removeDiscount  
                                                    </div>
                                                    <div style="display: flex; margin-bottom: 10px;">
                                                        <input type="checkbox" name="gender" value="female" style="margin-top: 5px; margin-right: 10px;">
                                                        removeCoupon  
                                                    </div>
                                                </div>
                                                <button class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail">
                                                    Remove permissions
                                                </button>



                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>
                <div class="wrap-modal1 js-modal1 p-t-60 p-b-20" id="addSaleToStoreModal">
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
                                                <span class="mtext-106 cl2">Add sale to store</span>
                                                <br />
                                                <br />
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
                                                <div class="wrap-input1 w-full p-b-4">
                                                    <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="product-amount-in-sale2" placeholder="Enter amount">
                                                    <div class="focus-input1 trans-04"></div>
                                                </div>

                                                <div class="size-204 respon6-next">
                                                    <div>
                                                        <select name="time">
                                                            <option>Kind of sale:</option>
                                                            <option>Instant sale</option>
                                                            <option>Raffle Sale</option>
                                                        </select>
                                                        <div class="dropDownSelect2"></div>
                                                    </div>
                                                </div>

                                                <br />
                                                <br />
                                                <div class="flex-w flex-r-m p-b-10">
                                                    <div></div>
                                                    <div class="wrap-input1 w-full p-b-4">
                                                        <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="product-due-date2" placeholder="Enter due date">
                                                        <div class="focus-input1 trans-04"></div>
                                                    </div>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <button class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail">
                                                        Edit sale
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
                <div class="wrap-modal1 js-modal1 p-t-60 p-b-20" id="editSaleModal">
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
                                                <span class="mtext-106 cl2">Edit sale in store</span>
                                                <br />
                                                <br />
                                                <br />
                                                <br />
                                                <div class="size-204 respon6-next">
                                                    <div>
                                                        <select name="time">
                                                            <option>Choose sale</option>
                                                            <option>Milk</option>
                                                            <option>Shawarma</option>
                                                        </select>
                                                        <div class="dropDownSelect2"></div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <br />
                                                <div class="wrap-input1 w-full p-b-4">
                                                    <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="product-amount-in-sale" placeholder="Enter amount">
                                                    <div class="focus-input1 trans-04"></div>
                                                </div>

                                                <div class="size-204 respon6-next">
                                                    <div>
                                                        <select name="time">
                                                            <option>Kind of sale:</option>
                                                            <option>when choosing the sale</option>
                                                            <option>this will put the correct sale</option>
                                                        </select>
                                                        <div class="dropDownSelect2"></div>
                                                    </div>
                                                </div>

                                                <br />
                                                <br />
                                                <div class="flex-w flex-r-m p-b-10">
                                                    <div></div>
                                                    <div class="wrap-input1 w-full p-b-4">
                                                        <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="product-due-date" placeholder="Enter due date">
                                                        <div class="focus-input1 trans-04"></div>
                                                    </div>
                                                    <br />
                                                    <br />
                                                    <br />
                                                    <button class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail">
                                                        Edit sale
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

                <div class="wrap-modal1 js-modal1 p-t-60 p-b-20" id="removeSaleFromStoreModal">
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
                                                            <option>Choose sale</option>
                                                            <option>Milk</option>
                                                            <option>Shawarma</option>
                                                        </select>
                                                        <div class="dropDownSelect2"></div>
                                                    </div>
                                                </div>
                                                <div class="size-204 respon6-next">
                                                    <div>
                                                        <select name="time">
                                                            <option>Kind of sale:</option>
                                                            <option>when choosing the sale</option>
                                                            <option>this will put the correct sale</option>
                                                        </select>
                                                        <div class="dropDownSelect2"></div>
                                                    </div>
                                                </div>
                                                <br />
                                                <br />
                                                <br />

                                                <button class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail">
                                                    Remove Sale
                                                </button>



                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>
                <div class="wrap-modal1 js-modal1 p-t-60 p-b-20" id="addDiscountModal">
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
                                                <span class="mtext-106 cl2">Add discount</span>
                                                <br />
                                                <br />
                                                <div class="size-204 respon6-next">
                                                    <div>
                                                        <select name="time">
                                                            <option>Choose sale</option>
                                                            <option>Milk</option>
                                                            <option>Shawarma</option>
                                                        </select>
                                                        <div class="dropDownSelect2"></div>
                                                    </div>
                                                </div>
                                                <div class="wrap-input1 w-full p-b-4">
                                                    <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="product-dicount" placeholder="Enter discount">
                                                    <div class="focus-input1 trans-04"></div>
                                                </div>
                                                <br />
                                                <br />
                                                <br />

                                                <button class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail">
                                                    Add discount
                                                </button>



                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>
                <div class="wrap-modal1 js-modal1 p-t-60 p-b-20" id="removeDiscountModal">
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
                                                <span class="mtext-106 cl2">Remove discount</span>
                                                <br />
                                                <br />
                                                <div class="size-204 respon6-next">
                                                    <div>
                                                        <select name="time">
                                                            <option>Choose sale</option>
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
                                                    Remove discount
                                                </button>



                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>



                    </div>
                </div>
                <div class="wrap-modal1 js-modal1 p-t-60 p-b-20" id="addNewCouponModal">
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
                                                <span class="mtext-106 cl2">Add new coupon</span>
                                                <br />
                                                <br />
                                                <div class="size-204 respon6-next">
                                                    <div>
                                                        <select name="time">
                                                            <option>Choose sale</option>
                                                            <option>Milk</option>
                                                            <option>Shawarma</option>
                                                        </select>
                                                        <div class="dropDownSelect2"></div>
                                                    </div>
                                                </div>
                                                <div class="wrap-input1 w-full p-b-4">
                                                    <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="offer" id="product-new-coupon" placeholder="Enter coupon">
                                                    <div class="focus-input1 trans-04"></div>
                                                </div>
                                                <br />
                                                <br />
                                                <br />

                                                <button class="flex-c-m stext-101 cl0 size-101 bg1 bor1 hov-btn1 p-lr-15 trans-04 js-addcart-detail">
                                                    Add coupon
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
            <div class="bor10 p-lr-40 p-t-30 p-b-40 m-l-63 m-r-40 m-lr-0-xl p-lr-15-sm" style="margin-top:46px; margin-right:91px; margin-left:-27px;">
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



    <script src="vendor/JS/MyStores.js" type="text/javascript"></script>

    <script type="text/javascript">
        

    </script>
</asp:Content>


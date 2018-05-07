﻿
<%@ Page Title="View Store Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="viewStore.aspx.cs" Inherits="WebServices.Views.Pages.viewStore" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <section class="sec-product-detail bg0 p-t-65 p-b-60">
        <div class="container">
            <div class="row">


                <div class="col-md-6 col-lg-5 p-b-30">
                    <div class="p-r-50 p-t-5 p-lr-0-lg">
                        <h4 class="mtext-105 cl2 js-name-detail p-b-14"> *Store Name*
                        </h4>
                        <span class="mtext-106 cl2">*owners*
                        </span>
                        <br />

                        <span class="mtext-106 cl2">*Managers*
                        </span>

                          
                        </div>
                        

                    </div>

             <div id="viewStore" class="row isotope-grid">

                </div>

                </div>
            </div>
           

    </section>


        <script type="text/javascript">
        function loadModal(saleId) {
            document.getElementById("modalContent").innerHTML = '<object type="text/html" data="http://localhost:53416/viewInstantSale?saleId=' + saleId + ' ></object>';
        }
    </script>


    <script type="text/javascript">

        $(document).ready(function () {
            var storeId = <%=ViewData["storeId"]%>;
            var mainDiv = document.getElementById('viewStore');
            
            jQuery.ajax({
                type: "GET",
                url: "http://localhost:53416/api/store/viewSalesByStore?storeId="+storeId,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    console.log(response);
                    var i;

                    for (i = 0; i < response.length; i++) {

                        sale = response[i];
                        var pis = sale["ProductInStoreId"];
                        var saleId = sale["SaleId"];
                        typeOfSale = sale["TypeOfSale"]; //typeOfSale = sale[typeOfSale];
                        var string = "";
                        string += "<div class=\"col-sm-6 col-md-4 col-lg-3 p-b-35 isotope-item women\" >";
                        string += "<div class=\"block2\">";
                        string += "<div class=\"block2-pic hov-img0\">";
                        string += "<img src=\"images/itamar.jpg\" alt=\"IMG-PRODUCT\">";
                        if (typeOfSale==1)
                            string += "<a href=\"http://localhost:53416/viewInstantSale?saleId="+saleId+"\" class=\"block2-btn flex-c-m stext-103 cl2 size-102 bg0 bor2 hov-btn1 p-lr-15 trans-04 js-show-modal1\">Quick Buy</a>";
                        else
                            string += "<a href=\"http://localhost:53416/viewRaffleSale?saleId="+saleId+"\" class=\"block2-btn flex-c-m stext-103 cl2 size-102 bg0 bor2 hov-btn1 p-lr-15 trans-04 js-show-modal1\">Quick Buy</a>";
                        string += "</div>";
                        string += "<div class=\"block2-txt flex-w flex-t p-t-14\">";
                        string += "<div class=\"block2-txt-child1 flex-col-l \">";
                        string += "<a href=\"product-detail.html\" class=\"stext-104 cl4 hov-cl1 trans-04 js-name-b2 p-b-6\">";
                        string += "<div id=\"productName" + i + "\">Product Name: </div>"; // add sale name here to saleName1
                        string += "</a>";
                        string += "<span class=\"stext-105 cl3\">";
                        string += "<div id=\"salePrice" + i + "\">Sale price: </div>"; // add sale name here to storeName
                        string += "</span>";
                        string += "<span class=\"stext-105 cl3\">";
                        string += "<div id=\"storeName" + i + "\">Store Name: </div>"; // add sale name here to storeName
                        string += "</span>";
                        string += "<span class=\"stext-105 cl3\">Kind of sale: " + typeOfSale + "</span>";
                        string += "</div>";
                        string += "</div>";
                        string += "</div>";
                        string += "</div>";
                        mainDiv.innerHTML += string;
                        (function (i) {
                            jQuery.ajax({
                                type: "GET",
                                url: "http://localhost:53416/api/store/getProductInStoreById?id=" + pis,
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (response) {
                                    var productNameElement = document.getElementById("productName" + i);
                                    productNameElement.innerHTML += response["product"]["name"];

                                    var storeNameElement = document.getElementById("storeName" + i);
                                    storeNameElement.innerHTML += response["store"]["name"];
                                },
                                error: function (response) {
                                    console.log(response);
                                }
                            });

                            jQuery.ajax({
                                type: "GET",
                                url: "http://localhost:53416/api/store/checkPriceOfAProduct?saleId=" + saleId, //add call to get price
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (response) {
                                    var salePriceElement = document.getElementById("salePrice" + i);
                                    salePriceElement.innerHTML += response;
                                },
                                error: function (response) {
                                    console.log(response);
                                }
                            });
                        })(i);
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
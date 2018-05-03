<%@ Page Title="Products Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AllProducts.aspx.cs" Inherits="WebServices.Views.Pages.AllProducts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="bg0 m-t-23 p-b-140" style="margin-left: auto; margin-right: auto; margin-top:100px ;max-width: 100%;">
        <div class="container">
            <div class="row isotope-grid">
                <div class="col-sm-6 col-md-4 col-lg-3 p-b-35 isotope-item women">
                    <!-- Block2 -->
                    <div class="block2">
                        <div class="block2-pic hov-img0">
                            <img src="images/product-01New.jpg" alt="IMG-PRODUCT">

                            <a href="#" class="block2-btn flex-c-m stext-103 cl2 size-102 bg0 bor2 hov-btn1 p-lr-15 trans-04 js-show-modal1">Quick Buy
                            </a>
                        </div>

                        <div class="block2-txt flex-w flex-t p-t-14">
                            <div class="block2-txt-child1 flex-col-l ">
                                <a href="product-detail.html" class="stext-104 cl4 hov-cl1 trans-04 js-name-b2 p-b-6">Esprit Ruffle Shirt
                                </a>

                                <span class="stext-105 cl3">$16.64
                                </span>
                                <span class="stext-105 cl3">Shay's Store
                                </span>
                                <span class="stext-105 cl3">Kind of sale: Regular
                                </span>
                                <span class="stext-105 cl3">ARAB MONEY
                                </span>

                            </div>

                            
                        </div>
                    </div>
                </div>
                </div>
        </div>
    </div>

     <script type="text/javascript">

        $(document).ready(function () {

        jQuery.ajax({
                type: "GET",
                url: "http://localhost:53416/api/user/viewAllSales",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                console.log(response);
			    },
                error: function (response) {
                    console.log(response);
				    window.location.href = "http://localhost:53416/error";
			    }
            });
});

</script>

</asp:Content>


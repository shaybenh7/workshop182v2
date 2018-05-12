<%@ Page Title="index Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="WebServices.Views.Pages.admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container">
        <div class="row">
            <div class="bor10 p-lr-40 p-t-30 p-b-40 m-l-63 m-r-40 m-lr-0-xl p-lr-15-sm " style="margin-left: 0px; margin-right: 0px">


                <div class="wrap-modal1 js-modal1 p-t-60 p-b-20" id="viewHistoryModal">
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
                                                <span class="mtext-106 cl2">View History</span>
                                                <br />

                                                    <table id="historyTable" class="table-shopping-cart">

                                                        <tr class="table_head">
                                                            <th class="column-2">userName</th>
                                                            <th class="column-1">StoreId</th>
                                                            <th class="column-1">ProductId</th>
                                                            <th class="column-1">BuyId</th>
                                                            <th class="column-1">Amount</th>
                                                            <th class="column-1">Price</th>
                                                            <th class="column-1">TypeOfSale</th>
                                                            <th class="column-5">Date</th>
                                                        </tr>
                                                    </table>

                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>


                    </div>
                </div>

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
                    <input type="radio" id="userRadio" name="optradio" checked="checked">User
                    <input type="radio" id="storeRadio" name="optradio">Store
                </div>
                <div class="flex-w flex-t bor12 p-t-15 p-b-30">

                    <div class="size-208 w-full-ssm">
                        <span class="stext-110 cl2">Name / StoreId:
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
                <input type="button" value="View Purchase History" id="viewHistoryButton" onclick="viewHistory();" class="flex-c-m stext-101 cl0 size-116 bg3 bor14 hov-btn3 p-lr-15 trans-04 pointer" />
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
                url: baseUrl+"/api/user/removeUser?userDeleted=" + userName,
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

        var viewHistory = function () {
            name = $("#nameInput").val();
            var ajaxURL = "";

            if (document.getElementById('userRadio').checked) {
                ajaxURL = baseUrl+"/api/store/viewUserHistory?userToGet=" + name;
            } else if (document.getElementById('storeRadio').checked) {
                ajaxURL = baseUrl+"/api/store/viewStoreHistory?storeId=" + name;
            }

            var mainDivModal = document.getElementById('historyTable');
            jQuery.ajax({
                type: "GET",
                url: ajaxURL,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    console.log(response);
                    var i;
                    for (i = 0; i < response.length; i++) {
                        element = response[i];
                        var Amount = element["Amount"];
                        var BuyId = element["BuyId"];
                        var Date = element["Date"];
                        var Price = element["Price"];
                        var ProductId = element["ProductId"];
                        var StoreId = element["StoreId"];
                        var TypeOfSale = element["TypeOfSale"];
                        var UserName = element["UserName"];

                        var string = "";
                        string += "<tr class=\"table_row\">";
                        string += "<td class=\"column-2\">" + UserName + "</td>";
                        string += "<td class=\"column-1\">" + StoreId + "</td>";
                        string += "<td class=\"column-1\">" + ProductId + "</td>";
                        string += "<td class=\"column-1\">" + BuyId + "</td>";
                        string += "<td class=\"column-1\">" + Amount + "</td>";
                        string += "<td class=\"column-1\">" + Price + "</td>";
                        string += "<td class=\"column-1\">" + TypeOfSale + "</td>";
                        string += "<td class=\"column-5\">" + Date + "</td>";

                        string += "</tr>";
                        mainDivModal.innerHTML += string;

                    }

                    var element = document.getElementById("viewHistoryModal");
                    element.classList.add("show-modal1");
                    //window.location.reload(false);

                },
                error: function (response) {
                    console.log(response);
                    // window.location.reload(false); 
                }
            });
            //var element = document.getElementById("viewHistoryModal");
            //element.classList.add("show-modal1");
        };
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#AdminMenuButton").addClass("active-menu")
        });
    </script>
</asp:Content>


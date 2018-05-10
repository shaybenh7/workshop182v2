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

        var viewHistory = function () {
            name = $("#nameInput").val();
            var ajaxURL = "";

            if (document.getElementById('userRadio').checked) {
                ajaxURL = "http://localhost:53416/api/store/viewUserHistory?userToGet=" + name;
            } else if (document.getElementById('storeRadio').checked) {
                ajaxURL = "http://localhost:53416/api/store/viewStoreHistory?storeId=" + name;
            }

            jQuery.ajax({
                type: "GET",
                url: ajaxURL,
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (response) {
                    console.log(response);
                    alert(response);
                    //window.location.reload(false);

                },
                error: function (response) {
                    console.log(response);
                    // window.location.reload(false); 
                }
            });
        };
    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            $("#AdminMenuButton").addClass("active-menu")
        });
    </script>
</asp:Content>


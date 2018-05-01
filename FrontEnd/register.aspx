<%@ Page Title="Register Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="register.aspx.cs" Inherits="FrontEnd.register" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bg0 p-t-75 p-b-32" style="margin-left: auto; margin-right: auto; max-width: 100%;">

        <div class="container" style="max-width: 100%;">
            <div class="row centerElem" style="max-width: 100%;">

                <div class="col-sm-6 col-lg-3 p-b-50 centerElem" style="max-width: 100%;">
                    <h4 class="stext-301 cl0 p-b-30">Newsletter
                    </h4>

                        <div class="wrap-input1 w-full p-b-4">
                            <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="username" placeholder="Enter username">
                            <div class="focus-input1 trans-04"></div>
                        </div>

                        <div class="wrap-input1 w-full p-b-4">
                            <input class="input1 bg-none plh1 stext-107 cl7" type="password" name="password1" placeholder="Enter your password">
                            <div class="focus-input1 trans-04"></div>
                        </div>

                        <div class="wrap-input1 w-full p-b-4">
                            <input class="input1 bg-none plh1 stext-107 cl7" type="password" name="password2" placeholder="Confirm password">
                            <div class="focus-input1 trans-04"></div>
                        </div>

                        <div class="p-t-18">
                            <button class="flex-c-m stext-101 cl0 size-103 bg1 bor1 hov-btn2 p-lr-15 trans-04">
                                Register
                            </button>
                        </div>
                </div>
            </div>


        </div>
    </div>
</asp:Content>

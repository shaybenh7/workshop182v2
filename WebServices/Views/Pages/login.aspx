<%@ Page Title="Login Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="WebServices.Views.Pages.login" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="bg0 p-t-75 p-b-32" style="margin-left: auto; margin-right: auto; max-width: 100%;">

        <div class="container" style="max-width: 100%;">
            <div class="row centerElem" style="max-width: 100%;">

                <div class="col-sm-6 col-lg-3 p-b-50 centerElem" style="max-width: 100%;">
                    <h4 class="stext-301 cl0 p-b-30">Newsletter
                    </h4>

                        <div class="wrap-input1 w-full p-b-4">
                            <input class="input1 bg-none plh1 stext-107 cl7" type="text" name="username" placeholder="Anatoly">
                            <div class="focus-input1 trans-04"></div>
                        </div>

                        <div class="wrap-input1 w-full p-b-4">
                            <input class="input1 bg-none plh1 stext-107 cl7" type="password" name="password" placeholder="123456">
                            <div class="focus-input1 trans-04"></div>
                        </div>

                        <div class="p-t-18">
                                <asp:Panel id="Form1" runat="server">

                            <asp:Button runat="server" class="flex-c-m stext-101 cl0 size-103 bg1 bor1 hov-btn2 p-lr-15 trans-04" name="btnLogin" id="btnLogin" Text="Login" OnClick="Button2_Click">
                                
                            </asp:button>
                                    </asp:Panel>
                        </div>
                </div>
            </div>


        </div>
    </div>

    <script type="text/javascript">
/*
        $(document).ready(function () {
	$("#btnLogin").click(function(){
		
		username=$("#username").val();
		pass=$("#password").val();
		
		var arguments= {
			"username":username,
			"password":pass
		};
        console.log("In js1");
		$.ajax({
			type: "Get",
			contentType:"application/json",
			dataType: "json",
			url: "http://localhost:53416/api/user/login",
			data: JSON.stringify(arguments),
			success: function(response){ 
				console.log(response);
				if (response.message == "success")
                {
                    console.log("In js2");
					//window.location.href = "http://localhost:53416/";
				}
				else
                {
                    console.log("In js3");
					//window.location.href = "http://localhost:53416/error";
				}
			},
			error: function(response){
                console.log(response);
                console.log("In js4");
				//window.location.href = "http://localhost:53416/error";
			}
		});
	});
});
*/
</script>

</asp:Content>



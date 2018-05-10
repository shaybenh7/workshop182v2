var lastClickedStoreId;
var productsInStore;


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
                if (storeRole["store"]["isActive"] === 1 && (storeRole["type"] === "Manager" || storeRole["type"] === "Owner")) {
                    var storeName = storeRole["store"]["name"];
                    var storeId = storeRole["store"]["storeId"];
                    var disabledLinksInitial = "disabledLink";
                    var actionInitial = "";
                    if (storeRole["type"] === "Owner") {
                        disabledLinksInitial = "";
                        actionInitial = "modalLinkListener(event);";
                    }
                    var string = "";

                    string += "<div class=\"p-t-50\" style=\"padding-left:50px\">";
                    string += "<h4 class=\"mtext-112 cl2 p-b-27\">" + storeName + "</h4>";
                    string += "<div class=\"flex-w m-r--5\">";
                    string += "<a href=\"#\" id=\"addProductInStore" + i + "\" data-id=\"" + storeId + "\" onclick=\"" + actionInitial+"\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Product</a>";
                    string += "<a href=\"#\" id=\"editProductInStore" + i + "\" data-id=\"" + storeId + "\" onclick=\"" + actionInitial +"\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Edit Product</a>";
                    string += "<a href=\"#\" id=\"removeProductFromStore" + i + "\" data-id=\"" + storeId + "\" onclick=\"" + actionInitial +"\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Product</a>";
                    string += "<a href=\"#\" id=\"addStoreManager" + i + "\" data-id=\"" + storeId + "\" onclick=\"" + actionInitial +"\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Store Manager</a>";
                    string += "<a href=\"#\" id=\"removeStoreManager" + i + "\" data-id=\"" + storeId + "\" onclick=\"" + actionInitial +"\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Store Manager</a>";
                    string += "<a href=\"#\" id=\"addStoreOwner" + i + "\" data-id=\"" + storeId + "\" onclick=\"" + actionInitial +"\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Store Owner</a>";
                    string += "<a href=\"#\" id=\"removeStoreOwner" + i + "\" data-id=\"" + storeId + "\" onclick=\"" + actionInitial +"\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Store Owner</a>";
                    string += "<a href=\"#\" id=\"addManagerPermission" + i + "\" data-id=\"" + storeId + "\" onclick=\"" + actionInitial +"\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Manager Permission</a>";
                    string += "<a href=\"#\" id=\"removeManagerPermission" + i + "\" data-id=\"" + storeId + "\" onclick=\"" + actionInitial +"\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Manager Permission</a>";
                    string += "<a href=\"#\" id=\"addSaleToStore" + i + "\" data-id=\"" + storeId + "\" onclick=\"" + ((actionInitial=="")?"":"addSaleView(event)") +"\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Sale</a>";
                    string += "<a href=\"#\" id=\"editSale" + i + "\" data-id=\"" + storeId + "\" onclick=\"" + actionInitial +"\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Edit Sale</a>";
                    string += "<a href=\"#\" id=\"removeSaleFromStore" + i + "\" data-id=\"" + storeId + "\" onclick=\"" + actionInitial +"\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Sale</a>";
                    string += "<a href=\"#\" id=\"addDiscount" + i + "\" data-id=\"" + storeId + "\" onclick=\"" + actionInitial +"\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Discount</a>";
                    string += "<a href=\"#\" id=\"removeDiscount" + i + "\" data-id=\"" + storeId + "\" onclick=\"" + actionInitial +"\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Discount</a>";
                    string += "<a href=\"#\" id=\"addNewCoupon" + i + "\" data-id=\"" + storeId + "\" onclick=\"" + ((actionInitial == "") ? "" : "viewCopun(event)") +"\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Add Coupon</a>";
                    string += "<a href=\"#\" id=\"removeCoupon" + i + "\" data-id=\"" + storeId + "\" onclick=\"" + actionInitial +"\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">Remove Coupon</a>";
                    string += "<a href=\"#\" id=\"viewPurchasesHistory" + i + "\" data-id=\"" + storeId + "\" onclick=\"" + ((actionInitial == "") ? "" : "viewHistory(event)")+"\" class=\"flex-c-m stext-107 cl6 size-301 bor7 p-lr-15 hov-tag1 trans-04 m-r-5 m-b-5 " + disabledLinksInitial + "\">View History</a>";

                    string += "</div>";
                    string += "</div>";
                    mainDiv.innerHTML += string;


                    if (storeRole["type"] === "Manager") {
                        (function (i, storeId) {
                            jQuery.ajax({
                                type: "GET",
                                url: "http://localhost:53416/api/user/getPremissionsOfAManager?storeId=" + storeId,
                                contentType: "application/json; charset=utf-8",
                                dataType: "json",
                                success: function (response) { //iterate through premissions and enable links
                                    response = response["privileges"];
                                    for (var key in response) {
                                        if (response.hasOwnProperty(key) && response[key] === true) {
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

$("#createStoreButton").click(function () {

    Storename = $("#storeName").val();

    jQuery.ajax({
        type: "GET",
        url: "http://localhost:53416/api/store/createStore?storeName=" + Storename,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response);
            window.location.reload(false);

        },
        error: function (response) {
            console.log(response);
            window.location.reload(false);
        }
    });
});


var addProductFunct = function () {
    productName = $("#product-name").val();
    price = $("#product-price").val();
    amount = $("#product-amount").val();

    jQuery.ajax({
        type: "GET",
        url: "http://localhost:53416/api/store/addProductInStore?productName=" + productName + "&price=" + price + "&amount=" + amount + "&storeId="+lastClickedStoreId,
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

var addNewManager = function () {
    ManagerName = $("#new-manager-name").val();

    jQuery.ajax({
        type: "GET",
        url: "http://localhost:53416/api/store/addStoreManager?storeId=" + lastClickedStoreId + "&newManager=" + ManagerName,
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

var RemoveStoreManager = function () {
    ManagerName = $("#old-manager-name").val();

    jQuery.ajax({
        type: "GET",
        url: "http://localhost:53416/api/store/removeStoreManager?storeId=" + lastClickedStoreId + "&oldManageruserName=" + ManagerName,
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

var addStoreOwner = function () {
    NewOwnerName = $("#new-owner-name").val();

    jQuery.ajax({
        type: "GET",
        url: "http://localhost:53416/api/store/addStoreOwner?storeId=" + lastClickedStoreId + "&newOwner=" + NewOwnerName,
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

var removeStoreOwner = function () {
    OldOwnerName = $("#old-owner-name").val();

    jQuery.ajax({
        type: "GET",
        url: "http://localhost:53416/api/store/removeStoreOwner?storeId=" + lastClickedStoreId + "&oldOwner=" + OldOwnerName,
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

var editStoreProduct = function () {
    productId = $("#product-id2").val();
    price = $("#product-price2").val();
    amount = $("#product-amount2").val();
    
    jQuery.ajax({
        type: "GET",
        url: "http://localhost:53416/api/store/editProductInStore?productInStoreId=" + productId +
            "&price=" + price + "&amount=" + amount + "&storeId=" + lastClickedStoreId,
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

var removeStoreProduct = function () {
    productId = $("#product-id3").val();

    jQuery.ajax({
        type: "GET",
        url: "http://localhost:53416/api/store/removeProductFromStore?storeId=" + lastClickedStoreId +
            "&ProductInStoreId=" + productId, 
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

var addSale = function () {
    productId = $("#products")[0].selectedIndex;
    productId = productsInStore[productId].productInStoreId;
    amount = $("#product-amount-in-sale2").val();
    kindOfSale = $("#saleOption")[0].selectedIndex+1;
    if (kindOfSale === 2) {
        kindOfSale = 3;
    }
    date = $("#product-due-date2").val();

    jQuery.ajax({
        type: "GET",
        url: "http://localhost:53416/api/store/addSaleToStore?storeId=" + lastClickedStoreId +
            "&pisId=" + productId + "&typeOfSale=" + kindOfSale + "&amount=" + amount +
            "&dueDtae=" + date,
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

var editSale = function () {
    saleId = $("#Sale-id5").val();
    amount = $("#product-amount-in-sale").val();
    date = $("#product-due-date").val();

    jQuery.ajax({
        type: "GET",
        url: "http://localhost:53416/api/store/editSale?storeId=" + lastClickedStoreId +
            "&saleId=" + saleId + "&amount=" + amount + "&dueDate=" + date +
            "&dueDtae=" + date,
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

var removeSale = function () {
    saleId = $("#Sale-id6").val();

    jQuery.ajax({
        type: "GET",
        url: "http://localhost:53416/api/store/removeSaleFromStore?storeId=" + lastClickedStoreId +
            "&saleId=" + saleId ,
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


function addSaleView(e) {
    modalLinkListener(e);
    jQuery.ajax({
        type: "GET",
        url: "http://localhost:53416/api/store/getProductInStore?storeId=" + lastClickedStoreId,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log(response);
            var viewHistory = document.getElementById("viewHistory");
            productsInStore = response;
            var productHtml = document.getElementById("products");
            productHtml.innerHTML = ""
            for (i = 0; i < productsInStore.length; i++) {
                productHtml.innerHTML += "<option>" + productsInStore[i].product.name + "</option>";
            }

        },
        error: function (response) {
            console.log(response);

        }
    });

}

function viewHistory(e) {
    modalLinkListener(e);
    storeid = lastClickedStoreId;
    jQuery.ajax({
        type: "GET",
        url: "http://localhost:53416/api/store/viewStoreHistory?storeId=" + lastClickedStoreId,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log(response);
            var viewHistory = document.getElementById("viewHistory");
            if (response.length === 0) {
                viewHistory.innerHTML = "<div style=\"padding-left: 30px;\"> there were not purcheses from this store  </div>"
            }
            else {
                viewHistory.innerHTML = "<div>  </div>"
            }
            
        },
        error: function (response) {
            console.log(response);
            
        }
    });
    
}

var viewCopun = function (e) {
    modalLinkListener(e);
    $("#typeOfCopun").on('change', function () {
        typeOfCopun = $("#typeOfCopun")[0].selectedIndex;
        changeTypeOfCopun(typeOfCopun, "#to-what");
    });

}

var viewAddDiscount = function (e) {
    modalLinkListener(e);
    $("#typeOfDiscount").on('change', function () {
        typeOfCopun = $("#typeOfDiscount")[0].selectedIndex;
        changeTypeOfCopun(typeOfCopun,"#discountto-what");
    });

}



var changeTypeOfCopun = function (typeOfCopun, towhat) {
    switch (typeOfCopun) {
        case 0:
            $(towhat).attr("placeholder", "enter the products in store ids you want the copun to act on divide by ','");
            break;
        case 1:
            $(towhat).attr("placeholder", "enter the categoris names you want the copun to act on divide by ','");
            break;

        case 2:
            $(towhat).attr("placeholder", "enter the product names you want the copun to act on divide by ','");
            break;
    }
}

var addCopun = function () {
    copunId = $("#copun-id").val();
    typeOfCopun = $("#typeOfCopun")[0].selectedIndex+1;
    to_what = $("#to-what").val();
    Restriction = fixRestricion("#Restriction", "#copunRaffle", "#copunInstant");
    DiscountPrecentage = $("#DiscountPrecentage").val();
    CopunDueDate = $("#CopunDueDate").val();

    jQuery.ajax({
        type: "GET",
        url: "http://localhost:53416/api/store/addCouponDiscount?storeId=" + lastClickedStoreId +
            "&couponId=" + copunId + "&type=" + typeOfCopun + "&towaht=" + to_what +
            "&percentage=" + DiscountPrecentage + "&dueDate=" + CopunDueDate +
            "&restrictions=" + Restriction ,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response);
            window.location.reload(false);
        },
        error: function (response) {
            console.log(response);

        }
    });
}

var addDiscount = function () {
    type = $("#typeOfDiscount")[0].selectedIndex + 1;
    DiscountPrecentage = $("#DiscountPrecentage2").val();
    DueDate = $("#discountDueDate").val();
    to_what = $("#discountto-what").val();
    Restriction = fixRestricion("#Restriction2", "#discountRaffle", "#discountInstant");

    jQuery.ajax({
        type: "GET",
        url: "http://localhost:53416/api/store/addDiscount?storeId=" + lastClickedStoreId +
            "&type=" + type + "&percentage=" + DiscountPrecentage +
            "&toWhat=" + to_what + "&dueDate=" + DueDate +
            "&restrictions=" + Restriction,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert(response);
            window.location.reload(false);
        },
        error: function (response) {
            console.log(response);

        }
    });
}

var fixRestricion = function (restriction, copunRaffle, copunInstant) {
    Restriction = $(restriction).val();
    if (Restriction !== null && Restriction !== "") {
        Restriction = "COUNTRY=" + Restriction;
    }
    RaffleCheck = $(copunRaffle)[0].checked;
    InstantCheck = $(copunInstant)[0].checked
    if (RaffleCheck || InstantCheck) {
        Restriction += "/TOS=";
    }
    if (RaffleCheck & !InstantCheck) {
        Restriction += "3";
    }
    else if (!RaffleCheck & InstantCheck) {
        Restriction += "1";
    }
    else {
        Restriction += "1,3";
    }
    return Restriction;
}


function modalLinkListener(e) {
    lastClickedStoreId = e["srcElement"]["dataset"]["id"];
    key = e["srcElement"]["id"];
    key = key.replace(/[0-9]/g, '');
    openModal(key + "Modal");
    return false;
}

function enableLink(id) {
    var element = document.getElementById(id);
    element.setAttribute("onClick", "modalLinkListener(event);");
    element.classList.remove("disabledLink");
}

function openModal(id) {
    var element = document.getElementById(id);
    element.classList.add("show-modal1");
}

var addPolicyAdmin = function () {
    minAmount = $("#minPolicyAdmin").val();
    maxAmount = $("#maxPolicyAdmin").val();
    noDiscount = $("#NoDiscountAdmin")[0].checked;
    NoCopuns = $("#NoCopunsAdmin")[0].checked
    productId = $("#ProductIdAdmin").val(); 
    addProductPolicyAdmin(minAmount, maxAmount, noDiscount, NoCopuns, productId);

}

var addProductPolicyAdmin = function (minAmount, maxAmount, noDiscount, NoCopuns, pId) {
    if (minAmount !== undefined && minAmount !== "" && maxAmount !== undefined && maxAmount !== "") {
        jQuery.ajax({
            type: "GET",
            url: baseUrl + "/api/user/setAmountPolicyOnProduct?productName=" + pId +
                "&minAmount=" + minAmount + "&maxAmount=" + maxAmount,
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
    if (noDiscount) {
        jQuery.ajax({
            type: "GET",
            url: baseUrl + "/api/user/setAmountPolicyOnProduct?productName=" + pId,
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

    if (NoCopuns) {
        jQuery.ajax({
            type: "GET",
            url: baseUrl + "/api/user/setNoCouponsPolicyOnProduct?productName=" + pId,
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
}

var addDiscountAdmin = function () {
    type = 3;
    DiscountPrecentage = $("#zahiDiscountPrecentage").val();
    DueDate = $("#zahiDueDateDiscount").val();
    to_what = $("#zahiProductsName").val();
    Restriction = fixRestricion("#zahiCountryDiscount", "#RaffleAdminDiscount", "#InstanteAdminDiscount");

    jQuery.ajax({
        type: "GET",
        url: baseUrl + "/api/store/addDiscount?storeId=" + 12 +
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
    if (Restriction !== null && Restriction !== "" && (RaffleCheck || InstantCheck))
        Restriction += "/";
    RaffleCheck = $(copunRaffle)[0].checked;
    InstantCheck = $(copunInstant)[0].checked
    if (RaffleCheck || InstantCheck) {
        Restriction += "TOS=";
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
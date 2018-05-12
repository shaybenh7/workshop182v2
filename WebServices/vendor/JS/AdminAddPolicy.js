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
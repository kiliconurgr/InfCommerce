﻿$(document).ready(function () {

    $(".addCart").click(function () {
        urunID = parseInt($(".stockQuantity").attr("urunID"));
        istenenMiktar = parseInt($(".stockQuantity").val());
        dbStokMiktari = parseInt($(".stockQuantity").attr("stokMiktari"));
        if (istenenMiktar > dbStokMiktari) $(".istenenStokDurum").text("Bu üründen en fazla " + dbStokMiktari + " adet sipariş verebilirsiniz.");
        else addCart(urunID, istenenMiktar, dbStokMiktari);
    });
    if ($(".selectDeliveryCity").length) getDistrict($(".selectDeliveryCity"),'selectDeliveryDistinct');
    if ($(".selectBilingCity").length) getDistrict($(".selectBilingCity"),'selectBilingDistinct');
    getCartCount();
});

function addCart(pID, pQuantity, pStock) {
    $.ajax({
        type: "POST",
        url: "/sepet/ekle",
        data: { "productID": pID, "quantity": pQuantity, "stock": pStock },
        success: function (data) {
            $("#sepetModal .modal-body").text(data + " ürünü başarıyla sepete eklendi");
            $("#sepetModal").modal("show");
            setTimeout(function () { $("#sepetModal").modal("hide") }, 3000);
            getCartCount();
        },
        error: function (e) {
            alert(e.responseText);
        }
    });
}

function getCartCount() {
    $.ajax({
        type: "GET",
        url: "/sepet/urunsayisiver",
        success: function (data) {
            $(".shopping-card span").text(data);
        },
        error: function (e) {
            alert(e.responseText);
        }
    });
}

function getDistrict(_objeCity,_objeDistinct) {
    $.ajax({
        type: "GET",
        url: "/sepet/ilcegetir",
        data: { "cityID": $(_objeCity).val() },
        success: function (data) {
            $("." + _objeDistinct).empty();
            $.each(data, function (i, v) {
                $("." + _objeDistinct).append("<option value='"+v.id+"'>"+v.name+"</option>")
            })
        },
        error: function (e) {
            alert(e.responseText);
        }
    });
}

function deliveryNotBiling(_obje) {
    if (!$(_obje).prop("checked")) $(".bilingInputs").slideDown();
    else $(".bilingInputs").slideUp();
}
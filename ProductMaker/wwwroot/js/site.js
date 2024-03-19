$(function () {
    console.log("document ready");
    const userCulture = navigator.language;
    $(document).on("click", ".edit-product-button", function () {
        console.log("Clicked" + $(this).val());
        var productID = $(this).val();

        $.ajax({
            type: 'json',
            data: {
                "id": productID
            },
            url: "/product/ShowDetailsJSON",
            success: function (data) {
                console.log(data);
                $("#modal-input-id").val(data.id);
                $("#modal-input-name").val(data.name);
                const formattedPrice = formatPriceForCulture(data.price, userCulture);
                $("#modal-input-price").val(formattedPrice);
                $("#modal-input-description").val(data.description);
            }
        })

    });

    $("#save-button").click(function () {
        var Product = {
            "Id": $("#modal-input-id").val(),
            "Name": $("#modal-input-name").val(),
            "Price": $("#modal-input-price").val(),
            "Description": $("#modal-input-description").val()
        };

        console.log(Product);

        $.ajax({
            type: 'json',
            data: Product,
            url: "/product/ProcessEditReturnPartial",
            success: function (data) {
                console.log(data);
                $("#card-number-" + Product.Id).html(data).hide().fadeIn(2000);
            }
        });

    });

    function formatPriceForCulture(price, culture) {
        if (culture.startsWith("pl-")) {
            return price.toLocaleString('pl-PL', { minimumFractionDigits: 2 });
        } else {
            return price.toLocaleString();
        }
    }

});
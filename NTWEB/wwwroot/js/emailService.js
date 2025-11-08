$("form").on("submit", function (e) {
    e.preventDefault();

    var form = $(this)[0];
    var formData = new FormData(form);
    var btn = $("#submitBtn");

    btn.prop("disabled", true).text("در حال ارسال...");

    $.ajax({
        url: window.location.pathname,
        type: "POST",
        data: formData,
        processData: false,
        contentType: false,
        success: function (response) {
            if (response.success) {
                showPopup("✅ پیام با موفقیت ارسال شد");
                $("form")[0].reset();
            }
            else {
                showPopup(response.message, true);
            }
            btn.prop("disabled", false).text("ارسال پیام");
        },
        error: function () {
            showPopup(response.message, true);
            btn.prop("disabled", false).text("ارسال پیام");
        }
    });
});

function showPopup(message, isError = false) {
    var popUp = $("#popupMessage");
    popUp
        .text(message)
        .removeClass("error")
        .toggleClass("error", isError)
        .fadeIn(300);

    setTimeout(function () {
        popUp.fadeOut(400);
    }, 3000);
}
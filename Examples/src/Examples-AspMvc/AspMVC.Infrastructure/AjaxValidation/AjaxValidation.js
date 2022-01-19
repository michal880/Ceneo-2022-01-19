$(document).ready(function () {
  $("#AjaxValidationForm").submit(function (event) {
    event.preventDefault();

    $.ajax({
      type: "POST",
      url: $(this).attr("action"),
      data: $(this).serialize(),
      success: function (data, responseStatus, request) {
        window.location = request.getResponseHeader("location");
      }
    }).error(function (data) {
      _json = eval("(" + data.responseText + ")");
      $.each(_json, function (i, val) {
        $("[data-valmsg-for = '" + val.key + "']")
          .html(val.errors)
          .removeClass("field-validation-valid")
          .addClass("field-validation-invalid");
      });
    });

    return false;
  });
});

$(document).ready(function () {
  
    $("table").bind("DOMSubtreeModified", function () {

        var products = $(".priceTd");
        var buff = 0;
        products.each(function () {

            buff += parseInt($(this).text());
        });
       
        $("#totalPrice").text(buff);
    });
   
});
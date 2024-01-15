<script src="https://code.jquery.com/jquery-3.6.4.min.js"></script>

<script>
    $(document).ready(function () {
        $(".subcategory-link").click(function (e) {
            e.preventDefault();

            var categoryId = $(this).data("category-id");

            $.ajax({
                url: '/ControllerName/GetProductsByCategory',
                type: 'GET',
                data: { categoryId: categoryId },
                dataType: 'json',
                success: function (data) {
                    // Assuming you have a container with the id "product-container" to display the products
                    $("#product-container").empty();

                    // Iterate through the returned data and update the product container
                    $.each(data, function (index, product) {
                        // Customize this part based on your product data structure
                        $("#product-container").append("<div>" + product.ProductName + "</div>");
                    });
                },
                error: function (error) {
                    console.log(error);
                }
            });
        });
    });
</script>

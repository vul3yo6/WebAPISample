(function () {
    $(function () {
        var basicAuthUI =
            '<div class="input"><input placeholder="header name" id="header_name" name="name" type="text" size="10" value="Authorization"></div>' +
            '<div class="input"><input placeholder="header value" id="header_value" name="value" type="text" size="10"></div>';
        $(basicAuthUI).insertBefore('#api_selector div.input:last-child');
        $("#input_apiKey").hide();
        
        $('#header_name').change(addAuthorization);
        $('#header_value').change(addAuthorization);
    });
    
    function addAuthorization() {
        var headerName = $('#header_name').val();
        var headerValue = $('#header_value').val();
        if (headerName && headerName.trim() != "" && headerValue && headerValue.trim() != "") {
            //var basicAuth = new SwaggerClient.PasswordAuthorization('basic', username, password);
            //window.swaggerUi.api.clientAuthorizations.add("basicAuth", basicAuth);
            var basicAuth = new SwaggerClient.ApiKeyAuthorization(headerName, headerValue, 'header');
            window.swaggerUi.api.clientAuthorizations.add("key", basicAuth);
            console.log("authorization added: headerName = " + headerName + ", headerValue = " + headerValue);
        }
    }
})();
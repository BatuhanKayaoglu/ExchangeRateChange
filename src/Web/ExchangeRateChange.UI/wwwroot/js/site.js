$(document).ready(function () {
    $('.exchangeDataSendBtn').off('click').on('click', function (e) {
        e.preventDefault(); // Butona tıklandığında formun normal submit işlemini durdur

        var formData = {
            Name: $('#productName').val(),
            SerialNumber: $('#serialNumber').val(),
            Price: parseFloat($('#Price').val()),
            Count: parseInt($('#Count').val()),
            ExchangeType: $('#exchangeRate').val()
        };

        $.ajax({
            url: 'Home/sendProductData',
            type: 'POST',
            data: formData,
            success: function (response) {
                console.log(response);
                var newRow = `<tr>
                                    <td>${response.id}</td>
                                    <td>${response.name}</td>
                                    <td>${response.serialNumber}</td>
                                    <td>-</td>
                                    <td>${response.price}</td>
                                    <td>-</td>
                                    <td>${response.exchangeType}</td>
                                    <td>-</td>
                                </tr>`;

                $('table tbody').append(newRow);
            },
            error: function (xhr, status, error) {
                console.error('Hata: ' + error);
                alert('Ürün gönderilemedi, lütfen tekrar deneyin.');
            }
        });
    });
});

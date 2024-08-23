$(document).ready(function () {
    $('.exchangeDataSendBtn').off('click').on('click', function (e) {
        e.preventDefault();

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
                alert('Ürün gönderilemedi, lütfen tekrar deneyin.');
            }
        });
    });


    // SignalR
    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/ExchangeRateHub")
        .build();
    connection.on("ReceiveMessage", function (data) {
        console.log(data);
        const currency = data.currency;
        const buyPrice = parseFloat(data.buyPrice.replace(',', '.'));
        const sellPrice = parseFloat(data.sellPrice.replace(',', '.'));
        const id = data.id.toLowerCase();
        const price = parseFloat(data.price);

        const rows = document.querySelectorAll("#exchangeRateTable tbody tr");
        rows.forEach(row => {
            const cellId = row.cells[0].textContent.trim();
            if (cellId === id) {
                console.log("MATCHED:", cellId)
                row.cells[5].textContent = (price * sellPrice).toFixed(2);
                row.cells[6].textContent = currency;
                row.cells[7].textContent = buyPrice.toFixed(4);
            }
        });
    });

    connection.start().catch(function (err) {
        return console.error(err.toString());
    });

});



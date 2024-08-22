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


    const connection = new signalR.HubConnectionBuilder()
        .withUrl("/ExchangeRateHub")
        .build();


    connection.on("ReceiveMessage", function (data) {
        console.log(data);
        // JSON verisini işleme
        const currency = data.currency;
        const buyPrice = parseFloat(data.buyPrice.replace(',', '.')); // ',' yerine '.' kullanarak dönüştürme
        const sellPrice = parseFloat(data.sellPrice.replace(',', '.')); // ',' yerine '.' kullanarak dönüştürme
        const id = data.id.toLowerCase();
        const price = parseFloat(data.price);

        // ID ile eşleşen satırı bulma
        const rows = document.querySelectorAll("#exchangeRateTable tbody tr");
        rows.forEach(row => {
            const cellId = row.cells[0].textContent.trim(); // ID hücresini al
            if (cellId === id) {
                console.log("EŞLEŞTİ:", cellId)
                // Eşleşen satırı bulduğunda bilgileri güncelle
                row.cells[5].textContent = (price * buyPrice).toFixed(2); // New Price hesaplama ve yazdırma
                row.cells[6].textContent = currency; // Exchange Type
                row.cells[7].textContent = buyPrice.toFixed(4); // Exchange Rate
            }
        });
    });

    connection.start().catch(function (err) {
        return console.error(err.toString());
    });


});



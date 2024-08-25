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
                          <td>
                              <div class="loader"></div>
                              <div class="data-cell" style="display:none;">-</div>
                          </td>
                          <td>${response.exchangeType}</td>
                          <td>
                              <div class="loader"></div>
                              <div class="data-cell" style="display:none;">-</div>
                          </td>
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
        const buyPrice = parseFloat(data.buyPrice.replace(',', '.'));
        const sellPrice = parseFloat(data.sellPrice.replace(',', '.'));
        const id = data.id.toLowerCase();
        const price = parseFloat(data.price);

        const rows = document.querySelectorAll("#exchangeRateTable tbody tr");
        rows.forEach(row => {
            const cellId = row.cells[0].textContent.trim();
            if (cellId === id) {
                console.log("MATCHED:", cellId);
                const newPriceCell = row.cells[5];
                const exchangeRateCell = row.cells[7];

                // Hide the loader and show the new price
                newPriceCell.querySelector('.loader').style.display = 'none';
                newPriceCell.querySelector('.data-cell').style.display = 'block';
                newPriceCell.querySelector('.data-cell').textContent = (price * sellPrice).toFixed(2);

                // Hide the loader and show the exchange rate
                exchangeRateCell.querySelector('.loader').style.display = 'none';
                exchangeRateCell.querySelector('.data-cell').style.display = 'block';
                exchangeRateCell.querySelector('.data-cell').textContent = buyPrice.toFixed(4);
            }
        });
    });

    connection.start().catch(function (err) {
        return console.error(err.toString());
    });



});



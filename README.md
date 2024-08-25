# ExchangeRateChange

## Project Overview

This project demonstrates a system that dynamically updates product prices using real-time exchange rate information. The system ensures seamless data flow between a .NET application and a Python microservice. Specifically, it handles the process where selected exchange rates and prices are sent via a message queue (RabbitMQ) to a Python microservice. The microservice then performs web scraping from a source like döviz.com to retrieve the latest exchange rate and sends this data back to the .NET application via RabbitMQ. The .NET application then calculates the updated product price based on the exchange rate and displays it to the client in real-time using SignalR.

## Architecture

The architecture of this project is built around two main components: the .NET Application and the Python Microservice. Both components interact with each other using the RabbitMQ message queue. The architectural details are as follows:

- **.NET Application**:
  - **Front-End Management**: Handles the user interface (UI) operations. The product information (price and exchange rate) input by the user is processed in this layer.
  - **Data Processing**: The user-provided data is formatted and sent to the RabbitMQ queue.
  - **RabbitMQ Interaction**: Sends product information to the Python microservice via RabbitMQ and receives exchange rate data back from the microservice.
  - **SignalR Interaction**: The updated price is transmitted to the client in real-time using SignalR and displayed to the user.

- **Python Microservice**:
  - **Web Scraping**: The Python microservice performs web scraping from sources like döviz.com to retrieve real-time exchange rate data. This is done using libraries such as BeautifulSoup.
  - **Data Processing and Return**: The retrieved exchange rate data is processed and sent back to the .NET application through RabbitMQ.

## Project Workflow

The workflow of this project consists of three main steps:

### 1. Sending Product Information
   - The user selects the product price and exchange rate through the .NET application's interface.
   - The selected exchange rate and price information are formatted and placed in the RabbitMQ queue.
   - This data is then sent to the Python microservice via the queue.

### 2. Retrieving Exchange Rate Information
   - The Python microservice picks up the message from the queue and starts the web scraping process based on the exchange rate information in the message.
   - The real-time exchange rate is retrieved from a reliable source like döviz.com.
   - The retrieved data is processed and placed back in the RabbitMQ queue, ready to be sent back to the .NET application.

### 3. Calculating and Displaying the Price
   - The .NET application receives the exchange rate data from the Python microservice via the message queue.
   - The product’s updated price is calculated using the received exchange rate.
   - The calculated price is then displayed to the user in real-time using SignalR.

This workflow ensures that the user always has access to up-to-date pricing information, reflecting the latest exchange rates. The role of RabbitMQ and SignalR in this process is crucial for ensuring there is no delay in data transmission and that the user experience remains seamless.


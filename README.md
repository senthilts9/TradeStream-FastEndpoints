# ⚡ Real-Time Kafka Trade Stream with FastEndpoints (.NET 8)

## 🎯 Purpose

This is a **production-grade microservice** demonstrating how to stream trade data using **Kafka** and **.NET 8's FastEndpoints**. The system is designed for **low-latency trade ingestion**, **VWAP (Volume-Weighted Average Price) computation**, and **async API exposure**, making it ideal for use cases in:

- Front Office: trade streaming, pricing feeds
- Middle Office: trade validation, PnL aggregation
- Back Office: post-trade reconciliation, audit trails

---

## ✅ Key Highlights

- 🧠 Event-driven pipeline using Kafka (Producer + Consumer)
- 📈 VWAP calculation engine with in-memory storage
- ⚙️ REST API endpoints using FastEndpoints (.NET 8)
- 🐳 Docker-ready microservice
- 🧪 Extensive xUnit test coverage for business logic & endpoints

---

## 🧱 Folder Structure

```
Kafka.FastEndpoints.TradeStream/
├── Domain/                  # VWAP logic, trade models
├── Endpoints/               # API: upload trades + fetch VWAP
├── ProducerService/         # Simulates Kafka trade producers
├── ConsumerService/         # Kafka consumers process trades
├── Tests/                   # Unit/integration tests using xUnit
├── Dockerfile               # Container build file
└── README.md
```

---

## 🔧 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- Docker Desktop (for Kafka or Redpanda)
- CLI / Terminal

---

## 🚀 How to Run (End-to-End)

### 🔌 1. Start Kafka Locally (Using Redpanda)

```bash
docker run -d --name redpanda -p 9092:9092 docker.redpanda.com/redpandadata/redpanda:latest redpanda start --overprovisioned --advertise-kafka-addr=localhost:9092
```

### ⚙️ 2. Run the Main API Service

```bash
dotnet run --project Kafka.FastEndpoints.TradeStream
```

### 📤 3. Run Kafka Trade Producer

```bash
dotnet run --project Kafka.FastEndpoints.TradeStream/ProducerService
```

### 📥 4. Run Kafka Trade Consumer

```bash
dotnet run --project Kafka.FastEndpoints.TradeStream/ConsumerService
```

---

## 🌐 API Endpoints (FastEndpoints)

| Verb | Endpoint                  | Purpose                     |
|------|---------------------------|-----------------------------|
| POST | `/trade/upload`          | Upload trade into Kafka     |
| GET  | `/trade/vwap/{symbol}`   | Get latest VWAP by symbol   |

---

## 🧪 Test Coverage (xUnit)

This repo includes professional-level tests with clear separation:

| Test Project             | Coverage Area                                |
|--------------------------|----------------------------------------------|
| VWAPStoreTests.cs        | VWAP math logic, edge-case precision         |
| TradeProcessorTests.cs   | Trade validation logic, malformed inputs     |
| TradeRepositoryTests.cs  | DB I/O test doubles (mock/fake interactions) |
| UploadVWAPTradeTests.cs  | FastEndpoint API status, invalid payloads    |

### Run Tests

```bash
dotnet test
```

---

## 🐳 Docker Instructions

### 📦 Build Docker Image

```bash
docker build -t trade-fastendpoints .
```

### 🚀 Run Docker Container

```bash
docker run --rm -p 8080:80 trade-fastendpoints
```

---

## 🧠 What This Demonstrates

- Real-time Kafka ingestion pipeline (Producer → Consumer)
- Clean, testable FastEndpoints API layer
- VWAP logic useful for front-office analytics or portfolio tools
- Professional test suite following best practice patterns
- Fully modular, async-ready microservice using .NET 8

---

## 🔗 GitHub

View full source code and future improvements on GitHub:  
👉 [https://github.com/senthilts9/](https://github.com/senthilts9/)

---

Crafted for modern financial systems where **speed**, **accuracy**, and **observability** matter. 🧠📊
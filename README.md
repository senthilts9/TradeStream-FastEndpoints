# ⚡ Kafka Trade Streaming using FastEndpoints (.NET 8 + Kafka)

## 🚀 Overview

A high-performance, event-driven microservice that streams trades, recalculates VWAP in real-time, and exposes FastEndpoints to ingest or query trades. Perfect for trading desks, risk platforms, or real-time analytics.

---

## 📦 Features

- ✅ **Kafka-Driven Architecture** — Clean separation of producer/consumer
- ✅ **VWAP Calculator** — In-memory trade aggregation with precision
- ✅ **Async FastEndpoints** — Minimal, low-latency API endpoints
- ✅ **Docker-Ready** — Local setup in seconds
- ✅ **Pro-Level xUnit Tests** — Coverage for domain, endpoints, and edge cases

---

## 🧠 Folder Structure

```
Kafka.FastEndpoints.TradeStream/
├── Domain/                  # Models + VWAPStore
├── Endpoints/               # POST /trade/upload & GET /trade/vwap/{symbol}
├── ProducerService/         # Kafka producer for simulated trades
├── ConsumerService/         # Kafka consumer (hosted) for VWAP updates
├── Tests/                   # VWAPStore, Processor, DB mocks, Endpoint tests
├── Dockerfile               # Buildable microservice container
└── README.md
```

---

## 🔧 Local Setup Guide

### 1️⃣ Prerequisites
- [.NET 8 SDK](https://dotnet.microsoft.com/)
- Docker Desktop
- Kafka (using Redpanda for dev)

### 2️⃣ Run Kafka locally (via Docker)

```bash
docker run -d --name redpanda -p 9092:9092 docker.redpanda.com/redpandadata/redpanda:latest redpanda start --overprovisioned --advertise-kafka-addr=localhost:9092
```

### 3️⃣ Run API
```bash
dotnet run --project Kafka.FastEndpoints.TradeStream
```

### 4️⃣ Kafka Producer
```bash
dotnet run --project Kafka.FastEndpoints.TradeStream/ProducerService
```

### 5️⃣ Kafka Consumer (Hosted service)
```bash
dotnet run --project Kafka.FastEndpoints.TradeStream/ConsumerService
```

---

## ✅ API Endpoints

| Verb | Path                    | Description              |
|------|-------------------------|--------------------------|
| POST | `/trade/upload`         | Submit new trade         |
| GET  | `/trade/vwap/{symbol}`  | Fetch VWAP for symbol    |

---

## 🧪 Unit Test Plan

Tests cover:

- ✔️ VWAP logic edge cases
- ✔️ No trades / malformed input handling
- ✔️ JSON deserialization & type safety
- ✔️ Endpoint-level integration
- ✔️ Placeholders for DB interaction

Run tests:

```bash
dotnet test
```

---

## 📦 Docker Build

```bash
docker build -t trade-fastendpoints .
```

---

## 🧠 Hiring Manager Highlights

- 🔁 End-to-end trade stream + real-time recalculation
- 📉 Optimized for low-latency processing with Kafka
- 📊 Finance-first use case (VWAP + async delivery)
- 🧪 Pro-level unit test design
- 🚀 Modular, testable, and cloud-ready

---

## 🔗 GitHub

[🔗 GitHub: senthilts9/TradeStream FastEndpoints](https://github.com/senthilts9/)

---

Built for production-grade, low-latency trading systems 💹
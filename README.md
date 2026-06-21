# HomeCare N8N API

![.Net](https://img.shields.io/badge/.NET-5C2D91?style=for-the-badge&logo=.net&logoColor=white)
![C#](https://img.shields.io/badge/c%23-%23239120.svg?style=for-the-badge&logo=csharp&logoColor=white)
![n8n](https://img.shields.io/badge/n8n-EA4B71?style=for-the-badge&logo=n8n&logoColor=white)
![Docker](https://img.shields.io/badge/docker-%230db7ed.svg?style=for-the-badge&logo=docker&logoColor=white)
![Visual Studio](https://img.shields.io/badge/Visual%20Studio-5C2D91.svg?style=for-the-badge&logo=visual-studio&logoColor=white)

## 🚀 Key Features

* **Medication Management**: Endpoints to insert new medications and retrieve them filtered by user.
* **n8n Workflow Integration**: Webhook ready to trigger automated workflows whenever a new medication is added or scheduled.
* **Telegram Notifications**: Seamlessly sends reminders, logs, or medication alerts directly to a designated Telegram chat/bot via n8n.
* **Fully Containerized**: Ready-to-go multi-container environment syncing the Web API, PostgreSQL database, and n8n instance.

---

## 🛠️ Built With

* **.NET Core / C#** - Robust backend framework for building the Web API.
* **PostgreSQL** - Relational database for structured, persistent data storage.
* **Docker & Docker Compose** - Containerization platform to orchestrate the entire stack.
* **n8n** - Fair-code workflow automation tool to bridge the API and messaging services.
* **Telegram Bot API** - Delivered via n8n to send real-time notifications to users.

---

## 🔌 API Endpoints

### 1. Insert Medication
Adds a new medication schedule to the system and triggers the automation flow.

* **URL:** `/api/medications`
* **Method:** `POST`
* **Payload Example:**
    ```json
    {
        "name": "Amoxicillin",
        "receivedAt": "2026-06-21T15:00:00Z",
        "IsPublic": "true",
        "Amount": "60",
        "patientName": "Thiago",
        "nextReceivedAt": "2026-07-21T15:00:00Z"";
      }
    ```

### 2. Get Medications For User
Retrieves all registered medications for a specific user.

* **URL:** `/api/medications/user/{userId}`
* **Method:** `GET`
* **Response Example:**
    ```json
    [
      {
        "name": "Amoxicillin",
        "receivedAt": "2026-06-21T15:00:00Z",
        "IsPublic": "true",
        "Amount": "60",
        "patientName": "Thiago",
        "nextReceivedAt": "2026-07-21T15:00:00Z";
      }
    ]
    ```

---

## ⚙️ Architecture & Integration Flow

1.  **Client Application / User** sends a request to the **.NET API**.
2.  The API processes and persists the data into the **PostgreSQL** database.
3.  Upon success, a webhook or event triggers **n8n**.
4.  **n8n** processes the payload and invokes the **Telegram Bot Node** to ping the user with their prescription/reminder.

---

## 📦 Getting Started

### Prerequisites
* [Docker Desktop](https://www.docker.com/products/docker-desktop/) installed.
* N8N and Postgres images added in Docker.
* A Telegram Bot Token (obtained via `@BotFather`).

### Installation & Setup

1. Clone this repository:
   ```bash
   git clone https://github.com/thiagvs/HomeCare.N8N.git
   cd HomeCare.N8N

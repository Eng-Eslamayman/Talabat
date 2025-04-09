# 🛒 Talabat Ordering System

A simple full-stack ordering system built with:
- ASP.NET Core 6 Web API (3-Tier Architecture)
- Entity Framework Core + SQL Server
- JWT Authentication
- Plain HTML/CSS/JavaScript Frontend

---

## 📁 Project Structure


---

## 🧪 Features

- ✅ Register & Login users (with JWT)
- ✅ Create / View / Delete Orders
- ✅ Get orders by logged-in customer
- ✅ Simple UI to test (shop.html)
- ✅ Full CORS configured for frontend

---

## 🚀 How to Run

### 🔧 Prerequisites

- [.NET 6 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server)
- Visual Studio / VS Code

---

### 1️⃣ Configure Database

Set your connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=Talabat;Trusted_Connection=True;"
}

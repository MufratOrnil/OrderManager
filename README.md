# 📦 Order Manager (ASP.NET MVC)

Order Manager is a clean and beginner-friendly **ASP.NET MVC (Master–Detail)** application for managing customer orders and their related order items.
Each order can contain **multiple items** and an **optional image upload**, making it ideal for learning real-world CRUD operations using **Entity Framework Code First**.

---

## 📸 Screenshots

### ➕ Create Order

<img width="1920" height="957" alt="Screenshot 2025-12-18 020010" src="https://github.com/user-attachments/assets/02af86be-2e5c-42fc-88f8-23f10d9d12d6" />


### 📋 Orders List

<img width="1920" height="961" alt="Screenshot 2025-12-18 023810" src="https://github.com/user-attachments/assets/d8d0740e-432b-45e3-9bc9-d3d6885fef8e" />


### 📦 Orders with Items (Expanded)

<img width="1920" height="958" alt="Screenshot 2025-12-18 023653" src="https://github.com/user-attachments/assets/d2ad6193-b508-47a2-a662-a9ed8361bcef" />


### ✏️ Edit Order

<img width="1920" height="960" alt="Screenshot 2025-12-18 023726" src="https://github.com/user-attachments/assets/e09e3c8e-e783-44e8-bbb6-1cda15320496" />


---

## ✨ Features

* ✅ Create, view, edit, and delete orders
* 🧾 Add multiple order items per order (Product, Quantity, Price)
* 🖼 Upload an image for each order
* 🔗 Master–Detail relationship (Order ↔ OrderItems)
* 🎨 Clean and responsive **Bootstrap-based UI**
* 🗄 Entity Framework **Code First** with migrations

---

## 🛠 Tech Stack

* **ASP.NET MVC 5**
* **C#**
* **Entity Framework (Code First)**
* **SQL Server / LocalDB**
* **Razor Views**
* **Bootstrap**

---

---

## ⚙️ Setup Instructions

### 1️⃣ Clone the Repository

```bash
git clone https://github.com/MufratOrnil/OrderManager.git
cd MasterDetailApp
```

---

### 2️⃣ Open the Solution

* Open **`MasterDetailApp.sln`** in **Visual Studio**

---

### 3️⃣ Configure Database Connection

1. Open **Web.config**
2. Locate the `DefaultConnection`
3. Update it with your SQL Server or LocalDB connection string

```xml
<connectionStrings>
  <add name="DefaultConnection"
       connectionString="Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OrderManagerDB;Integrated Security=True"
       providerName="System.Data.SqlClient" />
</connectionStrings>
```

---

### 4️⃣ Create Images Folder

* In the **web project root**, create a folder named:

```text
Images
```

This folder stores uploaded order images.

---

## 🧩 Entity Framework Migrations

Open **Tools → NuGet Package Manager → Package Manager Console** and ensure the **Default project** is set to the web project.

Run the following commands:

```powershell
Enable-Migrations      # Run only once (if not already enabled)
Add-Migration InitialCreate
Update-Database
```

✔ This creates database tables for:

* `Orders`
* `OrderItems`

---

## ▶️ Run the Application

1. Build the solution
2. Press **F5** or **Ctrl + F5**
3. Open your browser and navigate to:

```text
/Orders
```

Start creating and managing orders 🚀

---

## 🎯 Learning Outcomes

This project helps you understand:

* ASP.NET MVC architecture
* Master–Detail CRUD operations
* Model binding with collections
* File upload handling in MVC
* Entity Framework Code First & migrations
* Clean UI using Bootstrap

---

## 📌 Future Improvements (Optional)

* 🔍 Search & filtering
* 📄 Pagination
* 🔐 Authentication & authorization
* 📦 Order total calculation
* 🧪 Unit testing

---

## 🧑‍💻 Author

Developed as a **learning & portfolio project** for ASP.NET MVC and Entity Framework.

If you find this useful, ⭐ star the repository and feel free to extend it.

---

Happy Coding! 🚀

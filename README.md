# 📊 Coaching Automation System (Excel-Based)

Automate communication for coaching classes using Excel + WhatsApp + Telegram.

This system reads student data from an Excel file and automatically sends:

* 📲 Attendance alerts
* 💰 Fee reminders

---

## 🚀 Features

* ✅ Excel-based data input (no technical skills needed)
* ✅ WhatsApp messaging via Twilio
* ✅ Telegram bot integration
* ✅ Multi-channel notification system
* ✅ Automated scheduler (runs every few minutes)
* ✅ Simple API trigger for manual execution

---

## 🧱 Tech Stack

* .NET Web API
* EPPlus (Excel processing)
* Twilio (WhatsApp API)
* Telegram Bot API
* Hangfire (background jobs)

---

## 📂 Project Structure

```
/Models
/Services
/Jobs
/Controllers
students.xlsx
appsettings.json
```

---

## 📊 Excel Format

Create a file named:

```
students.xlsx
```

Add the following columns:

| StudentName | ParentPhone   | Attendance | FeesDue | Channel  |
| ----------- | ------------- | ---------- | ------- | -------- |
| Rahul       | +919876543210 | Absent     | 5000    | WhatsApp |
| Amit        | +919812345678 | Present    | 0       | Telegram |

---

## ⚙️ Configuration

Update `appsettings.json`:

```json
{
  "Twilio": {
    "AccountSid": "YOUR_SID",
    "AuthToken": "YOUR_TOKEN",
    "FromNumber": "whatsapp:+14155238886"
  },
  "Telegram": {
    "BotToken": "YOUR_BOT_TOKEN",
    "ChatId": "YOUR_CHAT_ID"
  },
  "Excel": {
    "FilePath": "students.xlsx"
  }
}
```

---

## 🔑 Setup Instructions

### 1. Clone Repository

```bash
git clone https://github.com/YOUR_USERNAME/coaching-automation.git
cd coaching-automation
```

---

### 2. Install Dependencies

```bash
dotnet restore
```

---

### 3. Add Excel File

Place `students.xlsx` in project root.

---

### 4. Ensure File is Copied to Output

Update `.csproj`:

```xml
<ItemGroup>
  <None Update="students.xlsx">
    <CopyToOutputDirectory>Always</CopyToOutputDirectory>
  </None>
</ItemGroup>
```

---

### 5. Run Project

```bash
dotnet run
```

---

## 🧪 API Usage

Trigger notifications manually:

```
GET /api/run
```

Example:

```
http://localhost:5000/api/run
```

---

## ⏰ Automation (Scheduler)

System runs automatically every few minutes using Hangfire.

You can modify schedule in `Program.cs`.

---

## ⚠️ Important Notes

* Excel file should not be open while running the application
* Phone numbers must include country code (e.g., +91XXXXXXXXXX)
* WhatsApp Sandbox requires user opt-in (for testing)
* Production requires WhatsApp Business API approval

---

## 🔒 Security

Do NOT commit:

* `appsettings.json`
* `credentials.json`

Use `appsettings.example.json` for sharing configuration.

---

## 💡 Use Cases

* Coaching classes
* Tuition centers
* Schools
* Training institutes

---

## 🚀 Future Enhancements

* Multi-coaching (multi-tenant) support
* Admin dashboard (Angular)
* Excel upload UI
* Database integration
* Analytics & reporting

---

## 🤝 Contributing

Feel free to fork and improve the project.

---

## 📞 Contact

Your Name
Your Email / Phone

---

## ⭐ If You Like This Project

Give it a star on GitHub!

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
attendance.xlsx
fees.xlsx
appsettings.json
```

---

## 📊 Excel Format

Create two files named:

```
attendance.xlsx
fees.xlsx
```

Add the following columns to attendance.xls:

| StudentName | ParentPhone   | Attendance | Channel  |
| ----------- | ------------- | ---------- | -------- |
| TEST1       | +919876543210 | Absent     | WhatsApp |
| TEST2       | +919812345678 | Present    | Telegram |


Add the following columns to fees.xls:

| StudentName | ParentPhone   | FeesDue | Channel  |
| ----------- | ------------- | ------- | -------- |
| TEST1       | +919876543210 | 5000    | WhatsApp |
| TEST2       | +919812345678 | 1000    | Telegram |
---

## ⚙️ Configuration

Update `appsettings.json`:

```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information"
    }
  },
  "Twilio": {
    "AccountSid": "ACCOUNT_SID",
    "AuthToken": "AUTH_TOKEN",
    "FromNumber": "FROM_NUMBER"
  },
  "Telegram": {
    "BotToken": "BOT_TOKEN",
    "ChatId": "CHAT_ID"
  },
  "Excel": {
    "AttendanceFilePath": "attendance.xlsx",
    "FeesFilePath": "fees.xlsx"
  }
}
```

---

## 🔑 Setup Instructions

### 1. Clone Repository

```bash
git clone https://github.com/prathameshbhirud/coaching-automation.git
cd coaching-automation
```

---

### 2. Install Dependencies

```bash
dotnet restore
```

---

### 3. Add Excel File

Place `attendance.xlsx` and `fees.xlsx` in project root.

---

### 4. Ensure File is Copied to Output

Update `.csproj`:

```xml
<ItemGroup>
    <None Update="attendance.xlsx">
      <CopyToOutputDirectory>Always</CopyToOutputDirectory>
    </None>
    <None Update="fees.xlsx">
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
http://localhost:5000/api/run/attendance
http://localhost:5000/api/run/fees
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

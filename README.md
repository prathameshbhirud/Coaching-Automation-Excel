# 📊 Coaching Automation System (Excel-Based)

Automate communication for coaching classes using Excel + WhatsApp + Telegram.

This system reads data from Excel files and automatically sends:

* 📲 Attendance alerts
* 💰 Fee reminders
* 📝 Exam notifications
* 📢 Broadcast announcements

---

# 🚀 Features

* ✅ Excel-based data input (non-technical staff friendly)
* ✅ WhatsApp messaging via Twilio
* ✅ Telegram bot integration
* ✅ Attendance notification module
* ✅ Fee reminder module
* ✅ Exam reminder module
* ✅ Broadcast / announcement module
* ✅ Multi-channel notification support
* ✅ Structured logging using Serilog
* ✅ Automated scheduling using Hangfire
* ✅ Modular API architecture

---

# 🧱 Tech Stack

* .NET Web API
* EPPlus (Excel processing)
* Twilio (WhatsApp API)
* Telegram Bot API
* Hangfire (background jobs)
* Serilog (structured logging)

---

# 📂 Project Structure

```text
/Controllers
/Jobs
/Models
/Services
/logs

attendance.xlsx
fees.xlsx
exams.xlsx
broadcast.xlsx

appsettings.json
```

---

# 📊 Excel File Formats

## 1️⃣ attendance.xlsx

| StudentName | ParentPhone   | Attendance | Channel  |
| ----------- | ------------- | ---------- | -------- |
| TEST1       | +919876543210 | Absent     | WhatsApp |
| TEST2       | +919812345678 | Present    | Telegram |

---

## 2️⃣ fees.xlsx

| StudentName | ParentPhone   | FeesDue | Channel  |
| ----------- | ------------- | ------- | -------- |
| TEST1       | +919876543210 | 5000    | WhatsApp |
| TEST2       | +919812345678 | 1000    | Telegram |

---

## 3️⃣ exams.xlsx

| StudentName | ParentPhone   | ExamName     | ExamDate   | Channel  |
| ----------- | ------------- | ------------ | ---------- | -------- |
| TEST1       | +919876543210 | Maths Test   | 2026-06-05 | WhatsApp |
| TEST2       | +919812345678 | Physics Quiz | 2026-06-06 | Telegram |

---

## 4️⃣ broadcast.xlsx

| Message                       | Channel  |
| ----------------------------- | -------- |
| Tomorrow holiday due to rain  | WhatsApp |
| Physics class shifted to 6 PM | Telegram |

---

# ⚙️ Configuration

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
    "FeesFilePath": "fees.xlsx",
    "ExamsFilePath": "exams.xlsx",
    "BroadcastFilePath": "broadcast.xlsx"
  }
}
```

---

# 🔑 Setup Instructions

## 1️⃣ Clone Repository

```bash
git clone https://github.com/prathameshbhirud/coaching-automation.git

cd coaching-automation
```

---

## 2️⃣ Install Dependencies

```bash
dotnet restore
```

---

## 3️⃣ Add Excel Files

Place these files in project root:

```text
attendance.xlsx
fees.xlsx
exams.xlsx
broadcast.xlsx
```

---

## 4️⃣ Ensure Excel Files Are Copied To Output

Update `.csproj`:

```xml
<ItemGroup>

  <None Update="attendance.xlsx">
    <CopyToOutputDirectory>Always</CopyToOutputDirectory>
  </None>

  <None Update="fees.xlsx">
    <CopyToOutputDirectory>Always</CopyToOutputDirectory>
  </None>

  <None Update="exams.xlsx">
    <CopyToOutputDirectory>Always</CopyToOutputDirectory>
  </None>

  <None Update="broadcast.xlsx">
    <CopyToOutputDirectory>Always</CopyToOutputDirectory>
  </None>

</ItemGroup>
```

---

## 5️⃣ Run Application

```bash
dotnet run
```

---

# 🧪 API Endpoints

## 📲 Attendance Notifications

```http
GET /api/run/attendance
```

Example:

```text
http://localhost:5000/api/run/attendance
```

---

## 💰 Fee Reminders

```http
GET /api/run/fees
```

Example:

```text
http://localhost:5000/api/run/fees
```

---

## 📝 Exam Notifications

```http
GET /api/run/exams
```

Example:

```text
http://localhost:5000/api/run/exams
```

---

## 📢 Broadcast Messages

```http
GET /api/run/broadcast
```

Example:

```text
http://localhost:5000/api/run/broadcast
```

---

# 📜 Logging

Application uses Serilog for structured logging.

Logs are stored in:

```text
/logs
```

Example logs:

```text
[INF] Starting exam reminders
[INF] Sending message to TEST1
[INF] Message sent successfully
```

Errors:

```text
[ERR] Failed sending message
Twilio Authentication Error
```

---

# ⏰ Scheduling

System uses Hangfire for automation.

You can schedule:

* Daily attendance reminders
* Monthly fee reminders
* Exam notifications
* Broadcast announcements

Modify schedules in:

```text
Program.cs
```

---

# ⚠️ Important Notes

* Excel files should not be open while application is running
* Phone numbers must include country code (e.g., +91XXXXXXXXXX)
* WhatsApp Sandbox requires opt-in for testing
* Production requires WhatsApp Business API approval
* Ensure Excel files exist in output directory

---

# 🔒 Security

Do NOT commit:

* `appsettings.json`
* credentials
* API tokens

Use:

```text
appsettings.example.json
```

for shared configuration templates.

---

# 💡 Use Cases

* Coaching classes
* Tuition centers
* Schools
* Training institutes
* Educational institutes

---

# 🚀 Future Enhancements

* Multi-tenant coaching support
* Parent-specific broadcast targeting
* Bulk recipient management
* Angular admin dashboard
* Database integration
* Analytics & reporting
* Excel upload UI
* WhatsApp template management

---

# 🤝 Contributing

Feel free to fork and improve the project.

---

# 📞 Contact

Prathamesh B

GitHub:
https://github.com/prathameshbhirud

---

# ⭐ Support

If you like this project, give it a star on GitHub.

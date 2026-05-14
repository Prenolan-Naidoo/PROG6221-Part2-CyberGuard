# 🛡️ CyberGuard - Cybersecurity Awareness Chatbot

## PROG6221 Programming 2A - POE Part 2

---

##Student Information

| **Student Name** | Prenolan Naidoo |
| **Student Number** | ST10445908 |
| **Module Code** | PROG6221 |
| **Assessment** | POE Part 2 |
| **Date** | 14 May 2026 |

---

## Project Overview

**CyberGuard** is a Windows Forms-based cybersecurity awareness chatbot designed to educate **South African citizens** about online safety. The application helps users learn about:

| Topic | Description |
|-------|-------------|
| **Password Safety** | Creating strong passwords, using password managers, enabling 2FA |
| **Phishing Emails** | Identifying fake emails, spotting red flags, reporting scams |
| **Scam Detection** | South African specific scams (SARS, SASSA, Banking) |
| **Online Privacy** | Protecting personal information, social media settings |
---
GitHub Repository :	https://github.com/Prenolan-Naidoo/PROG6221-Part2-CyberGuard
Youtube link : https://youtu.be/4UIuE-BeThc?is=2bAokDWddF7NaYvP

---

## 💻 System Requirements

### Minimum Requirements

| Component | Requirement |
|-----------|-------------|
| **Operating System** | Windows 10 or Windows 11 |
| **Framework** | .NET 8.0 SDK or later |
| **IDE** | Visual Studio 2022 (Community/Professional/Enterprise) |
| **RAM** | 4GB minimum (8GB recommended) |
| **Disk Space** | 500MB free space |
| **Audio** | Speakers or headphones (for voice greeting) |

### Required NuGet Package

| Package | Version | Purpose |
|---------|---------|---------|
| System.Windows.Extensions | 10.0.5 | Audio playback for voice greeting |

---

## 🔧 Installation & Setup Steps

### Step 1: Clone or Download the Repository

** Clone with Git (Recommended):**
---
Step 2: Open the Project
Navigate to the CyberGuardChatbot folder

Double-click CyberGuardChatbot.sln to open in Visual Studio 2022

Step 3: Restore NuGet Packages
In Visual Studio:

Right-click the solution → Restore NuGet Packages

OR: Tools → NuGet Package Manager → Package Manager Console → Run:

powershell
Update-Package -reinstall
Step 4: Verify Audio File
Ensure greeting.wav exists in the Audio folder. If missing:

Record yourself saying: "Welcome to CyberGuard. Your personal cybersecurity awareness assistant. I'm here to help you stay safe online in South Africa."

Save as greeting.wav

Place in the Audio folder

Step 5: Build the Project
Build → Build Solution (Ctrl+Shift+B)

Ensure no compilation errors

Step 6: Run the Application
Press F5 to run with debugging

OR: Ctrl+F5 to run without debugging

How to Use - Detailed Usage Instructions
Starting the Application
Launch the app (F5 in Visual Studio)

Enter your name in the dialog box that appears

Click "Start Chatting"

The voice greeting will play (if audio file present)

The main chat window opens

Main Chat Window Layout
Section	Content
Top Header	Title bar with status indicator
Left Sidebar	ASCII art logo, memory status, sentiment status, quick action buttons
Main Chat Area	Chat history with coloured messages and timestamps
Bottom Input Area	Text box for typing messages, Send button, Clear button

Chat Example
text
John: Hello
CyberGuard: Hello John! 👋 How can I help you with cybersecurity today? Try asking for 'password tips' or 'phishing tips'!

John: Give me a password tip
CyberGuard: 🔐 PASSWORD TIP #1: Use at least 12 characters - longer passwords are much harder for hackers to crack!

John: Tell me more
CyberGuard: 🔐 PASSWORD TIP #3: Never reuse passwords across different websites. If one site gets hacked, your other accounts stay safe!

John: What do you remember?
CyberGuard: I remember your name is John. You're interested in passwords. I've shared 2 tips with you.
Using Quick Action Buttons
The sidebar contains buttons for common commands:

Button	What it does
Password Tips	Sends "Give me a password tip" automatically
Phishing Tips	Sends "Give me a phishing tip" automatically
Scam Tips	Sends "Give me a scam tip" automatically
Privacy Tips	Sends "Give me a privacy tip" automatically
Tell Me More	Sends "Tell me more" to get additional info
Another Tip	Sends "Give me another tip" for more variety
What do you remember?	Shows stored user information
Hello	Sends a greeting
Help	Displays help information
Colour Coding in Chat
Colour	Sender	Meaning
Light Green	User	Your messages
Cyan	System	Welcome and info messages
Yellow	Tip	Helpful cybersecurity advice
Light Blue	CyberGuard	Chatbot responses
Command Reference
Topic-Specific Commands
Command	Response
password tips	Random password safety tip
phishing tips	Random phishing detection tip
scam tips	Random scam awareness tip
privacy tips	Random privacy protection tip
2fa or two factor	Information about two-factor authentication
Conversation Flow Commands
Command	Response
tell me more	Additional information about current topic
another tip	Another random tip on the same topic
give me another	Same as "another tip"
Memory Commands
Command	Response
What do you remember?	Shows stored user information
What do you know about me?	Same as above
I'm interested in passwords	Stores password as favourite topic
I like phishing	Stores phishing as favourite topic
I want to learn about privacy	Stores privacy as favourite topic
Sentiment Commands
Command	Response
I'm worried about scams	Empathetic response + scam tip
I'm scared of being hacked	Reassuring response + security tip
This is confusing	Simplifying explanation + encouragement
General Commands
Command	Response
hello or hi	Personalized greeting
menu	Shows available topics
help	Shows help information
exit or goodbye	Closes the application
South African Specific Commands
Command	Response
sars	Information about SARS phishing scams
sassa	Information about SASSA scams
fnb	FNB banking security information
capitec	Capitec banking security information
standard bank	Standard Bank security information

📁 Code Structure
text
PROG6221-Part2-CyberGuard/
│
├── 📁 Audio/
│   └── greeting.wav                 # Voice greeting (Part 1)
│
├── 📁 Classes/
│   ├── AudioManager.cs              # Audio playback (Part 1)
│   ├── Chatbot.cs                   # Keyword responses (Part 1 + Part 2)
│   ├── ConsoleHelper.cs             # Console UI helpers (Part 1)
│   ├── Logo.cs                      # ASCII art (Part 1)
│   ├── ResponseManager.cs           # Random responses (Part 2 - NEW)
│   ├── SentimentAnalyzer.cs         # Emotion detection (Part 2 - NEW)
│   ├── Topic.cs                     # Educational topics (Part 1)
│   └── UserMemory.cs                # Memory storage (Part 2 - NEW)
│
├── 📁 Forms/
│   └── MainForm.cs                  # GUI window (Part 2 - NEW)
│
├── .gitignore                       # Excludes bin/, obj/, .vs/
├── Program.cs                       # Entry point - launches GUI
├── CyberGuardChatbot.csproj         # Project file with WinForms
├── README.md                        # This file
└── REFERENCES.md                    # Harvard-style references

References
Pieterse, H. (2021) 'The Cyber Threat Landscape in South Africa: A 10-Year Review', The African Journal of Information and Communication, 28(28).

Troelsen, A. and Japikse, P. (2022) Pro C# 10 with .NET 6. 11th edn. New York: Apress.

NIST (2020) Digital Identity Guidelines. National Institute of Standards and Technology Special Publication 800-63B.

Hutto, C.J. and Gilbert, E.E. (2014) 'VADER: Sentiment Analysis for Social Media Text', Proceedings of the 8th ICWSM.

Microsoft Corporation (2024) Windows Forms Documentation. Available at: https://learn.microsoft.com/en-us/dotnet/desktop/winforms/



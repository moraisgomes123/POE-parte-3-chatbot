# 🛡️ Cybersecurity Awareness Chatbot – Part 2

Advanced Cybersecurity Education, Task Management and Quiz System
# 1. Project Overview
The Cybersecurity Awareness Chatbot is a desktop application developed using C# and Windows Presentation Foundation (WPF). The system was designed to educate users about cybersecurity threats, promote safe online practices, and provide an engaging user experience through multiple integrated features.
The application combines artificial intelligence concepts, task management, cybersecurity education, quiz-based learning, database management, Natural Language Processing (NLP) simulation, reminder systems, and activity tracking into a single professional desktop solution.
The project was developed across three stages:

# Part 1
Basic cybersecurity chatbot with predefined responses and user interaction.

# Part 2
Advanced chatbot functionality including:
Intent recognition
Sentiment analysis
Context awareness
Memory management
Response randomisation
Enhanced graphical user interface


# Part 3
Advanced integrated system including:
Cybersecurity Task Assistant
Reminder System
Cybersecurity Quiz Game
NLP Simulation
Activity Logging
SQL Database Integration
Complete GUI Integration


# 2. Purpose of the System
Cybercrime continues to increase globally, making cybersecurity awareness more important than ever.
Many users remain vulnerable to attacks such as:
Phishing
Identity theft
Malware infections
Ransomware attacks
Social engineering scams
Password attacks
The purpose of this application is to educate users about these threats while providing interactive tools that encourage learning and safe cybersecurity practices.
The system acts as both:
Educational Tool
Teaching users cybersecurity concepts through conversations and quizzes.
Productivity Tool
Helping users manage cybersecurity-related tasks and reminders.

# 3. Main Features

# 3.1 Cybersecurity Chatbot

The chatbot serves as the primary communication interface.
Users can ask questions related to cybersecurity topics such as:
Phishing
Malware
Password security
VPNs
Firewalls
Social engineering
Data breaches
Safe browsing
The chatbot responds using predefined knowledge stored in JSON files and processed through the chatbot engine.
Benefits
Interactive learning
User-friendly communication
Immediate cybersecurity guidance
Educational engagement

# 3.2 Natural Language Processing (NLP) Simulation
The NLP simulation improves user interaction by detecting user intent rather than relying solely on exact keyword matching.
Supported Intent Recognition
User Input	Detected Intent
"I need to create a task"	ADD_TASK
"Remind me tomorrow"	REMINDER
"I want a quiz"	QUIZ
"Show activities"	ACTIVITY
Advantages
More natural conversations
Better user experience
Intelligent response generation
Context awareness

# 3.3 Cybersecurity Task Assistant
The Task Assistant allows users to manage cybersecurity-related activities.
Users can:
Add tasks
View tasks
Mark tasks as completed
Delete tasks
Refresh task list
Example Tasks
Change email password
Enable two-factor authentication
Update antivirus software
Backup important files
Review privacy settings
Stored Information
Each task contains:
Task ID
Title
Description
Reminder Date
Creation Date
Status

# 3.4 Reminder System
The reminder system automatically checks task deadlines.
When a task becomes due, the application displays a reminder notification.
Example
Task:
Enable 2FA
Reminder Date:
15 June 2026
Reminder:
"Reminder: Enable 2FA is due today."
Benefits
Improves cybersecurity habits
Encourages proactive security
Helps users stay organised

# 3.5 Cybersecurity Quiz Game
The quiz system provides interactive cybersecurity training.
The quiz contains between 15 and 20 cybersecurity questions covering:
Phishing
Malware
Firewalls
VPNs
Password security
Encryption
Social engineering
Data breaches
Safe browsing
Example Question
What is 2FA?
A) Extra login security
B) Antivirus software
C) Email filter
D) VPN service
Quiz Features
Multiple-choice questions
Instant feedback
Explanations after answers
Final score calculation
Database score storage
Activity logging
Educational Benefits
Reinforces cybersecurity knowledge
Interactive learning
User engagement
Performance tracking

# 3.6 Activity Log System
Every important action performed within the application is recorded.
Recorded Activities
Task creation
Task deletion
Task completion
Quiz start
Quiz completion
Reminder notifications
NLP detections
Example Log Entry
[15/06/2026 14:30]
TASK
Task added: Enable 2FA
Features
Chronological tracking
Show More functionality
Easy navigation
User activity monitoring

# 3.7 Database Integration
The application uses Microsoft SQL Server LocalDB for persistent data storage.
Database Tables
Tasks
Stores task information.
ActivityLog
Stores application activities.
QuizResults
Stores quiz scores and completion dates.
CRUD Operations
The system supports full database functionality:
Operation	Supported
Create	Yes
Read	Yes
Update	Yes
Delete	Yes

# 4. System Architecture
The project follows a modular architecture.
Benefits include:
Maintainability
Scalability
Reusability
Separation of concerns
Easier debugging

# 5. Project Structure
CybersecurityChatbot
│
├── Activity
│   ├── ActivityItem.cs
│   └── ActivityLogger.cs
│
├── Audio
│   └── Greeting.wav
│
├── Chatbot
│   ├── AsciiArt.cs
│   ├── ChatbotEngine.cs
│   ├── ConversationContext.cs
│   ├── UIFormatter.cs
│   └── VoiceGreeting.cs
│
├── Data
│   └── responses.json
│
├── Database
│   ├── DatabaseHelper.cs
│   └── TaskModel.cs
│
├── Models
│   └── Response.cs
│
├── Quiz
│   ├── QuizManager.cs
│   └── QuizQuestion.cs
│
├── Services
│   ├── NLPService.cs
│   ├── ReminderService.cs
│   ├── JsonResponseLoader.cs
│   └── ResponseService.cs
│
├── MainWindow.xaml
├── MainWindow.xaml.cs
├── App.xaml
├── App.xaml.cs
└── README.md

# 6. Technologies Used
Technology	Purpose
C#	Core programming language
WPF	Desktop user interface
.NET Framework	Application framework
SQL Server LocalDB	Database storage
Microsoft.Data.SqlClient	Database connectivity
JSON	Chatbot knowledge base
Visual Studio	Development environment

# 7. Testing Performed
The application was tested using multiple scenarios.
Chatbot Testing
Phishing questions
Password security questions
VPN questions
Firewall questions
Task Assistant Testing
Add task
Delete task
Complete task
Refresh tasks
Quiz Testing
Correct answers
Incorrect answers
Final score generation
Quiz restart
Activity Log Testing
Logging functionality
Show More functionality
Activity retrieval
Database Testing
Insert operations
Update operations
Delete operations
Data retrieval
All tests completed successfully.
8. Challenges Encountered
Several challenges were encountered during development:
Database Connectivity
Ensuring stable SQL Server LocalDB connections.
Quiz Navigation
Managing question progression and score calculations.
WPF Interface Design
Creating a modern and responsive interface.
NLP Detection
Developing accurate intent recognition using keyword analysis.
Activity Synchronisation
Ensuring logs reflected real-time user actions.
These challenges were resolved through iterative testing and debugging.

# 9. Future Improvements
Future versions may include:
Voice recognition
AI-powered chatbot integration
Online cybersecurity news feed
User authentication system
Cloud database integration
User profiles
Progress analytics dashboard
Gamification achievements
Export reports to PDF
Multi-language support

# 10. Conclusion
The Cybersecurity Awareness Chatbot successfully combines cybersecurity education with productivity and interactive learning tools.
The system demonstrates the practical application of:
Object-Oriented Programming
WPF Development
Database Management
Software Engineering Principles
User Interface Design
Natural Language Processing Concepts
The completed application provides users with a comprehensive platform for learning cybersecurity concepts, managing security-related tasks, testing knowledge through quizzes, and maintaining awareness of cybersecurity best practices.


# 🖥️ WPF Graphical User Interface

Part 2 introduces a complete WPF graphical interface replacing the console-only interface from Part 1.

<img width="1906" height="1092" alt="Screenshot 2026-05-28 155944" src="https://github.com/user-attachments/assets/7c6b424e-1eb7-48f9-9d45-25794d078453" />


<img width="1917" height="1081" alt="Screenshot 2026-05-28 160045" src="https://github.com/user-attachments/assets/33c1ea2e-132b-4ab4-872e-2cbf119533ce" />




# 📚 References

Microsoft, 2025. Microsoft Learn: WPF Documentation. Available at: https://learn.microsoft.com/ [Accessed 25 June 2026].
Microsoft, 2025. Microsoft.Data.SqlClient Documentation. Available at: https://learn.microsoft.com/sql/connect/ado-net/ [Accessed 25 June 2026].
Microsoft, 2025. SQL Server LocalDB Documentation. Available at: https://learn.microsoft.com/sql/database-engine/configure-windows/sql-server-express-localdb [Accessed 25 June 2026].
Oracle, 2025. Object-Oriented Programming Concepts. Available at: https://docs.oracle.com/ [Accessed 25 June 2026].
National Cyber Security Centre (NCSC), 2025. Cyber Security Guidance. Available at: https://www.ncsc.gov.uk/ [Accessed 25 June 2026].


Codecademy. (2026) *Codecademy*. Available at: https://www.codecademy.com (Accessed: 20 May 2026).

Coursera. (2026) *Coursera*. Available at: https://www.coursera.org (Accessed: 22 May 2026).

freeCodeCamp. (2026) *freeCodeCamp*. Available at: https://www.freecodecamp.org (Accessed: 22 May 2026).

GeeksforGeeks. (2026) *GeeksforGeeks*. Available at: https://www.geeksforgeeks.org (Accessed: 22 May 2026).

GitHub. (2026) *GitHub*. Available at: https://github.com (Accessed: 29 May 2026).

Microsoft Learn. (2026) *Microsoft Learn*. Available at: https://learn.microsoft.com (Accessed: 23 May 2026).

Stack Overflow. (2026) *Stack Overflow*. Available at: https://stackoverflow.com (Accessed: 24 May 2026).

W3Schools. (2026) *W3Schools Online Web Tutorials*. Available at: https://www.w3schools.com (Accessed: 23 May 2026).


## Cybersecurity References

Stallings, W. and Brown, L. (2018) *Cybersecurity Essentials*. 2nd edn. Pearson.

Pfleeger, C.P. and Pfleeger, S.L. (2012) *Security in Computing*. 5th edn. Prentice Hall.

NIST (2020) *Cybersecurity Framework*.

ENISA (2022) *Cybersecurity Awareness Raising Guide*.

Kaspersky (2024) *What is phishing?*

---

## Microsoft Technologies

Microsoft (2025) .NET Documentation.  
https://learn.microsoft.com/

Microsoft (2025) WPF Documentation.  
https://learn.microsoft.com/dotnet/desktop/wpf/

Microsoft (2025) System.Text.Json Documentation.  
https://learn.microsoft.com/dotnet/standard/serialization/system-text-json

---

## Libraries

Heath, M. (2024) NAudio GitHub Repository.  
https://github.com/naudio/NAudio

---

# 👨‍💻 Author

## Cybersecurity Awareness Chatbot – Part 2

Developed as an educational cybersecurity awareness application using:

- C#
- WPF
- .NET
- Modern software engineering principles
- Modular architecture
- Object-oriented programming
````



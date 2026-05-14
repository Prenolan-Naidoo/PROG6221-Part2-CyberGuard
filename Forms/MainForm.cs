// ====================================================================
// PROGRAMMING 2A (PROG6221) - POE PART 2
// ====================================================================
// STUDENT NAME: Prenolan Naidoo
// STUDENT NUMBER: ST10445908
// DATE: 5/14/2026
// ====================================================================
// CLASS: MainForm
// DESCRIPTION: Main GUI window for the CyberGuard Chatbot
//              Converts the console app to a Windows Forms application
// ====================================================================

using System;
using System.Drawing;
using System.Windows.Forms;
using CyberGuardChatbot.Classes;

namespace CyberGuardChatbot.Forms
{
    /// <summary>
    /// Main form class for the GUI chatbot interface
    /// </summary>
    public partial class MainForm : Form
    {
        // Core components from Part 1 (enhanced for Part 2)
        private Chatbot chatbot;
        private UserMemory userMemory;
        private SentimentAnalyzer sentimentAnalyzer;
        private ResponseManager responseManager;
        private AudioManager audioManager;

        // UI Components
        private Panel headerPanel;
        private Panel sidebarPanel;
        private Panel chatPanel;
        private RichTextBox chatDisplay;
        private TextBox userInputBox;
        private Button sendButton;
        private Button clearButton;
        private Button exitButton;
        private Label titleLabel;
        private Label statusLabel;
        private FlowLayoutPanel quickActionsPanel;
        private Label memoryStatusLabel;

        public MainForm()
        {
            // Initialize components
            InitializeComponents();

            // Initialize chatbot components (Part 1 + Part 2 enhancements)
            InitializeChatbot();

            // Set up quick action buttons
            SetupQuickActions();

            // Show name input dialog
            ShowNameInputDialog();

            // Play voice greeting (from Part 1)
            audioManager.PlayGreeting();
        }

        private void InitializeComponents()
        {
            // Form settings
            this.Text = "CyberGuard - Cybersecurity Awareness Assistant";
            this.Size = new Size(1100, 750);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(15, 25, 35);
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            this.MinimumSize = new Size(800, 600);

            // Header Panel
            headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.FromArgb(0, 120, 120)
            };

            // Title Label
            titleLabel = new Label
            {
                Text = "🛡️ CYBERGUARD | Cybersecurity Awareness Assistant",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Location = new Point(20, 25),
                AutoSize = true
            };

            // Status Label
            statusLabel = new Label
            {
                Text = "● Online | Ready to help",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Color.FromArgb(200, 255, 200),
                BackColor = Color.Transparent,
                Location = new Point(20, 55),
                AutoSize = true
            };

            headerPanel.Controls.Add(titleLabel);
            headerPanel.Controls.Add(statusLabel);

            // Sidebar Panel
            sidebarPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 220,
                BackColor = Color.FromArgb(25, 35, 45)
            };

            // ASCII Art Label (from Part 1)
            Label asciiLabel = new Label
            {
                Text = "╔══════════════════╗\n" +
                       "║  ██████╗██╗   ██╗ ║\n" +
                       "║ ██╔════╝╚██╗ ██╔╝ ║\n" +
                       "║ ██║      ╚████╔╝  ║\n" +
                       "║ ██║       ╚██╔╝   ║\n" +
                       "║ ╚██████╗   ██║    ║\n" +
                       "║  ╚═════╝   ╚═╝    ║\n" +
                       "╚══════════════════╝",
                Font = new Font("Consolas", 7F, FontStyle.Bold),
                ForeColor = Color.Cyan,
                BackColor = Color.Transparent,
                Location = new Point(10, 15),
                AutoSize = true
            };

            // Memory status label (NEW for Part 2)
            memoryStatusLabel = new Label
            {
                Text = "🧠 Memory: Active",
                Font = new Font("Segoe UI", 8F, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 200, 100),
                BackColor = Color.Transparent,
                Location = new Point(10, 130),
                AutoSize = true
            };

            Label sidebarTitle = new Label
            {
                Text = "── QUICK ACTIONS ──",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = Color.Transparent,
                Location = new Point(10, 160),
                AutoSize = true
            };

            sidebarPanel.Controls.Add(asciiLabel);
            sidebarPanel.Controls.Add(memoryStatusLabel);
            sidebarPanel.Controls.Add(sidebarTitle);

            // Quick Actions Flow Panel
            quickActionsPanel = new FlowLayoutPanel
            {
                Location = new Point(10, 190),
                Size = new Size(200, 350),
                BackColor = Color.Transparent,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true
            };

            sidebarPanel.Controls.Add(quickActionsPanel);

            // Chat Panel
            chatPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(20, 30, 40),
                Padding = new Padding(10)
            };

            // Chat Display
            chatDisplay = new RichTextBox
            {
                Location = new Point(10, 10),
                Size = new Size(820, 520),
                BackColor = Color.FromArgb(30, 40, 50),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10F),
                BorderStyle = BorderStyle.None,
                ReadOnly = true,
                ScrollBars = RichTextBoxScrollBars.Vertical
            };

            // User Input Area
            Panel inputPanel = new Panel
            {
                Location = new Point(10, 540),
                Size = new Size(820, 60),
                BackColor = Color.FromArgb(25, 35, 45)
            };

            userInputBox = new TextBox
            {
                Location = new Point(10, 15),
                Size = new Size(650, 30),
                BackColor = Color.FromArgb(40, 50, 60),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Font = new Font("Segoe UI", 11F)
            };
            userInputBox.KeyPress += UserInputBox_KeyPress;

            sendButton = new Button
            {
                Text = "📤 SEND",
                Location = new Point(670, 14),
                Size = new Size(70, 32),
                BackColor = Color.FromArgb(0, 120, 120),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            sendButton.Click += SendButton_Click;

            clearButton = new Button
            {
                Text = "🗑️ CLEAR",
                Location = new Point(745, 14),
                Size = new Size(65, 32),
                BackColor = Color.FromArgb(80, 60, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            clearButton.Click += ClearButton_Click;

            inputPanel.Controls.Add(userInputBox);
            inputPanel.Controls.Add(sendButton);
            inputPanel.Controls.Add(clearButton);

            // Exit Button
            exitButton = new Button
            {
                Text = "🚪 EXIT",
                Location = new Point(10, 560),
                Size = new Size(200, 40),
                BackColor = Color.FromArgb(120, 40, 40),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            exitButton.Click += ExitButton_Click;
            sidebarPanel.Controls.Add(exitButton);

            chatPanel.Controls.Add(chatDisplay);
            chatPanel.Controls.Add(inputPanel);

            // Add panels to form
            this.Controls.Add(chatPanel);
            this.Controls.Add(sidebarPanel);
            this.Controls.Add(headerPanel);
        }

        private void InitializeChatbot()
        {
            // Initialize Part 1 components
            chatbot = new Chatbot();
            audioManager = new AudioManager();

            // Initialize Part 2 components
            userMemory = new UserMemory();
            sentimentAnalyzer = new SentimentAnalyzer();
            responseManager = new ResponseManager();
        }

        private void SetupQuickActions()
        {
            // Quick action buttons for common queries
            string[][] actions = new string[][]
            {
                new string[] { "🔐 Password Tips", "Give me a password tip" },
                new string[] { "🎣 Phishing Tips", "Give me a phishing tip" },
                new string[] { "⚠️ Scam Tips", "Give me a scam tip" },
                new string[] { "🛡️ Privacy Tips", "Give me a privacy tip" },
                new string[] { "📚 Tell Me More", "Tell me more" },
                new string[] { "🔁 Another Tip", "Give me another tip" },
                new string[] { "🧠 What do you remember?", "What do you remember about me?" },
                new string[] { "👋 Hello", "Hello" },
                new string[] { "❓ Help", "Help" }
            };

            foreach (var action in actions)
            {
                Button btn = new Button
                {
                    Text = action[0],
                    Tag = action[1],
                    Size = new Size(190, 38),
                    BackColor = Color.FromArgb(0, 100, 100),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                    TextAlign = ContentAlignment.MiddleLeft,
                    Padding = new Padding(8, 0, 0, 0),
                    Cursor = Cursors.Hand
                };
                btn.Click += (s, e) => ProcessQuickAction(btn.Tag.ToString());
                quickActionsPanel.Controls.Add(btn);
            }
        }

        private void ProcessQuickAction(string message)
        {
            userInputBox.Text = message;
            SendButton_Click(null, null);
        }

        private void ShowNameInputDialog()
        {
            string userName = "";
            using (Form dialog = new Form())
            {
                dialog.Text = "Welcome to CyberGuard";
                dialog.Size = new Size(450, 220);
                dialog.StartPosition = FormStartPosition.CenterParent;
                dialog.BackColor = Color.FromArgb(30, 40, 50);
                dialog.FormBorderStyle = FormBorderStyle.FixedDialog;
                dialog.MaximizeBox = false;
                dialog.MinimizeBox = false;

                Label lbl = new Label
                {
                    Text = "Welcome to CyberGuard!\n\nPlease enter your name to begin:",
                    Location = new Point(20, 20),
                    Size = new Size(390, 60),
                    Font = new Font("Segoe UI", 12F),
                    ForeColor = Color.White,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                TextBox txtName = new TextBox
                {
                    Location = new Point(20, 95),
                    Size = new Size(390, 30),
                    Font = new Font("Segoe UI", 11F),
                    BackColor = Color.FromArgb(50, 60, 70),
                    ForeColor = Color.White
                };

                Button btnOk = new Button
                {
                    Text = "Start Chatting",
                    Location = new Point(135, 140),
                    Size = new Size(160, 35),
                    BackColor = Color.FromArgb(0, 120, 120),
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    DialogResult = DialogResult.OK
                };

                dialog.Controls.Add(lbl);
                dialog.Controls.Add(txtName);
                dialog.Controls.Add(btnOk);

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    userName = txtName.Text.Trim();
                    if (string.IsNullOrWhiteSpace(userName))
                        userName = "Friend";
                }
                else
                {
                    userName = "Friend";
                }
            }

            // Store in memory (Part 2 feature)
            userMemory.UserName = userName;

            // Also set in chatbot (Part 1 compatibility)
            chatbot.SetUserName(userName);

            // Welcome message
            AppendToChat("🛡️ SYSTEM", $"Welcome to CyberGuard, {userName}!", Color.Cyan);
            AppendToChat("💡 INFO", "I can help you learn about:\n• Password safety\n• Phishing emails\n• Scam detection\n• Online privacy\n\nTry typing 'password tips' or 'phishing tips'!", Color.Yellow);
            AppendToChat("🧠 MEMORY", "I'll remember our conversation and personalize my responses!", Color.FromArgb(150, 200, 150));
        }

        private void AppendToChat(string sender, string message, Color color)
        {
            if (chatDisplay.InvokeRequired)
            {
                chatDisplay.Invoke(new Action(() => AppendToChat(sender, message, color)));
                return;
            }

            chatDisplay.SelectionStart = chatDisplay.TextLength;
            chatDisplay.SelectionLength = 0;
            chatDisplay.SelectionColor = color;
            chatDisplay.AppendText($"[{DateTime.Now:HH:mm}] {sender}: ");

            chatDisplay.SelectionColor = Color.White;
            chatDisplay.AppendText($"{message}\n\n");

            chatDisplay.SelectionStart = chatDisplay.TextLength;
            chatDisplay.ScrollToCaret();

            // Update memory status display
            UpdateMemoryStatus();
        }

        private void UpdateMemoryStatus()
        {
            if (memoryStatusLabel.InvokeRequired)
            {
                memoryStatusLabel.Invoke(new Action(UpdateMemoryStatus));
                return;
            }

            string memoryText = $"🧠 Remembering: {userMemory.UserName}";
            if (!string.IsNullOrEmpty(userMemory.FavoriteTopic))
                memoryText += $" | 📚 {userMemory.FavoriteTopic}";
            if (userMemory.TipsGivenCount > 0)
                memoryText += $" | 💡 {userMemory.TipsGivenCount} tips";

            memoryStatusLabel.Text = memoryText;
            memoryStatusLabel.ForeColor = Color.FromArgb(100, 255, 100);
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            string userMessage = userInputBox.Text.Trim();
            if (string.IsNullOrWhiteSpace(userMessage))
                return;

            // Display user message
            AppendToChat(userMemory.UserName, userMessage, Color.LightGreen);

            // DETECT SENTIMENT (Part 2 feature)
            string sentiment = sentimentAnalyzer.DetectSentiment(userMessage);
            userMemory.StorePreference("last_sentiment", sentiment);

            // PROCESS INPUT with enhanced Part 2 logic
            string response = ProcessUserInputWithMemory(userMessage, sentiment);

            // Display bot response
            AppendToChat("🤖 CyberGuard", response, Color.FromArgb(150, 200, 255));

            // Clear input box
            userInputBox.Clear();
            userInputBox.Focus();
        }

        private string ProcessUserInputWithMemory(string userMessage, string sentiment)
        {
            string lowerMessage = userMessage.ToLower();

            // ============================================================
            // PART 2: CONVERSATION FLOW - "Tell me more" handling
            // ============================================================
            if (lowerMessage.Contains("tell me more") ||
                lowerMessage.Contains("another tip") ||
                lowerMessage.Contains("give me another"))
            {
                userMemory.AwaitingMoreInfo = true;
                if (!string.IsNullOrEmpty(userMemory.CurrentTopic))
                {
                    userMemory.TipsGivenCount++;
                    return responseManager.GetMoreInfo(userMemory.CurrentTopic);
                }
                else
                {
                    return "What topic would you like to learn more about? Try asking about passwords, phishing, scams, or privacy!";
                }
            }

            // ============================================================
            // PART 2: MEMORY & RECALL - "What do you remember?" 
            // ============================================================
            if (lowerMessage.Contains("what do you remember") ||
                lowerMessage.Contains("what do you know about me") ||
                lowerMessage.Contains("memory"))
            {
                return userMemory.GetMemorySummary();
            }

            // ============================================================
            // PART 2: RANDOM RESPONSES for specific requests
            // ============================================================
            if (lowerMessage.Contains("password tip") || lowerMessage == "password tips")
            {
                userMemory.CurrentTopic = "password";
                userMemory.TipsGivenCount++;
                return responseManager.GetRandomPasswordTip();
            }

            if (lowerMessage.Contains("phishing tip") || lowerMessage == "phishing tips")
            {
                userMemory.CurrentTopic = "phishing";
                userMemory.TipsGivenCount++;
                return responseManager.GetRandomPhishingTip();
            }

            if (lowerMessage.Contains("scam tip") || lowerMessage == "scam tips")
            {
                userMemory.CurrentTopic = "scam";
                userMemory.TipsGivenCount++;
                return responseManager.GetRandomScamTip();
            }

            if (lowerMessage.Contains("privacy tip") || lowerMessage == "privacy tips")
            {
                userMemory.CurrentTopic = "privacy";
                userMemory.TipsGivenCount++;
                return responseManager.GetRandomPrivacyTip();
            }

            // ============================================================
            // PART 2: FAVORITE TOPIC MEMORY - User expresses interest
            // ============================================================
            if (lowerMessage.Contains("interested in") || lowerMessage.Contains("i like"))
            {
                if (lowerMessage.Contains("password"))
                {
                    userMemory.FavoriteTopic = "passwords";
                    return $"Great! I'll remember that you're interested in passwords. That's a very important topic! {responseManager.GetRandomPasswordTip()}";
                }
                else if (lowerMessage.Contains("phishing"))
                {
                    userMemory.FavoriteTopic = "phishing";
                    return $"Excellent! I'll note that you want to learn about phishing. {responseManager.GetRandomPhishingTip()}";
                }
                else if (lowerMessage.Contains("privacy"))
                {
                    userMemory.FavoriteTopic = "privacy";
                    return $"Privacy is crucial! I'll remember that's your focus. {responseManager.GetRandomPrivacyTip()}";
                }
                else if (lowerMessage.Contains("scam"))
                {
                    userMemory.FavoriteTopic = "scams";
                    return $"Good to know! Learning about scams is very wise. {responseManager.GetRandomScamTip()}";
                }
            }

            // ============================================================
            // PART 2: SENTIMENT-BASED RESPONSES (empathetic)
            // ============================================================
            if (sentiment != "neutral" && sentiment != "positive")
            {
                string empatheticResponse = sentimentAnalyzer.GetEmpatheticResponse(sentiment, userMemory.UserName);
                // Also give a helpful tip
                string tip = responseManager.GetRandomPhishingTip();
                return $"{empatheticResponse}\n\n{tip}";
            }

            // ============================================================
            // PART 1: Use existing keyword responses from Chatbot.cs
            // ============================================================
            string keywordResponse = chatbot.GetKeywordResponse(userMessage);
            if (keywordResponse != null)
            {
                // Update current topic based on keywords
                if (lowerMessage.Contains("password"))
                    userMemory.CurrentTopic = "password";
                else if (lowerMessage.Contains("phishing"))
                    userMemory.CurrentTopic = "phishing";
                else if (lowerMessage.Contains("scam"))
                    userMemory.CurrentTopic = "scam";
                else if (lowerMessage.Contains("privacy") || lowerMessage.Contains("2fa"))
                    userMemory.CurrentTopic = "privacy";

                userMemory.TipsGivenCount++;
                return keywordResponse;
            }

            // ============================================================
            // PART 2: PERSONALIZED RESPONSES using memory
            // ============================================================
            if (!string.IsNullOrEmpty(userMemory.FavoriteTopic))
            {
                // Occasionally reference their favorite topic
                Random rand = new Random();
                if (rand.Next(5) == 0) // 20% chance
                {
                    return $"Since you're interested in {userMemory.FavoriteTopic}, here's a reminder: {responseManager.GetMoreInfo(userMemory.FavoriteTopic)}";
                }
            }

            // Check if user is just saying hello with name
            if (lowerMessage.Contains("hello") || lowerMessage.Contains("hi") || lowerMessage == "hey")
            {
                return $"Hello {userMemory.UserName}! How can I help you with cybersecurity today? Try asking for 'password tips' or 'phishing tips'!";
            }

            // ============================================================
            // PART 2: ERROR HANDLING - Default response for unknown input
            // ============================================================
            string[] defaultResponses = {
                $"I'm not sure I understand, {userMemory.UserName}. Can you try rephrasing?",
                $"Hmm, I didn't quite get that. Try asking me about passwords, phishing, or scams!",
                $"Let me help you better. Type 'password tips' or 'phishing tips' for helpful advice!",
                $"I'm still learning! You can ask me for 'password tips', 'phishing tips', or 'scam tips'!"
            };
            Random random = new Random();
            return defaultResponses[random.Next(defaultResponses.Length)];
        }

        private void UserInputBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                SendButton_Click(null, null);
                e.Handled = true;
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            chatDisplay.Clear();
            AppendToChat("🤖 CyberGuard", "Chat history cleared. I still remember who you are and our conversation context!", Color.FromArgb(150, 200, 255));
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Are you sure you want to exit CyberGuard?\n\nRemember: Stay safe online! 🔒",
                "Exit Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
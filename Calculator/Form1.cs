using System.Runtime.InteropServices;
using System.Web;
using Timer = System.Windows.Forms.Timer;

namespace Simple_Windows_Calculator
{
    public partial class SimpleCalculator : Form
    {
        public SimpleCalculator()
        {
            InitializeComponent();
        }

        // hide the blinking text cursor
        [DllImport("user32.dll")]
        private static extern bool HideCaret(IntPtr hWnd);

        private readonly double[] operand = [Double.MaxValue, Double.MaxValue]; // store the two numbers you’re working with
        private double result = Double.MaxValue; // stores the result of the latest operation
        private string specialOperation = ""; // keeps track of things like √, %, or 1/x.

        // ⚠️ ERROR HANDLING
        private enum ErrorCode
        {
            None,
            DivideByZero,
            NegativeSquareRoot
        }
        private readonly string[] errorText =
        {
            "No Error",
            "Cannot divide by zero",
            "Invalid input"
        };

        private const string precisionFormat = "##############0.##############";

        private void Form1_Load(object sender, EventArgs e)
        {
            // Initialize memory indicator
            UpdateMemoryIndicator();

            // Initialize memory panel visibility - set to TRUE by default
            memoryPanelVisible = true;
            panelMemory.Visible = memoryPanelVisible;

            // Initialize history system (but don't show it yet)
            InitializeHistoryPanel();

            // Set focus to form for keyboard input
            this.Focus();

            // Initialize displays
            textMainDisplay.Text = "0";
            textFormulaDisplay.Clear();
        }


        // Hide blinking cursor from textboxes
        private void MainDisplay_MouseDown(object sender, MouseEventArgs e)
        {
            HideCaret(textMainDisplay.Handle);
        }

        private bool clearFirstTime = false;

        //➕ BUTTON CLICK HANDLERS

        // Ensures display doesn’t exceed 13 digits.
        private void ButtonNumbers_Click(object sender, EventArgs e)
        {
            EnableOperationKeys(sender, e);
            Button button = (Button)sender;
            //textMainDisplay.Text += button.Text;
            //MessageBox.Show($"Button {button.Text} clicked", caption: "Number clicked");
            if (textMainDisplay.Text == result.ToString(precisionFormat) && clearFirstTime == false)
            {
                btnClearEntry.PerformClick();
                clearFirstTime = true;
            }

            if (textMainDisplay.TextLength < 13 + Convert.ToInt32(textMainDisplay.Text.Contains(btnDot.Text)) + Convert.ToInt32(textMainDisplay.Text.Contains("-")))
            {
                if (textMainDisplay.Text.Equals("0"))
                {
                    textMainDisplay.Text = button.Text;
                }
                else
                {
                    textMainDisplay.Text += button.Text;
                }
            }
        }

        // prevents adding more than one . to a number.
        private void ButtonDot_Click(object sender, EventArgs e)
        {
            Button btnDot = (Button)sender;
            //MessageBox.Show("Button Dot clicked");
            if (textMainDisplay.Text.Contains(btnDot.Text) == false)
            {
                textMainDisplay.Text += btnDot.Text;
            }
        }

        // Toggles between positive and negative numbers. ( +/- )
        private void ButtonPlusMinus_Click(object sender, EventArgs e)
        {
            clearFirstTime = false;
            if (double.Parse(textMainDisplay.Text) != 0.0)
            {
                textMainDisplay.Text = (Convert.ToDouble(textMainDisplay.Text) * -1.0).ToString(precisionFormat);
            }
        }

        // Clears both the top and main displays.
        private void ButtonClear_Click(object sender, EventArgs e)
        {
            EnableOperationKeys(sender, e);
            textMainDisplay.Text = "0";
            textFormulaDisplay.Clear();
        }

        // Clears only the current entry.
        private void ButtonClearEntry_Click(object sender, EventArgs e)
        {
            EnableOperationKeys(sender, e);
            if (textFormulaDisplay.Text.Contains("="))
            {
                textFormulaDisplay.Clear();
            }
            textMainDisplay.Text = "0";
        }

        // Deletes the last digit.
        private void ButtonBack_Click(object sender, EventArgs e)
        {
            EnableOperationKeys(sender, e);
            if (textMainDisplay.Text.Length == 1)
            {
                textMainDisplay.Text = "0";
            }
            else
            {
                textMainDisplay.Text = textMainDisplay.Text.Remove(textMainDisplay.Text.Length - 1);
                StandardizeMainDisplay(sender, e);
            }
        }


        // 🧮 BASIC OPERATIONS LOGIC
        private ErrorCode ApplyBasicOperation()
        {
            if (textFormulaDisplay.Text.Contains("+"))
            {
                operand[0] += operand[1];
            }
            else if (textFormulaDisplay.Text.Contains("-"))
            {
                operand[0] -= operand[1];
            }
            else if (textFormulaDisplay.Text.Contains("×"))
            {
                operand[0] *= operand[1];
            }
            else if (textFormulaDisplay.Text.Contains("÷"))
            {
                if (operand[1] == 0)
                {
                    //MessageBox.Show("Check var");
                    return ErrorCode.DivideByZero;
                }
                operand[0] /= operand[1];
            }
            else
            {
                operand[0] = operand[1];
            }
            return ErrorCode.None;
        }

        private void ButtonBasicOperation_Click(object sender, EventArgs e)
        {
            clearFirstTime = false;
            Button button = (Button)sender;
            //MessageBox.Show(button.Text + " clicked");
            double mainDisplayValue = Double.Parse(textMainDisplay.Text);

            // “If the current number on the screen is the same as the last result, then start the next calculation using that result as the first number.”
            if (mainDisplayValue == result)
            {
                operand[0] = result;
            }

            // if the user has already selected an operation earlier), it means the user is entering the second operand.
            else if (textFormulaDisplay.Text != String.Empty)
            {
                operand[1] = mainDisplayValue;
                if (ApplyBasicOperation() == ErrorCode.DivideByZero)
                {
                    HandleInvalidInput(ErrorCode.DivideByZero);
                    return;
                }
                textMainDisplay.Text = operand[0].ToString(precisionFormat);
            }
            else
            {
                operand[0] = mainDisplayValue;
            }
            textFormulaDisplay.Text = operand[0].ToString(precisionFormat) + " " + button.Text;
            textMainDisplay.Text = "0";
        }

        private void ButtonSpecialOperation_Click(object sender, EventArgs e)
        {
            clearFirstTime = false;
            Button button = (Button)sender;
            //MessageBox.Show(button.Text + " clicked");
            String operationName = button.Name;
            double mainDisplayValue = Double.Parse(textMainDisplay.Text);
            switch (operationName)
            {
                case "btnSquare":
                    textMainDisplay.Text = (mainDisplayValue * mainDisplayValue).ToString(precisionFormat);
                    specialOperation = "sqr";
                    break;
                case "btnSquareRoot":
                    if (mainDisplayValue < 0)
                    {
                        HandleInvalidInput(ErrorCode.NegativeSquareRoot);
                        return;
                    }
                    textMainDisplay.Text = Math.Sqrt(mainDisplayValue).ToString(precisionFormat);
                    specialOperation = "√";
                    break;
                case "btnInverse":
                    if (mainDisplayValue == 0)
                    {
                        HandleInvalidInput(ErrorCode.DivideByZero);
                        return;
                    }
                    textMainDisplay.Text = (1.0 / mainDisplayValue).ToString(precisionFormat);
                    specialOperation = "1/";
                    break;
                case "btnPercent":
                    if (operand[0] != Double.MaxValue)
                    {
                        textMainDisplay.Text = (operand[0] * mainDisplayValue / 100.0).ToString(precisionFormat);
                    }
                    else
                    {
                        textMainDisplay.Text = "0";
                    }
                    specialOperation = "%";
                    break;
                default:
                    break;
            }
            result = mainDisplayValue;
            btnEqual.PerformClick();
        }


        private void ButtonEqual_Click(object sender, EventArgs e)
        {
            EnableOperationKeys(sender, e);

            string originalFormula = textFormulaDisplay.Text;

            if (textMainDisplay.Text != result.ToString(precisionFormat) || textMainDisplay.Text == "0")
            {
                operand[1] = Double.Parse(textMainDisplay.Text);

                if (textFormulaDisplay.Text != String.Empty && !textFormulaDisplay.Text.Contains('='))
                {
                    ErrorCode error = ApplyBasicOperation();
                    if (error != ErrorCode.None)
                    {
                        HandleInvalidInput(error);
                        return;
                    }

                    if (specialOperation != String.Empty)
                    {
                        if (specialOperation.Equals("%"))
                        {
                            double displayValue = operand[0] != Double.MaxValue ? operand[0] : 0.0;
                            textFormulaDisplay.Text += $" ({displayValue}) × {result}% = ";
                        }
                        else
                        {
                            textFormulaDisplay.Text += " " + specialOperation + "(" + result.ToString(precisionFormat) + ") =";
                        }
                    }
                    else
                    {
                        textFormulaDisplay.Text += " " + operand[1].ToString(precisionFormat) + " =";
                    }

                    result = operand[0];
                    textMainDisplay.Text = result.ToString(precisionFormat);

                    // Add to history with enhanced format
                    if (!string.IsNullOrEmpty(originalFormula))
                    {
                        string historyExpression = $"{originalFormula} {operand[1]}";
                        string historyResult = result.ToString(precisionFormat);
                        AddToHistory(historyExpression, historyResult);
                    }

                    specialOperation = "";
                }
                else if (specialOperation != String.Empty)
                {
                    textFormulaDisplay.Clear();
                    if (specialOperation.Equals("%"))
                    {
                        double displayValue = operand[0] != Double.MaxValue ? operand[0] : 0.0;
                        textFormulaDisplay.Text = $"({displayValue}) × {result}% = ";
                    }
                    else
                    {
                        textFormulaDisplay.Text = $"{specialOperation}({result}) = ";
                    }
                    specialOperation = "";
                    result = operand[1];
                }
            }
        }

        private void ResetCalculationValues()
        {
            operand[0] = operand[1] = result = Double.MaxValue;
        }

        private void DisableOperationKeys()
        {
            btnAdd.Enabled = false;
            btnSubtract.Enabled = false;
            btnMultiply.Enabled = false;
            btnDivide.Enabled = false;
            btnPercent.Enabled = false;
            btnInverse.Enabled = false;
            btnSquare.Enabled = false;
            btnSquareRoot.Enabled = false;
            btnPlusMinus.Enabled = false;
            btnDot.Enabled = false;
        }

        private void HandleInvalidInput(ErrorCode errorCode)
        {
            ResetCalculationValues();
            DisableOperationKeys();
            textMainDisplay.Text = errorText[(int)errorCode];
            textFormulaDisplay.Clear();
        }

        private void EnableOperationKeys(object sender, EventArgs e)
        {
            if (btnAdd.Enabled)
            {
                return;
            }
            btnAdd.Enabled = true;
            btnSubtract.Enabled = true;
            btnMultiply.Enabled = true;
            btnDivide.Enabled = true;
            btnPercent.Enabled = true;
            btnInverse.Enabled = true;
            btnSquare.Enabled = true;
            btnSquareRoot.Enabled = true;
            btnPlusMinus.Enabled = true;
            btnDot.Enabled = true;

            // Also enable memory store, add, and subtract buttons
            btnMemoryStore.Enabled = true;
            btnMemoryAdd.Enabled = true;
            btnMemorySubtract.Enabled = true;

            textMainDisplay.Text = "0";
        }

        private void StandardizeMainDisplay(object sender, EventArgs e)
        {
            if (Double.TryParse(textMainDisplay.Text, out double standardValue))
            {
                textMainDisplay.Text = standardValue.ToString(precisionFormat);
            }
            else
            {
                textMainDisplay.Text = "0";
            }
        }

        // 🎹 KEYBOARD SUPPORT
        private void SimpleCalculator_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                case (char)Keys.D0:
                case (char)Keys.NumPad0:
                    btnNum0.PerformClick();
                    break;
                case (char)Keys.D1:
                case (char)Keys.NumPad1:
                    btnNum1.PerformClick();
                    break;
                case (char)Keys.D2:
                case (char)Keys.NumPad2:
                    btnNum2.PerformClick();
                    break;
                case (char)Keys.D3:
                case (char)Keys.NumPad3:
                    btnNum3.PerformClick();
                    break;
                case (char)Keys.D4:
                case (char)Keys.NumPad4:
                    btnNum4.PerformClick();
                    break;
                case (char)Keys.D5:
                case (char)Keys.NumPad5:
                    btnNum5.PerformClick();
                    break;
                case (char)Keys.D6:
                case (char)Keys.NumPad6:
                    btnNum6.PerformClick();
                    break;
                case (char)Keys.D7:
                case (char)Keys.NumPad7:
                    btnNum7.PerformClick();
                    break;
                case (char)Keys.D8:
                case (char)Keys.NumPad8:
                    btnNum8.PerformClick();
                    break;
                case (char)Keys.D9:
                case (char)Keys.NumPad9:
                    btnNum9.PerformClick();
                    break;
                case (char)Keys.Back:
                    btnBack.PerformClick();
                    break;
                default:
                    break;
            }
        }

        private void SimpleCalculator_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Oemplus || e.KeyCode == Keys.Add)
            {
                btnAdd.PerformClick();
            }
            else if (e.KeyCode == Keys.OemMinus || e.KeyCode == Keys.Subtract)
            {
                btnSubtract.PerformClick();
            }
            else if (e.KeyCode == Keys.Multiply || (e.Shift && e.KeyCode == Keys.D8))
            {
                btnMultiply.PerformClick();
            }
            else if (e.KeyCode == Keys.Divide || e.KeyCode == Keys.OemQuestion)
            {
                btnDivide.PerformClick();
            }
            else if (e.KeyCode == Keys.OemPeriod || e.KeyCode == Keys.Decimal)
            {
                btnDot.PerformClick();
            }
            else if (e.KeyCode == Keys.Delete)
            {
                btnClearEntry.PerformClick();
            }
            // History shortcut (Ctrl+H) and close with Escape when history is open
            else if (e.KeyCode == Keys.H && e.Control)
            {
                ToggleHistoryPanel();
            }
            else if (e.KeyCode == Keys.Escape && isHistoryVisible)
            {
                ToggleHistoryPanel();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter && this.ActiveControl != null)
            {
                if (this.ActiveControl.Handle != this.btnEqual.Handle)
                {
                    this.btnEqual.Select();
                }
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void textFormulaDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        // Memory functionality
        private double memoryValue = 0;
        private bool memoryStored = false;
        private bool memoryPanelVisible = true;

        // Memory functions implementation
        private void ButtonMemoryClear_Click(object sender, EventArgs e)
        {
            memoryValue = 0;
            memoryStored = false;
            UpdateMemoryIndicator();
        }

        private void ButtonMemoryRecall_Click(object sender, EventArgs e)
        {
            if (memoryStored)
            {
                // Windows 10 behavior: Recall memory value to display
                textMainDisplay.Text = memoryValue.ToString(precisionFormat);
                clearFirstTime = false;

                // If there's an ongoing operation, use memory value as second operand
                if (!string.IsNullOrEmpty(textFormulaDisplay.Text) && !textFormulaDisplay.Text.Contains("="))
                {
                    operand[1] = memoryValue;
                }
            }
        }

        private void ButtonMemoryAdd_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textMainDisplay.Text, out double currentValue))
            {
                memoryValue += currentValue;
                memoryStored = true;
                UpdateMemoryIndicator();

                // Windows 10 behavior: Show "M+" briefly in formula display
                ShowMemoryOperationInDisplay("M+");
            }
        }

        private void ButtonMemorySubtract_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textMainDisplay.Text, out double currentValue))
            {
                memoryValue -= currentValue;
                memoryStored = true;
                UpdateMemoryIndicator();

                // Windows 10 behavior: Show "M-" briefly in formula display
                ShowMemoryOperationInDisplay("M-");
            }
        }

        private void ButtonMemoryStore_Click(object sender, EventArgs e)
        {
            if (double.TryParse(textMainDisplay.Text, out double currentValue))
            {
                memoryValue = currentValue;
                memoryStored = true;
                UpdateMemoryIndicator();

                // Windows 10 behavior: Show "MS" briefly in formula display
                ShowMemoryOperationInDisplay("MS");
            }
        }

        private void ButtonMemoryShow_Click(object sender, EventArgs e)
        {
            // Just update the indicator without hiding the panel
            UpdateMemoryIndicator();

            // Optional: Show memory value in formula display briefly
            if (memoryStored)
            {
                ShowMemoryOperationInDisplay($"Memory: {memoryValue}");
            }
        }

        private void ShowMemoryOperationInDisplay(string operation)
        {
            string originalFormula = textFormulaDisplay.Text;
            textFormulaDisplay.Text = operation;

            // Clear after a short delay (Windows 10 behavior)
            Timer timer = new Timer();
            timer.Interval = 500; // 0.5 seconds
            timer.Tick += (s, args) =>
            {
                textFormulaDisplay.Text = originalFormula;
                timer.Stop();
                timer.Dispose();
            };
            timer.Start();
        }

        private void UpdateMemoryIndicator()
        {
            // Windows 10 behavior: Only show M indicator when memory has value
            if (memoryStored)
            {
                btnMemoryShow.Text = "M▴";
                btnMemoryShow.ForeColor = Color.FromArgb(0, 120, 215);

                // Enable all memory buttons when memory has value
                btnMemoryClear.Enabled = true;
                btnMemoryRecall.Enabled = true;
                btnMemoryAdd.Enabled = true;
                btnMemorySubtract.Enabled = true;
                btnMemoryStore.Enabled = true;

                // White color for enabled buttons
                btnMemoryClear.ForeColor = Color.White;
                btnMemoryRecall.ForeColor = Color.White;
                btnMemoryAdd.ForeColor = Color.White;
                btnMemorySubtract.ForeColor = Color.White;
                btnMemoryStore.ForeColor = Color.White;

                // Make MC, MR, M+, M- fully opaque when memory has value
                btnMemoryClear.BackColor = Color.FromArgb(32, 32, 32);
                btnMemoryRecall.BackColor = Color.FromArgb(32, 32, 32);
                btnMemoryAdd.BackColor = Color.FromArgb(32, 32, 32);
                btnMemorySubtract.BackColor = Color.FromArgb(32, 32, 32);
                btnMemoryStore.BackColor = Color.FromArgb(32, 32, 32);
            }
            else
            {
                btnMemoryShow.Text = "M▾";
                btnMemoryShow.ForeColor = Color.FromArgb(100, 100, 100);
            }
        }
        // end of memory functionality

        // History functionality
        private List<HistoryEntry> calculationHistory = new List<HistoryEntry>();
        private const int MaxHistoryEntries = 50;

        // History panel animation - made nullable
        private Panel? historyOverlayPanel;
        private Panel? historyContentPanel;
        private bool isHistoryVisible = false;
        private const int HistoryPanelHeight = 500;
        private Timer? slideTimer;
        private int targetY;

        public class HistoryEntry
        {
            public string Expression { get; set; } = string.Empty;
            public string Result { get; set; } = string.Empty;
            public DateTime Timestamp { get; set; }

            public override string ToString()
            {
                return $"{Expression} = {Result}";
            }
        }

        private void InitializeHistoryPanel()
        {
            if (historyOverlayPanel != null) return;

            // Create overlay panel for dark background
            historyOverlayPanel = new Panel()
            {
                BackColor = Color.FromArgb(80, 0, 0, 0), // Semi-transparent black
                Dock = DockStyle.Fill,
                Visible = false,
                Location = new Point(0, 0),
                Size = this.ClientSize
            };

            // Add click event to close when clicking outside
            historyOverlayPanel.Click += (s, e) => ToggleHistoryPanel();

            // Create history content panel
            historyContentPanel = new Panel()
            {
                BackColor = Color.FromArgb(32, 32, 32),
                ForeColor = Color.White,
                Size = new Size(this.ClientSize.Width, HistoryPanelHeight),
                Location = new Point(0, this.ClientSize.Height),
                Visible = false
            };

            // Header
            Label headerLabel = new Label()
            {
                Text = "History",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                Height = 60,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0)
            };

            // Clear button in header - FIXED: Added to the correct parent
            Button clearHistoryBtn = new Button()
            {
                Text = "Clear all",
                Font = new Font("Segoe UI", 10F),
                BackColor = Color.FromArgb(50, 50, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Height = 30,
                Width = 180,
                Dock = DockStyle.Right,
                Margin = new Padding(0, 15, 20, 15)
            };
            clearHistoryBtn.FlatAppearance.BorderSize = 0;

            Panel headerPanel = new Panel()
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(32, 32, 32)
            };

            // Add controls to header panel in correct order
            headerPanel.Controls.Add(headerLabel);
            headerPanel.Controls.Add(clearHistoryBtn); // Clear button now properly added

            // History list
            ListBox historyList = new ListBox()
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 11F),
                BackColor = Color.FromArgb(32, 32, 32),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.None,
                DrawMode = DrawMode.OwnerDrawVariable
            };

            // Custom drawing for history items
            historyList.DrawItem += (s, args) =>
            {
                if (args.Index < 0) return;

                args.DrawBackground();

                if ((args.State & DrawItemState.Selected) == DrawItemState.Selected)
                {
                    args.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(50, 50, 50)), args.Bounds);
                }

                HistoryEntry? entry = historyList.Items[args.Index] as HistoryEntry;
                if (entry != null)
                {
                    // Draw expression
                    Rectangle expressionRect = new Rectangle(args.Bounds.X + 10, args.Bounds.Y,
                                                           args.Bounds.Width - 20, args.Bounds.Height / 2);
                    using (Font expressionFont = new Font("Segoe UI", 10F, FontStyle.Regular))
                    {
                        args.Graphics.DrawString(entry.Expression, expressionFont,
                                               Brushes.LightGray, expressionRect);
                    }

                    // Draw result
                    Rectangle resultRect = new Rectangle(args.Bounds.X + 10, args.Bounds.Y + args.Bounds.Height / 2,
                                                       args.Bounds.Width - 20, args.Bounds.Height / 2);
                    using (Font resultFont = new Font("Segoe UI", 11F, FontStyle.Bold))
                    {
                        args.Graphics.DrawString(entry.Result, resultFont,
                                               Brushes.White, resultRect);
                    }
                }

                args.DrawFocusRectangle();
            };

            historyList.MeasureItem += (s, args) =>
            {
                args.ItemHeight = 60;
            };

            historyList.DoubleClick += (s, args) =>
            {
                if (historyList.SelectedItem is HistoryEntry selectedEntry)
                {
                    textMainDisplay.Text = selectedEntry.Result;
                    ToggleHistoryPanel(); // Close after selection
                }
            };

            // Clear history button event
            clearHistoryBtn.Click += (s, ev) =>
            {
                var result = MessageBox.Show("Are you sure you want to delete all history?",
                                           "Clear History",
                                           MessageBoxButtons.YesNo,
                                           MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    calculationHistory.Clear();
                    historyList.Items.Clear();
                }
            };

            // Add controls to history content panel
            historyContentPanel.Controls.Add(historyList);
            historyContentPanel.Controls.Add(headerPanel);

            // Store reference to update later
            historyContentPanel.Tag = historyList;

            // Add panels to main form
            this.Controls.Add(historyOverlayPanel);
            this.Controls.Add(historyContentPanel);

            // Bring to front
            historyOverlayPanel.BringToFront();
            historyContentPanel.BringToFront();

            // Initialize slide timer
            slideTimer = new Timer();
            slideTimer.Interval = 10;
            slideTimer.Tick += SlideTimer_Tick;
        }

        private void SlideTimer_Tick(object? sender, EventArgs e)
        {
            if (historyContentPanel == null) return;

            if (isHistoryVisible)
            {
                // Slide in (moving up)
                if (historyContentPanel.Top > targetY)
                {
                    historyContentPanel.Top -= 25; // Faster animation
                    if (historyContentPanel.Top <= targetY)
                    {
                        historyContentPanel.Top = targetY;
                        slideTimer?.Stop();
                    }
                }
            }
            else
            {
                // Slide out (moving down)
                if (historyContentPanel.Top < targetY)
                {
                    historyContentPanel.Top += 80; // Faster animation
                    if (historyContentPanel.Top >= targetY)
                    {
                        historyContentPanel.Top = targetY;
                        slideTimer?.Stop();
                        historyContentPanel.Visible = false;
                        if (historyOverlayPanel != null) { 
                            historyOverlayPanel.Visible = false;
                    }
                }
                }
            }
        }

        private void ToggleHistoryPanel()
        {
            if (historyContentPanel == null)
            {
                InitializeHistoryPanel();
            }

            // Use null-conditional operators to handle potential nulls
            if (historyContentPanel == null) return;

            isHistoryVisible = !isHistoryVisible;

            if (isHistoryVisible)
            {
                // Update history list before showing
                ListBox? historyList = historyContentPanel.Tag as ListBox;
                historyList?.Items.Clear();
                foreach (var entry in calculationHistory)
                {
                    historyList?.Items.Add(entry);
                }

                // Ensure proper width
                historyContentPanel.Width = this.ClientSize.Width;
                historyOverlayPanel!.Size = this.ClientSize;

                // Position history panel at bottom (off-screen)
                historyContentPanel.Location = new Point(0, this.ClientSize.Height);
                historyContentPanel.Visible = true;
                historyOverlayPanel.Visible = true;

                // Calculate target position (slide up to show)
                targetY = this.ClientSize.Height - HistoryPanelHeight;

                // Start animation
                slideTimer?.Start();
            }
            else
            {
                // Calculate target position (slide down to hide)
                targetY = this.ClientSize.Height;
                slideTimer?.Start();
            }
        }

        private void ButtonHistory_Click(object? sender, EventArgs e)
        {
            ToggleHistoryPanel();
        }

        private void AddToHistory(string expression, string result)
        {
            HistoryEntry entry = new HistoryEntry
            {
                Expression = expression,
                Result = result,
                Timestamp = DateTime.Now
            };

            calculationHistory.Insert(0, entry);

            // Keep only the most recent entries
            if (calculationHistory.Count > MaxHistoryEntries)
            {
                calculationHistory.RemoveAt(MaxHistoryEntries);
            }
        }

        // Handle form resize to keep history panel properly sized
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            if (historyOverlayPanel != null)
            {
                historyOverlayPanel.Size = this.ClientSize;
            }

            if (historyContentPanel != null && isHistoryVisible)
            {
                historyContentPanel.Width = this.ClientSize.Width;
                historyContentPanel.Location = new Point(0, this.ClientSize.Height - HistoryPanelHeight);
            }
            else if (historyContentPanel != null)
            {
                historyContentPanel.Width = this.ClientSize.Width;
            }
        }

        // Clean up resources
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            slideTimer?.Stop();
            slideTimer?.Dispose();
            base.OnFormClosing(e);
        }

        // end of history functionality

        private void ShowCalculatorMode(string mode)
        {
            lblTitle.Text = mode;
            // Here you would typically show/hide different calculator panels
            // For now, we'll just update the title
            MessageBox.Show($"Switched to {mode} mode", "Calculator Mode");
        }

        private void ShowAboutDialog()
        {
            MessageBox.Show(
                "Simple Windows Calculator\n\n" +
                "A feature-rich calculator application\n" +
                "with memory functions and history tracking.",
                "About Calculator",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }
        private void ButtonMenu_Click(object sender, EventArgs e)
        {
            // Create context menu with Windows 10 styling
            ContextMenuStrip contextMenu = new ContextMenuStrip();
            contextMenu.Renderer = new Windows10MenuRenderer();
            contextMenu.BackColor = Color.FromArgb(45, 45, 45);
            contextMenu.ForeColor = Color.White;
            contextMenu.Font = new Font("Segoe UI", 9F);
            contextMenu.ShowImageMargin = false;
            contextMenu.ShowCheckMargin = false;

            // Add menu items with Windows 10 styling
            ToolStripMenuItem standardItem = new ToolStripMenuItem("Standard");
            ToolStripMenuItem scientificItem = new ToolStripMenuItem("Scientific");
            ToolStripMenuItem programmerItem = new ToolStripMenuItem("Programmer");

            // History item with count (Windows 10 style)
            string historyText = calculationHistory.Count > 0 ?
                $"History ({calculationHistory.Count})" : "History";
            ToolStripMenuItem historyItem = new ToolStripMenuItem(historyText);

            ToolStripMenuItem aboutItem = new ToolStripMenuItem("About");

            // Style menu items with Windows 10 colors and padding
            foreach (ToolStripMenuItem item in new[] { standardItem, scientificItem, programmerItem, historyItem, aboutItem })
            {
                item.BackColor = Color.FromArgb(45, 45, 45);
                item.ForeColor = Color.White;
                item.Font = new Font("Segoe UI", 9F);
                item.Padding = new Padding(10, 6, 10, 6);
                item.Margin = new Padding(0);
            }

            // Add click events
            standardItem.Click += (s, args) => ShowCalculatorMode("Standard");
            scientificItem.Click += (s, args) => ShowCalculatorMode("Scientific");
            programmerItem.Click += (s, args) => ShowCalculatorMode("Programmer");
            historyItem.Click += (s, args) => ToggleHistoryPanel();
            aboutItem.Click += (s, args) => ShowAboutDialog();

            // Add items to menu with Windows 10 spacing
            contextMenu.Items.Add(standardItem);
            contextMenu.Items.Add(scientificItem);
            contextMenu.Items.Add(programmerItem);

            // Add separator with Windows 10 style
            ToolStripSeparator sep1 = new ToolStripSeparator();
            sep1.Margin = new Padding(0, 2, 0, 2);
            sep1.Padding = new Padding(0);
            contextMenu.Items.Add(sep1);

            contextMenu.Items.Add(historyItem);

            // Add second separator
            ToolStripSeparator sep2 = new ToolStripSeparator();
            sep2.Margin = new Padding(0, 2, 0, 2);
            sep2.Padding = new Padding(0);
            contextMenu.Items.Add(sep2);

            contextMenu.Items.Add(aboutItem);

            // Show menu at button location (aligned properly)
            contextMenu.Show(btnMenu, new Point(0, btnMenu.Height));
        }

        // Custom renderer for Windows 10 style menu
        private class Windows10MenuRenderer : ToolStripProfessionalRenderer
        {
            public Windows10MenuRenderer() : base(new Windows10ColorTable()) { }

            protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
            {
                e.TextColor = e.Item.Selected ? Color.Black : Color.White;
                e.TextFont = new Font("Segoe UI", 9F);
                base.OnRenderItemText(e);
            }

            protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
            {
                e.ArrowColor = e.Item.Selected ? Color.Black : Color.LightGray;
                base.OnRenderArrow(e);
            }

            protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
            {
                Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);
                using (Pen pen = new Pen(Color.FromArgb(60, 60, 60)))
                {
                    e.Graphics.DrawLine(pen, rect.Left + 10, rect.Height / 2, rect.Right - 10, rect.Height / 2);
                }
            }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                Rectangle rect = new Rectangle(Point.Empty, e.Item.Size);

                if (e.Item.Selected)
                {
                    // Windows 10 selection color
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(65, 156, 227)))
                    {
                        e.Graphics.FillRectangle(brush, rect);
                    }
                }
                else
                {
                    // Default background
                    using (SolidBrush brush = new SolidBrush(Color.FromArgb(45, 45, 45)))
                    {
                        e.Graphics.FillRectangle(brush, rect);
                    }
                }
            }

            protected override void OnRenderToolStripBorder(ToolStripRenderEventArgs e)
            {
                // Remove the default border and add subtle Windows 10 style border
                using (Pen pen = new Pen(Color.FromArgb(80, 80, 80)))
                {
                    e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, e.ToolStrip.Width - 1, e.ToolStrip.Height - 1));
                }
            }
        }

        // Custom color table for Windows 10
        private class Windows10ColorTable : ProfessionalColorTable
        {
            public override Color MenuBorder => Color.FromArgb(80, 80, 80);
            public override Color MenuItemBorder => Color.Transparent;
            public override Color MenuItemSelected => Color.FromArgb(65, 156, 227);
            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(65, 156, 227);
            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(65, 156, 227);
            public override Color MenuStripGradientBegin => Color.FromArgb(45, 45, 45);
            public override Color MenuStripGradientEnd => Color.FromArgb(45, 45, 45);
            public override Color ImageMarginGradientBegin => Color.FromArgb(45, 45, 45);
            public override Color ImageMarginGradientEnd => Color.FromArgb(45, 45, 45);
            public override Color ImageMarginGradientMiddle => Color.FromArgb(45, 45, 45);
            public override Color ToolStripDropDownBackground => Color.FromArgb(45, 45, 45);
            public override Color SeparatorDark => Color.FromArgb(60, 60, 60);
            public override Color SeparatorLight => Color.FromArgb(60, 60, 60);
        }



        private void textMainDisplay_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

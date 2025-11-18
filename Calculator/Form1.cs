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

                    // Add to history
                    if (!string.IsNullOrEmpty(originalFormula))
                    {
                        string historyEntry = $"{originalFormula} {operand[1]} = {result}";
                        AddToHistory(historyEntry);
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

        // History functionality
        private List<string> calculationHistory = new List<string>();
        private const int MaxHistoryEntries = 10;

        private void ButtonMenu_Click(object sender, EventArgs e)
        {
            // Create context menu
            ContextMenuStrip contextMenu = new ContextMenuStrip();

            // Add menu items
            ToolStripMenuItem standardItem = new ToolStripMenuItem("Standard");
            ToolStripMenuItem scientificItem = new ToolStripMenuItem("Scientific");
            ToolStripMenuItem programmerItem = new ToolStripMenuItem("Programmer");
            ToolStripMenuItem aboutItem = new ToolStripMenuItem("About");

            standardItem.Click += (s, args) => ShowCalculatorMode("Standard");
            scientificItem.Click += (s, args) => ShowCalculatorMode("Scientific");
            programmerItem.Click += (s, args) => ShowCalculatorMode("Programmer");
            aboutItem.Click += (s, args) => ShowAboutDialog();

            contextMenu.Items.Add(standardItem);
            contextMenu.Items.Add(scientificItem);
            contextMenu.Items.Add(programmerItem);
            contextMenu.Items.Add(new ToolStripSeparator());
            contextMenu.Items.Add(aboutItem);

            // Show menu at button location
            contextMenu.Show(btnMenu, new Point(0, btnMenu.Height));
        }

        private void ButtonHistory_Click(object sender, EventArgs e)
        {
            ShowHistoryDialog();
        }

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

        private void AddToHistory(string calculation)
        {
            calculationHistory.Insert(0, calculation);
            if (calculationHistory.Count > MaxHistoryEntries)
            {
                calculationHistory.RemoveAt(MaxHistoryEntries);
            }
        }

        private void ShowHistoryDialog()
        {
            if (calculationHistory.Count == 0)
            {
                MessageBox.Show("No calculation history available.", "History",
                               MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Form historyForm = new Form()
            {
                Text = "Calculation History",
                Size = new Size(400, 300),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            ListBox historyList = new ListBox()
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10F),
                DataSource = calculationHistory.ToArray()
            };

            Button clearButton = new Button()
            {
                Text = "Clear History",
                Dock = DockStyle.Bottom,
                Height = 40
            };

            clearButton.Click += (s, e) =>
            {
                calculationHistory.Clear();
                historyForm.Close();
            };

            historyForm.Controls.Add(historyList);
            historyForm.Controls.Add(clearButton);
            historyForm.ShowDialog(this);
        }

        private void textMainDisplay_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

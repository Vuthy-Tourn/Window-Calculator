namespace Simple_Windows_Calculator
{
    partial class SimpleCalculator
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimpleCalculator));
            btnBack = new Button();
            btnClear = new Button();
            btnClearEntry = new Button();
            btnPercent = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnInverse = new Button();
            btnSquare = new Button();
            btnSquareRoot = new Button();
            btnDivide = new Button();
            btnNum7 = new Button();
            btnNum8 = new Button();
            btnNum9 = new Button();
            btnMultiply = new Button();
            btnNum4 = new Button();
            btnNum5 = new Button();
            btnNum6 = new Button();
            btnSubtract = new Button();
            btnNum1 = new Button();
            btnNum2 = new Button();
            btnNum3 = new Button();
            btnAdd = new Button();
            btnPlusMinus = new Button();
            btnNum0 = new Button();
            btnDot = new Button();
            btnEqual = new Button();
            textMainDisplay = new TextBox();
            textFormulaDisplay = new TextBox();
            panelMemory = new Panel();
            btnMemoryClear = new Button();
            btnMemoryRecall = new Button();
            btnMemoryAdd = new Button();
            btnMemorySubtract = new Button();
            btnMemoryStore = new Button();
            btnMemoryShow = new Button();
            panelHeader = new Panel();
            btnHistory = new Button();
            btnMenu = new Button();
            lblTitle = new Label();
            tableLayoutPanel1.SuspendLayout();
            panelMemory.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(50, 50, 50);
            btnBack.Dock = DockStyle.Fill;
            btnBack.FlatAppearance.BorderSize = 0;
            btnBack.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            btnBack.FlatStyle = FlatStyle.Flat;
            btnBack.Font = new Font("Segoe UI", 16F);
            btnBack.ForeColor = Color.White;
            btnBack.Location = new Point(597, 3);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(192, 130);
            btnBack.TabIndex = 3;
            btnBack.TabStop = false;
            btnBack.Text = "⌫";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += ButtonBack_Click;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.FromArgb(50, 50, 50);
            btnClear.Dock = DockStyle.Fill;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Segoe UI", 16F);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(399, 3);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(192, 130);
            btnClear.TabIndex = 2;
            btnClear.TabStop = false;
            btnClear.Text = "C";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += ButtonClear_Click;
            // 
            // btnClearEntry
            // 
            btnClearEntry.BackColor = Color.FromArgb(50, 50, 50);
            btnClearEntry.Dock = DockStyle.Fill;
            btnClearEntry.FlatAppearance.BorderSize = 0;
            btnClearEntry.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            btnClearEntry.FlatStyle = FlatStyle.Flat;
            btnClearEntry.Font = new Font("Segoe UI", 16F);
            btnClearEntry.ForeColor = Color.White;
            btnClearEntry.Location = new Point(201, 3);
            btnClearEntry.Name = "btnClearEntry";
            btnClearEntry.Size = new Size(192, 130);
            btnClearEntry.TabIndex = 1;
            btnClearEntry.TabStop = false;
            btnClearEntry.Text = "CE";
            btnClearEntry.UseVisualStyleBackColor = false;
            btnClearEntry.Click += ButtonClearEntry_Click;
            // 
            // btnPercent
            // 
            btnPercent.BackColor = Color.FromArgb(50, 50, 50);
            btnPercent.Dock = DockStyle.Fill;
            btnPercent.FlatAppearance.BorderSize = 0;
            btnPercent.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            btnPercent.FlatStyle = FlatStyle.Flat;
            btnPercent.Font = new Font("Segoe UI", 16F);
            btnPercent.ForeColor = Color.White;
            btnPercent.Location = new Point(3, 3);
            btnPercent.Name = "btnPercent";
            btnPercent.Size = new Size(192, 130);
            btnPercent.TabIndex = 0;
            btnPercent.TabStop = false;
            btnPercent.Text = "%";
            btnPercent.UseVisualStyleBackColor = false;
            btnPercent.Click += ButtonSpecialOperation_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.Controls.Add(btnPercent, 0, 0);
            tableLayoutPanel1.Controls.Add(btnClearEntry, 1, 0);
            tableLayoutPanel1.Controls.Add(btnClear, 2, 0);
            tableLayoutPanel1.Controls.Add(btnBack, 3, 0);
            tableLayoutPanel1.Controls.Add(btnInverse, 0, 1);
            tableLayoutPanel1.Controls.Add(btnSquare, 1, 1);
            tableLayoutPanel1.Controls.Add(btnSquareRoot, 2, 1);
            tableLayoutPanel1.Controls.Add(btnDivide, 3, 1);
            tableLayoutPanel1.Controls.Add(btnNum7, 0, 2);
            tableLayoutPanel1.Controls.Add(btnNum8, 1, 2);
            tableLayoutPanel1.Controls.Add(btnNum9, 2, 2);
            tableLayoutPanel1.Controls.Add(btnMultiply, 3, 2);
            tableLayoutPanel1.Controls.Add(btnNum4, 0, 3);
            tableLayoutPanel1.Controls.Add(btnNum5, 1, 3);
            tableLayoutPanel1.Controls.Add(btnNum6, 2, 3);
            tableLayoutPanel1.Controls.Add(btnSubtract, 3, 3);
            tableLayoutPanel1.Controls.Add(btnNum1, 0, 4);
            tableLayoutPanel1.Controls.Add(btnNum2, 1, 4);
            tableLayoutPanel1.Controls.Add(btnNum3, 2, 4);
            tableLayoutPanel1.Controls.Add(btnAdd, 3, 4);
            tableLayoutPanel1.Controls.Add(btnPlusMinus, 0, 5);
            tableLayoutPanel1.Controls.Add(btnNum0, 1, 5);
            tableLayoutPanel1.Controls.Add(btnDot, 2, 5);
            tableLayoutPanel1.Controls.Add(btnEqual, 3, 5);
            tableLayoutPanel1.Location = new Point(15, 280);
            tableLayoutPanel1.Margin = new Padding(6);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.666F));
            tableLayoutPanel1.Size = new Size(792, 820);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // btnInverse
            // 
            btnInverse.BackColor = Color.FromArgb(50, 50, 50);
            btnInverse.Dock = DockStyle.Fill;
            btnInverse.FlatAppearance.BorderSize = 0;
            btnInverse.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            btnInverse.FlatStyle = FlatStyle.Flat;
            btnInverse.Font = new Font("Segoe UI", 16F);
            btnInverse.ForeColor = Color.White;
            btnInverse.Location = new Point(3, 139);
            btnInverse.Name = "btnInverse";
            btnInverse.Size = new Size(192, 130);
            btnInverse.TabIndex = 4;
            btnInverse.TabStop = false;
            btnInverse.Text = "⅟x";
            btnInverse.UseVisualStyleBackColor = false;
            btnInverse.Click += ButtonSpecialOperation_Click;
            // 
            // btnSquare
            // 
            btnSquare.BackColor = Color.FromArgb(50, 50, 50);
            btnSquare.Dock = DockStyle.Fill;
            btnSquare.FlatAppearance.BorderSize = 0;
            btnSquare.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            btnSquare.FlatStyle = FlatStyle.Flat;
            btnSquare.Font = new Font("Segoe UI", 16F);
            btnSquare.ForeColor = Color.White;
            btnSquare.Location = new Point(201, 139);
            btnSquare.Name = "btnSquare";
            btnSquare.Size = new Size(192, 130);
            btnSquare.TabIndex = 5;
            btnSquare.TabStop = false;
            btnSquare.Text = "x²";
            btnSquare.UseVisualStyleBackColor = false;
            btnSquare.Click += ButtonSpecialOperation_Click;
            // 
            // btnSquareRoot
            // 
            btnSquareRoot.BackColor = Color.FromArgb(50, 50, 50);
            btnSquareRoot.Dock = DockStyle.Fill;
            btnSquareRoot.FlatAppearance.BorderSize = 0;
            btnSquareRoot.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            btnSquareRoot.FlatStyle = FlatStyle.Flat;
            btnSquareRoot.Font = new Font("Segoe UI", 16F);
            btnSquareRoot.ForeColor = Color.White;
            btnSquareRoot.Location = new Point(399, 139);
            btnSquareRoot.Name = "btnSquareRoot";
            btnSquareRoot.Size = new Size(192, 130);
            btnSquareRoot.TabIndex = 6;
            btnSquareRoot.TabStop = false;
            btnSquareRoot.Text = "²√x";
            btnSquareRoot.UseVisualStyleBackColor = false;
            btnSquareRoot.Click += ButtonSpecialOperation_Click;
            // 
            // btnDivide
            // 
            btnDivide.BackColor = Color.FromArgb(50, 50, 50);
            btnDivide.Dock = DockStyle.Fill;
            btnDivide.FlatAppearance.BorderSize = 0;
            btnDivide.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            btnDivide.FlatStyle = FlatStyle.Flat;
            btnDivide.Font = new Font("Segoe UI", 20F);
            btnDivide.ForeColor = Color.White;
            btnDivide.Location = new Point(597, 139);
            btnDivide.Name = "btnDivide";
            btnDivide.Size = new Size(192, 130);
            btnDivide.TabIndex = 7;
            btnDivide.TabStop = false;
            btnDivide.Text = "÷";
            btnDivide.UseVisualStyleBackColor = false;
            btnDivide.Click += ButtonBasicOperation_Click;
            // 
            // btnNum7
            // 
            btnNum7.BackColor = Color.FromArgb(59, 59, 59);
            btnNum7.Dock = DockStyle.Fill;
            btnNum7.FlatAppearance.BorderSize = 0;
            btnNum7.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80);
            btnNum7.FlatStyle = FlatStyle.Flat;
            btnNum7.Font = new Font("Segoe UI", 18F);
            btnNum7.ForeColor = Color.White;
            btnNum7.Location = new Point(3, 275);
            btnNum7.Name = "btnNum7";
            btnNum7.Size = new Size(192, 130);
            btnNum7.TabIndex = 8;
            btnNum7.TabStop = false;
            btnNum7.Text = "7";
            btnNum7.UseVisualStyleBackColor = false;
            btnNum7.Click += ButtonNumbers_Click;
            // 
            // btnNum8
            // 
            btnNum8.BackColor = Color.FromArgb(59, 59, 59);
            btnNum8.Dock = DockStyle.Fill;
            btnNum8.FlatAppearance.BorderSize = 0;
            btnNum8.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80);
            btnNum8.FlatStyle = FlatStyle.Flat;
            btnNum8.Font = new Font("Segoe UI", 18F);
            btnNum8.ForeColor = Color.White;
            btnNum8.Location = new Point(201, 275);
            btnNum8.Name = "btnNum8";
            btnNum8.Size = new Size(192, 130);
            btnNum8.TabIndex = 9;
            btnNum8.TabStop = false;
            btnNum8.Text = "8";
            btnNum8.UseVisualStyleBackColor = false;
            btnNum8.Click += ButtonNumbers_Click;
            // 
            // btnNum9
            // 
            btnNum9.BackColor = Color.FromArgb(59, 59, 59);
            btnNum9.Dock = DockStyle.Fill;
            btnNum9.FlatAppearance.BorderSize = 0;
            btnNum9.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80);
            btnNum9.FlatStyle = FlatStyle.Flat;
            btnNum9.Font = new Font("Segoe UI", 18F);
            btnNum9.ForeColor = Color.White;
            btnNum9.Location = new Point(399, 275);
            btnNum9.Name = "btnNum9";
            btnNum9.Size = new Size(192, 130);
            btnNum9.TabIndex = 10;
            btnNum9.TabStop = false;
            btnNum9.Text = "9";
            btnNum9.UseVisualStyleBackColor = false;
            btnNum9.Click += ButtonNumbers_Click;
            // 
            // btnMultiply
            // 
            btnMultiply.BackColor = Color.FromArgb(50, 50, 50);
            btnMultiply.Dock = DockStyle.Fill;
            btnMultiply.FlatAppearance.BorderSize = 0;
            btnMultiply.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            btnMultiply.FlatStyle = FlatStyle.Flat;
            btnMultiply.Font = new Font("Segoe UI", 20F);
            btnMultiply.ForeColor = Color.White;
            btnMultiply.Location = new Point(597, 275);
            btnMultiply.Name = "btnMultiply";
            btnMultiply.Size = new Size(192, 130);
            btnMultiply.TabIndex = 11;
            btnMultiply.TabStop = false;
            btnMultiply.Text = "×";
            btnMultiply.UseVisualStyleBackColor = false;
            btnMultiply.Click += ButtonBasicOperation_Click;
            // 
            // btnNum4
            // 
            btnNum4.BackColor = Color.FromArgb(59, 59, 59);
            btnNum4.Dock = DockStyle.Fill;
            btnNum4.FlatAppearance.BorderSize = 0;
            btnNum4.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80);
            btnNum4.FlatStyle = FlatStyle.Flat;
            btnNum4.Font = new Font("Segoe UI", 18F);
            btnNum4.ForeColor = Color.White;
            btnNum4.Location = new Point(3, 411);
            btnNum4.Name = "btnNum4";
            btnNum4.Size = new Size(192, 130);
            btnNum4.TabIndex = 12;
            btnNum4.TabStop = false;
            btnNum4.Text = "4";
            btnNum4.UseVisualStyleBackColor = false;
            btnNum4.Click += ButtonNumbers_Click;
            // 
            // btnNum5
            // 
            btnNum5.BackColor = Color.FromArgb(59, 59, 59);
            btnNum5.Dock = DockStyle.Fill;
            btnNum5.FlatAppearance.BorderSize = 0;
            btnNum5.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80);
            btnNum5.FlatStyle = FlatStyle.Flat;
            btnNum5.Font = new Font("Segoe UI", 18F);
            btnNum5.ForeColor = Color.White;
            btnNum5.Location = new Point(201, 411);
            btnNum5.Name = "btnNum5";
            btnNum5.Size = new Size(192, 130);
            btnNum5.TabIndex = 13;
            btnNum5.TabStop = false;
            btnNum5.Text = "5";
            btnNum5.UseVisualStyleBackColor = false;
            btnNum5.Click += ButtonNumbers_Click;
            // 
            // btnNum6
            // 
            btnNum6.BackColor = Color.FromArgb(59, 59, 59);
            btnNum6.Dock = DockStyle.Fill;
            btnNum6.FlatAppearance.BorderSize = 0;
            btnNum6.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80);
            btnNum6.FlatStyle = FlatStyle.Flat;
            btnNum6.Font = new Font("Segoe UI", 18F);
            btnNum6.ForeColor = Color.White;
            btnNum6.Location = new Point(399, 411);
            btnNum6.Name = "btnNum6";
            btnNum6.Size = new Size(192, 130);
            btnNum6.TabIndex = 14;
            btnNum6.TabStop = false;
            btnNum6.Text = "6";
            btnNum6.UseVisualStyleBackColor = false;
            btnNum6.Click += ButtonNumbers_Click;
            // 
            // btnSubtract
            // 
            btnSubtract.BackColor = Color.FromArgb(50, 50, 50);
            btnSubtract.Dock = DockStyle.Fill;
            btnSubtract.FlatAppearance.BorderSize = 0;
            btnSubtract.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            btnSubtract.FlatStyle = FlatStyle.Flat;
            btnSubtract.Font = new Font("Segoe UI", 20F);
            btnSubtract.ForeColor = Color.White;
            btnSubtract.Location = new Point(597, 411);
            btnSubtract.Name = "btnSubtract";
            btnSubtract.Size = new Size(192, 130);
            btnSubtract.TabIndex = 15;
            btnSubtract.TabStop = false;
            btnSubtract.Text = "-";
            btnSubtract.UseVisualStyleBackColor = false;
            btnSubtract.Click += ButtonBasicOperation_Click;
            // 
            // btnNum1
            // 
            btnNum1.BackColor = Color.FromArgb(59, 59, 59);
            btnNum1.Dock = DockStyle.Fill;
            btnNum1.FlatAppearance.BorderSize = 0;
            btnNum1.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80);
            btnNum1.FlatStyle = FlatStyle.Flat;
            btnNum1.Font = new Font("Segoe UI", 18F);
            btnNum1.ForeColor = Color.White;
            btnNum1.Location = new Point(3, 547);
            btnNum1.Name = "btnNum1";
            btnNum1.Size = new Size(192, 130);
            btnNum1.TabIndex = 16;
            btnNum1.TabStop = false;
            btnNum1.Text = "1";
            btnNum1.UseVisualStyleBackColor = false;
            btnNum1.Click += ButtonNumbers_Click;
            // 
            // btnNum2
            // 
            btnNum2.BackColor = Color.FromArgb(59, 59, 59);
            btnNum2.Dock = DockStyle.Fill;
            btnNum2.FlatAppearance.BorderSize = 0;
            btnNum2.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80);
            btnNum2.FlatStyle = FlatStyle.Flat;
            btnNum2.Font = new Font("Segoe UI", 18F);
            btnNum2.ForeColor = Color.White;
            btnNum2.Location = new Point(201, 547);
            btnNum2.Name = "btnNum2";
            btnNum2.Size = new Size(192, 130);
            btnNum2.TabIndex = 17;
            btnNum2.TabStop = false;
            btnNum2.Text = "2";
            btnNum2.UseVisualStyleBackColor = false;
            btnNum2.Click += ButtonNumbers_Click;
            // 
            // btnNum3
            // 
            btnNum3.BackColor = Color.FromArgb(59, 59, 59);
            btnNum3.Dock = DockStyle.Fill;
            btnNum3.FlatAppearance.BorderSize = 0;
            btnNum3.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80);
            btnNum3.FlatStyle = FlatStyle.Flat;
            btnNum3.Font = new Font("Segoe UI", 18F);
            btnNum3.ForeColor = Color.White;
            btnNum3.Location = new Point(399, 547);
            btnNum3.Name = "btnNum3";
            btnNum3.Size = new Size(192, 130);
            btnNum3.TabIndex = 18;
            btnNum3.TabStop = false;
            btnNum3.Text = "3";
            btnNum3.UseVisualStyleBackColor = false;
            btnNum3.Click += ButtonNumbers_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(50, 50, 50);
            btnAdd.Dock = DockStyle.Fill;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(70, 70, 70);
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 20F);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(597, 547);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(192, 130);
            btnAdd.TabIndex = 19;
            btnAdd.TabStop = false;
            btnAdd.Text = "+";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += ButtonBasicOperation_Click;
            // 
            // btnPlusMinus
            // 
            btnPlusMinus.BackColor = Color.FromArgb(59, 59, 59);
            btnPlusMinus.Dock = DockStyle.Fill;
            btnPlusMinus.FlatAppearance.BorderSize = 0;
            btnPlusMinus.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80);
            btnPlusMinus.FlatStyle = FlatStyle.Flat;
            btnPlusMinus.Font = new Font("Segoe UI", 18F);
            btnPlusMinus.ForeColor = Color.White;
            btnPlusMinus.Location = new Point(3, 683);
            btnPlusMinus.Name = "btnPlusMinus";
            btnPlusMinus.Size = new Size(192, 134);
            btnPlusMinus.TabIndex = 20;
            btnPlusMinus.TabStop = false;
            btnPlusMinus.Text = "+/-";
            btnPlusMinus.UseVisualStyleBackColor = false;
            btnPlusMinus.Click += ButtonPlusMinus_Click;
            // 
            // btnNum0
            // 
            btnNum0.BackColor = Color.FromArgb(59, 59, 59);
            btnNum0.Dock = DockStyle.Fill;
            btnNum0.FlatAppearance.BorderSize = 0;
            btnNum0.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80);
            btnNum0.FlatStyle = FlatStyle.Flat;
            btnNum0.Font = new Font("Segoe UI", 18F);
            btnNum0.ForeColor = Color.White;
            btnNum0.Location = new Point(201, 683);
            btnNum0.Name = "btnNum0";
            btnNum0.Size = new Size(192, 134);
            btnNum0.TabIndex = 21;
            btnNum0.TabStop = false;
            btnNum0.Text = "0";
            btnNum0.UseVisualStyleBackColor = false;
            btnNum0.Click += ButtonNumbers_Click;
            // 
            // btnDot
            // 
            btnDot.BackColor = Color.FromArgb(59, 59, 59);
            btnDot.Dock = DockStyle.Fill;
            btnDot.FlatAppearance.BorderSize = 0;
            btnDot.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 80, 80);
            btnDot.FlatStyle = FlatStyle.Flat;
            btnDot.Font = new Font("Segoe UI", 18F);
            btnDot.ForeColor = Color.White;
            btnDot.Location = new Point(399, 683);
            btnDot.Name = "btnDot";
            btnDot.Size = new Size(192, 134);
            btnDot.TabIndex = 22;
            btnDot.TabStop = false;
            btnDot.Text = ".";
            btnDot.UseVisualStyleBackColor = false;
            btnDot.Click += ButtonDot_Click;
            // 
            // btnEqual
            // 
            btnEqual.BackColor = Color.RoyalBlue;
            btnEqual.Dock = DockStyle.Fill;
            btnEqual.FlatAppearance.BorderSize = 0;
            btnEqual.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 103, 192);
            btnEqual.FlatStyle = FlatStyle.Flat;
            btnEqual.Font = new Font("Segoe UI", 20F);
            btnEqual.ForeColor = Color.White;
            btnEqual.Location = new Point(597, 683);
            btnEqual.Name = "btnEqual";
            btnEqual.Size = new Size(192, 134);
            btnEqual.TabIndex = 23;
            btnEqual.TabStop = false;
            btnEqual.Text = "=";
            btnEqual.UseVisualStyleBackColor = false;
            btnEqual.Click += ButtonEqual_Click;
            // 
            // textMainDisplay
            // 
            textMainDisplay.BackColor = Color.FromArgb(32, 32, 32);
            textMainDisplay.BorderStyle = BorderStyle.None;
            textMainDisplay.Font = new Font("Segoe UI", 28.125F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textMainDisplay.ForeColor = Color.White;
            textMainDisplay.Location = new Point(9, 120);
            textMainDisplay.Margin = new Padding(6);
            textMainDisplay.Name = "textMainDisplay";
            textMainDisplay.Size = new Size(792, 100);
            textMainDisplay.TabIndex = 1;
            textMainDisplay.TabStop = false;
            textMainDisplay.Text = "0";
            textMainDisplay.TextAlign = HorizontalAlignment.Right;
            textMainDisplay.TextChanged += textMainDisplay_TextChanged;
            textMainDisplay.MouseDown += MainDisplay_MouseDown;
            // 
            // textFormulaDisplay
            // 
            textFormulaDisplay.BackColor = Color.FromArgb(32, 32, 32);
            textFormulaDisplay.BorderStyle = BorderStyle.None;
            textFormulaDisplay.Enabled = false;
            textFormulaDisplay.Font = new Font("Segoe UI", 14F);
            textFormulaDisplay.ForeColor = Color.FromArgb(150, 150, 150);
            textFormulaDisplay.Location = new Point(12, 76);
            textFormulaDisplay.Margin = new Padding(6);
            textFormulaDisplay.Name = "textFormulaDisplay";
            textFormulaDisplay.ReadOnly = true;
            textFormulaDisplay.Size = new Size(792, 50);
            textFormulaDisplay.TabIndex = 2;
            textFormulaDisplay.TabStop = false;
            textFormulaDisplay.TextAlign = HorizontalAlignment.Right;
            // 
            // panelMemory
            // 
            panelMemory.BackColor = Color.FromArgb(32, 32, 32);
            panelMemory.Controls.Add(btnMemoryClear);
            panelMemory.Controls.Add(btnMemoryRecall);
            panelMemory.Controls.Add(btnMemoryAdd);
            panelMemory.Controls.Add(btnMemorySubtract);
            panelMemory.Controls.Add(btnMemoryStore);
            panelMemory.Controls.Add(btnMemoryShow);
            panelMemory.Location = new Point(15, 220);
            panelMemory.Name = "panelMemory";
            panelMemory.Size = new Size(792, 57);
            panelMemory.TabIndex = 3;
            // 
            // btnMemoryClear
            // 
            btnMemoryClear.BackColor = Color.FromArgb(32, 32, 32);
            btnMemoryClear.FlatAppearance.BorderSize = 0;
            btnMemoryClear.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            btnMemoryClear.FlatStyle = FlatStyle.Flat;
            btnMemoryClear.Font = new Font("Segoe UI", 11F);
            btnMemoryClear.ForeColor = Color.FromArgb(100, 100, 100);
            btnMemoryClear.Location = new Point(5, 7);
            btnMemoryClear.Name = "btnMemoryClear";
            btnMemoryClear.Size = new Size(125, 50);
            btnMemoryClear.TabIndex = 0;
            btnMemoryClear.TabStop = false;
            btnMemoryClear.Text = "MC";
            btnMemoryClear.UseVisualStyleBackColor = false;
            btnMemoryClear.Click += ButtonMemoryClear_Click;
            // 
            // btnMemoryRecall
            // 
            btnMemoryRecall.BackColor = Color.FromArgb(32, 32, 32);
            btnMemoryRecall.FlatAppearance.BorderSize = 0;
            btnMemoryRecall.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            btnMemoryRecall.FlatStyle = FlatStyle.Flat;
            btnMemoryRecall.Font = new Font("Segoe UI", 11F);
            btnMemoryRecall.ForeColor = Color.FromArgb(100, 100, 100);
            btnMemoryRecall.Location = new Point(136, 7);
            btnMemoryRecall.Name = "btnMemoryRecall";
            btnMemoryRecall.Size = new Size(125, 50);
            btnMemoryRecall.TabIndex = 1;
            btnMemoryRecall.TabStop = false;
            btnMemoryRecall.Text = "MR";
            btnMemoryRecall.UseVisualStyleBackColor = false;
            btnMemoryRecall.Click += ButtonMemoryRecall_Click;
            // 
            // btnMemoryAdd
            // 
            btnMemoryAdd.BackColor = Color.FromArgb(32, 32, 32);
            btnMemoryAdd.FlatAppearance.BorderSize = 0;
            btnMemoryAdd.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            btnMemoryAdd.FlatStyle = FlatStyle.Flat;
            btnMemoryAdd.Font = new Font("Segoe UI", 11F);
            btnMemoryAdd.ForeColor = Color.FromArgb(100, 100, 100);
            btnMemoryAdd.Location = new Point(267, 7);
            btnMemoryAdd.Name = "btnMemoryAdd";
            btnMemoryAdd.Size = new Size(125, 50);
            btnMemoryAdd.TabIndex = 2;
            btnMemoryAdd.TabStop = false;
            btnMemoryAdd.Text = "M+";
            btnMemoryAdd.UseVisualStyleBackColor = false;
            btnMemoryAdd.Click += ButtonMemoryAdd_Click;
            // 
            // btnMemorySubtract
            // 
            btnMemorySubtract.BackColor = Color.FromArgb(32, 32, 32);
            btnMemorySubtract.FlatAppearance.BorderSize = 0;
            btnMemorySubtract.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            btnMemorySubtract.FlatStyle = FlatStyle.Flat;
            btnMemorySubtract.Font = new Font("Segoe UI", 11F);
            btnMemorySubtract.ForeColor = Color.FromArgb(100, 100, 100);
            btnMemorySubtract.Location = new Point(398, 7);
            btnMemorySubtract.Name = "btnMemorySubtract";
            btnMemorySubtract.Size = new Size(125, 50);
            btnMemorySubtract.TabIndex = 3;
            btnMemorySubtract.TabStop = false;
            btnMemorySubtract.Text = "M-";
            btnMemorySubtract.UseVisualStyleBackColor = false;
            btnMemorySubtract.Click += ButtonMemorySubtract_Click;
            // 
            // btnMemoryStore
            // 
            btnMemoryStore.BackColor = Color.FromArgb(32, 32, 32);
            btnMemoryStore.FlatAppearance.BorderSize = 0;
            btnMemoryStore.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            btnMemoryStore.FlatStyle = FlatStyle.Flat;
            btnMemoryStore.Font = new Font("Segoe UI", 11F);
            btnMemoryStore.ForeColor = Color.FromArgb(100, 100, 100);
            btnMemoryStore.Location = new Point(529, 7);
            btnMemoryStore.Name = "btnMemoryStore";
            btnMemoryStore.Size = new Size(125, 50);
            btnMemoryStore.TabIndex = 4;
            btnMemoryStore.TabStop = false;
            btnMemoryStore.Text = "MS";
            btnMemoryStore.UseVisualStyleBackColor = false;
            btnMemoryStore.Click += ButtonMemoryStore_Click;
            // 
            // btnMemoryShow
            // 
            btnMemoryShow.BackColor = Color.FromArgb(32, 32, 32);
            btnMemoryShow.FlatAppearance.BorderSize = 0;
            btnMemoryShow.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            btnMemoryShow.FlatStyle = FlatStyle.Flat;
            btnMemoryShow.Font = new Font("Segoe UI", 11F);
            btnMemoryShow.ForeColor = Color.FromArgb(100, 100, 100);
            btnMemoryShow.Location = new Point(660, 7);
            btnMemoryShow.Name = "btnMemoryShow";
            btnMemoryShow.Size = new Size(125, 50);
            btnMemoryShow.TabIndex = 5;
            btnMemoryShow.TabStop = false;
            btnMemoryShow.Text = "M▼";
            btnMemoryShow.UseVisualStyleBackColor = false;
            btnMemoryShow.Click += ButtonMemoryShow_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.FromArgb(32, 32, 32);
            panelHeader.Controls.Add(btnMenu);
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Controls.Add(btnHistory);
            panelHeader.Location = new Point(0, 0);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(815, 76);
            panelHeader.TabIndex = 4;
            // 
            // btnHistory
            // 
            btnHistory.BackColor = Color.Transparent;
            btnHistory.FlatAppearance.BorderSize = 0;
            btnHistory.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            btnHistory.FlatStyle = FlatStyle.Flat;
            btnHistory.Font = new Font("Segoe MDL2 Assets", 16F);
            btnHistory.ForeColor = Color.White;
            btnHistory.Location = new Point(750, 5);
            btnHistory.Name = "btnHistory";
            btnHistory.Size = new Size(60, 68);
            btnHistory.TabIndex = 2;
            btnHistory.Text = "🕐";
            btnHistory.TextAlign = ContentAlignment.TopCenter;
            btnHistory.UseVisualStyleBackColor = false;
            btnHistory.Click += ButtonHistory_Click;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.FromArgb(32, 32, 32);
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatAppearance.MouseOverBackColor = Color.FromArgb(50, 50, 50);
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Segoe MDL2 Assets", 16F);
            btnMenu.ForeColor = Color.White;
            btnMenu.ImageAlign = ContentAlignment.TopCenter;
            btnMenu.Location = new Point(5, 5);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(60, 54);
            btnMenu.TabIndex = 0;
            btnMenu.Text = "☰";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += ButtonMenu_Click;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 13F);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(58, 12);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(160, 47);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Standard";
            // 
            // SimpleCalculator
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(32, 32, 32);
            ClientSize = new Size(815, 1110);
            Controls.Add(panelMemory);
            Controls.Add(panelHeader);
            Controls.Add(textFormulaDisplay);
            Controls.Add(textMainDisplay);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            MaximizeBox = false;
            Name = "SimpleCalculator";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Calculator";
            Load += Form1_Load;
            KeyDown += SimpleCalculator_KeyDown;
            KeyPress += SimpleCalculator_KeyPress;
            tableLayoutPanel1.ResumeLayout(false);
            panelMemory.ResumeLayout(false);
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Header controls
        private Panel panelHeader;
        private Button btnMenu;
        private Label lblTitle;
        private Button btnHistory;

        // Display controls
        private TextBox textMainDisplay;
        private TextBox textFormulaDisplay;

        // Memory panel
        private Panel panelMemory;
        private Button btnMemoryClear;
        private Button btnMemoryRecall;
        private Button btnMemoryAdd;
        private Button btnMemorySubtract;
        private Button btnMemoryStore;
        private Button btnMemoryShow;

        // Button layout
        private TableLayoutPanel tableLayoutPanel1;

        // Row 0 buttons
        private Button btnPercent;
        private Button btnClearEntry;
        private Button btnClear;
        private Button btnBack;

        // Row 1 buttons
        private Button btnInverse;
        private Button btnSquare;
        private Button btnSquareRoot;
        private Button btnDivide;

        // Row 2 buttons
        private Button btnNum7;
        private Button btnNum8;
        private Button btnNum9;
        private Button btnMultiply;

        // Row 3 buttons
        private Button btnNum4;
        private Button btnNum5;
        private Button btnNum6;
        private Button btnSubtract;

        // Row 4 buttons
        private Button btnNum1;
        private Button btnNum2;
        private Button btnNum3;
        private Button btnAdd;

        // Row 5 buttons
        private Button btnPlusMinus;
        private Button btnNum0;
        private Button btnDot;
        private Button btnEqual;
    }
}
namespace Simple_Windows_Calculator
{
    partial class SimpleCalculator
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.textFormulaDisplay = new TextBox();
            this.textMainDisplay = new TextBox();
            this.tableLayoutPanel1 = new TableLayoutPanel();
            this.panelMemory = new Panel();

            this.btnBack = new Button();
            this.btnClear = new Button();
            this.btnClearEntry = new Button();
            this.btnPercent = new Button();
            this.btnNum0 = new Button();
            this.btnPlusMinus = new Button();
            this.btnEqual = new Button();
            this.btnDot = new Button();
            this.btnNum2 = new Button();
            this.btnNum7 = new Button();
            this.btnNum3 = new Button();
            this.btnAdd = new Button();
            this.btnNum6 = new Button();
            this.btnNum5 = new Button();
            this.btnNum1 = new Button();
            this.btnSubtract = new Button();
            this.btnNum9 = new Button();
            this.btnNum8 = new Button();
            this.btnNum4 = new Button();
            this.btnMultiply = new Button();
            this.btnSquare = new Button();
            this.btnInverse = new Button();
            this.btnSquareRoot = new Button();
            this.btnDivide = new Button();

            this.btnMemoryClear = new Button();
            this.btnMemoryRecall = new Button();
            this.btnMemoryAdd = new Button();
            this.btnMemorySubtract = new Button();
            this.btnMemoryStore = new Button();
            this.btnMemoryShow = new Button();

            // --- Form properties ---
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(32, 32, 32);
            this.ClientSize = new Size(815, 1208);
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.Text = "Simple Calculator";
            this.KeyPreview = true;
            this.Load += Form1_Load;
            this.KeyDown += SimpleCalculator_KeyDown;
            this.KeyPress += SimpleCalculator_KeyPress;

            // --- Add controls ---
            this.Controls.Add(textFormulaDisplay);
            this.Controls.Add(textMainDisplay);
            this.Controls.Add(tableLayoutPanel1);
            this.Controls.Add(panelMemory);

            // --- PanelMemory setup ---
            panelMemory.BackColor = Color.FromArgb(32, 32, 32);
            panelMemory.Controls.Add(btnMemoryClear);
            panelMemory.Controls.Add(btnMemoryRecall);
            panelMemory.Controls.Add(btnMemoryAdd);
            panelMemory.Controls.Add(btnMemorySubtract);
            panelMemory.Controls.Add(btnMemoryStore);
            panelMemory.Controls.Add(btnMemoryShow);
            panelMemory.Location = new Point(5, 220);
            panelMemory.Size = new Size(680, 48);

            // --- TableLayoutPanel setup ---
            tableLayoutPanel1.ColumnCount = 4;
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.Size = new Size(792, 895);
            tableLayoutPanel1.Location = new Point(15, 309);
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 16.66F));

            // --- Displays ---
            textFormulaDisplay.BackColor = Color.FromArgb(32, 32, 32);
            textFormulaDisplay.BorderStyle = BorderStyle.None;
            textFormulaDisplay.ForeColor = Color.White;
            textFormulaDisplay.Font = new Font("Segoe UI Semibold", 24F, FontStyle.Bold);
            textFormulaDisplay.Size = new Size(792, 86);
            textFormulaDisplay.Location = new Point(15, 15);
            textFormulaDisplay.ReadOnly = true;
            textFormulaDisplay.TextAlign = HorizontalAlignment.Right;

            textMainDisplay.BackColor = Color.FromArgb(32, 32, 32);
            textMainDisplay.BorderStyle = BorderStyle.None;
            textMainDisplay.ForeColor = Color.White;
            textMainDisplay.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            textMainDisplay.Size = new Size(792, 128);
            textMainDisplay.Location = new Point(9, 152);
            textMainDisplay.Text = "0";
            textMainDisplay.TextAlign = HorizontalAlignment.Right;
        }

        #endregion

        // --- Controls declarations ---
        private TextBox textFormulaDisplay;
        private TextBox textMainDisplay;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel panelMemory;

        private Button btnBack;
        private Button btnClear;
        private Button btnClearEntry;
        private Button btnPercent;
        private Button btnNum0;
        private Button btnPlusMinus;
        private Button btnEqual;
        private Button btnDot;
        private Button btnNum2;
        private Button btnNum7;
        private Button btnNum3;
        private Button btnAdd;
        private Button btnNum6;
        private Button btnNum5;
        private Button btnNum1;
        private Button btnSubtract;
        private Button btnNum9;
        private Button btnNum8;
        private Button btnNum4;
        private Button btnMultiply;
        private Button btnSquare;
        private Button btnInverse;
        private Button btnSquareRoot;
        private Button btnDivide;

        private Button btnMemoryClear;
        private Button btnMemoryRecall;
        private Button btnMemoryAdd;
        private Button btnMemorySubtract;
        private Button btnMemoryStore;
        private Button btnMemoryShow;
    }
}

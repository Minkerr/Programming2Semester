namespace Calculator;

partial class CalculatorForm
{
    private Button addButton;
    private Button changeSignButton;
    private Button clearButton;
    private Label display;
    private Button[] numberButton;
    private Button divideButton;
    private Button equalButton;
    private Button multiplyButton;
    private Button subtractButton;
    private Button dotButton;
    private TableLayoutPanel tableLayoutPanel;

    /// <summary>
    /// Set up all buttons on the form
    /// </summary>
    private void SetUpButtons()
    {
        tableLayoutPanel = new TableLayoutPanel();
        display = new Label();
        numberButton = new Button[10];
        for (int i = 0; i < 10; i++)
        {
            numberButton[i] = new Button();
        }
        dotButton = new Button();
        divideButton = new Button();
        multiplyButton = new Button();
        subtractButton = new Button();
        addButton = new Button();
        equalButton = new Button();
        clearButton = new Button();
        changeSignButton = new Button();
        var defaultFont = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
        
        // calculator form
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(320, 480);
        MinimumSize = new Size(200, 400);
        Controls.Add(tableLayoutPanel);
        Text = "Calculator";
        
        // tableLayoutPanel
        tableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        tableLayoutPanel.BackColor = Color.Gray;
        tableLayoutPanel.ColumnCount = 4;
        tableLayoutPanel.RowCount = 6;
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
        tableLayoutPanel.Controls.Add(display, 0, 0);
        tableLayoutPanel.Controls.Add(numberButton[0], 1, 5);
        tableLayoutPanel.Controls.Add(numberButton[1], 0, 4);
        tableLayoutPanel.Controls.Add(numberButton[2], 1, 4);
        tableLayoutPanel.Controls.Add(numberButton[3], 2, 4);
        tableLayoutPanel.Controls.Add(numberButton[4], 0, 3);
        tableLayoutPanel.Controls.Add(numberButton[5], 1, 3);
        tableLayoutPanel.Controls.Add(numberButton[6], 2, 3);
        tableLayoutPanel.Controls.Add(numberButton[7], 0, 2);
        tableLayoutPanel.Controls.Add(numberButton[8], 1, 2);
        tableLayoutPanel.Controls.Add(numberButton[9], 2, 2);
        tableLayoutPanel.Controls.Add(divideButton, 3, 1);
        tableLayoutPanel.Controls.Add(multiplyButton, 3, 2);
        tableLayoutPanel.Controls.Add(subtractButton, 3, 3);
        tableLayoutPanel.Controls.Add(addButton, 3, 4);
        tableLayoutPanel.Controls.Add(equalButton, 3, 5);
        tableLayoutPanel.Controls.Add(clearButton, 0, 1);
        tableLayoutPanel.Controls.Add(dotButton, 2, 5);
        tableLayoutPanel.Controls.Add(changeSignButton, 0, 5);
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 26.9027157F));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 14.6194534F));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 14.6194534F));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 14.6194534F));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 14.6194534F));
        tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 14.6194534F));
        tableLayoutPanel.Size = new Size(320, 480);
        
        // display
        display.AutoSize = true;
        display.BackColor = Color.Gray;
        display.ForeColor = Color.Transparent;
        tableLayoutPanel.SetColumnSpan(display, 4);
        display.Dock = DockStyle.Fill;
        display.Font = new Font("Segoe UI", 30F, FontStyle.Regular, GraphicsUnit.Point);
        display.TextAlign = ContentAlignment.BottomRight;
        
        // zero button
        numberButton[0].BackColor = Color.Orange;
        numberButton[0].ForeColor = Color.Transparent;
        numberButton[0].Dock = DockStyle.Fill;
        numberButton[0].Font = defaultFont;
        numberButton[0].Text = "0";
        numberButton[0].Click += OnNumberButtonClick;
        
        // one button
        numberButton[1].BackColor = Color.Orange;
        numberButton[1].ForeColor = Color.Transparent;
        numberButton[1].Dock = DockStyle.Fill;
        numberButton[1].Font = defaultFont;
        numberButton[1].Text = "1";
        numberButton[1].Click += OnNumberButtonClick;
        
        // two button
        numberButton[2].BackColor = Color.Orange;
        numberButton[2].ForeColor = Color.Transparent;
        numberButton[2].Dock = DockStyle.Fill;
        numberButton[2].Font = defaultFont;
        numberButton[2].Text = "2";
        numberButton[2].Click += OnNumberButtonClick;
        
        // three button
        numberButton[3].BackColor = Color.Orange;
        numberButton[3].ForeColor = Color.Transparent;
        numberButton[3].Dock = DockStyle.Fill;
        numberButton[3].Font = defaultFont;
        numberButton[3].Text = "3";
        numberButton[3].Click += OnNumberButtonClick;
        
        // four button
        numberButton[4].BackColor = Color.Orange;
        numberButton[4].ForeColor = Color.Transparent;
        numberButton[4].Dock = DockStyle.Fill;
        numberButton[4].Font = defaultFont;
        numberButton[4].Text = "4";
        numberButton[4].Click += OnNumberButtonClick;
        
        // five button
        numberButton[5].BackColor = Color.Orange;
        numberButton[5].ForeColor = Color.Transparent;
        numberButton[5].Dock = DockStyle.Fill;
        numberButton[5].Font = defaultFont;
        numberButton[5].Text = "5";
        numberButton[5].Click += OnNumberButtonClick;
        
        // six button
        numberButton[6].BackColor = Color.Orange;
        numberButton[6].ForeColor = Color.Transparent;
        numberButton[6].Dock = DockStyle.Fill;
        numberButton[6].Font = defaultFont;
        numberButton[6].Text = "6";
        numberButton[6].Click += OnNumberButtonClick;
        
        // seven button
        numberButton[7].BackColor = Color.Orange;
        numberButton[7].ForeColor = Color.Transparent;
        numberButton[7].Dock = DockStyle.Fill;
        numberButton[7].Font = defaultFont;
        numberButton[7].Text = "7";
        numberButton[7].Click += OnNumberButtonClick;
        
        // eight button
        numberButton[8].BackColor = Color.Orange;
        numberButton[8].ForeColor = Color.Transparent;
        numberButton[8].Dock = DockStyle.Fill;
        numberButton[8].Font = defaultFont;
        numberButton[8].Text = "8";
        numberButton[8].Click += OnNumberButtonClick;
        
        // nine button
        numberButton[9].BackColor = Color.Orange;
        numberButton[9].ForeColor = Color.Transparent;
        numberButton[9].Dock = DockStyle.Fill;
        numberButton[9].Font = defaultFont;
        numberButton[9].Text = "9";
        numberButton[9].Click += OnNumberButtonClick;
        
        // divide button
        divideButton.BackColor = Color.Orange;
        divideButton.ForeColor = Color.Transparent;
        divideButton.Dock = DockStyle.Fill;
        divideButton.Font = defaultFont;
        divideButton.Text = "÷";
        divideButton.Click += OnOperationButtonClick;
        
        // multiply button
        multiplyButton.BackColor = Color.Orange;
        multiplyButton.ForeColor = Color.Transparent;
        multiplyButton.Dock = DockStyle.Fill;
        multiplyButton.Font = defaultFont;
        multiplyButton.Text = "×";
        multiplyButton.Click += OnOperationButtonClick;
        
        // subtract button
        subtractButton.BackColor = Color.Orange;
        subtractButton.ForeColor = Color.Transparent;
        subtractButton.Dock = DockStyle.Fill;
        subtractButton.Font = defaultFont;
        subtractButton.Text = "-";
        subtractButton.Click += OnOperationButtonClick;
        
        // add button
        addButton.BackColor = Color.Orange;
        addButton.ForeColor = Color.Transparent;
        addButton.Dock = DockStyle.Fill;
        addButton.Font = defaultFont;
        addButton.Text = "+";
        addButton.Click += OnOperationButtonClick;
        
        // equal button
        equalButton.BackColor = Color.Coral;
        equalButton.ForeColor = Color.Transparent;
        equalButton.Dock = DockStyle.Fill;
        equalButton.Font = defaultFont;
        equalButton.Text = "=";
        equalButton.Click += OnEqualButtonClick;
        
        // clear button
        clearButton.BackColor = Color.Orange;
        clearButton.ForeColor = Color.Transparent;
        tableLayoutPanel.SetColumnSpan(clearButton, 3);
        clearButton.Dock = DockStyle.Fill;
        clearButton.Font = defaultFont;
        clearButton.Text = "C";
        clearButton.Click += OnClearButtonClick;
        
        // dot button
        dotButton.BackColor = Color.Orange;
        dotButton.ForeColor = Color.Transparent;
        dotButton.Dock = DockStyle.Fill;
        dotButton.Font = defaultFont;
        dotButton.Text = ",";
        dotButton.Click += OnDotButtonClick;
        
        // change sign button
        changeSignButton.BackColor = Color.Orange;
        changeSignButton.ForeColor = Color.Transparent;
        changeSignButton.Dock = DockStyle.Fill;
        changeSignButton.Font = defaultFont;
        changeSignButton.Text = "+/-";
        changeSignButton.Click += OnChangeSignButtonClick;
    }
}
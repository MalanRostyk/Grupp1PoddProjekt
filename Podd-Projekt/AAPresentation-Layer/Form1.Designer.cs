namespace AAPresentation_Layer;

partial class Form1
{
    private Button btnAdd;
    private ComboBox cmbCategory;
    private TextBox txtUrl;
    private ListBox lstFeeds;
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        button1 = new Button();
        comboBox1 = new ComboBox();
        textBox1 = new TextBox();
        listBox1 = new ListBox();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(434, 28);
        button1.Name = "button1";
        button1.Size = new Size(94, 29);
        button1.TabIndex = 0;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        // 
        // comboBox1
        // 
        comboBox1.FormattingEnabled = true;
        comboBox1.Location = new Point(12, 325);
        comboBox1.Name = "comboBox1";
        comboBox1.Size = new Size(151, 28);
        comboBox1.TabIndex = 1;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(50, 28);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(268, 27);
        textBox1.TabIndex = 2;
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.Location = new Point(12, 75);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(551, 244);
        listBox1.TabIndex = 3;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(listBox1);
        Controls.Add(textBox1);
        Controls.Add(comboBox1);
        Controls.Add(button1);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    
}

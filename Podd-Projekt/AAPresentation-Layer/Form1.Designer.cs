namespace AAPresentation_Layer;

partial class Form1
{
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
        listBox1 = new ListBox();
        button1 = new Button();
        textBox1 = new TextBox();
        SuspendLayout();
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.Location = new Point(67, 29);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(150, 104);
        listBox1.TabIndex = 0;
        // 
        // button1
        // 
        button1.Location = new Point(239, 239);
        button1.Name = "button1";
        button1.Size = new Size(94, 29);
        button1.TabIndex = 1;
        button1.Text = "button1";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(163, 206);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(263, 27);
        textBox1.TabIndex = 2;
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1275, 450);
        Controls.Add(textBox1);
        Controls.Add(button1);
        Controls.Add(listBox1);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private ListBox listBox1;
    private Button button1;
    private TextBox textBox1;
}

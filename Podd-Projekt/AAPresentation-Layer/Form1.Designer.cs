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
        button1 = new Button();
        button2 = new Button();
        listBox1 = new ListBox();
        textBox1 = new TextBox();
        textBox2 = new TextBox();
        textBox3 = new TextBox();
        textBox4 = new TextBox();
        textBox6 = new TextBox();
        textBox7 = new TextBox();
        textBox8 = new TextBox();
        textBox9 = new TextBox();
        textBox5 = new TextBox();
        label1 = new Label();
        listBox2 = new ListBox();
        button3 = new Button();
        label2 = new Label();
        button4 = new Button();
        label3 = new Label();
        SuspendLayout();
        // 
        // button1
        // 
        button1.Location = new Point(86, 419);
        button1.Name = "button1";
        button1.Size = new Size(94, 29);
        button1.TabIndex = 9;
        button1.Text = "Add";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // button2
        // 
        button2.Location = new Point(86, 143);
        button2.Name = "button2";
        button2.Size = new Size(94, 29);
        button2.TabIndex = 11;
        button2.Text = "button2";
        button2.UseVisualStyleBackColor = true;
        button2.Click += button2_Click;
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.Location = new Point(217, 110);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(150, 104);
        listBox1.TabIndex = 12;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(86, 44);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(125, 27);
        textBox1.TabIndex = 13;
        // 
        // textBox2
        // 
        textBox2.Location = new Point(86, 77);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(125, 27);
        textBox2.TabIndex = 14;
        // 
        // textBox3
        // 
        textBox3.Location = new Point(86, 110);
        textBox3.Name = "textBox3";
        textBox3.Size = new Size(125, 27);
        textBox3.TabIndex = 15;
        // 
        // textBox4
        // 
        textBox4.Location = new Point(86, 221);
        textBox4.Name = "textBox4";
        textBox4.Size = new Size(125, 27);
        textBox4.TabIndex = 16;
        // 
        // textBox6
        // 
        textBox6.Location = new Point(86, 287);
        textBox6.Name = "textBox6";
        textBox6.Size = new Size(125, 27);
        textBox6.TabIndex = 18;
        // 
        // textBox7
        // 
        textBox7.Location = new Point(86, 320);
        textBox7.Name = "textBox7";
        textBox7.Size = new Size(125, 27);
        textBox7.TabIndex = 19;
        // 
        // textBox8
        // 
        textBox8.Location = new Point(86, 353);
        textBox8.Name = "textBox8";
        textBox8.Size = new Size(125, 27);
        textBox8.TabIndex = 20;
        // 
        // textBox9
        // 
        textBox9.Location = new Point(86, 386);
        textBox9.Name = "textBox9";
        textBox9.Size = new Size(125, 27);
        textBox9.TabIndex = 21;
        // 
        // textBox5
        // 
        textBox5.Location = new Point(86, 254);
        textBox5.Name = "textBox5";
        textBox5.Size = new Size(125, 27);
        textBox5.TabIndex = 22;
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(100, 21);
        label1.Name = "label1";
        label1.Size = new Size(50, 20);
        label1.TabIndex = 23;
        label1.Text = "label1";
        // 
        // listBox2
        // 
        listBox2.FormattingEnabled = true;
        listBox2.Location = new Point(450, 9);
        listBox2.Name = "listBox2";
        listBox2.Size = new Size(813, 284);
        listBox2.TabIndex = 24;
        // 
        // button3
        // 
        button3.Location = new Point(186, 419);
        button3.Name = "button3";
        button3.Size = new Size(94, 29);
        button3.TabIndex = 25;
        button3.Text = "Update";
        button3.UseVisualStyleBackColor = true;
        button3.Click += button3_Click;
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(12, 79);
        label2.Name = "label2";
        label2.Size = new Size(74, 20);
        label2.TabIndex = 26;
        label2.Text = "PodName";
        // 
        // button4
        // 
        button4.Location = new Point(217, 43);
        button4.Name = "button4";
        button4.Size = new Size(94, 29);
        button4.TabIndex = 27;
        button4.Text = "Delete";
        button4.UseVisualStyleBackColor = true;
        button4.Click += button4_Click;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Location = new Point(58, 47);
        label3.Name = "label3";
        label3.Size = new Size(22, 20);
        label3.TabIndex = 28;
        label3.Text = "Id";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(8F, 20F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(1275, 450);
        Controls.Add(label3);
        Controls.Add(button4);
        Controls.Add(label2);
        Controls.Add(button3);
        Controls.Add(listBox2);
        Controls.Add(label1);
        Controls.Add(textBox5);
        Controls.Add(textBox9);
        Controls.Add(textBox8);
        Controls.Add(textBox7);
        Controls.Add(textBox6);
        Controls.Add(textBox4);
        Controls.Add(textBox3);
        Controls.Add(textBox2);
        Controls.Add(textBox1);
        Controls.Add(listBox1);
        Controls.Add(button2);
        Controls.Add(button1);
        Name = "Form1";
        Text = "Form1";
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion
    private Button button1;
    private Button button2;
    private ListBox listBox1;
    private TextBox textBox1;
    private TextBox textBox2;
    private TextBox textBox3;
    private TextBox textBox4;
    private TextBox textBox6;
    private TextBox textBox7;
    private TextBox textBox8;
    private TextBox textBox9;
    private TextBox textBox5;
    private Label label1;
    private ListBox listBox2;
    private Button button3;
    private Label label2;
    private Button button4;
    private Label label3;
}

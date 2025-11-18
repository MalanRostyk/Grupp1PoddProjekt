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
        lbSearchedResults = new ListBox();
        btnSearch = new Button();
        tbLink = new TextBox();
        rtbSearchedPodInfo = new RichTextBox();
        label1 = new Label();
        label2 = new Label();
        tabControl1 = new TabControl();
        tabPage1 = new TabPage();
        tbeEmptyName = new Label();
        btnSave = new Button();
        label6 = new Label();
        tbNewFeedName = new TextBox();
        label5 = new Label();
        tabPage2 = new TabPage();
        label4 = new Label();
        listBox1 = new ListBox();
        tabPage3 = new TabPage();
        label3 = new Label();
        tbUpdateCategory = new TextBox();
        tbUpdateName = new TextBox();
        lblToUpdateCategory = new Label();
        lblToUpdateName = new Label();
        lblDisplayLink = new Label();
        lblToUpdate = new Label();
        tabPage4 = new TabPage();
        tabPage5 = new TabPage();
        button4 = new Button();
        textBox2 = new TextBox();
        label7 = new Label();
        label11 = new Label();
        tabControl1.SuspendLayout();
        tabPage1.SuspendLayout();
        tabPage2.SuspendLayout();
        tabPage3.SuspendLayout();
        tabPage5.SuspendLayout();
        SuspendLayout();
        // 
        // lbSearchedResults
        // 
        lbSearchedResults.FormattingEnabled = true;
        lbSearchedResults.Location = new Point(17, 32);
        lbSearchedResults.Margin = new Padding(4);
        lbSearchedResults.Name = "lbSearchedResults";
        lbSearchedResults.Size = new Size(467, 284);
        lbSearchedResults.TabIndex = 0;
        lbSearchedResults.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        // 
        // btnSearch
        // 
        btnSearch.BackColor = Color.DarkSlateGray;
        btnSearch.FlatStyle = FlatStyle.Popup;
        btnSearch.ForeColor = SystemColors.GradientActiveCaption;
        btnSearch.Location = new Point(420, 359);
        btnSearch.Margin = new Padding(4);
        btnSearch.Name = "btnSearch";
        btnSearch.Size = new Size(129, 41);
        btnSearch.TabIndex = 1;
        btnSearch.Text = "Search";
        btnSearch.UseVisualStyleBackColor = false;
        btnSearch.Click += button1_Click;
        // 
        // tbLink
        // 
        tbLink.BackColor = SystemColors.ButtonHighlight;
        tbLink.Location = new Point(17, 362);
        tbLink.Margin = new Padding(4);
        tbLink.Name = "tbLink";
        tbLink.Size = new Size(395, 34);
        tbLink.TabIndex = 2;
        // 
        // rtbSearchedPodInfo
        // 
        rtbSearchedPodInfo.BackColor = SystemColors.ButtonHighlight;
        rtbSearchedPodInfo.Location = new Point(557, 32);
        rtbSearchedPodInfo.Margin = new Padding(4);
        rtbSearchedPodInfo.Name = "rtbSearchedPodInfo";
        rtbSearchedPodInfo.ReadOnly = true;
        rtbSearchedPodInfo.Size = new Size(497, 284);
        rtbSearchedPodInfo.TabIndex = 4;
        rtbSearchedPodInfo.Text = "";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(17, 330);
        label1.Margin = new Padding(4, 0, 4, 0);
        label1.Name = "label1";
        label1.Size = new Size(348, 28);
        label1.TabIndex = 5;
        label1.Text = "Enter Link To RSS Feed to search from: ";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(551, 0);
        label2.Margin = new Padding(4, 0, 4, 0);
        label2.Name = "label2";
        label2.Size = new Size(218, 28);
        label2.TabIndex = 6;
        label2.Text = "About selected podcast";
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabPage1);
        tabControl1.Controls.Add(tabPage2);
        tabControl1.Controls.Add(tabPage3);
        tabControl1.Controls.Add(tabPage4);
        tabControl1.Controls.Add(tabPage5);
        tabControl1.Location = new Point(12, -2);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(1078, 511);
        tabControl1.TabIndex = 7;
        // 
        // tabPage1
        // 
        tabPage1.Controls.Add(tbeEmptyName);
        tabPage1.Controls.Add(btnSave);
        tabPage1.Controls.Add(label6);
        tabPage1.Controls.Add(tbNewFeedName);
        tabPage1.Controls.Add(label5);
        tabPage1.Controls.Add(rtbSearchedPodInfo);
        tabPage1.Controls.Add(label1);
        tabPage1.Controls.Add(tbLink);
        tabPage1.Controls.Add(label2);
        tabPage1.Controls.Add(lbSearchedResults);
        tabPage1.Controls.Add(btnSearch);
        tabPage1.Location = new Point(4, 37);
        tabPage1.Name = "tabPage1";
        tabPage1.Padding = new Padding(3);
        tabPage1.Size = new Size(1070, 470);
        tabPage1.TabIndex = 0;
        tabPage1.Text = "Start";
        tabPage1.UseVisualStyleBackColor = true;
        // 
        // tbeEmptyName
        // 
        tbeEmptyName.AutoSize = true;
        tbeEmptyName.Location = new Point(557, 435);
        tbeEmptyName.Name = "tbeEmptyName";
        tbeEmptyName.Size = new Size(0, 28);
        tbeEmptyName.TabIndex = 12;
        // 
        // btnSave
        // 
        btnSave.BackColor = Color.DarkSlateGray;
        btnSave.FlatStyle = FlatStyle.Popup;
        btnSave.ForeColor = SystemColors.GradientActiveCaption;
        btnSave.Location = new Point(420, 429);
        btnSave.Margin = new Padding(4);
        btnSave.Name = "btnSave";
        btnSave.Size = new Size(129, 41);
        btnSave.TabIndex = 11;
        btnSave.Text = "Save";
        btnSave.UseVisualStyleBackColor = false;
        btnSave.Click += btnSave_Click;
        // 
        // label6
        // 
        label6.AutoSize = true;
        label6.Location = new Point(17, 3);
        label6.Margin = new Padding(4, 0, 4, 0);
        label6.Name = "label6";
        label6.Size = new Size(136, 28);
        label6.TabIndex = 10;
        label6.Text = "Search Result: ";
        // 
        // tbNewFeedName
        // 
        tbNewFeedName.BackColor = SystemColors.ButtonHighlight;
        tbNewFeedName.Location = new Point(17, 432);
        tbNewFeedName.Margin = new Padding(4);
        tbNewFeedName.Name = "tbNewFeedName";
        tbNewFeedName.Size = new Size(395, 34);
        tbNewFeedName.TabIndex = 9;
        // 
        // label5
        // 
        label5.AutoSize = true;
        label5.Location = new Point(17, 400);
        label5.Margin = new Padding(4, 0, 4, 0);
        label5.Name = "label5";
        label5.Size = new Size(319, 28);
        label5.TabIndex = 8;
        label5.Text = "Enter category to save RSS Feed as:";
        // 
        // tabPage2
        // 
        tabPage2.Controls.Add(label4);
        tabPage2.Controls.Add(listBox1);
        tabPage2.Location = new Point(4, 37);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new Padding(3);
        tabPage2.Size = new Size(1070, 470);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "Register";
        tabPage2.UseVisualStyleBackColor = true;
        // 
        // label4
        // 
        label4.AutoSize = true;
        label4.Location = new Point(6, 27);
        label4.Name = "label4";
        label4.Size = new Size(211, 28);
        label4.TabIndex = 1;
        label4.Text = "My save Podcast Feeds";
        // 
        // listBox1
        // 
        listBox1.FormattingEnabled = true;
        listBox1.Location = new Point(6, 68);
        listBox1.Name = "listBox1";
        listBox1.Size = new Size(437, 396);
        listBox1.TabIndex = 0;
        // 
        // tabPage3
        // 
        tabPage3.Controls.Add(label3);
        tabPage3.Controls.Add(tbUpdateCategory);
        tabPage3.Controls.Add(tbUpdateName);
        tabPage3.Controls.Add(lblToUpdateCategory);
        tabPage3.Controls.Add(lblToUpdateName);
        tabPage3.Controls.Add(lblDisplayLink);
        tabPage3.Controls.Add(lblToUpdate);
        tabPage3.Location = new Point(4, 37);
        tabPage3.Name = "tabPage3";
        tabPage3.Size = new Size(1070, 470);
        tabPage3.TabIndex = 2;
        tabPage3.Text = "Update";
        tabPage3.UseVisualStyleBackColor = true;
        // 
        // label3
        // 
        label3.AutoSize = true;
        label3.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
        label3.Location = new Point(31, 27);
        label3.Name = "label3";
        label3.Size = new Size(255, 38);
        label3.TabIndex = 6;
        label3.Text = "Update a PodFeed";
        // 
        // tbUpdateCategory
        // 
        tbUpdateCategory.Location = new Point(129, 288);
        tbUpdateCategory.Name = "tbUpdateCategory";
        tbUpdateCategory.Size = new Size(327, 34);
        tbUpdateCategory.TabIndex = 5;
        // 
        // tbUpdateName
        // 
        tbUpdateName.Location = new Point(129, 212);
        tbUpdateName.Name = "tbUpdateName";
        tbUpdateName.Size = new Size(327, 34);
        tbUpdateName.TabIndex = 4;
        // 
        // lblToUpdateCategory
        // 
        lblToUpdateCategory.AutoSize = true;
        lblToUpdateCategory.Location = new Point(31, 288);
        lblToUpdateCategory.Name = "lblToUpdateCategory";
        lblToUpdateCategory.Size = new Size(101, 28);
        lblToUpdateCategory.TabIndex = 3;
        lblToUpdateCategory.Text = "Category: ";
        // 
        // lblToUpdateName
        // 
        lblToUpdateName.AutoSize = true;
        lblToUpdateName.Location = new Point(64, 212);
        lblToUpdateName.Name = "lblToUpdateName";
        lblToUpdateName.Size = new Size(68, 28);
        lblToUpdateName.TabIndex = 2;
        lblToUpdateName.Text = "Name:";
        // 
        // lblDisplayLink
        // 
        lblDisplayLink.AutoSize = true;
        lblDisplayLink.Location = new Point(80, 146);
        lblDisplayLink.Name = "lblDisplayLink";
        lblDisplayLink.Size = new Size(231, 28);
        lblDisplayLink.TabIndex = 1;
        lblDisplayLink.Text = "Link: (Glöm ej += länken)";
        // 
        // lblToUpdate
        // 
        lblToUpdate.AutoSize = true;
        lblToUpdate.Location = new Point(98, 91);
        lblToUpdate.Name = "lblToUpdate";
        lblToUpdate.Size = new Size(213, 28);
        lblToUpdate.TabIndex = 0;
        lblToUpdate.Text = "Id: (Glöm ej += länken)";
        // 
        // tabPage4
        // 
        tabPage4.Location = new Point(4, 37);
        tabPage4.Name = "tabPage4";
        tabPage4.Size = new Size(1070, 470);
        tabPage4.TabIndex = 3;
        tabPage4.Text = "Delete";
        tabPage4.UseVisualStyleBackColor = true;
        // 
        // tabPage5
        // 
        tabPage5.Controls.Add(label11);
        tabPage5.Controls.Add(label7);
        tabPage5.Controls.Add(button4);
        tabPage5.Controls.Add(textBox2);
        tabPage5.Location = new Point(4, 37);
        tabPage5.Name = "tabPage5";
        tabPage5.Size = new Size(1070, 470);
        tabPage5.TabIndex = 4;
        tabPage5.Text = "Category";
        tabPage5.UseVisualStyleBackColor = true;
        // 
        // button4
        // 
        button4.BackColor = Color.DarkSlateGray;
        button4.FlatStyle = FlatStyle.Popup;
        button4.ForeColor = SystemColors.GradientActiveCaption;
        button4.Location = new Point(468, 56);
        button4.Margin = new Padding(4);
        button4.Name = "button4";
        button4.Size = new Size(129, 41);
        button4.TabIndex = 19;
        button4.Text = "Create";
        button4.UseVisualStyleBackColor = false;
        // 
        // textBox2
        // 
        textBox2.BackColor = SystemColors.ButtonHighlight;
        textBox2.Location = new Point(127, 56);
        textBox2.Margin = new Padding(4);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(333, 34);
        textBox2.TabIndex = 18;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Font = new Font("Segoe UI", 13.8F);
        label7.Location = new Point(55, 21);
        label7.Margin = new Padding(4, 0, 4, 0);
        label7.Name = "label7";
        label7.Size = new Size(226, 31);
        label7.TabIndex = 21;
        label7.Text = "Create new Category";
        // 
        // label11
        // 
        label11.AutoSize = true;
        label11.Location = new Point(55, 59);
        label11.Margin = new Padding(4, 0, 4, 0);
        label11.Name = "label11";
        label11.Size = new Size(64, 28);
        label11.TabIndex = 24;
        label11.Text = "Name";
        // 
        // Form1
        // 
        AutoScaleDimensions = new SizeF(11F, 28F);
        AutoScaleMode = AutoScaleMode.Font;
        BackColor = Color.Gray;
        BackgroundImageLayout = ImageLayout.None;
        ClientSize = new Size(1114, 521);
        Controls.Add(tabControl1);
        Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
        ForeColor = SystemColors.ActiveCaptionText;
        Margin = new Padding(4);
        Name = "Form1";
        Text = "Form1";
        Load += Form1_Load;
        tabControl1.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        tabPage1.PerformLayout();
        tabPage2.ResumeLayout(false);
        tabPage2.PerformLayout();
        tabPage3.ResumeLayout(false);
        tabPage3.PerformLayout();
        tabPage5.ResumeLayout(false);
        tabPage5.PerformLayout();
        ResumeLayout(false);
    }

    #endregion

    private ListBox lbSearchedResults;
    private Button btnSearch;
    private TextBox tbLink;
    private RichTextBox rtbSearchedPodInfo;
    private Label label1;
    private Label label2;
    private TabControl tabControl1;
    private TabPage tabPage1;
    private TabPage tabPage2;
    private TabPage tabPage3;
    private TabPage tabPage4;
    private Label lblToUpdateCategory;
    private Label lblToUpdateName;
    private Label lblDisplayLink;
    private Label lblToUpdate;
    private TextBox tbUpdateCategory;
    private TextBox tbUpdateName;
    private Label label3;
    private Label label4;
    private ListBox listBox1;
    private Label label5;
    private TextBox tbNewFeedName;
    private Label label6;
    private Button btnSave;
    private Label tbeEmptyName;
    private TabPage tabPage5;
    private Label label11;
    private Label label7;
    private Button button4;
    private TextBox textBox2;
}

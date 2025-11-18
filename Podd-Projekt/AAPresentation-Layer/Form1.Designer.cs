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
        tabCreateCategory = new TabControl();
        tabPage7 = new TabPage();
        textBox2 = new TextBox();
        label11 = new Label();
        btnCreateCategory = new Button();
        label7 = new Label();
        tabPage8 = new TabPage();
        btnUpdateCategory = new Button();
        textBox1 = new TextBox();
        label8 = new Label();
        tabPage6 = new TabPage();
        label9 = new Label();
        btnDeleteCategory = new Button();
        CategoryList = new ListBox();
        tabControl1.SuspendLayout();
        tabPage1.SuspendLayout();
        tabPage2.SuspendLayout();
        tabPage3.SuspendLayout();
        tabPage5.SuspendLayout();
        tabCreateCategory.SuspendLayout();
        tabPage7.SuspendLayout();
        tabPage8.SuspendLayout();
        tabPage6.SuspendLayout();
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
        tabPage2.Location = new Point(4, 29);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new Padding(3);
        tabPage2.Size = new Size(1070, 478);
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
        tabPage3.Location = new Point(4, 29);
        tabPage3.Name = "tabPage3";
        tabPage3.Size = new Size(1070, 478);
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
        tabPage4.Location = new Point(4, 29);
        tabPage4.Name = "tabPage4";
        tabPage4.Size = new Size(1070, 478);
        tabPage4.TabIndex = 3;
        tabPage4.Text = "Delete";
        tabPage4.UseVisualStyleBackColor = true;
        // 
        // tabPage5
        // 
        tabPage5.Controls.Add(CategoryList);
        tabPage5.Controls.Add(tabCreateCategory);
        tabPage5.Location = new Point(4, 37);
        tabPage5.Name = "tabPage5";
        tabPage5.Size = new Size(1070, 470);
        tabPage5.TabIndex = 4;
        tabPage5.Text = "Category";
        tabPage5.UseVisualStyleBackColor = true;
        // 
        // tabCreateCategory
        // 
        tabCreateCategory.Controls.Add(tabPage7);
        tabCreateCategory.Controls.Add(tabPage8);
        tabCreateCategory.Controls.Add(tabPage6);
        tabCreateCategory.Location = new Point(16, 23);
        tabCreateCategory.Name = "tabCreateCategory";
        tabCreateCategory.SelectedIndex = 0;
        tabCreateCategory.Size = new Size(447, 419);
        tabCreateCategory.TabIndex = 25;
        tabCreateCategory.DataContextChanged += rrr;
        // 
        // tabPage7
        // 
        tabPage7.Controls.Add(textBox2);
        tabPage7.Controls.Add(label11);
        tabPage7.Controls.Add(btnCreateCategory);
        tabPage7.Controls.Add(label7);
        tabPage7.Location = new Point(4, 37);
        tabPage7.Name = "tabPage7";
        tabPage7.Padding = new Padding(3);
        tabPage7.Size = new Size(439, 378);
        tabPage7.TabIndex = 1;
        tabPage7.Text = "Create";
        tabPage7.UseVisualStyleBackColor = true;
        // 
        // textBox2
        // 
        textBox2.BackColor = SystemColors.ButtonHighlight;
        textBox2.Location = new Point(41, 119);
        textBox2.Margin = new Padding(4);
        textBox2.Name = "textBox2";
        textBox2.Size = new Size(333, 34);
        textBox2.TabIndex = 18;
        textBox2.TextChanged += textBox2_TextChanged;
        // 
        // label11
        // 
        label11.AutoSize = true;
        label11.Location = new Point(41, 75);
        label11.Margin = new Padding(4, 0, 4, 0);
        label11.Name = "label11";
        label11.Size = new Size(64, 28);
        label11.TabIndex = 24;
        label11.Text = "Name";
        // 
        // btnCreateCategory
        // 
        btnCreateCategory.BackColor = Color.DarkSlateGray;
        btnCreateCategory.FlatStyle = FlatStyle.Popup;
        btnCreateCategory.ForeColor = SystemColors.GradientActiveCaption;
        btnCreateCategory.Location = new Point(132, 187);
        btnCreateCategory.Margin = new Padding(4);
        btnCreateCategory.Name = "btnCreateCategory";
        btnCreateCategory.Size = new Size(129, 41);
        btnCreateCategory.TabIndex = 19;
        btnCreateCategory.Text = "Create";
        btnCreateCategory.UseVisualStyleBackColor = false;
        btnCreateCategory.Click += button4_Click;
        // 
        // label7
        // 
        label7.AutoSize = true;
        label7.Font = new Font("Segoe UI", 13.8F);
        label7.Location = new Point(1, 27);
        label7.Margin = new Padding(4, 0, 4, 0);
        label7.Name = "label7";
        label7.Size = new Size(226, 31);
        label7.TabIndex = 21;
        label7.Text = "Create new Category";
        // 
        // tabPage8
        // 
        tabPage8.Controls.Add(btnUpdateCategory);
        tabPage8.Controls.Add(textBox1);
        tabPage8.Controls.Add(label8);
        tabPage8.Location = new Point(4, 29);
        tabPage8.Name = "tabPage8";
        tabPage8.Padding = new Padding(3);
        tabPage8.Size = new Size(439, 386);
        tabPage8.TabIndex = 2;
        tabPage8.Text = "Update";
        tabPage8.UseVisualStyleBackColor = true;
        // 
        // btnUpdateCategory
        // 
        btnUpdateCategory.BackColor = Color.DarkSlateGray;
        btnUpdateCategory.ForeColor = SystemColors.ButtonFace;
        btnUpdateCategory.Location = new Point(128, 151);
        btnUpdateCategory.Name = "btnUpdateCategory";
        btnUpdateCategory.Size = new Size(129, 45);
        btnUpdateCategory.TabIndex = 2;
        btnUpdateCategory.Text = "Update";
        btnUpdateCategory.UseVisualStyleBackColor = false;
        btnUpdateCategory.Click += btnUpdateCategory_Click;
        // 
        // textBox1
        // 
        textBox1.Location = new Point(34, 77);
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(349, 34);
        textBox1.TabIndex = 1;
        textBox1.TextChanged += textBox1_TextChanged;
        // 
        // label8
        // 
        label8.AutoSize = true;
        label8.Location = new Point(21, 24);
        label8.Name = "label8";
        label8.Size = new Size(215, 28);
        label8.TabIndex = 0;
        label8.Text = "Update Category name";
        // 
        // tabPage6
        // 
        tabPage6.Controls.Add(label9);
        tabPage6.Controls.Add(btnDeleteCategory);
        tabPage6.Location = new Point(4, 37);
        tabPage6.Name = "tabPage6";
        tabPage6.Size = new Size(439, 378);
        tabPage6.TabIndex = 3;
        tabPage6.Text = "Delete";
        tabPage6.UseVisualStyleBackColor = true;
        // 
        // label9
        // 
        label9.AutoSize = true;
        label9.Location = new Point(66, 44);
        label9.Name = "label9";
        label9.Size = new Size(248, 28);
        label9.TabIndex = 1;
        label9.Text = "Choose Category To Delete";
        // 
        // btnDeleteCategory
        // 
        btnDeleteCategory.BackColor = Color.DarkSlateGray;
        btnDeleteCategory.ForeColor = SystemColors.ButtonFace;
        btnDeleteCategory.Location = new Point(158, 131);
        btnDeleteCategory.Name = "btnDeleteCategory";
        btnDeleteCategory.Size = new Size(106, 46);
        btnDeleteCategory.TabIndex = 0;
        btnDeleteCategory.Text = "Delete";
        btnDeleteCategory.UseVisualStyleBackColor = false;
        btnDeleteCategory.Click += btnDeleteCategory_Click;
        // 
        // CategoryList
        // 
        CategoryList.FormattingEnabled = true;
        CategoryList.Location = new Point(607, 61);
        CategoryList.Name = "CategoryList";
        CategoryList.Size = new Size(410, 368);
        CategoryList.TabIndex = 26;
        CategoryList.SelectedIndexChanged += CategoryList_SelectedIndexChanged;
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
        tabCreateCategory.ResumeLayout(false);
        tabPage7.ResumeLayout(false);
        tabPage7.PerformLayout();
        tabPage8.ResumeLayout(false);
        tabPage8.PerformLayout();
        tabPage6.ResumeLayout(false);
        tabPage6.PerformLayout();
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
    private Button btnCreateCategory;
    private TextBox textBox2;
    private TabControl tabCreateCategory;
    private TabPage tabPage7;
    private TabPage tabPage8;
    private Button btnUpdateCategory;
    private TextBox textBox1;
    private Label label8;
    private TabPage tabPage6;
    private Label label9;
    private Button btnDeleteCategory;
    private ListBox CategoryList;
}

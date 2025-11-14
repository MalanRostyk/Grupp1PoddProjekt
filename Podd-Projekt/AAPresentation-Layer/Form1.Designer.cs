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
        btnSve = new Button();
        tabPage2 = new TabPage();
        tabPage3 = new TabPage();
        label3 = new Label();
        tbUpdateCategory = new TextBox();
        tbUpdateName = new TextBox();
        lblToUpdateCategory = new Label();
        lblToUpdateName = new Label();
        lblDisplayLink = new Label();
        lblToUpdate = new Label();
        tabPage4 = new TabPage();
        tabControl1.SuspendLayout();
        tabPage1.SuspendLayout();
        tabPage3.SuspendLayout();
        SuspendLayout();
        // 
        // lbSearchedResults
        // 
        lbSearchedResults.FormattingEnabled = true;
        lbSearchedResults.Location = new Point(17, 32);
        lbSearchedResults.Margin = new Padding(4);
        lbSearchedResults.Name = "lbSearchedResults";
        lbSearchedResults.Size = new Size(486, 312);
        lbSearchedResults.TabIndex = 0;
        lbSearchedResults.SelectedIndexChanged += listBox1_SelectedIndexChanged;
        // 
        // btnSearch
        // 
        btnSearch.BackColor = Color.DarkSlateGray;
        btnSearch.FlatStyle = FlatStyle.Popup;
        btnSearch.ForeColor = SystemColors.GradientActiveCaption;
        btnSearch.Location = new Point(422, 422);
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
        tbLink.Location = new Point(19, 422);
        tbLink.Margin = new Padding(4);
        tbLink.Name = "tbLink";
        tbLink.Size = new Size(395, 34);
        tbLink.TabIndex = 2;
        // 
        // rtbSearchedPodInfo
        // 
        rtbSearchedPodInfo.BackColor = SystemColors.ButtonHighlight;
        rtbSearchedPodInfo.Location = new Point(548, 32);
        rtbSearchedPodInfo.Margin = new Padding(4);
        rtbSearchedPodInfo.Name = "rtbSearchedPodInfo";
        rtbSearchedPodInfo.ReadOnly = true;
        rtbSearchedPodInfo.Size = new Size(515, 312);
        rtbSearchedPodInfo.TabIndex = 4;
        rtbSearchedPodInfo.Text = "";
        // 
        // label1
        // 
        label1.AutoSize = true;
        label1.Location = new Point(19, 385);
        label1.Margin = new Padding(4, 0, 4, 0);
        label1.Name = "label1";
        label1.Size = new Size(305, 28);
        label1.TabIndex = 5;
        label1.Text = "Enter Link To View Podcasts from: ";
        // 
        // label2
        // 
        label2.AutoSize = true;
        label2.Location = new Point(548, 0);
        label2.Margin = new Padding(4, 0, 4, 0);
        label2.Name = "label2";
        label2.Size = new Size(142, 28);
        label2.TabIndex = 6;
        label2.Text = "About podcast";
        // 
        // tabControl1
        // 
        tabControl1.Controls.Add(tabPage1);
        tabControl1.Controls.Add(tabPage2);
        tabControl1.Controls.Add(tabPage3);
        tabControl1.Controls.Add(tabPage4);
        tabControl1.Location = new Point(12, -2);
        tabControl1.Name = "tabControl1";
        tabControl1.SelectedIndex = 0;
        tabControl1.Size = new Size(1078, 511);
        tabControl1.TabIndex = 7;
        tabControl1.UseWaitCursor = true;
        // 
        // tabPage1
        // 
        tabPage1.Controls.Add(btnSve);
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
        // btnSve
        // 
        btnSve.BackColor = Color.DarkSlateGray;
        btnSve.FlatStyle = FlatStyle.Popup;
        btnSve.ForeColor = SystemColors.GradientActiveCaption;
        btnSve.Location = new Point(934, 422);
        btnSve.Margin = new Padding(4);
        btnSve.Name = "btnSve";
        btnSve.Size = new Size(129, 41);
        btnSve.TabIndex = 7;
        btnSve.Text = "Save";
        btnSve.UseVisualStyleBackColor = false;
        // 
        // tabPage2
        // 
        tabPage2.Location = new Point(4, 29);
        tabPage2.Name = "tabPage2";
        tabPage2.Padding = new Padding(3);
        tabPage2.Size = new Size(1070, 478);
        tabPage2.TabIndex = 1;
        tabPage2.Text = "Register";
        tabPage2.UseVisualStyleBackColor = true;
        tabPage2.UseWaitCursor = true;
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
        tabPage3.UseWaitCursor = true;
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
        label3.UseWaitCursor = true;
        // 
        // tbUpdateCategory
        // 
        tbUpdateCategory.Location = new Point(129, 288);
        tbUpdateCategory.Name = "tbUpdateCategory";
        tbUpdateCategory.Size = new Size(327, 34);
        tbUpdateCategory.TabIndex = 5;
        tbUpdateCategory.UseWaitCursor = true;
        // 
        // tbUpdateName
        // 
        tbUpdateName.Location = new Point(129, 212);
        tbUpdateName.Name = "tbUpdateName";
        tbUpdateName.Size = new Size(327, 34);
        tbUpdateName.TabIndex = 4;
        tbUpdateName.UseWaitCursor = true;
        // 
        // lblToUpdateCategory
        // 
        lblToUpdateCategory.AutoSize = true;
        lblToUpdateCategory.Location = new Point(31, 288);
        lblToUpdateCategory.Name = "lblToUpdateCategory";
        lblToUpdateCategory.Size = new Size(101, 28);
        lblToUpdateCategory.TabIndex = 3;
        lblToUpdateCategory.Text = "Category: ";
        lblToUpdateCategory.UseWaitCursor = true;
        // 
        // lblToUpdateName
        // 
        lblToUpdateName.AutoSize = true;
        lblToUpdateName.Location = new Point(64, 212);
        lblToUpdateName.Name = "lblToUpdateName";
        lblToUpdateName.Size = new Size(68, 28);
        lblToUpdateName.TabIndex = 2;
        lblToUpdateName.Text = "Name:";
        lblToUpdateName.UseWaitCursor = true;
        // 
        // lblDisplayLink
        // 
        lblDisplayLink.AutoSize = true;
        lblDisplayLink.Location = new Point(80, 146);
        lblDisplayLink.Name = "lblDisplayLink";
        lblDisplayLink.Size = new Size(231, 28);
        lblDisplayLink.TabIndex = 1;
        lblDisplayLink.Text = "Link: (Glöm ej += länken)";
        lblDisplayLink.UseWaitCursor = true;
        // 
        // lblToUpdate
        // 
        lblToUpdate.AutoSize = true;
        lblToUpdate.Location = new Point(98, 91);
        lblToUpdate.Name = "lblToUpdate";
        lblToUpdate.Size = new Size(213, 28);
        lblToUpdate.TabIndex = 0;
        lblToUpdate.Text = "Id: (Glöm ej += länken)";
        lblToUpdate.UseWaitCursor = true;
        // 
        // tabPage4
        // 
        tabPage4.Location = new Point(4, 29);
        tabPage4.Name = "tabPage4";
        tabPage4.Size = new Size(1070, 478);
        tabPage4.TabIndex = 3;
        tabPage4.Text = "Delete";
        tabPage4.UseVisualStyleBackColor = true;
        tabPage4.UseWaitCursor = true;
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
        UseWaitCursor = true;
        Load += Form1_Load;
        tabControl1.ResumeLayout(false);
        tabPage1.ResumeLayout(false);
        tabPage1.PerformLayout();
        tabPage3.ResumeLayout(false);
        tabPage3.PerformLayout();
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
    private Button btnSve;
    private TabPage tabPage3;
    private TabPage tabPage4;
    private Label lblToUpdateCategory;
    private Label lblToUpdateName;
    private Label lblDisplayLink;
    private Label lblToUpdate;
    private TextBox tbUpdateCategory;
    private TextBox tbUpdateName;
    private Label label3;
}

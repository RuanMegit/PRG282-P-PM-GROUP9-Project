namespace WildlifeRecordsSystem
{
    partial class frmView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSummaryReport = new System.Windows.Forms.Button();
            this.dgvAnimals = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.txtAnimalID = new System.Windows.Forms.TextBox();
            this.txtAnimalName = new System.Windows.Forms.TextBox();
            this.txtAnimalSpecies = new System.Windows.Forms.TextBox();
            this.txtAnimalAge = new System.Windows.Forms.TextBox();
            this.txtRecoveryScore = new System.Windows.Forms.TextBox();
            this.lblID = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.lblSpecies = new System.Windows.Forms.Label();
            this.lblAge = new System.Windows.Forms.Label();
            this.lblRecoveryScore = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSaveChanges = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimals)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(42, 512);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(339, 510);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSummaryReport
            // 
            this.btnSummaryReport.Location = new System.Drawing.Point(893, 512);
            this.btnSummaryReport.Name = "btnSummaryReport";
            this.btnSummaryReport.Size = new System.Drawing.Size(155, 23);
            this.btnSummaryReport.TabIndex = 3;
            this.btnSummaryReport.Text = "Summary Report";
            this.btnSummaryReport.UseVisualStyleBackColor = true;
            this.btnSummaryReport.Click += new System.EventHandler(this.btnSummaryReport_Click);
            // 
            // dgvAnimals
            // 
            this.dgvAnimals.BackgroundColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAnimals.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAnimals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAnimals.GridColor = System.Drawing.SystemColors.ControlText;
            this.dgvAnimals.Location = new System.Drawing.Point(311, 67);
            this.dgvAnimals.Name = "dgvAnimals";
            this.dgvAnimals.RowHeadersWidth = 51;
            this.dgvAnimals.RowTemplate.Height = 24;
            this.dgvAnimals.Size = new System.Drawing.Size(737, 411);
            this.dgvAnimals.TabIndex = 4;
            this.dgvAnimals.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAnimals_CellClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(407, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(333, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "Baobab Ridge Wildlife Rehabilitation Records System";
            // 
            // txtAnimalID
            // 
            this.txtAnimalID.Location = new System.Drawing.Point(123, 92);
            this.txtAnimalID.Name = "txtAnimalID";
            this.txtAnimalID.Size = new System.Drawing.Size(170, 22);
            this.txtAnimalID.TabIndex = 6;
            // 
            // txtAnimalName
            // 
            this.txtAnimalName.Location = new System.Drawing.Point(123, 125);
            this.txtAnimalName.Name = "txtAnimalName";
            this.txtAnimalName.Size = new System.Drawing.Size(170, 22);
            this.txtAnimalName.TabIndex = 7;
            // 
            // txtAnimalSpecies
            // 
            this.txtAnimalSpecies.Location = new System.Drawing.Point(123, 161);
            this.txtAnimalSpecies.Name = "txtAnimalSpecies";
            this.txtAnimalSpecies.Size = new System.Drawing.Size(170, 22);
            this.txtAnimalSpecies.TabIndex = 8;
            // 
            // txtAnimalAge
            // 
            this.txtAnimalAge.Location = new System.Drawing.Point(123, 199);
            this.txtAnimalAge.Name = "txtAnimalAge";
            this.txtAnimalAge.Size = new System.Drawing.Size(170, 22);
            this.txtAnimalAge.TabIndex = 9;
            // 
            // txtRecoveryScore
            // 
            this.txtRecoveryScore.Location = new System.Drawing.Point(123, 237);
            this.txtRecoveryScore.Name = "txtRecoveryScore";
            this.txtRecoveryScore.Size = new System.Drawing.Size(170, 22);
            this.txtRecoveryScore.TabIndex = 10;
            // 
            // lblID
            // 
            this.lblID.AutoSize = true;
            this.lblID.Location = new System.Drawing.Point(6, 95);
            this.lblID.Name = "lblID";
            this.lblID.Size = new System.Drawing.Size(26, 16);
            this.lblID.TabIndex = 11;
            this.lblID.Text = "ID :";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(6, 128);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(50, 16);
            this.lblName.TabIndex = 12;
            this.lblName.Text = "Name :";
            // 
            // lblSpecies
            // 
            this.lblSpecies.AutoSize = true;
            this.lblSpecies.Location = new System.Drawing.Point(6, 164);
            this.lblSpecies.Name = "lblSpecies";
            this.lblSpecies.Size = new System.Drawing.Size(60, 16);
            this.lblSpecies.TabIndex = 13;
            this.lblSpecies.Text = "Species:";
            // 
            // lblAge
            // 
            this.lblAge.AutoSize = true;
            this.lblAge.Location = new System.Drawing.Point(6, 202);
            this.lblAge.Name = "lblAge";
            this.lblAge.Size = new System.Drawing.Size(38, 16);
            this.lblAge.TabIndex = 14;
            this.lblAge.Text = "Age :";
            // 
            // lblRecoveryScore
            // 
            this.lblRecoveryScore.AutoSize = true;
            this.lblRecoveryScore.Location = new System.Drawing.Point(6, 240);
            this.lblRecoveryScore.Name = "lblRecoveryScore";
            this.lblRecoveryScore.Size = new System.Drawing.Size(111, 16);
            this.lblRecoveryScore.TabIndex = 15;
            this.lblRecoveryScore.Text = "Recovery Score :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 49);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Enter the details of  the animal";
            // 
            // btnSaveChanges
            // 
            this.btnSaveChanges.Enabled = false;
            this.btnSaveChanges.Location = new System.Drawing.Point(223, 510);
            this.btnSaveChanges.Name = "btnSaveChanges";
            this.btnSaveChanges.Size = new System.Drawing.Size(110, 23);
            this.btnSaveChanges.TabIndex = 17;
            this.btnSaveChanges.Text = "Save Changes";
            this.btnSaveChanges.UseVisualStyleBackColor = true;
            this.btnSaveChanges.Click += new System.EventHandler(this.btnSaveChanges_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(430, 510);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 18;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // frmView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(1084, 558);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSaveChanges);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.lblRecoveryScore);
            this.Controls.Add(this.lblAge);
            this.Controls.Add(this.lblSpecies);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.lblID);
            this.Controls.Add(this.txtRecoveryScore);
            this.Controls.Add(this.txtAnimalAge);
            this.Controls.Add(this.txtAnimalSpecies);
            this.Controls.Add(this.txtAnimalName);
            this.Controls.Add(this.txtAnimalID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvAnimals);
            this.Controls.Add(this.btnSummaryReport);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Name = "frmView";
            this.Text = "View Animal";
            this.Load += new System.EventHandler(this.frmView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAnimals)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSummaryReport;
        private System.Windows.Forms.DataGridView dgvAnimals;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtAnimalID;
        private System.Windows.Forms.TextBox txtAnimalName;
        private System.Windows.Forms.TextBox txtAnimalSpecies;
        private System.Windows.Forms.TextBox txtAnimalAge;
        private System.Windows.Forms.TextBox txtRecoveryScore;
        private System.Windows.Forms.Label lblID;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblSpecies;
        private System.Windows.Forms.Label lblAge;
        private System.Windows.Forms.Label lblRecoveryScore;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSaveChanges;
        private System.Windows.Forms.Button btnClear;
    }
}


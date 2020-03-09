namespace FcukWinforms
{
    partial class frmGetOrder
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
            this.txtOrderNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvOrder = new System.Windows.Forms.DataGridView();
            this.spltTopBottom = new System.Windows.Forms.SplitContainer();
            this.chkChooseOrder = new System.Windows.Forms.CheckBox();
            this.cboOrderToRetrieveSql = new System.Windows.Forms.ComboBox();
            this.chkXmlFromSql = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboSqlServer = new System.Windows.Forms.ComboBox();
            this.btnOpenXmlFile = new System.Windows.Forms.Button();
            this.tvXml = new System.Windows.Forms.TreeView();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDescDataProc = new System.Windows.Forms.TextBox();
            this.btnXmlCreate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCareDataProc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtFitDataProc = new System.Windows.Forms.TextBox();
            this.btnImageSearch = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtImageLocation = new System.Windows.Forms.TextBox();
            this.cboAs400Connections = new System.Windows.Forms.ComboBox();
            this.chkUseThisParm = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtOrderDataProc = new System.Windows.Forms.TextBox();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFetchOrder = new System.Windows.Forms.Button();
            this.spltInner = new System.Windows.Forms.SplitContainer();
            this.dgvCare = new System.Windows.Forms.DataGridView();
            this.diaImageFolder = new System.Windows.Forms.FolderBrowserDialog();
            this.diaFileXml = new System.Windows.Forms.OpenFileDialog();
            this.tt = new System.Windows.Forms.ToolTip(this.components);
            this.label8 = new System.Windows.Forms.Label();
            this.txtLiningDataProc = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.spltTopBottom)).BeginInit();
            this.spltTopBottom.Panel1.SuspendLayout();
            this.spltTopBottom.Panel2.SuspendLayout();
            this.spltTopBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.spltInner)).BeginInit();
            this.spltInner.Panel1.SuspendLayout();
            this.spltInner.Panel2.SuspendLayout();
            this.spltInner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCare)).BeginInit();
            this.SuspendLayout();
            // 
            // txtOrderNumber
            // 
            this.txtOrderNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderNumber.Location = new System.Drawing.Point(201, 14);
            this.txtOrderNumber.Name = "txtOrderNumber";
            this.txtOrderNumber.Size = new System.Drawing.Size(153, 23);
            this.txtOrderNumber.TabIndex = 0;
            this.txtOrderNumber.Text = "\'1084411\'";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Order to retrieve:";
            // 
            // dgvOrder
            // 
            this.dgvOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrder.Location = new System.Drawing.Point(0, 0);
            this.dgvOrder.Name = "dgvOrder";
            this.dgvOrder.Size = new System.Drawing.Size(846, 291);
            this.dgvOrder.TabIndex = 2;
            // 
            // spltTopBottom
            // 
            this.spltTopBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltTopBottom.Location = new System.Drawing.Point(0, 0);
            this.spltTopBottom.Name = "spltTopBottom";
            this.spltTopBottom.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // spltTopBottom.Panel1
            // 
            this.spltTopBottom.Panel1.Controls.Add(this.label8);
            this.spltTopBottom.Panel1.Controls.Add(this.txtLiningDataProc);
            this.spltTopBottom.Panel1.Controls.Add(this.chkChooseOrder);
            this.spltTopBottom.Panel1.Controls.Add(this.cboOrderToRetrieveSql);
            this.spltTopBottom.Panel1.Controls.Add(this.chkXmlFromSql);
            this.spltTopBottom.Panel1.Controls.Add(this.label7);
            this.spltTopBottom.Panel1.Controls.Add(this.cboSqlServer);
            this.spltTopBottom.Panel1.Controls.Add(this.btnOpenXmlFile);
            this.spltTopBottom.Panel1.Controls.Add(this.tvXml);
            this.spltTopBottom.Panel1.Controls.Add(this.label6);
            this.spltTopBottom.Panel1.Controls.Add(this.txtDescDataProc);
            this.spltTopBottom.Panel1.Controls.Add(this.btnXmlCreate);
            this.spltTopBottom.Panel1.Controls.Add(this.label5);
            this.spltTopBottom.Panel1.Controls.Add(this.txtCareDataProc);
            this.spltTopBottom.Panel1.Controls.Add(this.label4);
            this.spltTopBottom.Panel1.Controls.Add(this.txtFitDataProc);
            this.spltTopBottom.Panel1.Controls.Add(this.btnImageSearch);
            this.spltTopBottom.Panel1.Controls.Add(this.label3);
            this.spltTopBottom.Panel1.Controls.Add(this.txtImageLocation);
            this.spltTopBottom.Panel1.Controls.Add(this.cboAs400Connections);
            this.spltTopBottom.Panel1.Controls.Add(this.chkUseThisParm);
            this.spltTopBottom.Panel1.Controls.Add(this.label2);
            this.spltTopBottom.Panel1.Controls.Add(this.txtOrderDataProc);
            this.spltTopBottom.Panel1.Controls.Add(this.btnExit);
            this.spltTopBottom.Panel1.Controls.Add(this.btnFetchOrder);
            this.spltTopBottom.Panel1.Controls.Add(this.label1);
            this.spltTopBottom.Panel1.Controls.Add(this.txtOrderNumber);
            // 
            // spltTopBottom.Panel2
            // 
            this.spltTopBottom.Panel2.Controls.Add(this.spltInner);
            this.spltTopBottom.Size = new System.Drawing.Size(1268, 599);
            this.spltTopBottom.SplitterDistance = 304;
            this.spltTopBottom.TabIndex = 3;
            // 
            // chkChooseOrder
            // 
            this.chkChooseOrder.AutoSize = true;
            this.chkChooseOrder.Checked = true;
            this.chkChooseOrder.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkChooseOrder.Location = new System.Drawing.Point(512, 48);
            this.chkChooseOrder.Name = "chkChooseOrder";
            this.chkChooseOrder.Size = new System.Drawing.Size(155, 17);
            this.chkChooseOrder.TabIndex = 24;
            this.chkChooseOrder.Text = "Or choose order to retrieve:";
            this.chkChooseOrder.UseVisualStyleBackColor = true;
            this.chkChooseOrder.CheckedChanged += new System.EventHandler(this.chkChooseOrder_CheckedChanged);
            // 
            // cboOrderToRetrieveSql
            // 
            this.cboOrderToRetrieveSql.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboOrderToRetrieveSql.FormattingEnabled = true;
            this.cboOrderToRetrieveSql.Location = new System.Drawing.Point(673, 45);
            this.cboOrderToRetrieveSql.Name = "cboOrderToRetrieveSql";
            this.cboOrderToRetrieveSql.Size = new System.Drawing.Size(173, 24);
            this.cboOrderToRetrieveSql.TabIndex = 22;
            // 
            // chkXmlFromSql
            // 
            this.chkXmlFromSql.AutoSize = true;
            this.chkXmlFromSql.Location = new System.Drawing.Point(824, 72);
            this.chkXmlFromSql.Name = "chkXmlFromSql";
            this.chkXmlFromSql.Size = new System.Drawing.Size(73, 17);
            this.chkXmlFromSql.TabIndex = 21;
            this.chkXmlFromSql.Text = "From Sql?";
            this.chkXmlFromSql.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(16, 248);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 17);
            this.label7.TabIndex = 20;
            this.label7.Text = "SQL Server connection:";
            // 
            // cboSqlServer
            // 
            this.cboSqlServer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSqlServer.FormattingEnabled = true;
            this.cboSqlServer.Location = new System.Drawing.Point(228, 247);
            this.cboSqlServer.Name = "cboSqlServer";
            this.cboSqlServer.Size = new System.Drawing.Size(530, 24);
            this.cboSqlServer.TabIndex = 19;
            // 
            // btnOpenXmlFile
            // 
            this.btnOpenXmlFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOpenXmlFile.Location = new System.Drawing.Point(1085, 61);
            this.btnOpenXmlFile.Name = "btnOpenXmlFile";
            this.btnOpenXmlFile.Size = new System.Drawing.Size(171, 37);
            this.btnOpenXmlFile.TabIndex = 18;
            this.btnOpenXmlFile.Text = "Create XML doc from file";
            this.btnOpenXmlFile.UseVisualStyleBackColor = true;
            this.btnOpenXmlFile.Click += new System.EventHandler(this.btnOpenXmlFile_Click);
            // 
            // tvXml
            // 
            this.tvXml.Location = new System.Drawing.Point(787, 107);
            this.tvXml.Name = "tvXml";
            this.tvXml.Size = new System.Drawing.Size(469, 147);
            this.tvXml.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(16, 187);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(208, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "Retrieve description data using:";
            // 
            // txtDescDataProc
            // 
            this.txtDescDataProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescDataProc.Location = new System.Drawing.Point(228, 184);
            this.txtDescDataProc.Name = "txtDescDataProc";
            this.txtDescDataProc.Size = new System.Drawing.Size(530, 23);
            this.txtDescDataProc.TabIndex = 15;
            this.txtDescDataProc.Text = "lifeit.getss20copydata";
            // 
            // btnXmlCreate
            // 
            this.btnXmlCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXmlCreate.Location = new System.Drawing.Point(899, 61);
            this.btnXmlCreate.Name = "btnXmlCreate";
            this.btnXmlCreate.Size = new System.Drawing.Size(115, 37);
            this.btnXmlCreate.TabIndex = 14;
            this.btnXmlCreate.Text = "Create XML doc";
            this.btnXmlCreate.UseVisualStyleBackColor = true;
            this.btnXmlCreate.Click += new System.EventHandler(this.btnXmlCreate_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(169, 17);
            this.label5.TabIndex = 13;
            this.label5.Text = "Retrieve Care data using:";
            // 
            // txtCareDataProc
            // 
            this.txtCareDataProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCareDataProc.Location = new System.Drawing.Point(228, 149);
            this.txtCareDataProc.Name = "txtCareDataProc";
            this.txtCareDataProc.Size = new System.Drawing.Size(530, 23);
            this.txtCareDataProc.TabIndex = 12;
            this.txtCareDataProc.Text = "lifeit.getfcukcaredata";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(159, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Retrieve FIT data using:";
            // 
            // txtFitDataProc
            // 
            this.txtFitDataProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFitDataProc.Location = new System.Drawing.Point(228, 113);
            this.txtFitDataProc.Name = "txtFitDataProc";
            this.txtFitDataProc.Size = new System.Drawing.Size(530, 23);
            this.txtFitDataProc.TabIndex = 10;
            this.txtFitDataProc.Text = "lifeit.getfcukfitdata";
            // 
            // btnImageSearch
            // 
            this.btnImageSearch.AutoSize = true;
            this.btnImageSearch.Location = new System.Drawing.Point(673, 78);
            this.btnImageSearch.Name = "btnImageSearch";
            this.btnImageSearch.Size = new System.Drawing.Size(27, 23);
            this.btnImageSearch.TabIndex = 9;
            this.btnImageSearch.Text = "...";
            this.btnImageSearch.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnImageSearch.UseVisualStyleBackColor = true;
            this.btnImageSearch.Click += new System.EventHandler(this.btnImageSearch_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Retrieve images from:";
            // 
            // txtImageLocation
            // 
            this.txtImageLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImageLocation.Location = new System.Drawing.Point(228, 78);
            this.txtImageLocation.Name = "txtImageLocation";
            this.txtImageLocation.Size = new System.Drawing.Size(439, 23);
            this.txtImageLocation.TabIndex = 7;
            this.txtImageLocation.Text = "\\\\uk.fc.local\\camdfs\\Images\\WHOLESALE IMAGES\\SS20 SEASON WOMANS\\ZALANDO";
            // 
            // cboAs400Connections
            // 
            this.cboAs400Connections.FormattingEnabled = true;
            this.cboAs400Connections.Location = new System.Drawing.Point(488, 16);
            this.cboAs400Connections.Name = "cboAs400Connections";
            this.cboAs400Connections.Size = new System.Drawing.Size(356, 21);
            this.cboAs400Connections.TabIndex = 4;
            // 
            // chkUseThisParm
            // 
            this.chkUseThisParm.AutoSize = true;
            this.chkUseThisParm.Checked = true;
            this.chkUseThisParm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkUseThisParm.Location = new System.Drawing.Point(360, 18);
            this.chkUseThisParm.Name = "chkUseThisParm";
            this.chkUseThisParm.Size = new System.Drawing.Size(90, 17);
            this.chkUseThisParm.TabIndex = 6;
            this.chkUseThisParm.Text = "Use this parm";
            this.chkUseThisParm.UseVisualStyleBackColor = true;
            this.chkUseThisParm.CheckedChanged += new System.EventHandler(this.chkChooseOrder_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Procedure to run:";
            // 
            // txtOrderDataProc
            // 
            this.txtOrderDataProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOrderDataProc.Location = new System.Drawing.Point(228, 45);
            this.txtOrderDataProc.Name = "txtOrderDataProc";
            this.txtOrderDataProc.Size = new System.Drawing.Size(157, 23);
            this.txtOrderDataProc.TabIndex = 4;
            this.txtOrderDataProc.Text = "lifeit.GetFcukOrder";
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(1085, 7);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(171, 37);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "E&xit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnFetchOrder
            // 
            this.btnFetchOrder.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFetchOrder.Location = new System.Drawing.Point(899, 7);
            this.btnFetchOrder.Name = "btnFetchOrder";
            this.btnFetchOrder.Size = new System.Drawing.Size(115, 37);
            this.btnFetchOrder.TabIndex = 2;
            this.btnFetchOrder.Text = "Get the Order";
            this.btnFetchOrder.UseVisualStyleBackColor = true;
            this.btnFetchOrder.Click += new System.EventHandler(this.btnFetchOrder_Click);
            // 
            // spltInner
            // 
            this.spltInner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.spltInner.Location = new System.Drawing.Point(0, 0);
            this.spltInner.Name = "spltInner";
            // 
            // spltInner.Panel1
            // 
            this.spltInner.Panel1.Controls.Add(this.dgvOrder);
            // 
            // spltInner.Panel2
            // 
            this.spltInner.Panel2.Controls.Add(this.dgvCare);
            this.spltInner.Size = new System.Drawing.Size(1268, 291);
            this.spltInner.SplitterDistance = 846;
            this.spltInner.TabIndex = 3;
            // 
            // dgvCare
            // 
            this.dgvCare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCare.Location = new System.Drawing.Point(0, 0);
            this.dgvCare.Name = "dgvCare";
            this.dgvCare.Size = new System.Drawing.Size(418, 291);
            this.dgvCare.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 216);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(204, 17);
            this.label8.TabIndex = 26;
            this.label8.Text = "Retrieve Lining etc. data using:";
            // 
            // txtLiningDataProc
            // 
            this.txtLiningDataProc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLiningDataProc.Location = new System.Drawing.Point(228, 213);
            this.txtLiningDataProc.Name = "txtLiningDataProc";
            this.txtLiningDataProc.Size = new System.Drawing.Size(530, 23);
            this.txtLiningDataProc.TabIndex = 25;
            this.txtLiningDataProc.Text = "lifeit.getFcukLiningdata";
            // 
            // frmGetOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1268, 599);
            this.Controls.Add(this.spltTopBottom);
            this.Name = "frmGetOrder";
            this.Text = "FCUK: Test Zalando order retrieval";
            this.Load += new System.EventHandler(this.frmGetOrder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrder)).EndInit();
            this.spltTopBottom.Panel1.ResumeLayout(false);
            this.spltTopBottom.Panel1.PerformLayout();
            this.spltTopBottom.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltTopBottom)).EndInit();
            this.spltTopBottom.ResumeLayout(false);
            this.spltInner.Panel1.ResumeLayout(false);
            this.spltInner.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.spltInner)).EndInit();
            this.spltInner.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCare)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtOrderNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvOrder;
        private System.Windows.Forms.SplitContainer spltTopBottom;
        private System.Windows.Forms.Button btnFetchOrder;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtOrderDataProc;
        private System.Windows.Forms.CheckBox chkUseThisParm;
        private System.Windows.Forms.ComboBox cboAs400Connections;
        private System.Windows.Forms.Button btnImageSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtImageLocation;
        private System.Windows.Forms.FolderBrowserDialog diaImageFolder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtFitDataProc;
        private System.Windows.Forms.SplitContainer spltInner;
        private System.Windows.Forms.DataGridView dgvCare;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCareDataProc;
        private System.Windows.Forms.Button btnXmlCreate;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDescDataProc;
        private System.Windows.Forms.TreeView tvXml;
        private System.Windows.Forms.Button btnOpenXmlFile;
        private System.Windows.Forms.OpenFileDialog diaFileXml;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboSqlServer;
        private System.Windows.Forms.CheckBox chkXmlFromSql;
        private System.Windows.Forms.ComboBox cboOrderToRetrieveSql;
        private System.Windows.Forms.CheckBox chkChooseOrder;
        private System.Windows.Forms.ToolTip tt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtLiningDataProc;
    }
}


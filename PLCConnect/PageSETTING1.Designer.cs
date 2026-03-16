namespace PLCConnect
{
    partial class PageSETTING1
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
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblInputFile = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnConnect = new System.Windows.Forms.Label();
            this.btnDisconnect = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLoad = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblOutputFile = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.lblExcelExport = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblExcelRowsCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGrid1.HelpVisible = false;
            this.propertyGrid1.Location = new System.Drawing.Point(0, 109);
            this.propertyGrid1.Margin = new System.Windows.Forms.Padding(4);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(539, 271);
            this.propertyGrid1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblInputFile);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(539, 37);
            this.panel1.TabIndex = 2;
            // 
            // lblInputFile
            // 
            this.lblInputFile.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblInputFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblInputFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInputFile.Location = new System.Drawing.Point(107, 0);
            this.lblInputFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblInputFile.Name = "lblInputFile";
            this.lblInputFile.Size = new System.Drawing.Size(432, 37);
            this.lblInputFile.TabIndex = 5;
            this.lblInputFile.Text = "C://";
            this.lblInputFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblInputFile.Click += new System.EventHandler(this.lblInputFile_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 37);
            this.label1.TabIndex = 4;
            this.label1.Text = "INPUT";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.btnConnect, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.btnDisconnect, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblLoad, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 380);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 37, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(539, 96);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnConnect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnConnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnConnect.Location = new System.Drawing.Point(269, 48);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(0);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(270, 48);
            this.btnConnect.TabIndex = 8;
            this.btnConnect.Text = "CONNECT";
            this.btnConnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.btnDisconnect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.btnDisconnect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDisconnect.Location = new System.Drawing.Point(0, 48);
            this.btnDisconnect.Margin = new System.Windows.Forms.Padding(0);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(269, 48);
            this.btnDisconnect.TabIndex = 7;
            this.btnDisconnect.Text = "DISCONNECT";
            this.btnDisconnect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(269, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(270, 48);
            this.label4.TabIndex = 6;
            this.label4.Text = "SAVE";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Click += new System.EventHandler(this.lblSave_Click);
            // 
            // lblLoad
            // 
            this.lblLoad.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLoad.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblLoad.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoad.Location = new System.Drawing.Point(0, 0);
            this.lblLoad.Margin = new System.Windows.Forms.Padding(0);
            this.lblLoad.Name = "lblLoad";
            this.lblLoad.Size = new System.Drawing.Size(269, 48);
            this.lblLoad.TabIndex = 5;
            this.lblLoad.Text = "LOAD";
            this.lblLoad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblLoad.Click += new System.EventHandler(this.lbLoad_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblOutputFile);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 37);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(539, 36);
            this.panel2.TabIndex = 4;
            // 
            // lblOutputFile
            // 
            this.lblOutputFile.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblOutputFile.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblOutputFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutputFile.Location = new System.Drawing.Point(107, 0);
            this.lblOutputFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblOutputFile.Name = "lblOutputFile";
            this.lblOutputFile.Size = new System.Drawing.Size(432, 36);
            this.lblOutputFile.TabIndex = 5;
            this.lblOutputFile.Text = "D://";
            this.lblOutputFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblOutputFile.Click += new System.EventHandler(this.lblOutputFile_Click);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Dock = System.Windows.Forms.DockStyle.Left;
            this.label6.Location = new System.Drawing.Point(0, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 36);
            this.label6.TabIndex = 4;
            this.label6.Text = "OUTPUT";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.lblExcelExport);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.lblExcelRowsCount);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 73);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(539, 36);
            this.panel3.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Dock = System.Windows.Forms.DockStyle.Right;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(445, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(94, 36);
            this.label9.TabIndex = 9;
            this.label9.Text = "CHECK";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExcelExport
            // 
            this.lblExcelExport.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblExcelExport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExcelExport.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblExcelExport.Location = new System.Drawing.Point(321, 0);
            this.lblExcelExport.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExcelExport.Name = "lblExcelExport";
            this.lblExcelExport.Size = new System.Drawing.Size(94, 36);
            this.lblExcelExport.TabIndex = 8;
            this.lblExcelExport.Text = "USE";
            this.lblExcelExport.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExcelExport.Click += new System.EventHandler(this.lblExcelExport_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Dock = System.Windows.Forms.DockStyle.Left;
            this.label7.Location = new System.Drawing.Point(261, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(60, 36);
            this.label7.TabIndex = 7;
            this.label7.Text = "USE";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblExcelRowsCount
            // 
            this.lblExcelRowsCount.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblExcelRowsCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblExcelRowsCount.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblExcelRowsCount.Location = new System.Drawing.Point(167, 0);
            this.lblExcelRowsCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExcelRowsCount.Name = "lblExcelRowsCount";
            this.lblExcelRowsCount.Size = new System.Drawing.Size(94, 36);
            this.lblExcelRowsCount.TabIndex = 6;
            this.lblExcelRowsCount.Text = "1000";
            this.lblExcelRowsCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExcelRowsCount.Click += new System.EventHandler(this.lblExcelRowsCount_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Location = new System.Drawing.Point(107, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 36);
            this.label2.TabIndex = 5;
            this.label2.Text = "ROWS";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlLight;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 36);
            this.label3.TabIndex = 4;
            this.label3.Text = "EXPORT";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PageSETTING1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PageSETTING1";
            this.Size = new System.Drawing.Size(539, 476);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblInputFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLoad;
        private System.Windows.Forms.Label btnConnect;
        private System.Windows.Forms.Label btnDisconnect;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblOutputFile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lblExcelRowsCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lblExcelExport;
        private System.Windows.Forms.Label label7;
    }
}


namespace ProjektTemperatur
{
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Väderdata = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textQuery = new System.Windows.Forms.TextBox();
            this.btnQuery = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxTemp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboPlats = new System.Windows.Forms.ComboBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.pictureHouse = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnVtK = new System.Windows.Forms.Button();
            this.btnTtF = new System.Windows.Forms.Button();
            this.MeteoHost = new System.Windows.Forms.Button();
            this.MeteoVinter = new System.Windows.Forms.Button();
            this.btnRiskförMögel = new System.Windows.Forms.Button();
            this.lblMeteoHost = new System.Windows.Forms.Label();
            this.lblStartVinterDag = new System.Windows.Forms.Label();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.lblGrid = new System.Windows.Forms.Label();
            this.TempInneUte = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnBalkong1 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureHouse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            this.SuspendLayout();
            // 
            // Väderdata
            // 
            this.Väderdata.AutoSize = true;
            this.Väderdata.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Väderdata.Location = new System.Drawing.Point(385, 5);
            this.Väderdata.MaximumSize = new System.Drawing.Size(200, 150);
            this.Väderdata.MinimumSize = new System.Drawing.Size(140, 42);
            this.Väderdata.Name = "Väderdata";
            this.Väderdata.Size = new System.Drawing.Size(172, 46);
            this.Väderdata.TabIndex = 0;
            this.Väderdata.Text = "Väderdata";
            this.Väderdata.Click += new System.EventHandler(this.Väderdata_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(257, 45);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(63, 27);
            this.btnLoad.TabIndex = 2;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 45);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(239, 27);
            this.textBox1.TabIndex = 3;
            this.textBox1.Text = "@\"C:\\Prova\\TemperaturData.csv\"";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(102, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Data Source";
            // 
            // textQuery
            // 
            this.textQuery.Location = new System.Drawing.Point(130, 689);
            this.textQuery.Name = "textQuery";
            this.textQuery.Size = new System.Drawing.Size(734, 27);
            this.textQuery.TabIndex = 7;
            this.textQuery.TextChanged += new System.EventHandler(this.textQuery_TextChanged);
            // 
            // btnQuery
            // 
            this.btnQuery.Location = new System.Drawing.Point(346, 743);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(211, 29);
            this.btnQuery.TabIndex = 8;
            this.btnQuery.Text = "execute  query";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(744, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "DATUM";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // textBoxTemp
            // 
            this.textBoxTemp.Location = new System.Drawing.Point(966, 71);
            this.textBoxTemp.Name = "textBoxTemp";
            this.textBoxTemp.Size = new System.Drawing.Size(61, 27);
            this.textBoxTemp.TabIndex = 13;
            this.textBoxTemp.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(580, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 20);
            this.label3.TabIndex = 14;
            this.label3.Text = "Plats";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(953, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "MedelTemp";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // comboPlats
            // 
            this.comboPlats.FormattingEnabled = true;
            this.comboPlats.Items.AddRange(new object[] {
            "inne",
            "ute"});
            this.comboPlats.Location = new System.Drawing.Point(565, 71);
            this.comboPlats.Name = "comboPlats";
            this.comboPlats.Size = new System.Drawing.Size(67, 28);
            this.comboPlats.TabIndex = 16;
            this.comboPlats.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(671, 72);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(250, 27);
            this.dateTimePicker1.TabIndex = 17;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // pictureHouse
            // 
            this.pictureHouse.Image = ((System.Drawing.Image)(resources.GetObject("pictureHouse.Image")));
            this.pictureHouse.Location = new System.Drawing.Point(346, 194);
            this.pictureHouse.Name = "pictureHouse";
            this.pictureHouse.Size = new System.Drawing.Size(385, 227);
            this.pictureHouse.TabIndex = 18;
            this.pictureHouse.TabStop = false;
            this.pictureHouse.Click += new System.EventHandler(this.pictureHouse_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 194);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(198, 29);
            this.button1.TabIndex = 21;
            this.button1.Text = "MedelTemperatur";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // btnVtK
            // 
            this.btnVtK.Location = new System.Drawing.Point(13, 247);
            this.btnVtK.Name = "btnVtK";
            this.btnVtK.Size = new System.Drawing.Size(198, 42);
            this.btnVtK.TabIndex = 22;
            this.btnVtK.Text = "Varmast till kallaste ";
            this.btnVtK.UseVisualStyleBackColor = true;
            this.btnVtK.Click += new System.EventHandler(this.btnVtK_Click);
            // 
            // btnTtF
            // 
            this.btnTtF.Location = new System.Drawing.Point(12, 321);
            this.btnTtF.Name = "btnTtF";
            this.btnTtF.Size = new System.Drawing.Size(199, 49);
            this.btnTtF.TabIndex = 23;
            this.btnTtF.Text = "Torrast till fuktigaste ";
            this.btnTtF.UseVisualStyleBackColor = true;
            this.btnTtF.Click += new System.EventHandler(this.btnTtF_Click);
            // 
            // MeteoHost
            // 
            this.MeteoHost.Location = new System.Drawing.Point(12, 456);
            this.MeteoHost.Name = "MeteoHost";
            this.MeteoHost.Size = new System.Drawing.Size(199, 52);
            this.MeteoHost.TabIndex = 25;
            this.MeteoHost.Text = "Datum för Meteorologisk Höst";
            this.MeteoHost.UseVisualStyleBackColor = true;
            this.MeteoHost.Click += new System.EventHandler(this.MeteoHost_Click);
            // 
            // MeteoVinter
            // 
            this.MeteoVinter.Location = new System.Drawing.Point(12, 524);
            this.MeteoVinter.Name = "MeteoVinter";
            this.MeteoVinter.Size = new System.Drawing.Size(199, 56);
            this.MeteoVinter.TabIndex = 26;
            this.MeteoVinter.Text = "Datum för Meteorologisk Vinter";
            this.MeteoVinter.UseVisualStyleBackColor = true;
            this.MeteoVinter.Click += new System.EventHandler(this.MeteoVinter_Click);
            // 
            // btnRiskförMögel
            // 
            this.btnRiskförMögel.Location = new System.Drawing.Point(13, 391);
            this.btnRiskförMögel.Name = "btnRiskförMögel";
            this.btnRiskförMögel.Size = new System.Drawing.Size(198, 43);
            this.btnRiskförMögel.TabIndex = 27;
            this.btnRiskförMögel.Text = "Minst till störst risk för mögel";
            this.btnRiskförMögel.UseVisualStyleBackColor = true;
            this.btnRiskförMögel.Click += new System.EventHandler(this.btnRiskförMögel_Click);
            // 
            // lblMeteoHost
            // 
            this.lblMeteoHost.AutoSize = true;
            this.lblMeteoHost.Location = new System.Drawing.Point(242, 472);
            this.lblMeteoHost.Name = "lblMeteoHost";
            this.lblMeteoHost.Size = new System.Drawing.Size(99, 20);
            this.lblMeteoHost.TabIndex = 30;
            this.lblMeteoHost.Text = "StartHostDag";
            this.lblMeteoHost.Click += new System.EventHandler(this.lblMeteoHost_Click);
            // 
            // lblStartVinterDag
            // 
            this.lblStartVinterDag.AutoSize = true;
            this.lblStartVinterDag.Location = new System.Drawing.Point(242, 542);
            this.lblStartVinterDag.Name = "lblStartVinterDag";
            this.lblStartVinterDag.Size = new System.Drawing.Size(105, 20);
            this.lblStartVinterDag.TabIndex = 31;
            this.lblStartVinterDag.Text = "StartVinterdag";
            this.lblStartVinterDag.Click += new System.EventHandler(this.lblStartVinterDag_Click);
            // 
            // dataGridView3
            // 
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Location = new System.Drawing.Point(848, 194);
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.RowHeadersWidth = 51;
            this.dataGridView3.RowTemplate.Height = 29;
            this.dataGridView3.Size = new System.Drawing.Size(564, 403);
            this.dataGridView3.TabIndex = 32;
            this.dataGridView3.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView3_CellContentClick);
            // 
            // lblGrid
            // 
            this.lblGrid.AutoSize = true;
            this.lblGrid.Location = new System.Drawing.Point(848, 151);
            this.lblGrid.Name = "lblGrid";
            this.lblGrid.Size = new System.Drawing.Size(88, 20);
            this.lblGrid.TabIndex = 33;
            this.lblGrid.Text = "Mögelindex";
            this.lblGrid.Click += new System.EventHandler(this.lblMogelindex_Click);
            // 
            // TempInneUte
            // 
            this.TempInneUte.ForeColor = System.Drawing.Color.Coral;
            this.TempInneUte.Location = new System.Drawing.Point(13, 92);
            this.TempInneUte.Name = "TempInneUte";
            this.TempInneUte.Size = new System.Drawing.Size(198, 79);
            this.TempInneUte.TabIndex = 34;
            this.TempInneUte.Text = "Differens mellan InneTemperatur och YtterTemperatur";
            this.TempInneUte.UseVisualStyleBackColor = true;
            this.TempInneUte.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(870, 657);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(531, 293);
            this.panel1.TabIndex = 35;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnBalkong1
            // 
            this.btnBalkong1.Location = new System.Drawing.Point(13, 599);
            this.btnBalkong1.Name = "btnBalkong1";
            this.btnBalkong1.Size = new System.Drawing.Size(198, 67);
            this.btnBalkong1.TabIndex = 36;
            this.btnBalkong1.Text = "Max InneTemperatur och Min YtterTemperatur";
            this.btnBalkong1.UseVisualStyleBackColor = true;
            this.btnBalkong1.Click += new System.EventHandler(this.btnBalkong1_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 692);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(111, 20);
            this.label5.TabIndex = 37;
            this.label5.Text = "Insert Sql query";
            this.label5.Click += new System.EventHandler(this.label5_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1550, 721);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnBalkong1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TempInneUte);
            this.Controls.Add(this.lblGrid);
            this.Controls.Add(this.dataGridView3);
            this.Controls.Add(this.lblStartVinterDag);
            this.Controls.Add(this.lblMeteoHost);
            this.Controls.Add(this.btnRiskförMögel);
            this.Controls.Add(this.MeteoVinter);
            this.Controls.Add(this.MeteoHost);
            this.Controls.Add(this.btnTtF);
            this.Controls.Add(this.btnVtK);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureHouse);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.comboPlats);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBoxTemp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnQuery);
            this.Controls.Add(this.textQuery);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.Väderdata);
            this.Name = "Form1";
            this.Text = "Luftigmedel";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureHouse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Väderdata;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textQuery;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxTemp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboPlats;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.PictureBox pictureHouse;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnVtK;
        private System.Windows.Forms.Button btnTtF;
        private System.Windows.Forms.Button MeteoHost;
        private System.Windows.Forms.Button MeteoVinter;
        private System.Windows.Forms.Button btnRiskförMögel;
        private System.Windows.Forms.Label lblMeteoHost;
        private System.Windows.Forms.Label lblStartVinterDag;
        private System.Windows.Forms.DataGridView dataGridView3;
        private System.Windows.Forms.Label lblGrid;
        private System.Windows.Forms.Button TempInneUte;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnBalkong1;
        private System.Windows.Forms.Label label5;
    }
}


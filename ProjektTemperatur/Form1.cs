using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Windows.Forms.DataVisualization.Charting;   // för att skapa en chart
using System.Data.SqlClient;


namespace ProjektTemperatur
{
    public partial class Form1 : Form
    {
        // Chart chart1 = new Chart();   
           
        Chart chart1;     // Deklarear objecten chart1      //  graf
        public Form1()                   // Constructor 
        {
            InitializeComponent();

            InitChart();                   // Inizialization  graf
        }

        private void Form1_Load(object sender, EventArgs e)    // Den blippar två gånger när solutionen lanseras 
        {
            Console.Beep();
            Console.Beep();

            // definierar format av dataTimerPicker 

            dateTimePicker1.Format = DateTimePickerFormat.Custom;
           
            dateTimePicker1.CustomFormat = "yyyy-MM-dd";    // skriver vilken datumformat jag vill ha 

            dateTimePicker1.MaxDate = EFMethods.MaxDatum();        // väljer vilket är Max datum som finns i databasen

            dateTimePicker1.MinDate = EFMethods.MinDatum();     // Minimun Datum som finns i databasen (det visas när vi väljaer datum)

            comboPlats.SelectedIndex = 0;     // om jag skriver 0 då får jag Inne. Annars Ute om skiven 1


        }

        private void InitChart()                // Metod  graf
        {
            this.chart1 = new Chart();
            var chartArea1 = new ChartArea();
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = DockStyle.Fill;
            this.chart1.Name = "Chart1";
            this.chart1.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            this.chart1.TabIndex = 0;
            panel1.Controls.Add(this.chart1);


        }

        public void SqlQuery(string query)
        {
            var dataS = Metoder.SqlQuery(query);    // dataS är dataset (tabellen) som vi får

            if(dataS != null) 
            
            {
                dataGridView3.DataSource = dataS;
                dataGridView3.DataMember = "datavarde";

            }  else { MessageBox.Show("insert query!"); }
        }



        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
               //  Inläsning av textfil till databasen 
        private void button1_Click(object sender, EventArgs e)  //     tar all data från cvs filen och lägger databasen
        {
            

               string FilNamn = textBox1.Text;

            if (File.Exists(FilNamn))
            {
                btnLoad.Enabled = false;

             //   EFMethods.InsertData1(FilNamn);             Långsammare alternativ     

                EFMethods.InsertData2(FilNamn);         //  4 gånger snabbare altenativ
            }

            else MessageBox.Show("File does not exist");
            btnLoad.Enabled = true;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

       


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnQuery_Click(object sender, EventArgs e)    // Execute  Sql query     
                                  
        {
            lblGrid.Text = "  Sql Query  ";

            SqlQuery(textQuery.Text);   // Skriver in en sql query i fältet
        }

        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

     

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {


           // string query = $"select format(AVG(Temp),'N1') from datavarde where datum = '{dateTimePicker1.Value}' and plats = '{comboPlats.SelectedItem}'";
           // textQuery.Text = query;

        }

        private void pictureHouse_Click(object sender, EventArgs e)
        {

        }       //   BILD  LÄGENHET

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Väderdata_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)              //  MEDELTEMPERATUR
        {
            

            float MedelTemp = EFMethods.MedelTempInUtomhus(dateTimePicker1.Value, comboPlats.SelectedItem.ToString());

            textBoxTemp.Text = MedelTemp.ToString("N1");
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btnVtK_Click(object sender, EventArgs e)      //  VARMAST TILL KALLASTE
        {
            using (var db = new ProjektarbeteContext())

            {
                lblGrid.Text = "Sortering av varmast till kallaste dagen enligt medeltemperatur per dag " + comboPlats.SelectedItem.ToString();

                dataGridView3.DataSource = EFMethods.VarmastTillKallasteUte(comboPlats.SelectedItem.ToString());     // lägger q i 
                dataGridView3.Columns["TempMedel"].DefaultCellStyle.Format = "0.#";  // 1.skriver kolumnnamn, 2.väljer med # hur många siffror efter kommatecken ska dyka upp  
            }
        }

        private void btnTtF_Click(object sender, EventArgs e)     // TORRAST TILL FUKTIGASTE    
        {
            using (var db = new ProjektarbeteContext())

            {
                lblGrid.Text = "Sortering av torrast till fuktigaste dagen enligt medelluftfuktighet per dag" + comboPlats.SelectedItem.ToString();

                dataGridView3.DataSource = EFMethods.TorrastTillfuktigaste(comboPlats.SelectedItem.ToString());
               dataGridView3.Columns["FuktMedel"].DefaultCellStyle.Format = "0.#";      

            }

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void MeteoHost_Click(object sender, EventArgs e)               //  METEOROLOGISK HÖST
        {
            DateTime StartHostDag = EFMethods.MeteorologiskHost();

            if (StartHostDag != DateTime.Parse("2099 12 12"))
             lblMeteoHost.Text = StartHostDag.ToString("yyyy MM dd"); 
            else MessageBox.Show(" StartHostDag ej Hittad ");
            
                
            
        }

        private void lblMeteoHost_Click(object sender, EventArgs e)
        {

        }

        private void MeteoVinter_Click(object sender, EventArgs e)             // METEOROLOGISK VINTER 
        {
            DateTime StartVinterDag = EFMethods.MeteorologiskVinter();          

            if (StartVinterDag != DateTime.Parse("2099 12 12"))
                lblStartVinterDag.Text = StartVinterDag.ToString("yyyy MM dd");
            else MessageBox.Show(" StartVinterDag ej Hittad ");
        }

        private void lblStartVinterDag_Click(object sender, EventArgs e)
        {
            //DateTime StartVinterDag = EFMethods.MeteorologiskVinter();

            //if (StartVinterDag != DateTime.Parse("2099 12 12"))
            //    lblStartVinterDag.Text = StartVinterDag.ToString("yyyy MM dd");
            //else MessageBox.Show(" StartVinterDag ej Hittad ");
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnRiskförMögel_Click(object sender, EventArgs e)           //  Minst till storst risk
        {
            lblGrid.Text = "Sortering av minst till störst risk för mögel  " + comboPlats.SelectedItem.ToString() + " i lägenheten";
            dataGridView3.DataSource = Fuktig.RiskForMogel(comboPlats.SelectedItem.ToString());    
            dataGridView3.Columns["TempMedel"].DefaultCellStyle.Format = "0.#";
            dataGridView3.Columns["fuktMedel"].DefaultCellStyle.Format = "0.#";
            dataGridView3.Columns["Mogelindex"].DefaultCellStyle.Format = "0.#";

            chart1.Series.Clear();
            var series1 = new Series();     // första  graf
            series1.Name = "graph1";
            series1.Color = Color.Red;
            series1.ChartType = SeriesChartType.Line;
            series1.XValueMember = dataGridView3.Columns[0].DataPropertyName;
            series1.YValueMembers = dataGridView3.Columns[1].DataPropertyName;
            chart1.Series.Add(series1);
            chart1.DataSource = dataGridView3.DataSource;
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void btnUte_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)    // Balkong      //   TempInUte     // diff Temperaturer Inne/ UT 
        {
            //  var tabTemp = Balkong.TabellTempInneUte(DateTime.Parse("2016-10-10"));

            lblGrid.Text = "Differens mellan InneTemperatur och YtterTemperatur av dagen : " + dateTimePicker1.Value.ToString("yyyy-MM-dd");

            var tabTemp = Balkong.MestMinst(dateTimePicker1.Value);
            dataGridView3.DataSource = tabTemp;




            //dataGridView3.ColumnCount = 2;

            //dataGridView3.Columns[0].Name = "dagdatum";
            //dataGridView3.Columns[1].Name = "diff";

            //dataGridView3.DataSource = tabTemp;

            //MessageBox.Show(tabTemp.ToString());
        }

        private void button2_Click_2(object sender, EventArgs e)
        {

        }

        private void btnBalkong1_Click(object sender, EventArgs e)         // Balkong +/-
        {
            lblGrid.Text = "Sortering på då inne och yttertemperaturen skiljt sig mest och minst" + dateTimePicker1.Value.ToString("yyyy-MM-dd");

            var tab = Balkong.MestMinst2(dateTimePicker1.Value);   

            dataGridView3.DataSource = tab;
            dataGridView3.Columns["diff"].DefaultCellStyle.Format = "0.#";


            //  Graph

            //var serie1 = new Series();
            //serie1.Color = Color.Blue;
            //serie1.ChartType = SeriesChartType.Line;
            //serie1.XValueMember = dataGridView3.Columns[0].DataPropertyName;
            //serie1.XValueMember = dataGridView3.Columns[2].DataPropertyName;
            //chart1.Series.Add(serie1);

            //var serie2 = new Series();
            //serie2.Color = Color.Red;
            //serie2.ChartType = SeriesChartType.Line;
            //serie2.XValueMember = dataGridView3.Columns[0].DataPropertyName;
            //serie2.XValueMember = dataGridView3.Columns[3].DataPropertyName;


            //chart1.Series.Add(serie2);
            //chart1.DataSource = dataGridView3.DataSource;




        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textQuery_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void lblMogelindex_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

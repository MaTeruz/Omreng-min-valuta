using System;
using System.Collections.Generic;
using System.Text.Json;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Omreng_min_valuta
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();         
        }
        
        public string[] getMoneyRates()
        {
            System.Net.WebClient wc = new System.Net.WebClient();
            string webData = wc.DownloadString("http://api.exchangeratesapi.io/v1/latest?access_key=1719511ede98606b617fa68112d65398");

            //Convert data to JSON represented in C#
            JObject radar = JObject.Parse(webData);

            //int[] newArray = new int[array.Length];

            string[] money =
            {
                radar.SelectToken("rates").SelectToken("EUR").ToString(),
                radar.SelectToken("rates").SelectToken("USD").ToString(),
                radar.SelectToken("rates").SelectToken("DKK").ToString(),
                radar.SelectToken("rates").SelectToken("NOK").ToString(),
                radar.SelectToken("rates").SelectToken("SEK").ToString()
            };
            return money;
        }

        public void updatemig(float guld, string currency)
        {

            //label5.Text = newRates[0];
            string[] newRates = getMoneyRates(); {}            
            

            float[] rates = new float[newRates.Length];
            for (int i = 0; i < newRates.Length; i++)
            {
                rates[i] = float.Parse(newRates[i]);
            }
            
            //Code prep fra array
            float dollers = float.Parse(newRates[1]);
            float dkKrone = float.Parse(newRates[2]);
            float nkKrone = float.Parse(newRates[3]);
            float skKrone = float.Parse(newRates[4]);

            //code prep fra array
            if (currency == "USD")  {guld = (guld / dollers);}
            if (currency == "DKK")  {guld = (guld / dkKrone);}
            if (currency == "NOK")  {guld = (guld / nkKrone);}
            if (currency == "SEK")  {guld = (guld / skKrone);}

            //Dis Euro
            Euro.Text = guld.ToString();
            Euro.Visible = true;

            //Euro Til USD            
            float uDol;
            uDol = (dollers * guld);
            USD.Text = uDol.ToString();
            USD.Visible = true;

            //Euro til DKK
            float Kro;
            Kro = (dkKrone * guld);
            DKK.Text = Kro.ToString();
            DKK.Visible = true;

            //Euro til NOK
            float nKro;
            nKro = (nkKrone * guld);
            NOK.Text = nKro.ToString();
            NOK.Visible = true;

            //Euro til SEK
            float sKro;
            sKro = (skKrone * guld);
            SEK.Text = sKro.ToString();
            SEK.Visible = true;
        }

        //Euro
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox1.Text )) 
            {
                //definere input fra textbox1
                float input = float.Parse(textBox1.Text);
                //kalder vores CLEAN function kald!!!
                updatemig(input, "");
            }
        }

        //USD
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox2.Text))
            {
                //definere input fra textbox1
                float input = float.Parse(textBox2.Text);          
                //kalder vores CLEAN function kald!!!
                updatemig(input, "USD");
            }
        }

        //DKK
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox3.Text))
            {                
                //definere input fra textbox1
                float input = float.Parse(textBox3.Text);
                //kalder vores CLEAN function kald!!!
                updatemig(input, "DKK");
            }
        }

        //NOK
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox4.Text))
            {
                //definere input fra textbox1
                float input = float.Parse(textBox4.Text);
                //kalder vores CLEAN function kald!!!
                updatemig(input, "NOK");
            }
        }

        //SEK
        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox5.Text))
            {
                float input = float.Parse(textBox5.Text);
                //kalder vores CLEAN function kald!!!
                updatemig(input, "SEK");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}

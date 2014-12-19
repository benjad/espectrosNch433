using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBoxcat.SelectedIndex = 0;//preseleccionamos los items para evitar error
            listBoxz.SelectedIndex = 0;
            listBoxs.SelectedIndex = 0;
            listBoxes.SelectedIndex = 0; 
        }

         string[] linesx = new string[120];  // variables publicas para guardar espectros
         string[] linesy = new string[120];

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string elemento = listBoxcat.SelectedIndex.ToString(); //convertir el indice en string
            
            if (elemento == "0")                                    //se compara el string  para asignar valor deseado
                textBoxcat.Text = "0.6";
            else
                if (elemento == "1")
                textBoxcat.Text = "1";
                else
                textBoxcat.Text = "1.2";
            
        }

        private void listBoxz_SelectedIndexChanged(object sender, EventArgs e)
        {
            string elemento1 = listBoxz.SelectedIndex.ToString(); //convertir el indice en string

            if (elemento1 == "0")                                    //se compara el string  para asignar valor deseado
                textBoxz.Text = "0.2";
            else
                if (elemento1 == "1")
                    textBoxz.Text = "0.3";
                else
                    textBoxz.Text = "0.4";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listBoxs_SelectedIndexChanged(object sender, EventArgs e)
        {
            string elemento2 = listBoxs.SelectedIndex.ToString(); //convertir el indice en string

            if (elemento2 == "0")                                    //se compara el string  para asignar valor deseado
            {
                textBoxs.Text = "0.9";
                textBoxs1.Text = "0.15";
                textBoxs2.Text = "0.2";
                textBoxs3.Text = "1";
                textBoxs4.Text = "2";
             }
        else{
                if (elemento2 == "1")
                {
                    textBoxs.Text = "1";
                    textBoxs1.Text = "0.3";
                    textBoxs2.Text = "0.35";
                    textBoxs3.Text = "1.33";
                    textBoxs4.Text = "1.5";
                }
                
                    if (elemento2 == "2")
                    {
                        textBoxs.Text = "1.05";
                        textBoxs1.Text = "0.4";
                        textBoxs2.Text = "0.45";
                        textBoxs3.Text = "1.4";
                        textBoxs4.Text = "1.6";
                        }
                   
                        if (elemento2 == "3")
                           {
                            textBoxs.Text = "1.2";
                            textBoxs1.Text = "0.75";
                            textBoxs2.Text = "0.85";
                            textBoxs3.Text = "1.8";
                            textBoxs4.Text = "1";
                            }
                       if (elemento2 == "4")
                            {
                            textBoxs.Text = "1.3";
                            textBoxs1.Text = "1.2";
                            textBoxs2.Text = "1.35";
                            textBoxs3.Text = "1.8";
                            textBoxs4.Text = "1";
                            }
                            }
                        
                       }

        private void listBoxes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string elemento3 = listBoxes.SelectedIndex.ToString(); //convertir el indice en string

            if (elemento3 == "0")                                    //se compara el string  para asignar valor deseado
                textBoxe.Text = "11";
            else
                if (elemento3 == "1")
                    textBoxe.Text = "4";
                else
                    if (elemento3 == "2")
                        textBoxe.Text = "11";
                    else
                        textBoxe.Text = "10";
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            double ry = 1 + (Convert.ToDouble(textBox2.Text)) / (0.1 * (Convert.ToDouble(textBoxs1.Text)) + (Convert.ToDouble(textBox2.Text)) / (Convert.ToDouble(textBoxe.Text)));//se genera el R*y
            double rx = 1 + (Convert.ToDouble(textBox1.Text)) / (0.1 * (Convert.ToDouble(textBoxs1.Text)) + (Convert.ToDouble(textBox1.Text)) / (Convert.ToDouble(textBoxe.Text)));//se genera el R*x
            
            double ss = Convert.ToDouble(textBoxs.Text);
            double to = Convert.ToDouble(textBoxs1.Text);
            double pp = Convert.ToDouble(textBoxs4.Text);
            double ao = Convert.ToDouble(textBoxz.Text);
            double ii = Convert.ToDouble(textBoxcat.Text);

           
            
            listBoxac.Items.Clear();// limpia la lista de valores anteriores
            listBoxac1.Items.Clear();// 
            Array.Clear(linesx, 0, linesx.Length);//limpia el array en el que es copiado en el texto
            Array.Clear(linesy, 0, linesx.Length);

            for (int contador = 0; contador <= linesx.Length - 1; contador++) 
            {
                string valor = listBoxt.GetItemText(listBoxt.Items[contador]);
                double tn = (Convert.ToDouble(valor));
                double alfa = (1+4.5*Math.Pow((tn/to),pp))/(1+Math.Pow((tn/to),3));
                double sa = Convert.ToDouble(ss * ao * alfa * ii / rx);
                string valors = Convert.ToString(sa);
               
                
                listBoxac.Items.Add(valors);
                linesx[contador] += listBoxt.GetItemText(listBoxt.Items[contador]) +"  "+listBoxt.GetItemText(listBoxac.Items[contador]);
                              
            }

            for (int contador = 0; contador <= linesy.Length-1 ; contador++)
            {
                string valor = listBoxt.GetItemText(listBoxt.Items[contador]);
                double tn = (Convert.ToDouble(valor));
                double alfa = (1 + 4.5 * Math.Pow((tn/to), pp)) / (1 + Math.Pow((tn / to), 3));
                double sa = Convert.ToDouble(ss * ao * alfa * ii / ry);
                string valors = Convert.ToString(sa);
                listBoxac1.Items.Add(valors);

                linesy[contador] += listBoxt.GetItemText(listBoxt.Items[contador]) + "  " + listBoxt.GetItemText(listBoxac1.Items[contador]);

            }

           
          
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string folderPath = "";
            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                folderPath = folderBrowserDialog1.SelectedPath;
                System.IO.File.WriteAllLines(@folderPath + @"\Ex.txt", linesx);  // crea los archivos de los espectros
                System.IO.File.WriteAllLines(@folderPath + @"\Ey.txt", linesy);
            }
            
            
        }

      

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxz_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void textBoxcat_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

/*
Oliver Gallo 000504-2916
oligal-1@student.ltu.se
Kurs: L0002B
*/
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Inlämnin1_Windows_Forms_App
{
    public partial class Form1 : Form
    {
        //Startar programmet
        public Form1()
        {
            InitializeComponent();
            richTextBox1.ReadOnly = true;
            richTextBox1.BackColor = Color.White;
        }

        //Buttonclikck metoden när man trycker på knappen
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //tar ut texterna och gör om till intar
                int first = int.Parse(textBox1.Text);
                int second = int.Parse(textBox2.Text);

                int result = second - first; //räknar ut resultaten

                if (result > 0)//om resultaten är större än 0 räkna och skriv ut resultatet för användaren 
                {
                    richTextBox1.Text = "Det här blev resultaten:\n\n";
                    CalculateResult(result);
                }
                else//annars skriv ut felmeddelande
                {
                    richTextBox1.Text = "Du kan inte betala mindre än vad det kostar\n";
                }
            }
            catch (Exception)//skulle boxarna lämnas tomma eller skrivas med text skriv ut felmeddelande
            {
                richTextBox1.Text = "Du kan inte Ge text för nummer eller lämna den tomt\n";
            }
        }

        //räknar ut resultaten och skriver ut det på skärmen
        private void CalculateResult(int price)
        {
            int femhundra = price / 500;
            price %= 500;
            if (femhundra > 0)
                richTextBox1.AppendText("Antal femhundra lappar: " + femhundra + '\n'+ '\n');

            int hundra = price / 100;
            price %= 100;
            if (hundra > 0)
                richTextBox1.AppendText("Antal hundra lappar: " + hundra + '\n' + '\n');


            int femtiolapp = price / 50;
            price %= 50;
            if (femtiolapp > 0)
                richTextBox1.AppendText("Antal femtio lappar: " + femtiolapp + '\n' + '\n');


            int tjugolapp = price / 20;
            price %= 20;
            if (tjugolapp > 0)
                richTextBox1.AppendText("Antal tjugo lappar: " + tjugolapp + '\n' + '\n');

            int tio = price / 10;
            price %= 10;
            if (tio > 0)
                richTextBox1.AppendText("Antal tio kroner: " + tio + '\n' + '\n');

            int fem = price / 5;
            price %= 5;
            if (fem > 0)
                richTextBox1.AppendText("Antal fem kroner: " + fem + '\n' + '\n');

            int ett = price / 1;
            price %= 1;
            if (ett > 0)
                richTextBox1.AppendText("Antal ett kroner: " + ett + '\n' + '\n');
        }


        /*
         
         Resten av koden här används inte men behövs för komponenterna
         
         */
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

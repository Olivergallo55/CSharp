/*
Oliver Gallo 000504-2916
oligal-1@student.ltu.se
Kurs: L0002B
*/
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Inlämning_3
{
    public partial class Form1 : Form
    {
        private RichTextBox n;
        private TextBox firstName, lastName, prNummer; 

        public Form1() 
        {
            InitializeComponent();
            CreateGUI();
        }

        //Create the GUI of the interface
        private void CreateGUI()
        {
            CreateText1();
            CreateText2();
            CreateText3();
            CreateRichTextBox();
        }     

        //Creates the first textbox and adds it to the contol
        private void CreateText1()
        {
            firstName = new TextBox
            {
                Location = new Point(98, 40),
                Width = 145,
                Height = 26,
                BackColor = Color.White
            };
            Controls.Add(firstName);
        }

        //Creates the second textbox and adds it to the contol
        private void CreateText2()
        {
            lastName = new TextBox
            {
                Location = new Point(98, 85),
                Width = 145,
                Height = 26,
                BackColor = Color.White
            };
            Controls.Add(lastName);
        }

        //Creates the third textbox and adds it to the contol
        private void CreateText3()
        {
            prNummer = new TextBox
            {
                Location = new Point(98, 130),
                Width = 145,
                Height = 26,
                BackColor = Color.White
            };
            Controls.Add(prNummer);
        }

        //Create the richTextbox where the result will be printed
        public void CreateRichTextBox()
        {
            n = new RichTextBox
            {
                ReadOnly = true,
                Width = 250,
                Height = 150,
                Location = new Point(50, 180),
                BackColor = Color.White
            };
            Controls.Add(n);
        }
      
        //Functions for the button to do when its clicked
        private void button1_Click_1(object sender, EventArgs e)
        {
            string firstname = "";
            string lastname = "";
            string gender = "";
            long pr = 0;
            Person pers = new Person();

                n.ForeColor = Color.Red; //sets the printed text to red
            if (!String.IsNullOrEmpty(firstName.Text) && !String.IsNullOrEmpty(lastName.Text) && !String.IsNullOrEmpty(prNummer.Text)) //checks if either one of the boxes are empty if they are it gives error message
            {
                firstname = firstName.Text;
                lastname = lastName.Text;

                //try to read the peronnummer and vontroll gender if the number is incorrect and button will be inaccesable, if not a number was input then start over by clearing everything
                try
                {
                    pr = long.Parse(prNummer.Text);
                    gender = pers.ControllGender(pr);
                    if (pers.ControlPrnr(prNummer.Text) && prNummer.Text.Length == 10)
                    {
                        n.AppendText("Korrekt Personnummer\n\n");
                        Person p = new Person(firstname, lastname, prNummer.Text, gender);
                        n.AppendText(p.ToString()); //print out the object using its ToString method
                    }else
                        n.Text = "Inte Korrekt personnummer";
                }
                catch (Exception)
                {
                    n.Text = "Personnumret måste ha ett nummeriskt värde!\nRensa och försök igen";
                    button1.Enabled = false;
                }
            }
            else
            {
                n.Text = "Lämna inte nån av textBoxarna tomma!\nRensa och gör igen";
                button1.Enabled = false;
            }
            button1.Enabled = false;
        }

        //Button action, clears everything and enables the OK button again so that it works
        private void button2_Click(object sender, EventArgs e)
        {
            firstName.Text = "";
            lastName.Text = "";
            prNummer.Text = "";
            n.Text = "";
            button1.Enabled = true;
        }             
    } 
}

class Person
{
    string firstname, lastname, gender;
    string personnummer;

    public Person() { }

    public Person(string firstname, string lastname, string personnummer, string gender)
    {
        this.firstname = firstname;
        this.lastname = lastname;
        this.personnummer = personnummer;
        this.gender = gender;
    }

    //Method to controll the gender, read in the input as an integer value and divide 
    public string ControllGender(long prNr)
    {
        /*
        if (prNr / 10 % 2 == 0)    //divide prNr by 10 to take away the last number and modulo 2 to see if its even    
            gender = "KVINNA";     //if even the gender is woman     
        else           
            gender = "MAN"; //and if its uneven the gender is man
        */
        return prNr / 10 % 2 == 0 ? "Kvinna" : "Man"; //return the gender on the screen
    }

    //Uses Lunhs algorithm to see if the personalnumber is correct or not
    public bool ControlPrnr(String prNr)
    {
        int sum = 0;
        bool isSecondNumber = false; //check if its a second number or not

        for (int i = prNr.Length - 1; i >= 0; i--) //goes through the personalnumber from the end
        {

            int current = prNr[i] - '0'; // to get the nummeric value at the current number of the string

            if (isSecondNumber == true)//if its a second number
                current *= 2;//then multiply the current numbers value

            sum += current / 10;  //divide the number with 10 (used for double digits, where the value is over 10, otherwise the value will be 0)
            sum += current % 10;  //used for the simple digits, if the vale us is 15, it will add 5 to the sum or if the current value is 5 it will add 5 to the sum

            isSecondNumber = !isSecondNumber;//if its a secondNumber then make it a fist number
        }
        return (sum % 10 == 0); //returns if the end number is equaly dividable                        
    }


    //method to print out the person corecctly
    public override string ToString()
    {         
        return "Förnamn: " + firstname  + "\n\n" + "Efternamn: " + lastname + "\n\n" + "Personnummer: " + personnummer + "\n\n" + "Kön: " + gender;
    }

}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thesisProject
{
    public partial class Form1 : Form
    {
        private string personalIdenitityNumberRegex ="^(?:19|[2-9][0-9]){0,1}(?:[0-9]{2})(?!0229|0230|0231|0431|0631|0931|1131)(?:(?:0[1-9])|(?:1[0-2]))(?:(?:0[1-9])|(?:1[0-9])|(?:2[0-9])|(?:3[01]))[-+](?!0000)(?:[0-9]{4})$";
        private string userInputMustBeIdentityNumber = "Must be a personal number, e.g. 12345678-9101";

        public Form1()
        {
            InitializeComponent();
            this.MaximizeBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tabControl1.TabPages.RemoveAt(tabControl1.SelectedIndex); //get the selected index
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int? index = checkIfUserHasAlreadyPicked(textBox1.Text); //check if user already exists. 
            if (index == null)
            {
                isPersonalEdentityNumber(textBox1.Text); //get input, check if its number 

            }
            else
            {
                tabControl1.SelectedIndex = Convert.ToInt32(index); //if tab exist, go to it!
            }
        }

        private int? checkIfUserHasAlreadyPicked(string textFromUser)
        {
            int? indexTab = null;
            foreach (TabPage tab in tabControl1.TabPages)
            {
                if (tab.Text == textFromUser)
                {
                    indexTab = tabControl1.TabPages.IndexOf(tab);

                }
            }
            return indexTab;
        }

        private bool isPersonalEdentityNumber(string textFromUser)
        {
            bool isValid;
            Match match = Regex.Match(textFromUser, personalIdenitityNumberRegex); //check if personalnumber
            if (!match.Success)
            {
                MessageBox.Show(userInputMustBeIdentityNumber);
                isValid = false;
            }
            else
            {
                tabControl1.TabPages.Add(textFromUser);
                addTabContent(textFromUser); //this class could for example get content from a db, based on the personal Identity Number.... in my case its dummy content
                isValid = true;
            }
            return isValid;
        }

        //huge method with dummy content to fill the labels, only for displaying purposes.
        private void addTabContent(string textFromUser)
        {
            Label personalIdentityNumberLabel = new Label();
            personalIdentityNumberLabel.Location = new System.Drawing.Point(238, 60);
            personalIdentityNumberLabel.Size = new System.Drawing.Size(50, 10);
            personalIdentityNumberLabel.Name = "IdentityNumber";
            personalIdentityNumberLabel.Text = "Personal Identity Number";
            personalIdentityNumberLabel.Font = Font;
            personalIdentityNumberLabel.AutoSize = true;
            tabControl1.TabPages.OfType<TabPage>().Last().Controls.Add(personalIdentityNumberLabel);

            TextBox personalIdentityNumberTextBox = new TextBox();
            personalIdentityNumberTextBox.Location = new System.Drawing.Point(240, 80);
            personalIdentityNumberTextBox.Size = new System.Drawing.Size(190, 30);
            personalIdentityNumberTextBox.ReadOnly = true;
            personalIdentityNumberTextBox.Name = "personalIdentityNumberTextBox";
            personalIdentityNumberTextBox.Text = textFromUser;
            tabControl1.TabPages.OfType<TabPage>().Last().Controls.Add(personalIdentityNumberTextBox);

            Label nameLabel = new Label();
            nameLabel.Location = new System.Drawing.Point(238, 110);
            nameLabel.Size = new System.Drawing.Size(50, 10);
            nameLabel.Name = "UserName";
            nameLabel.Text = "Name";
            nameLabel.Font = Font;
            nameLabel.AutoSize = true;
            tabControl1.TabPages.OfType<TabPage>().Last().Controls.Add(nameLabel);

            TextBox nameTextBox = new TextBox();
            nameTextBox.Location = new System.Drawing.Point(240, 130);
            nameTextBox.Size = new System.Drawing.Size(190, 30);
            nameTextBox.ReadOnly = true;
            nameTextBox.Name = "NameTextBox";
            nameTextBox.Text = "insert name from db";
            tabControl1.TabPages.OfType<TabPage>().Last().Controls.Add(nameTextBox);

            Label ageLabel = new Label();
            ageLabel.Location = new System.Drawing.Point(238, 160);
            ageLabel.Size = new System.Drawing.Size(50, 10);
            ageLabel.Name = "UserAge";
            ageLabel.Text = "Age";
            ageLabel.Font = Font;
            ageLabel.AutoSize = true;
            tabControl1.TabPages.OfType<TabPage>().Last().Controls.Add(ageLabel);

            TextBox ageTextBox = new TextBox();
            ageTextBox.Location = new System.Drawing.Point(240, 180);
            ageTextBox.Size = new System.Drawing.Size(190, 30);
            ageTextBox.ReadOnly = true;
            ageTextBox.Name = "AgeTextBox";
            ageTextBox.Text = "insert age from db";
            tabControl1.TabPages.OfType<TabPage>().Last().Controls.Add(ageTextBox);

            Label something1Label = new Label();
            something1Label.Location = new System.Drawing.Point(238, 210);
            something1Label.Size = new System.Drawing.Size(50, 10);
            something1Label.Name = "something1Label";
            something1Label.Text = "PlaceHolder";
            something1Label.Font = Font;
            something1Label.AutoSize = true;
            tabControl1.TabPages.OfType<TabPage>().Last().Controls.Add(something1Label);

            TextBox something1TextBox = new TextBox();
            something1TextBox.Location = new System.Drawing.Point(240, 230);
            something1TextBox.Size = new System.Drawing.Size(190, 30);
            something1TextBox.ReadOnly = true;
            something1TextBox.Name = "something1TextBox";
            something1TextBox.Text = "Something is here";
            tabControl1.TabPages.OfType<TabPage>().Last().Controls.Add(something1TextBox);

            Label something2Label = new Label();
            something2Label.Location = new System.Drawing.Point(238, 260);
            something2Label.Size = new System.Drawing.Size(50, 10);
            something2Label.Name = "something2Label";
            something2Label.Text = "PlaceHolder";
            something2Label.Font = Font;
            something2Label.AutoSize = true;
            tabControl1.TabPages.OfType<TabPage>().Last().Controls.Add(something2Label);

            TextBox something2TextBox = new TextBox();
            something2TextBox.Location = new System.Drawing.Point(240, 280);
            something2TextBox.Size = new System.Drawing.Size(190, 30);
            something2TextBox.ReadOnly = true;
            something2TextBox.Name = "something2TextBox";
            something2TextBox.Text = "This is something";
            tabControl1.TabPages.OfType<TabPage>().Last().Controls.Add(something2TextBox);
        }
    }
}

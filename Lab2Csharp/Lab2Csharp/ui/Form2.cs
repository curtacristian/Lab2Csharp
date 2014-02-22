using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab2Csharp.controller;

namespace Lab2Csharp.ui
{
    partial class Form2 : Form
    {
        private TextBox id = new TextBox();
        private TextBox name = new TextBox();
        private TextBox grade1 = new TextBox();
        private TextBox grade2 = new TextBox();
        private TextBox grade3 = new TextBox();
        private TextBox thesis = new TextBox();
        private TextBox supervisor = new TextBox();
        private Label lid = new Label();
        private Label lname = new Label();
        private Label lgrade1 = new Label();
        private Label lgrade2 = new Label();
        private Label lgrade3 = new Label();
        private Label lthesis = new Label();
        private Label lsupervisor = new Label();
        private Controller cont;
        private Button addData = new Button();
        private ComboBox chooseType = new ComboBox();
        

        public Form2(Controller cont)
        {
            this.chooseType.Items.Add("Normal");
            this.chooseType.Items.Add("UnderGraduate");
            this.chooseType.Items.Add("Graduate");
            this.chooseType.Items.Add("PhD");
            this.chooseType.DropDownStyle = ComboBoxStyle.DropDownList;
            
            this.chooseType.Location = new Point(15, 15);
            this.chooseType.Size = new Size(125, 25);
            this.addData.Text = "Add the data to repository";
            this.addData.Location = new Point(150, 15);
            this.addData.Size = new Size(125, 25);
           
            this.Text = "Student Add";
            this.Size = new Size(350, 350);
            this.cont = cont;
            this.id.Location = new Point(100, 45);
            this.name.Location = new Point(100, 75);
            this.grade1.Location = new Point(100, 105);
            this.grade2.Location = new Point(100, 135);
            this.grade3.Location = new Point(100, 165);
            this.thesis.Location = new Point(100, 195);
            this.supervisor.Location = new Point(100, 225);
            this.lid.Location = new Point(15, 45); this.lid.Text = "ID:";
            this.lname.Location = new Point(15, 75); this.lname.Text = "NAME:";
            this.lgrade1.Location = new Point(15, 105); this.lgrade1.Text = "Grade1:";
            this.lgrade2.Location = new Point(15, 135); this.lgrade2.Text = "Grade2:";
            this.lgrade3.Location = new Point(15, 165); this.lgrade3.Text = "Grade3:";
            this.lthesis.Location = new Point(15, 195); this.lthesis.Text = "Thesis:";
            this.lsupervisor.Location = new Point(15, 225); this.lsupervisor.Text = "Supervisor:";
            this.Controls.Add(addData);
            this.Controls.Add(chooseType);
            this.Controls.Add(id);
            this.Controls.Add(name);
            this.Controls.Add(grade1);
            this.Controls.Add(grade2);
            this.Controls.Add(grade3);
            this.Controls.Add(thesis);
            this.Controls.Add(supervisor);
            this.Controls.Add(lid);
            this.Controls.Add(lname);
            this.Controls.Add(lgrade1);
            this.Controls.Add(lgrade2);
            this.Controls.Add(lgrade3);
            this.Controls.Add(lthesis);
            this.Controls.Add(lsupervisor);
            addEvents();

            InitializeComponent();
        }

        public void addEvents()
        {
            this.chooseType.SelectedValueChanged += chooseType_SelectedValueChanged;
            this.addData.Click += addData_Click;
        }

        void addData_Click(object sender, EventArgs e)
        {
            if (chooseType.Text == "Normal")
            {
                this.cont.push(Convert.ToInt32(id.Text), name.Text, Convert.ToInt32(grade1.Text));
            }
            if (chooseType.Text == "Graduate")
            {
                this.cont.push(Convert.ToInt32(id.Text), name.Text, Convert.ToInt32(grade1.Text), Convert.ToInt32(grade2.Text), Convert.ToInt32(grade3.Text),supervisor.Text);
            }
            if (chooseType.Text == "UnderGraduate")
            {
                this.cont.push(Convert.ToInt32(id.Text), name.Text, Convert.ToInt32(grade1.Text),Convert.ToInt32(grade2.Text));
            }
            if (chooseType.Text == "PhD")
            {
                this.cont.push(Convert.ToInt32(id.Text), name.Text, Convert.ToInt32(grade1.Text), Convert.ToInt32(grade2.Text), thesis.Text, supervisor.Text);
            }
        }

        void chooseType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (chooseType.Text == "Normal")
            {
                this.name.Enabled = true;
                this.grade1.Enabled = true;
                this.grade2.Enabled = false;
                this.grade3.Enabled = false;
                this.thesis.Enabled = false;
                this.supervisor.Enabled = false;
            }
            if (chooseType.Text == "Graduate")
            {
                this.name.Enabled = true;
                this.grade1.Enabled = true;
                this.grade2.Enabled = true;
                this.grade3.Enabled = true;
                this.thesis.Enabled = false;
                this.supervisor.Enabled = true;
            }
            if (chooseType.Text == "UnderGraduate")
            {
                this.name.Enabled = true;
                this.grade1.Enabled = true;
                this.grade2.Enabled = true;
                this.grade3.Enabled = false;
                this.thesis.Enabled = false;
                this.supervisor.Enabled = false;
            }
            if (chooseType.Text == "PhD")
            {
                this.name.Enabled = true;
                this.grade1.Enabled = true;
                this.grade2.Enabled = true;
                this.grade3.Enabled = false;
                this.thesis.Enabled = true;
                this.supervisor.Enabled = true;
            }
        }
    }
}

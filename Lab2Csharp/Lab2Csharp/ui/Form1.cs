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
    
    partial class Form1 : Form
    {
        private Button ShowStudents=new Button();
        private Button addStudent = new Button();
        private ComboBox typesOfStudents=new ComboBox();
        private ListView students = new ListView();
        private Controller cont;
        private int type;

        public Form1(Controller cont)
        {
            this.Text = "Student Manager";
            this.Size = new Size(500, 500);
            this.cont = cont;
            this.type = 0;
            this.ShowStudents.Text = "Show Students";
            this.addStudent.Text = "Add a new student";
            this.typesOfStudents.Items.Add("All students");
            this.typesOfStudents.Items.Add("Grade under 5");
            this.typesOfStudents.Items.Add("Grade above 5");
            this.typesOfStudents.Items.Add("Grade is 10");
            this.typesOfStudents.SelectedItem = 0;
            this.ShowStudents.Location= new Point(15, 15);
            this.ShowStudents.Size = new Size(75, 25);
            this.addStudent.Location = new Point(100, 15);
            this.addStudent.Size = new Size(75, 25);
            this.typesOfStudents.Location = new Point(15, 45);
            this.typesOfStudents.Size = new Size(100, 40);
            this.typesOfStudents.DropDownStyle = ComboBoxStyle.DropDownList;
            this.students.Location = new Point(15, 75);
            this.students.Size = new Size(350, 350);
            this.students.Columns.Add("type", -2);
            this.students.Columns.Add("id", -2);
            this.students.Columns.Add("name", -2);
            this.students.Columns.Add("grade1", -2);
            this.students.Columns.Add("grade2", -2);
            this.students.Columns.Add("grade3", -2);
            this.students.Columns.Add("thesis", -2);
            this.students.Columns.Add("supervisor", -2);
            this.students.FullRowSelect = true;
            this.students.View = View.Details;
            this.students.GridLines = true;
            this.Controls.Add(addStudent);
            this.Controls.Add(ShowStudents);
            this.Controls.Add(typesOfStudents);
            this.Controls.Add(students);
            addEvents();
            InitializeComponent();
        }
        public void addEvents()
        {
            ShowStudents.Click += ShowStudents_Click;
            addStudent.Click+=addStudent_Click;
            typesOfStudents.SelectedValueChanged += typesOfStudents_SelectedValueChanged;

        }

        void typesOfStudents_SelectedValueChanged(object sender, EventArgs e)
        {
            if (typesOfStudents.Text == "All students")
            {
                this.students.Items.Clear();
                type = 0;
                ShowStudents_Click(this, new EventArgs());
            }


            if (typesOfStudents.Text == "Grade under 5")
            {
                this.students.Items.Clear();
                type = 1;
                ShowStudents_Click(this,new EventArgs());

            }
            if (typesOfStudents.Text == "Grade above 5")
            {
                this.students.Items.Clear();
                type = 2;
                ShowStudents_Click(this, new EventArgs());

            }
            if (typesOfStudents.Text == "Grade is 10")
            {
                this.students.Items.Clear();
                type = 3;
                ShowStudents_Click(this, new EventArgs());

            }

        }

        void addStudent_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2(this.cont);
            f.ShowDialog();
        }
        void ShowStudents_Click(object sender, EventArgs e)
        {
            this.students.Items.Clear();
            Student[] all = this.cont.getAllStudents();
            
            for (int i = 0; i < all.Length;i++ )
            {
     
                if (Convert.ToString(all[i].GetType()) == "Lab2Csharp.Student")
                {
                    ListViewItem it = new ListViewItem("Normal");
                    it.SubItems.Add(Convert.ToString(all[i].getID()));
                    it.SubItems.Add(all[i].getName());
                    it.SubItems.Add(Convert.ToString(all[i].getGrade()));
                    if (type == 0) this.students.Items.Add(it);
                    if (type == 1 && (all[i].average() < 5)) this.students.Items.Add(it);
                    if (type == 2 && (all[i].average() > 5)) this.students.Items.Add(it);
                    if (type == 3 && (all[i].average()==10)) this.students.Items.Add(it);

                    
                }
                if (Convert.ToString(all[i].GetType()) == "Lab2Csharp.UndergraduateStudent")
                {
                    ListViewItem it = new ListViewItem("Under");
                    UndergraduateStudent u;
                    u = (UndergraduateStudent)(all[i]);
                    it.SubItems.Add(Convert.ToString(all[i].getID()));
                    it.SubItems.Add(all[i].getName());
                    it.SubItems.Add(Convert.ToString(all[i].getGrade()));
                    it.SubItems.Add(Convert.ToString(u.getGrade2()));
                    if (type == 0) this.students.Items.Add(it);
                    if (type == 1 && (u.average() < 5)) this.students.Items.Add(it);
                    if (type == 2 && (u.average() > 5)) this.students.Items.Add(it);
                    if (type == 3 && (u.average() == 10)) this.students.Items.Add(it);
                }
                if (Convert.ToString(all[i].GetType()) == "Lab2Csharp.GraduateStudent")
                {
                    ListViewItem it = new ListViewItem("Grad");
                    GraduateStudent u;
                    u = (GraduateStudent)(all[i]);
                    it.SubItems.Add(Convert.ToString(all[i].getID()));
                    it.SubItems.Add(all[i].getName());
                    it.SubItems.Add(Convert.ToString(all[i].getGrade()));
                    it.SubItems.Add(Convert.ToString(u.getGrade2()));
                    it.SubItems.Add(Convert.ToString(u.getGrade3()));
                    it.SubItems.Add("");
                    it.SubItems.Add(u.getSupervisor());
                    if (type == 0) this.students.Items.Add(it);
                    if (type == 1 && (u.average() < 5)) this.students.Items.Add(it);
                    if (type == 2 && (u.average() > 5)) this.students.Items.Add(it);
                    if (type == 3 && (u.average() == 10)) this.students.Items.Add(it);
                }
                if (Convert.ToString(all[i].GetType()) == "Lab2Csharp.PhDStudent")
                {
                    ListViewItem it = new ListViewItem("PhD");
                    PhDStudent u;
                    u = (PhDStudent)(all[i]);
                    it.SubItems.Add(Convert.ToString(all[i].getID()));
                    it.SubItems.Add(all[i].getName());
                    it.SubItems.Add(Convert.ToString(all[i].getGrade()));
                    it.SubItems.Add(Convert.ToString(u.getGrade2()));
                    it.SubItems.Add("");
                    it.SubItems.Add(u.getThesis());
                    it.SubItems.Add(u.getSupervisor());

                    if (type == 0) this.students.Items.Add(it);
                    if (type == 1 && (u.average() < 5)) this.students.Items.Add(it);
                    if (type == 2 && (u.average() > 5)) this.students.Items.Add(it);
                    if (type == 3 && (u.average() == 10)) this.students.Items.Add(it);
                }

            }
        }
        

    }
}


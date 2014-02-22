using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2Csharp.controller;
using Lab2Csharp.repository;
using System.IO;
using System.Windows.Forms;


namespace Lab2Csharp.ui
{
    class Ui
    {
        private Controller cont;
        private String filename;

	
	    public Ui(){
		    this.cont=null;
            this.filename = "";
	    }
	
	    public void setCont(Controller c,String f){
		    this.cont=c;
            this.filename = f;
	    }

        public Controller getCont()
        {
            return this.cont;
        }

	    public void printMenu(){
		    Console.WriteLine("\nApplication Menu");
		    Console.WriteLine("1.Add Student");
		    Console.WriteLine("2.Delete until grade 10 appears");
		    Console.WriteLine("3.Total number of Students");
		    Console.WriteLine("4.Print Students");
            Console.WriteLine("5.Number of students greater than");
            Console.WriteLine("6.Move from a stack to another");
            Console.WriteLine("7.Read students from file");
            Console.WriteLine("8.Write repository to file");
		    Console.WriteLine("13.Quit Application");
	    }
        public bool isInteger(String s)
        {
            try
            {
                Convert.ToInt32(s);
            }
            catch(Exception e) 
            {
                return false;
            }
            return true;
        }


  

        public void readFromFile()
        {
            String line,name,supervisor,thesis;
            int id, grade, grade2, grade3;
            String[] tokens;
            try
            {
                StreamReader sr = new StreamReader(this.filename);
                line=sr.ReadLine();
                while(line != null){
					tokens = line.Split();
					switch (tokens.Length){
						case 3:
							id=Convert.ToInt32(tokens[0]);
							name = Convert.ToString(tokens[1]);
							grade= Convert.ToInt32(tokens[2]);
							try{
								this.cont.push(id, name, grade);
							}
							catch (Exception msg)
                            {
                                if (msg is MyException || msg is StackException)
                                {
                                    Console.WriteLine("{0}", msg.Message);
                                }
                            }
							break;
						case 4:
                            id = Convert.ToInt32(tokens[0]);
							name = Convert.ToString(tokens[1]);
                            grade = Convert.ToInt32(tokens[2]);
                            grade2 = Convert.ToInt32(tokens[3]);
							try{
								this.cont.push(id, name, grade,grade2);
							}
							catch (Exception msg)
                            {
                                if (msg is MyException || msg is StackException)
                                {
                                    Console.WriteLine("{0}", msg.Message);
                                }
                            }
							break;
						case 6:
                            id = Convert.ToInt32(tokens[0]);
							name = Convert.ToString(tokens[1]);
                            grade = Convert.ToInt32(tokens[2]);
							grade2=Convert.ToInt32(tokens[3]);
                            if (isInteger(tokens[4]))
                            {
                                grade3 = Convert.ToInt32(tokens[4]);
                                supervisor = Convert.ToString(tokens[5]);
                                try
                                {
                                    this.cont.push(id, name, grade, grade2, grade3, supervisor);
                                }
                                catch (Exception msg)
                                {
                                    if (msg is MyException || msg is StackException)
                                    {
                                        Console.WriteLine("{0}", msg.Message);
                                    }

                                }
                            }
                            else
                            {
                                thesis = Convert.ToString(tokens[4]);
                                supervisor = Convert.ToString(tokens[5]);
                                try
                                {
                                    this.cont.push(id, name, grade, grade2, thesis, supervisor);
                                }
                                catch (Exception msg)
                                {
                                    if (msg is MyException || msg is StackException)
                                    {
                                        Console.WriteLine("{0}", msg.Message);
                                    }
                                }
                            }
							 break;
						default:
							break;
					}
                    line = sr.ReadLine();
                }
                sr.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Succesfully read from file!!!");
            }
        }

        public void writeToFile()
        {
            try
            {
                StreamWriter sw = new StreamWriter(this.filename);
                String [] all=new String[this.cont.getSize()];
			    try{
				    all=this.cont.allToString();
			    }
                catch (Exception msg)
                {
                    if (msg is MyException || msg is StackException)
                    {
                        Console.WriteLine("{0}", msg.Message);
                    }
                }
			    for(int i=0;i<all.Length;i++){
			        sw.WriteLine(all[i]+"\n");
			    }
                
                sw.Close();    
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Sucessfully wrote to file!!");
            }
            

        }
	 
	    public void printStudents(){
		        Student [] all=new Student [this.cont.getSize()];
		        try{
			        all=this.cont.getAllStudents();
		        }
		        catch (Exception e){
                    if(e is MyException || e is StackException){
			            Console.WriteLine(e.Message);
			            return;
                    }
		        }
		        Console.Write("TYPE | ID | NAME |GRADE | GRADE2 | GRADE3 | THESIS | SUPERVISOR\n____________________________________________\n");
		        int i=0;
		        while(i<this.cont.getSize()){
			        Console.Write("{0}\n", all[i].toString());
			        i++;
		        }
	    }
        public String printUIStudents()
        {
            Student[] all = new Student[this.cont.getSize()];
            try
            {
                all = this.cont.getAllStudents();
            }
            catch (Exception e)
            {
                if (e is MyException || e is StackException)
                {
                    Console.WriteLine(e.Message);
                    return "";
                }
            }
            String msg="";
            msg+="TYPE | ID | NAME |GRADE | GRADE2 | GRADE3 | THESIS | SUPERVISOR\n____________________________________________\n";
            int i = 0;
            while (i < this.cont.getSize())
            {
                msg += all[i].toString();
                i++;
            }
            return msg;
        }

        public void readStudent()
        {
                int id=0,grade=0,grade2=0,grade3=0,choice;
                String name="",thesis="",supervisor="",valid="";
                Student s = new Student();
                Console.Write("ID:");
                id = Convert.ToInt32(Console.ReadLine());
                Console.Write("Grade:");
                grade = Convert.ToInt32(Console.ReadLine());
                Console.Write("Name:");
                name = Convert.ToString(Console.ReadLine());
                Console.WriteLine("Student Type\n1.Normal student\n2.Undergraduate student\n3.GraduateStudent\n4.PhD Student\nYour Choice:");
		        choice=Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        try
                        {
                            valid = this.cont.push(id, name, grade);
                        }
                        catch (StackException e)
                        {
                            Console.Write(e.Message);
                        }
                        if (!valid.Equals(""))
                            Console.Write("Errors at adding:\n{0}", valid);
                        break;
                    case 2:
                        Console.Write("Grade2:");
                        grade2 = Convert.ToInt32(Console.ReadLine());
                        try
                        {
                            valid = this.cont.push(id, name, grade, grade2);
                        }
                        catch (StackException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        if (!valid.Equals(""))
                            Console.Write("Errors at adding:\n{0}", valid);
                        break;
                    case 3:
                        Console.Write("Grade2:");
                        grade2 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Grade3:");
                        grade3 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Supervisor:");
                        supervisor = Convert.ToString(Console.ReadLine());
                        try
                        {
                            valid = this.cont.push(id, name, grade, grade2, grade3, supervisor);
                        }
                        catch (StackException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        if (!valid.Equals(""))
                            Console.Write("Errors at adding:\n{0}", valid);
                        break;
                    case 4:
                        Console.Write("Grade2:");
                        grade2 = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Supervisor:");
                        supervisor = Convert.ToString(Console.ReadLine());
                        Console.Write("Thesis:");
                        thesis = Convert.ToString(Console.ReadLine());

                        try
                        {
                            valid = this.cont.push(id, name, grade, grade2, supervisor, thesis);
                        }
                        catch (StackException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        if (!valid.Equals(""))
                            Console.Write("Errors at adding:\n{0}", valid);
                        break;
                    default:
                        Console.WriteLine("Wrong choice!");
                        break;
                }
        }

	
	    public void runUI(){
            int choice = 0;
            int id = 0;
		    Student x=new Student();
		    bool b=true;
            


		    while(b){
			    printMenu();
			    Console.Write("Your Choice:");
                try
                {
                    choice = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception msg){
                    Console.WriteLine("{0}", msg.Message);
                }
			    switch(choice){
			    case 1:
				    readStudent();
                    break;
			    case 2:
                    try
                    {
                        this.cont.removeStudentsUntilMaxGrade();
                    }
                    catch (Exception msg)
                    {
                        if (msg is MyException || msg is StackException)
                        {
                            Console.WriteLine("{0}", msg.Message);
                        }
                    }
				    break;
			    case 3:
				    Console.Write("Number of Students= {0}",this.cont.getSize());
				    break;
			    case 4:
				    printStudents();
				    break;
               case 5:
				    Console.Write("ID:");
				    id=Convert.ToInt32(Console.ReadLine());
				    Console.Write("Number of Students greater than {0} is {1}",id,this.cont.numberOfStudentGreaterThan(id));
				    break;
			   case 6:
				    IDictionary <int,Student> source=new Dictionary<int ,Student>();
                    IDictionary<int, Student> destination = new Dictionary<int, Student>();
				    //this.cont.moveElements(source,destination);
				    Console.WriteLine("New stack copy created!");
				    break;
               case 7:
                    this.readFromFile();
                    break;
               case 8:
                    this.writeToFile();
                    break;
               case 13:
				    b=false;
				    return;
			    default:
				    Console.WriteLine("Wrong choice.Try again!");
				    break;
			    }
		    }
		
	    }
    }
}

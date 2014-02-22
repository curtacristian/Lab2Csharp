using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2Csharp.domain;
namespace Lab2Csharp
{
    [Serializable()]
    public class Student:compareStudent<Student>, getID2
    {
       
        private int id;
	    private String name;
	    private int grade;
	
	    public Student(){
            this.id=0;this.name="";this.grade=0;
        }
        public Student(int id,string name,int grade)
        {
            this.id = id;
            this.name = name;
            this.grade = grade;
        }
	
	
	    int getID2.getID(){
		    return this.id;
	    }
        public int getID()
        {
            return this.id;
        }
	    public void setID(int id){
		    this.id=id;
	    }
	    public int getGrade(){
		    return this.grade;
	    }
	
	    public void setGrade(int grade){
		    this.grade=grade;
	    }
	
	    public void setName(String name){
		    this.name=name;
	    }
	
	    public String getName(){
		    return this.name;
	    }
	
	    public virtual float average() {
	        return grade;
	    }

	    public virtual bool isGreaterThan(Student student) {
	        return (this.average() > student.average());
	    }
	
	    public virtual String toString(){
		    String s="";
		    s="Norm | "+id+"  | "+name+"    | "+grade;
		    return s;
	    }
        public virtual String fileString()
        {
            String s = "";
            s = this.getID() + " " + this.getName() + " " + this.getGrade();
            return s;

        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Csharp
{
     [Serializable()]
    public class PhDStudent : Student{
        public String supervisor;
        public String thesis;
        public int grade2;

        public PhDStudent(int id, String name, int grade, int grade2, String supervisor, String thesis) :base(id,name,grade){
            this.supervisor = supervisor;
            this.thesis = thesis;
            this.grade2 = grade2;
        }
        public int getGrade2()
        {
            return this.grade2;
        }

        public string getSupervisor()
        {
            return this.supervisor;
        }

        public string getThesis()
        {
            return this.thesis;
        }

        public override float average() {
            return (float)(this.getGrade() + this.grade2) / 2;
        }

        public override bool isGreaterThan(Student student) {
            return (this.average() > student.average());
        }
    
        public override String toString(){
    	    String s="";
		    s="PHD | "+this.getID()+"  | "+this.getName()+"    | "+this.getGrade()+" |"+grade2+" | "+thesis+" | "+supervisor;
		    return s; 
        }
        public override String fileString()
        {
            String s = "";
            s = this.getID() + " " + this.getName() + " " + this.getGrade() + " " + grade2 + " " + this.thesis + " " + this.supervisor;
            return s;

        }
    }
}

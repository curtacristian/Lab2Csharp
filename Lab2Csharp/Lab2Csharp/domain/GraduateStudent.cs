using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Csharp
{
     [Serializable()]
    class GraduateStudent :Student{
    public String supervisor;
    public int grade2;
    public int grade3;

    public GraduateStudent(int id, String name, int grade, int grade2, int grade3, String supervisor) :base(id,name,grade){
        this.grade2 = grade2;
        this.grade3 = grade3;
        this.supervisor = supervisor;
    }

    public int getGrade2() {
        return this.grade2;
    }

    public int getGrade3()
    {
        return this.grade3;
    }
    public String getSupervisor()
    {
        return this.supervisor;
    }
    

    public override float average() {
        return (float)(this.getGrade() + this.grade2 + this.grade3) / 3;
    }

    public override bool isGreaterThan(Student student) {
        return (this.average() > student.average());
    }
    public override String toString(){
		String s="";
		s="Grad | "+this.getID()+"  | "+this.getName()+"    | "+this.getGrade()+" | "+grade2+" | "+grade3+" | "+supervisor;
		return s;
	}
    public override String fileString()
    {
        String s = "";
        s = this.getID() + " " + this.getName() + " " + this.getGrade() + " " + grade2 + " " + grade3 + " " + supervisor;
        return s;

    }
}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Csharp

{
     [Serializable()]
    class UndergraduateStudent :Student{
    public int grade2;

    public UndergraduateStudent(int id, String name, int grade, int grade2): base(id,name,grade){
        this.grade2 = grade2;
    }

    public override float average() {
        return (float)(this.getGrade() + this.grade2) / 2;
    }

    public int getGrade2()
    {
        return this.grade2;
    }

    public override bool isGreaterThan(Student student) {
        return (this.average() > student.average());
    }
    
    public override String toString(){
		String s="";
		s="Under | "+this.getID()+"  | "+this.getName()+"    | "+this.getGrade()+" | "+grade2;
		return s;
	}
    public override String fileString()
    {
        String s = "";
        s = this.getID() + " " + this.getName() + " " + this.getGrade() + " " + grade2;
        return s;

    }
}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2Csharp.repository;

namespace Lab2Csharp.controller
{
    class Validator
    {
        private Repository<Student> repo;
	    Student [] students;
	
	    public Validator(Repository<Student> r){
		    this.repo=r;
		    this.students=new Student[this.repo.totalNumber()];
	    }
	
	    public String validate(Student s){
		    //validates if the input data is correct
		    //in case the information is wrong,it returns an error message 
		    //that will be printed on the standard output
		    //pre condition:s is a student
		    //post condition: returns an empty string if no errors are found
		    //in case of errors it will return a string containing the error mesages
		    String msg="";
		    if(s.getID()<0){
			    msg+="Invalid id!\n";
		    }
		    if(s.getGrade()<1||s.getGrade()>10){
			    msg+="Invalid grade!\n";
		    }
		    if(s.getName()==""){
			    msg+="Invalid name!\n";
		    }
		    if(msg==""){
			    if(this.repo.totalNumber()!=0){
				    students=this.repo.getAllTs();
				    for(int i=0;i<this.repo.totalNumber();i++){
					    if(students[i].getID()==s.getID())
						    msg+="Duplicate id";
				    }
			    }
		    }
		    return msg;
	    }
        }
}

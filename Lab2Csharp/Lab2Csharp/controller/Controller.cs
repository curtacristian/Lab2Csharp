using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using Lab2Csharp.repository;
using Lab2Csharp.domain;
using Lab2Csharp.ui;


namespace Lab2Csharp.controller
{
    class Controller
    {
        private Validator val;
        private Repository<Student> repo;
        private ObserverHandler obsHand;
        public Controller(Repository<Student> r, Validator v)
        {
            this.repo = r;
            this.val = v;
        }

        public void setObserverHandler(ObserverHandler ob){
            obsHand=ob;
        }


        public String push(int id, String name, int grade)
        {
            //it validates the student s and 
            //Pushes it onto the stack if there are no errors
            //Precondition : s is a student
            //Postcondition : valid,a string containing the error list is returned
            //in case there are errors,it will print in the ui
            //if there are no errors,the student will be pushed into the stack
            Student s = new Student(id, name, grade);
            String valid = this.val.validate(s);
            if (valid == "")
            {
                this.repo.push(s);
                this.obsHand.Activate();
            }
            return valid;

        }

        public String push(int id, String name, int grade, int grade2)
        {
            //it validates the student s and 
            //Pushes it onto the stack if there are no errors
            //Precondition : s is a student
            //Postcondition : valid,a string containing the error list is returned
            //in case there are errors,it will print in the ui
            //if there are no errors,the student will be pushed into the stack
            Student s = new UndergraduateStudent(id, name, grade, grade2);
            String valid = this.val.validate(s);
            if (valid == "")
            {
                this.repo.push(s);
                this.obsHand.Activate();
            }
            return valid;

        }

        public String push(int id, String name, int grade, int grade2, int grade3, String supervisor)
        {
            //it validates the student s and 
            //Pushes it onto the stack if there are no errors
            //Precondition : s is a student
            //Postcondition : valid,a string containing the error list is returned
            //in case there are errors,it will print in the ui
            //if there are no errors,the student will be pushed into the stack
            Student s = new GraduateStudent(id, name, grade, grade2, grade3, supervisor);
            String valid = this.val.validate(s);
            if (valid == "")
            {
                this.repo.push(s);
                this.obsHand.Activate();
            }
            return valid;

        }

        public String push(int id, String name, int grade, int grade2, String supervisor, String thesis)
        {
            //it validates the student s and 
            //Pushes it onto the stack if there are no errors
            //Precondition : s is a student
            //Postcondition : valid,a string containing the error list is returned
            //in case there are errors,it will print in the ui
            //if there are no errors,the student will be pushed into the stack
            Student s = new PhDStudent(id, name, grade, grade2, supervisor, thesis);
            String valid = this.val.validate(s);
            if (valid == "")
            {
                this.repo.push(s);
                this.obsHand.Activate();
            }
            return valid;

        }



        public void serialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("serialize.out", FileMode.Create, FileAccess.Write);
            formatter.Serialize(stream, repo);
            stream.Close();
        }

        public void deserialize()
        {
            IFormatter formatter = new BinaryFormatter();
            Stream stream = new FileStream("serialize.out", FileMode.Open, FileAccess.Read);
            repo = (Repository<Student>)formatter.Deserialize(stream);
            stream.Close();
        }



        public int getSize()
        {
            //gets the size of the stack
            //precondition :true
            //postcondition :an int will be returned holding the value of the size of the repository
            return this.repo.totalNumber();
        }

        public void removeStudentsUntilMaxGrade()
        {
            Student current = this.repo.getTopT();
            while (current.average() != 10)
            {
                this.repo.removeT(current);
                current = this.repo.getTopT();
                
            }
            this.obsHand.Activate();
        }


        public Student[] getAllStudents()
        {
            //This will get the students array from the stack
            //precondition true
            //postcondition : the students will be returned in the UI
            if (this.getSize() == 0)
            {
                throw new MyException("No students in repository!");
            }
            return this.repo.getAllTs();

        }




        public int numberOfStudentGreaterThan(int id)
        {
            try
            {
                Student[] all = this.repo.getAllTs();
                Student s = null;
                int no = 0;
                for (int i = 0; i < all.Length; i++)
                {
                    s = all[i];
                    if (s.getID() == id)
                    {
                        break;
                    }
                }
                if (s != null)
                {
                    IDictionary<int, Student> copy = this.repo.getAll();
                    foreach (compareStudent<Student> compare in copy.Values)
                    {
                        if (compare.isGreaterThan(s))
                        {
                            no++;
                        }
                    }
                }
                return no;
            }
            catch (StackException e)
            {
                // TODO Auto-generated catch block
                Console.WriteLine(e.Message);
                return 0;
            }

        }
        public static void moveElements(IDictionary<int, Student> source, IDictionary<int, Student> destination)
        {
            foreach (Student s in source.Values)
            {
                destination.Add(s.getID(), s);
            }
        }
        public String[] allToString()
        {
            //This will get the students array from the stack
            //precondition true
            //postcondition : the students will be returned in the UI
            //Returns the information from the stack in the shape of an auxiliary copy array
            //pre condition : true
            //post condition : returns the array with the elements from the stack

            Student[] aux = new Student[this.repo.totalNumber()];
            String[] values = new String[this.repo.totalNumber()];
            IDictionary<int,Student> copy = this.repo.getAll();
            aux = this.repo.getAllTs();
            for (int i = 0; i < this.repo.totalNumber(); i++)
            {
                values[i] = aux[i].fileString() + "\n";
            }
            return values;


        }

        public String allToStringUI()
        {
            //This will get the students array from the stack
            //precondition true
            //postcondition : the students will be returned in the UI
            //Returns the information from the stack in the shape of an auxiliary copy array
            //pre condition : true
            //post condition : returns the array with the elements from the stack

            Student[] aux = new Student[this.repo.totalNumber()];
            String[] values = new String[this.repo.totalNumber()];
            IDictionary<int, Student> copy = this.repo.getAll();
            aux = this.repo.getAllTs();
            String msg = "";
            for (int i = 0; i < this.repo.totalNumber(); i++)
            {
                msg+= aux[i].fileString() + "\n";
            }
            return msg;


        }
        
     
    
    
    
    
    }

    class ObserverHandler : IObservable<Controller>
    {
        private List<AverageObserver> observers;
        private Controller c;
        
        public ObserverHandler(Controller cont)
        {
            this.observers = new List<AverageObserver>();
            this.c = cont;
        }


        public IDisposable Subscribe(IObserver<Controller> observer)
        {
            AverageObserver toAdd = (AverageObserver)(observer);
            if (!observers.Contains(observer))
            {
                
                observers.Add(toAdd);
            }
            return new Unsubscriber<AverageObserver>(this.observers, toAdd);
        }

        public void Activate()
        {
            foreach (AverageObserver obs in observers)
            {
                obs.OnNext(this.c);
            }
        }


    }
    class Unsubscriber<AverageObserver> : IDisposable
    {
        private List<AverageObserver> _observers;
        private AverageObserver _observer;

        internal Unsubscriber(List<AverageObserver> observers, AverageObserver observer)
        {
            this._observers = observers;
            this._observer = observer;
        }

        public void Dispose()
        {
            if (_observers.Contains(_observer))
                _observers.Remove(_observer);
        }
    }


}

    	 

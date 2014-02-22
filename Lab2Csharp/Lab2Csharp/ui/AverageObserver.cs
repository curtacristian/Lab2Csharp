using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2Csharp.controller;

namespace Lab2Csharp.ui
{
    class AverageObserver : IObserver<Controller>
    {
        private int type;
        private IDisposable cancel;
        public AverageObserver(int t)
        {
            this.type = t;
        }
   
        public int getType()
        {
            return this.type;
        }

        public virtual void Subscribe(ObserverHandler obh)
        {
            cancel = obh.Subscribe(this);
        }
        
        public virtual void Unsubscribe()
        {
            cancel.Dispose();
        }

        public void OnNext(Controller c)
        {
            string msg = "";
            if (this.type == 0)
            {
                msg += "Average less than 5\n";
                Student[] all = c.getAllStudents();
                foreach (Student s in all)
                {
                    if (s.average() < 5)
                    {
                        msg += s.toString();
                    }
                }
            }
            else
            {
                msg += "Average more than 5\n";
                Student[] all = c.getAllStudents();
                foreach (Student s in all)
                {
                    if (s.average() > 5)
                    {
                        msg += s.toString();
                    }
                }
            }
            Console.WriteLine("{0}", msg);
        }

        public void OnCompleted()
        {
        }

        public void OnError(Exception e)
        {
        }


    }

}
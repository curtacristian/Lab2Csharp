using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2Csharp.repository;
using Lab2Csharp.ui;
using Lab2Csharp.controller;
using System.Windows.Forms;

namespace Lab2Csharp
{
    class Program
    {
        static void Main(string[] args)
        {
            Repository<Student> StudentRepository = new Repository<Student>();
            Validator Validator = new Validator(StudentRepository);
            Controller controller = new Controller(StudentRepository, Validator);
            ObserverHandler obs = new ObserverHandler(controller);
            AverageObserver obs1 = new AverageObserver(0);
            AverageObserver obs2 = new AverageObserver(1);
            
            obs.Subscribe(obs1);
            obs.Subscribe(obs2);
            
            Ui UI = new Ui();
            controller.setObserverHandler(obs);
            UI.setCont(controller,"students.txt");
            UI.readFromFile();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1(UI.getCont()));
            
           
        }
    }
}

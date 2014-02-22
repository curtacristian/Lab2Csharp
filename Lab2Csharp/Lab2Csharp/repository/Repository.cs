using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2Csharp.domain;

namespace Lab2Csharp.repository
{
    [Serializable]
    class Repository <T> where T: getID2
    {
		
	
		private IDictionary<int ,T> elements=new Dictionary<int ,T>();
		
		
		public void push(T s){
			//pushes the T s in the stack
			//preconditions s=T
			//postcondition the repository stack 
			//in case the size hits the amount of the capacity,the stack will be resized
			//using an auxiliary T vector
			this.elements.Add(s.getID(),s);;
					

		}
		
		
		
		public void removeT(T s) {
            this.elements.Remove(s.getID());
		}
		
		public T [] getAllTs(){
			//Returns the information from the stack in the shape of an auxiliary copy array
			//pre condition : true
			//post condition : returns the array with the elements from the stack
			
			T [] aux = new T[this.elements.Count];
			IDictionary<int, T> copy=this.getAll();
			int i=0;
            foreach (T current in copy.Values)
            {
                aux[i] = current;
                i++;
            }
			return aux;
		}

        public T getTopT()
        {
            foreach (T element in this.elements.Values)
            {
                return element;
            }
            return default(T);
        }

        public IDictionary<int ,T> getAll()
        {
            IDictionary<int, T> n = new Dictionary<int, T>(this.elements);
			return n;
		}
		
		public int totalNumber(){
            return this.elements.Count;
		}
		
	
}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab2Csharp.Util;



namespace Lab2Csharp.repository
{
        [Serializable]
        class Stack<T> {

	        private Lab2Csharp.Util.LinkedList<T> elements;
	        private int size=0;
	
	        public Stack(){
		        elements = new Lab2Csharp.Util.LinkedList<T>();
	        }
	
	        public void push(T data){
		        Node<T> last=this.elements.getLast();
		        if(last!=null){
			        last.next=new Node<T>(data);
		        }
		        else{
			        this.elements.first=new Node<T>(data);
		        }
		        size++;
	        }
	
	        public T pop() {
		        Node<T> aux=this.elements.first;
		        if(size==0){
			        throw new StackException("Stack is empty!");
		        }
		        this.size--;
	            Node<T> lastNode = this.elements.getLast();
	            T returnData = lastNode.data;
	            this.elements.removeNode(lastNode);
	            return returnData;
		
		
	        }
	
	        public int getSize(){
		        return this.size;
	        }
	
	        public bool isEmpty(){
		        return this.size==0;
	        }
	
	        public Stack<T> getAll(){
		        Stack<T> copy=new Stack<T>();
		        copy.elements=this.elements.copy();
		        copy.size=this.size;
		        return copy;
	        }
    }
}

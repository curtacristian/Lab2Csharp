using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2Csharp.Util
{
    [Serializable]
    class Node<T>
    {
        public T data;
        public Node<T> next;

        public Node()
        {
            this.next = null;
        }

        public Node(T data)
        {
            this.data = data;
            this.next = null;
        }
    }
}

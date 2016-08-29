using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace XMLToWBT.DataStructure
{
    public class Tree<T> : Node<T>
    {
        #region Properties
        protected new static bool IsRoot = true;
        public bool _isRoot
        {
            get { return IsRoot; }
        }
        #endregion
        #region Constructors
        public Tree()
            : base()
        {
            this.Name = "TO BE INSERTED";
            this.Parent = null;
            this.Element = default(T);


        }
        #endregion
        #region Methods

        public bool isEmpty()
        {
            return this.Children.Count == 0;
        }

        public string ToString()
        {
            List<string> ls = new List<string>();
            return this.ToString(this,ls);
        }

        public string ToString(Node<T> t, List<string> ls)
        {
            foreach (Node<T> child in t.Children)
            {
                ls.Add(child.ToString());
                ToString(child, ls);
            }
     
            StringBuilder sb = new StringBuilder();

            foreach (string s in ls)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }

        public void showTree()
        {
            Console.WriteLine(this.ToString());
        }

        public string displayedTree()
        {
            StringBuilder sb = new StringBuilder();
            List<Node<T>> queue = new List<Node<T>>();



            try
            {
                if (!isEmpty())
                {
                    queue.Add(this);

                    while (queue.Count > 0)
                    {
                        Node<T> n = queue.Last();
                        if (n._name == "TO BE INSERTED")
                            sb.Append("TO BE INSERTED");
                        else
                            sb.Append(n.ToString());
                        queue.Remove(n);
                        foreach (Node<T> child in n.Children)
                        {
                            queue.Insert(0,child);
                        }
                    }

                }
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
            return sb.ToString();
        }

        public void insertNodeAt(Node<T> tree, Node<T> parentNode, Node<T> insertedNode)
        {
            if (parentNode.Equals(tree))
            {
                insertedNode._parent = tree;
                tree.addChild(insertedNode);
            }
            else
            {
                foreach (Node<T> child in tree.Children)
                {
                    if (parentNode.Equals(child))
                    {
                        insertedNode._parent = child;
                        child.addChild(insertedNode);
                        break;
                    }
                    else
                    {
                        insertNodeAt(child, parentNode, insertedNode);
                    }
                }

            }
        }

        #endregion
    }
}

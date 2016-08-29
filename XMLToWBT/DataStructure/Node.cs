using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLToWBT
{
    public class Node<T>
    {
        #region Properties
        protected static bool IsRoot = false;

        public bool _isRoot
        {
            get { return IsRoot; }
        }

        protected string Name;
        public string _name
        {
            get { return this.Name; }
            set
            {
                if (!IsRoot)
                {
                    this.Name = value;
                }
            }
        }

        protected T Element;
        public T _element
        {
            get { return this.Element; }
            set
            {
                if (!IsRoot)
                {
                    this.Element = value;
                }
            }
        }

        protected Node<T> Parent;
        public Node<T> _parent
        {
            get { return this.Parent; }
            set
            {
                if (!IsRoot)
                {
                    this.Parent = value;
                }
            }
        }

        public List<Node<T>> Children { get; set; }

        #endregion
        #region Constructors
        public Node()
        {
            this.Name = "newNode";
            this.Element = default(T);
            this.Parent = null;
            this.Children = new List<Node<T>>();

        }

        public Node(string _name, Node<T> _parent)
        {
            this.Name = _name;
            this.Element = default(T);
            if (!IsRoot)
                this.Parent = _parent;
            this.Children = new List<Node<T>>();

        }

        public Node(string _name, Node<T> _parent, T elt)
        {
            this.Name = _name;
            if (!IsRoot)
            {
                this.Element = elt;
                this.Parent = _parent;
            }
            this.Children = new List<Node<T>>();

        }
        #endregion
        #region Methods

        public new string ToString()
        {
            return this.Element.ToString();
        }

        public void addChild(Node<T> child)
        {
            try
            {
                child._parent = this;
                this.Children.Add(child);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void addChildAhead(Node<T> child)
        {
            try
            {
                child._parent = this;
                this.Children.Insert(0,child);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void removeChild(Node<T> child)
        {
            try
            {
                Children.Remove(child);

            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Node<T>> getSiblings()
        {
            try
            {
                List<Node<T>> siblings = this.Parent.Children;
                siblings.Remove(this);
                return siblings;
            }
            catch (Exception)
            {

                return null;
            }
            ;
        }

        #endregion
    }
}

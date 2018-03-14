using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BinaryTree
{
    public partial class BinarySearchTreeNode<T> where T : IComparable<T>
    {

        private T _value;
        private BinarySearchTreeNode<T> _parent;
        private BinarySearchTreeNode<T> _leftChild;
        private BinarySearchTreeNode<T> _rightChild;

        public T Value
        {
            get { return _value; }
            set {_value = value; }
        }

        public BinarySearchTreeNode<T> LeftChild
        {
            get { return _leftChild; }
            set { this._leftChild = value; }
        }

        public BinarySearchTreeNode<T> RightChild
        {
            get { return _rightChild; }
            set { this._rightChild = value; }
        }

        public BinarySearchTreeNode<T> Parent
        {
            get { return _parent; }
            set { this._parent = value; }
        }

        bool IsLeftChild
        {
            get
            {
                if (Parent == null)
                    return false;
                if (Value.CompareTo(Parent.Value) < 0)
                    return true;
                else
                    return false;
            }
        }

        bool IsRightChild
        {
            get
            {
                if (Parent == null)
                    return false;
                if (Value.CompareTo(Parent.Value) >= 0)
                    return true;
                else
                    return false;
            }
        }
        public BinarySearchTreeNode(T value)
        {
            _value = value;
        }

        public void Insert(T value)
        {
                      
               if (Find(value))
            {   
                   //Om det angivna värdet redan finns i trädet visas ett felmeddelande istället                    
                   throw new NotImplementedException("Det här värdet finns redan i trädet!");
            }
            //Undersöker om värdet är högre eller lägre än rotnoden
            if (value.CompareTo(Value) > 0)
            {
                if (this.RightChild == null)
                {
                    this.RightChild = new BinarySearchTreeNode<T>(value);
                    this.RightChild.Parent = this;
                }
                else
                {
                    RightChild.Insert(value);
                }
            }

            else
            {
                if (this.LeftChild == null)
                {
                    this.LeftChild = new BinarySearchTreeNode<T>(value);
                    this.LeftChild.Parent = this;
                }
                else
                {
                    LeftChild.Insert(value);
                }
            }
        }

        public void Remove(T value)
        {

            if (value.CompareTo(Value) == 0)
            {
                //Required for the GUI to work.
                Parent.IsChanged = true;


                //Om noden ej har barn.
                if (_rightChild == null && _leftChild == null)
                {
                    if (IsLeftChild)
                        _parent._leftChild = null;
                    else
                        _parent._rightChild = null;
                }
                //Om noden har ett högerbarn
                else if (_leftChild == null)
                {
                    if (IsLeftChild)
                    {
                        _parent._leftChild = _rightChild;
                        _rightChild._parent = _parent;
                    }

                    else
                    {
                        _parent._rightChild = _rightChild;
                        _rightChild._parent = _parent;
                    }

                }
                //Om noden har ett vänsterbarn
                else if (_rightChild == null)
                {
                    if (IsLeftChild)
                    {
                        _parent._leftChild = _leftChild;
                        _leftChild._parent = _parent;
                    }
                    else
                    {
                        _parent._rightChild = _leftChild;
                        _leftChild._parent = _parent;
                    }
                }

                //Om noden har 2 barn. Då ersätts den borttagna noden med det största värdet i vänster subträd
                else
                {
                    BinarySearchTreeNode<T> largestValue = this._leftChild;
                    while (largestValue._rightChild != null)
                    {
                        largestValue = largestValue._rightChild;
                    }
                    this._leftChild.Remove(largestValue.Value);
                    _value = largestValue.Value;                    
                }
            }
           
            //Letar efter noden som skall tas bort
            else if (value.CompareTo(_value) > 0)
            {
                _rightChild.Remove(value);
            }
            else
            {
                _leftChild.Remove(value);
            }
            
        }

        public bool Find(T value)
        {
            //Om rotnoden är det värde som söks
            if (Equals(this.Value, value))
            {
                return true;
            }
            if (value.CompareTo(Value) < 0)
            {
                //Om värdet som söks är lägre än nuvarande nod och dess vänsterbarn ej finns så finns värdet som söks inte
                if (Equals(LeftChild, null))
                {
                    return false;
                }

                //Om noden har ett vänsterbarn så fortsätter rekursionen
                return LeftChild.Find(value);
            }
            else
            {
                //Om noden har 2 barn. Då ersätts den borttagna noden med det minsta värdet i höger subträd
                if (Equals(RightChild, null))
                {
                    return false;
                }

                //Om noden har ett vänsterbarn så fortsätter rekursionen
                return RightChild.Find(value);
            }
        }


        //Traverseringsmetoder
        public IEnumerable<T> Inorder()
        {
            List<T> InList = new List<T>();
            if (_value != null)
            {
                if (_leftChild != null)
                {
                    InList.AddRange(_leftChild.Inorder());
                }

                InList.Add(_value);

                if (_rightChild != null)
                {
                    InList.AddRange(_rightChild.Inorder());
                }
            }
            return InList;        
        }

        public IEnumerable<T> Postorder()
        {
            List<T> PostList = new List<T>();

            if (_value != null)
            {
                if (_leftChild != null)
                    PostList.AddRange(_leftChild.Postorder());
                if (_rightChild != null)
                    PostList.AddRange(_rightChild.Postorder());

                PostList.Add(_value);
            }
            return PostList;
        }

        public IEnumerable<T> Preorder()
        {
            List<T> PreList = new List<T>();

            if (this._value != null)
            {
                PreList.Add(this._value);

                if (_leftChild != null)
                    PreList.AddRange(_leftChild.Preorder());
                if (_rightChild != null)
                    PreList.AddRange(_rightChild.Preorder());
            }
            return PreList;
            
        }
    }
}

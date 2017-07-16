using System;
using System.Collections.Generic;

namespace TreeBuilder
{
    public class Node<T>
    {
        private const char Separator = '/';
        public string Path { get; }
        public  object Value { get; }
        public  List<Node<T>> Children { get; }

        public Node(T value, string path,List<Node<T>> children = null)
        {
            if (!Separator.ToString().Equals(path))
            {
                path = path.TrimEnd(Separator);
                if (!path.StartsWith(Separator.ToString()))
                {
                    path = $"{Separator}{path}";
                }
            }
            Path = path;
            Value = value;
            Children = children ?? new List<Node<T>>();
        }

        public Node(string path, List<Node<T>> children = null) : this(default(T), path,children) { }
        // input : /x/y/z  (Current node path :  /x/y)
        public void AddDescendent(Node<T> node)
        {
            if (IsImmediateChild(node))
            {
                Children.Add(node);
                return;
            }
            var nextAncestor = Children.Find(c => node.Path.StartsWith(c.Path));
            if (nextAncestor != null)
            {
                nextAncestor.AddDescendent(node);
            }
            else
            {
                var fullPathOfNextChild = GetFullPathOfNextChild(node);
                var nextChild = new Node<T>(fullPathOfNextChild);
                nextChild.AddDescendent(node);
                Children.Add(nextChild);
            }
        }

        private string GetFullPathOfNextChild(Node<T> node)
        {
            var relativePathOfNodeWithSeparatorsTrimmed = RelativePathOfNodeWithSeparatorsTrimmed(node);
            var relativePathOfNextChild = relativePathOfNodeWithSeparatorsTrimmed.Split(Separator)[0];
            return Separator.ToString().Equals(Path) ? $"{Path}{relativePathOfNextChild}" : $"{Path}{Separator}{relativePathOfNextChild}";
        }


        private bool IsImmediateChild(Node<T> node)
        {
            var relativePathOfNodeWithSeparatorsTrimmed = RelativePathOfNodeWithSeparatorsTrimmed(node);
            var relativePathHasSegments = relativePathOfNodeWithSeparatorsTrimmed.Contains(Separator.ToString());
            return !relativePathHasSegments;
        }

        // for current node path /x and node path /x/y/z this will return y/z
        private string RelativePathOfNodeWithSeparatorsTrimmed(Node<T> node)
        {
            var trimmedDesecendantNodePath = node.Path.Trim(Separator);
            var trimmedCurrentNodePath = Path.Trim(Separator);
            var pathOfDescendantRelativeToCurrentNode
                = trimmedDesecendantNodePath.Remove(0, trimmedCurrentNodePath.Length);
            return pathOfDescendantRelativeToCurrentNode.Trim(Separator);
        }

        private bool Equals(Node<T> node)
        {
            var pathsAreEqual = Path.Equals(node.Path);
            if (!pathsAreEqual) return false;
            if (Value != null && node.Value != null)
            {
                return Value.Equals(node.Value);
            }
            return Value == null && node.Value == null;
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            return obj.GetType() == GetType() && Equals((Node<T>) obj);
        }

        public override int GetHashCode()
        {
            return 1;
        }

        
    }
}
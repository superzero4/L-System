using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Common.Sequence
{

    public class Tree<T> : IEnumerable<T>
    {
        T content;
        IEnumerable<Tree<T>> _childrens;
        public int DirectChildrenCount() => _childrens.Count();
        Tree<T> _parent;
        public Tree()
        {
            _childrens = new List<Tree<T>>();
        }
        public Tree(T t) : this()
        {
            content = t;
        }

        public T Content { get => content; set => content = value; }
        public Tree<T> Parent { get => _parent; set => _parent = value; }

        public Tree<T> AddChild(T t)
        {
            Tree<T> son = new Tree<T>(t);
            son._parent = this;
            this._childrens = this._childrens.Append(son);
            return son;
        }
        public IEnumerator<T> GetEnumerator()
        {
            yield return content;
            foreach (var item in _childrens)
            {
                var e = item.GetEnumerator();
                while (e.MoveNext())
                    yield return e.Current;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}

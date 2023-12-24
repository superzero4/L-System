using Scripts.Sequence.Action;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;

namespace Scripts.Common.Sequence
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="Action">Unused yet</typeparam>
    public class Sequence<T,Action> where Action : Enum 
    {
        public Tree<ContextAction<T>> _tree;
        public ContextAction<EAction> _action;

        public Sequence(ITranslatorUsingOther<EAction, ContextAction<T>> traductor, IEnumerable<EAction> actions)
        {
            var e = actions.GetEnumerator();
            if (e.MoveNext())
            {
                _tree = new Tree<ContextAction<T>>(traductor.Translate(e.Current,default));
                Add(traductor, e, _tree);
            }
        }

        private void Add(ITranslatorUsingOther<EAction, ContextAction<T>> traductor, IEnumerator<EAction> actionEnumerator, Tree<ContextAction<T>> current, int addIndex = 0)
        {
            while (actionEnumerator.MoveNext())
            {
                var action = actionEnumerator.Current;
                switch (action)
                {
                    case EAction.Begin:
                        Add(traductor, actionEnumerator, current, addIndex * 10);
                        break;
                    case EAction.End:
                        return;
                    default:
                        addIndex++;
                        ContextAction<T> translated = traductor.Translate(action,current.Content);
                        current = current.AddChild(translated);
                        //Debug.Log($"Adding child {addIndex}, with action {action} => {translated}, with parent having {current.Parent?.DirectChildrenCount()} childs and parent of parent having{current.Parent?.Parent?.DirectChildrenCount()} childs");
                        break;
                }
            }

            return;
        }

        public IEnumerable<ContextAction<T>> Enumerable()
        {
            return _tree;
        }
    }
}


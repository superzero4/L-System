using Scripts.Sequence.Action;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Animations;

namespace Scripts.Sequence
{

    public class Sequence<T> where T : BaseAction
    {
        public Tree<T> _tree;
        public ContextAction<EAction> _action;

        public Sequence(ITranslator<EAction, T> traductor, IEnumerable<EAction> actions)
        {
            var e = actions.GetEnumerator();
            if (e.MoveNext())
            {
                _tree = new Tree<T>(traductor.Translate(e.Current));
                Add(traductor, e, _tree);
            }
        }

        private void Add(ITranslator<EAction, T> traductor, IEnumerator<EAction> actionEnumerator, Tree<T> current, int addIndex = 0)
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
                        T translated = traductor.Translate(action);
                        current = current.AddChild(translated);
                        //Debug.Log($"Adding child {addIndex}, with action {action} => {translated}, with parent having {current.Parent?.DirectChildrenCount()} childs and parent of parent having{current.Parent?.Parent?.DirectChildrenCount()} childs");
                        break;
                }
            }

            return;
        }

        public IEnumerable<T> Enumerable()
        {
            return _tree;
        }
    }
}


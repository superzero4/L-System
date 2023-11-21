using Scripts.Sequence.Action;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Sequence
{

    public class Sequence<T> where T : BaseAction
    {
        public Tree<T> _tree;

        public Sequence(ITranslator<EAction, T> traductor, IEnumerable<EAction> actions)
        {
            _tree = new Tree<T>();
            int depth = 0;
            foreach (var action in actions)
            {
                switch (action)
                {
                    case EAction.Begin:
                        depth++;
                        return;
                        depth--;
                    case EAction.End:
                        return;
                }
                switch (traductor.Translate(action))
                {
                    default:
                        break;
                }
            }
        }
        public IEnumerable<T> Enumerable()
        {
            return _tree;
        }
    }
}

using Scripts.Chain;
using Scripts.Sequence;
using Scripts.Sequence.Action;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{

    public class Main : MonoBehaviour
    {
        [SerializeField]
        private Alphabet _alphabet;
        [SerializeField]
        private string input;
        // Start is called before the first frame update
        void Start()
        {
            Main2D();
        }
        void Main2D()
        {
            var actionSequence = _alphabet.Actions(input);
            var seq = new Sequence.Sequence<Action2D>(new ActionTranslator<Action2D>((EAction a) =>
            {
                Action2D b;
                switch (a)
                {
                    case EAction.Begin:
                        break;
                    case EAction.End:
                        break;
                    case EAction.Forward:
                        break;
                    case EAction.TurnL:
                        break;
                    case EAction.TurnR:
                        break;
                }
                return b;
            }), actionSequence);
            foreach (var a in seq.Enumerable())
            {
                a.Execute();
            }
        }
    }

}

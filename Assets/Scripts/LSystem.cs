using Scripts.Chain;
using Scripts.Rendering;
using Scripts.Sequence;
using Scripts.Sequence.Action;
using Scripts.Sequence.Context;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts
{

    public class LSystem : MonoBehaviour
    {
        [SerializeField]
        private Alphabet _alphabet;
        [SerializeField]
        private Replacement _rules;
        [SerializeField]
        private SpawnerRenderer _renderer;
        private LSettings _settings => _rules.Settings;
        private int depth => _settings.Depth;
        private float delta => _settings.Delta;
        // Start is called before the first frame update
        void Start()
        {
            string input = _settings.Input;
            for (int i = 0; i < depth; i++)
            {
                foreach (var r in _rules.Rules)
                {
                    input = input.Replace(r.c.ToString(), r.s);
                }
            }
            Debug.Log("LSYSTEM : Executing on " + input);
            IEnumerable<EAction> actionSequence = _alphabet.Actions(input);
            Main2D(actionSequence);
        }
        void Main2D(IEnumerable<EAction> actionSequence)
        {
            var seq = new Sequence.Sequence<Context2D>(new ActionTranslator<Context2D>((EAction type, ContextAction<Context2D> parent) =>
            {
                Action2D action = null;
                switch (type)
                {
                    case EAction.Begin:
                    case EAction.End:
                        break;
                    case EAction.Forward:
                    case EAction.TurnL:
                    case EAction.TurnR:
                        action = new Action2D(parent?.NextContext() ?? new Context2D(), type, _settings.Delta, 1);
                        break;
                }
                return action;
            }), actionSequence);
            foreach (var a in seq.Enumerable())
            {
                //Debug.Log($"executing => {a?.ToString()}");
                if (a.Action == EAction.Forward)
                    _renderer.UpdateRender(a.Context);
                //a.Execute();
            }
        }
    }

}

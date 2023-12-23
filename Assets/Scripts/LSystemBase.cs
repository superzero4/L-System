using Scripts.Chain;
using Scripts.Rendering;
using Scripts.Sequence;
using Scripts.Sequence.Action;
using Scripts.Sequence.Context;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts
{
    public abstract class LSystemBase<Context> : MonoBehaviour
    {
        [SerializeField]
        private Alphabet _alphabet;
        [SerializeField]
        private Replacement _rules;
        [SerializeField]
        private UnityEvent _onEnd;
        public abstract IRenderer<Context> Renderer { get; }
        public abstract IEActionToContextAction<Context> Traductor { get; }
        private GameObject first = null;
        protected LSettings _settings => _rules.Settings;
        private int depth => _settings.Depth;
        private float delta => _settings.Delta;
        protected abstract void Init();
        private void Start()
        {
            Init();
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
            var seq = Generate(actionSequence);
            foreach (var a in seq.Enumerable())
            {
                if (a.Action == EAction.Forward)
                {
                    Renderer.UpdateRender(a.Context);
                }
            }
            _onEnd.Invoke();
        }
        protected Sequence.Sequence<Context> Generate(IEnumerable<EAction> actionSequence)
        {
            return new Sequence<Context>(Traductor,actionSequence);
        }
    }

}

using Scripts.Common.Chain;
using Scripts.Common.Rendering;
using Scripts.Common.Sequence;
using Scripts.Sequence.Action;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Scripts.Common
{
    public abstract class LSystemBase<Context,Unused> : MonoBehaviour where Unused : Enum
    {
        [SerializeField]
        private Alphabet<EAction> _alphabet;
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
                if (a.Action == Scripts.Sequence.Action.EAction.Forward)
                {
                    Renderer.UpdateRender(a.Context);
                }
            }
            _onEnd.Invoke();
        }
        protected Sequence<Context,Unused> Generate(IEnumerable<EAction> actionSequence)
        {
            return new Sequence<Context,Unused>(Traductor,actionSequence);
        }
    }

}

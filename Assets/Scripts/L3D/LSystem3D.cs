using Scripts.Common;
using Scripts.Common.Rendering;
using Scripts.Rendering;
using Scripts.Sequence.Action;
using Scripts.Sequence.Context;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.L3D
{

    public class LSystem3D : LSystemBase<Context3D,EAction>
    {
        [SerializeField]
        private SpawnerRenderer _renderer;
        public override IRenderer<Context3D> Renderer => _renderer;

        public override IEActionToContextAction<Context3D> Traductor => _traductor;
        public IEActionToContextAction<Context3D> _traductor;

        protected override void Init()
        {
            var d = _settings.Delta;
            _traductor = new DelegateTranslator<Context3D>((EAction a, ContextAction<Context3D> context) =>
            {
                ContextAction<Context3D> action = null;
                if (a != EAction.Begin && a != EAction.End)
                    action = new Action3D(context?.Context ?? new Context3D(), a, d);
                return action;
            });
        }
    }

}

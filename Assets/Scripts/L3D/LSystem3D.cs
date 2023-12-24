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

    public class LSystem3D : LSystemBase<Context3D, EAction>
    {
        [SerializeField]
        private SpawnerRenderer _renderer;
        public override IRenderer<Context3D> Renderer => _renderer;

        public override IEActionToContextAction<Context3D> Traductor => _traductor;
        public IEActionToContextAction<Context3D> _traductor;
        private readonly Context3D initContext = new Context3D(Vector3.right);
        protected override void Init()
        {
            var d = _settings.Delta;
            _traductor = new DelegateTranslator<Context3D>((EAction a, ContextAction<Context3D> context) =>
            {
                ContextAction<Context3D> action = null;
                if (a != EAction.Begin && a != EAction.End)
                {
                    Context3D newContext = default;
                    if (context != null)
                        newContext = context.NextContext();
                    else
                        newContext = initContext;
                    action = new Action3D(newContext, a, d);
                    Debug.Log($"{a} will convert \n{action.Context} to \n{action.NextContext()}");
                }
                return action;
            });
        }
    }

}

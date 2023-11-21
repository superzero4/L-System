using Scripts.Sequence.Context;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

namespace Scripts.Sequence.Action
{
    public enum EAction
    {
        Begin = -2, End = -1, Forward = 1, TurnL = 2, TurnR = 3
    }
    public abstract class BaseAction
    {
        protected EAction action;
        public abstract void Execute();
        public BaseAction(EAction action)
        {
            this.action = action;
        }
    }
    public abstract class ContextAction<C> : BaseAction
    {
        private C _context;
        public abstract void Execute(C c, EAction action);
        public ContextAction(C context, EAction action) : base(action)
        {
            _context = context;
        }
        public override void Execute()
        {
            Execute(_context, action);
        }
    }
    public class Action2D : ContextAction<Context2D>
    {
        private float rotStep, forwardStep;
        public Action2D(Context2D context, EAction action, float rotStep = 15f, float forwardStep = 1f) : base(context, action)
        {
            this.rotStep = rotStep;
            this.forwardStep = forwardStep;
        }

        public override void Execute(Context2D c, EAction action)
        {
            switch (action)
            {
                case EAction.Forward:
                    c.pos += (new Vector2(Mathf.Cos(c.rot * Mathf.Deg2Rad), Mathf.Sin(c.rot * Mathf.Deg2Rad)) * forwardStep);
                    break;
                case EAction.TurnL:
                    c.rot += rotStep;
                    break;
                case EAction.TurnR:
                    c.rot += rotStep;
                    break;
                default:
                    break;
            }
        }
    }

}

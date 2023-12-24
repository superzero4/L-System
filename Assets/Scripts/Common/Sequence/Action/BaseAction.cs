using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;

namespace Scripts.Sequence.Action
{
    public enum EAction
    {
        Begin = -2, End = -1, 
        Forward = 1, 
        TurnL = 2, TurnR = 3,

        PitchDown = 14,PitchUp = 15, RollLeft=16, RollRight=17,TurnAround=18,
    }
    public abstract class BaseAction
    {
        protected EAction action;

        public EAction Action { get => action; }

        public abstract void Execute();
        public BaseAction(EAction action)
        {
            this.action = action;
        }
        public override string ToString()
        {
            return " " + action.ToString();
        }
    }
    public abstract class ContextAction<C> : BaseAction
    {
        protected C _context;
        public C Context
        {
            get
            {
                return _context;
            }
        }
        public C NextContext()
        {
            //We simulate on localCopied var parentContext the parent so we start our new context from correct point
            var copy=this.Execute(_context, Action);
            //UnityEngine.Debug.Log($"Currnet => {_context.ToString()} Next context => {copy.ToString()}");
            return copy;
        }
        public abstract C Execute(C c, EAction action);
        public ContextAction(C context, EAction action) : base(action)
        {
            _context = context;
        }
        public override void Execute()
        {
            _context=Execute(_context, action);
        }
    }
}

using Scripts.Common;
using Scripts.Sequence;
using Scripts.Sequence.Action;
using Scripts.Sequence.Context;

namespace Scripts.L2D
{
    public class Translator2D : IEActionToContextAction<Context2D>
    {
        private float delta = -1;

        public Translator2D(float delta)
        {
            this.delta = delta;
        }

        public ContextAction<Context2D> Translate(EAction type, ContextAction<Context2D> parent)
        {
            ContextAction<Context2D> action = null;
            switch (type)
            {
                case EAction.Begin:
                case EAction.End:
                    break;
                case EAction.Forward:
                case EAction.TurnL:
                case EAction.TurnR:
                    action = new Action2D(parent?.NextContext() ?? new Context2D(), type, delta);
                    break;
            }
            return action;
        }
    }
}

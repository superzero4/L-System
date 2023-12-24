using Scripts.Sequence.Action;

namespace Scripts.L2D
{
    public abstract class StepContextAction<T> : ContextAction<T>
    {
        protected float rotStep;
        protected float forwardStep;
        public StepContextAction(T context, EAction action, float rotStep = 15f, float forwardStep = 1f) : base(context, action)
        {
            this.rotStep = rotStep;
            this.forwardStep = forwardStep;
        }
        public override string ToString()
        {
            return base.ToString() + $" rot => {rotStep}, forwardStep => {forwardStep} => {_context.ToString()}";
        }
    }
}
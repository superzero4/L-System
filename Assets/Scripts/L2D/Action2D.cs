using Scripts.Sequence.Action;
using Scripts.Sequence.Context;
using UnityEngine;

namespace Scripts.L2D
{
    public class Action2D : StepContextAction<Context2D>
    {
        public Action2D(Context2D context, EAction action, float rotStep = 15, float forwardStep = 1) : base(context, action, rotStep, forwardStep)
        {
        }

        public override void Execute(ref Context2D c, EAction action)
        {
            switch (action)
            {
                case EAction.Forward:
                    c.pos += (new Vector2(Mathf.Cos((c.Rot) * Mathf.Deg2Rad), Mathf.Sin((c.Rot) * Mathf.Deg2Rad)).normalized * forwardStep);
                    break;
                //Trigonometral way, going to top, left is postive, right is negative
                case EAction.TurnL:
                    c.Rot += rotStep;
                    break;
                case EAction.TurnR:
                    c.Rot -= rotStep;
                    break;
                default:
                    break;
            }
            Debug.Log($"Current context after executing {action} : {_context.pos},{_context.Rot}");
        }
    }

}

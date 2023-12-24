using Scripts.L2D;
using Scripts.Sequence.Action;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Debug = UnityEngine.Debug;

namespace Scripts.L3D
{
    internal class Action3D : StepContextAction<Context3D>
    {
        public Action3D(Context3D context, EAction action, float rotStep = 15, float forwardStep = 1) : base(context, action, rotStep, forwardStep)
        {
        }

        public override void Execute(ref Context3D c, EAction action)
        {
            switch (action)
            {
                //Bracket logic handled in tree, no concrete action
                case EAction.Begin:
                case EAction.End:
                    Debug.LogError("Trying to execute action that's suppoed only to do sequence control");
                    return;
                case EAction.Forward:
                    break;
                case EAction.TurnL:
                    break;
                case EAction.TurnR:
                    break;
                case EAction.PitchDown:
                    break;
                case EAction.PitchUp:
                    break;
                case EAction.RollLeft:
                    break;
                case EAction.RollRight:
                    break;
                case EAction.TurnAround:
                    break;
                default:
                    break;
            }
        }
    }
}

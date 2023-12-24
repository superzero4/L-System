using Scripts.L2D;
using Scripts.Sequence.Action;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.Animations;
using Debug = UnityEngine.Debug;
using UnityEngine;

namespace Scripts.L3D
{
    internal class Action3D : StepContextAction<Context3D>
    {
        public Action3D(Context3D context, EAction action, float rotStep = 15, float forwardStep = 1) : base(context, action, rotStep, forwardStep)
        {
        }

        public override Context3D Execute(Context3D c, EAction action)
        {
            switch (action)
            {
                //Bracket logic handled in tree, no concrete action
                case EAction.Begin:
                case EAction.End:
                    Debug.LogError("Trying to execute action that's suppoed only to do sequence control");
                    return c;
                case EAction.Forward:
                    c.pos += forwardStep * c.dir;
                    break;
                case EAction.TurnL:
                    Rotate(ref c, Axis.Z);
                    break;
                case EAction.TurnR:
                    Rotate(ref c, Axis.Z, true);
                    break;
                case EAction.PitchDown:
                    Rotate(ref c, Axis.Y);
                    break;
                case EAction.PitchUp:
                    Rotate(ref c, Axis.Y, true);
                    break;
                case EAction.RollLeft:
                    Rotate(ref c, Axis.X);
                    break;
                case EAction.RollRight:
                    Rotate(ref c, Axis.X, true);
                    break;
                case EAction.TurnAround:
                    Rotate(ref c, Axis.Z, false, 180f);
                    break;
                default:
                    break;
            }
            return c;
        }
        public void Rotate(ref Context3D c, Axis a, bool reverse = false, float? val = null)
        {
            var dir = Vector3.one;
            switch (a)
            {
                case Axis.None:
                    break;
                case Axis.X:
                    dir = Vector3.right;
                    break;
                case Axis.Y:
                    dir = Vector3.up;
                    break;
                case Axis.Z:
                    dir = Vector3.forward;
                    break;
                default:
                    break;
            }
            float step = (val.HasValue ? val.Value : rotStep) * (reverse ? -1 : 1);
            dir *= step;
            //Debug.Log($"Multiplying {a}=>{dir}");
            c.dir = Matrix4x4.Rotate(Quaternion.Euler(dir)).MultiplyPoint3x4(c.dir);
        }
    }
}

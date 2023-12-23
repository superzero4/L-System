using Scripts.Sequence.Action;
using Scripts.Sequence.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Sequence
{

    public interface ITranslatorUsingOther<Input, Output>
    {
        Output Translate(Input @in, Output reference);
    }
    public interface IEActionToContextAction<Output> : ITranslatorUsingOther<EAction, ContextAction<Output>>
    {

    }
    public class ActionTranslator<T> : IEActionToContextAction<T>
    {
        Func<EAction, ContextAction<T>, ContextAction<T>> func;
        public ActionTranslator(Func<EAction, ContextAction<T>, ContextAction<T>> func)
        {
            this.func = func;
        }

        public ContextAction<T> Translate(EAction i, ContextAction<T> parent)
        {
            return func(i, parent);
        }
        public static implicit operator ActionTranslator<T>(Func<EAction, ContextAction<T>, ContextAction<T>> f)
        {
            return new ActionTranslator<T>(f);
        }
    }
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
                    action = new Action2D(parent?.NextContext() ?? new Context2D(), type, delta, 1);
                    break;
            }
            return action;
        }
    }
}

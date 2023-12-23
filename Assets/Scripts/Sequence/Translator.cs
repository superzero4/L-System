using Scripts.Sequence.Action;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Sequence
{

    public interface ITranslator<Input, Input2, Output>
    {
        Output Translate(Input i, Input2 i2);

    }
    public class ActionTranslator<T> : ITranslator<EAction, ContextAction<T>, ContextAction<T>>
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
    public class Translator2D : ITranslator<EAction, Action2D, Action2D>
    {
        public Action2D Translate(EAction i, Action2D i2)
        {
            throw new NotImplementedException();
        }
    }
}

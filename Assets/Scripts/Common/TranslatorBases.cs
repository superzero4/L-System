using Scripts.Sequence.Action;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Common
{

    public interface ITranslatorUsingOther<Input, Output>
    {
        Output Translate(Input @in, Output reference);
    }
    public interface IEActionToContextAction<Output> : ITranslatorUsingOther<EAction, ContextAction<Output>>
    {

    }
    public class DelegateTranslator<T> : IEActionToContextAction<T>
    {
        Func<EAction, ContextAction<T>, ContextAction<T>> func;
        public DelegateTranslator(Func<EAction, ContextAction<T>, ContextAction<T>> func)
        {
            this.func = func;
        }

        public ContextAction<T> Translate(EAction i, ContextAction<T> parent)
        {
            return func(i, parent);
        }
        public static implicit operator DelegateTranslator<T>(Func<EAction, ContextAction<T>, ContextAction<T>> f)
        {
            return new DelegateTranslator<T>(f);
        }
    }
}

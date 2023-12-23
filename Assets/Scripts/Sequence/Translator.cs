using Scripts.Sequence.Action;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Sequence
{

    public interface ITranslator<Input, Output>
    {
        Output Translate(Input i);
        
    }
    public class ActionTranslator<T> : ITranslator<EAction, T> where T : BaseAction
    {
        Func<EAction, T> func;
        public ActionTranslator(Func<EAction, T> func)
        {
            this.func = func;
        }

        public T Translate(EAction i)
        {
            return func(i);
        }
        public static implicit operator ActionTranslator<T>(Func<EAction, T> f)
        {
            return new ActionTranslator<T>(f);
        }
    }
    public class Translator2D : ITranslator<EAction, Action2D>
    {
        public Action2D Translate(EAction i)
        {
            throw new NotImplementedException("Use action tranlsator and lambda");
        }
    }
}

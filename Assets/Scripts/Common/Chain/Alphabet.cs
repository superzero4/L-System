using Scripts.Sequence.Action;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Common.Chain
{
    public class Alphabet<Action> : ScriptableObject where Action : Enum
    {
        [SerializeField]
        List<Character> _map;
        [Serializable]
        public struct Character
        {
            public char c;
            public Action action;
        }
        public IEnumerable<Action> Actions(string input)
        {
            Dictionary<char, Action> dico = _map.ToDictionary(kv => kv.c, kv => kv.action);
            //We only return valid keys that were mapped explicitely to actions
            return input.Select(c =>
            {
                if (dico.TryGetValue(c, out Action a))
                    return (a,true);
                else return (default,false);
            }).Where(x=>x.Item2).Select(x=>x.a);
        }
    }

}

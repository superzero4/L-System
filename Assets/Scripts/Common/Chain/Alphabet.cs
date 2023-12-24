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
            return input.Select(c => dico[c]);
        }
    }

}

using Scripts.Sequence.Action;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Scripts.Chain
{

    [CreateAssetMenu(fileName = "Alphabet", menuName = "LS/Alphabet")]
    public class Alphabet : ScriptableObject
    {
        [SerializeField]
        List<Character> _map;
        [Serializable]
        public struct Character
        {
            public char c;
            public EAction action;
        }
        public IEnumerable<EAction> Actions(string input)
        {
            Dictionary<char, EAction> dico = _map.ToDictionary(kv => kv.c,kv=> kv.action);
            return input.Select(c => dico[c]);
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Common.Chain
{

    [System.Serializable]
    public struct ReplacementRule
    {
        public char c;
        public string s;
    }
    [System.Serializable]
    public struct LSettings
    {
        [SerializeField]
        private string _input;
        [SerializeField, Range(0, 10)]
        private int _depth;
        [SerializeField, Range(.01f, 180f)]
        private float _delta;

        public int Depth { get => _depth; }
        public float Delta { get => _delta; }
        public string Input { get => _input; set => _input = value; }
    }
    [CreateAssetMenu(fileName = "Rules", menuName = "LS/Rules")]
    public class Replacement : ScriptableObject
    {
        [SerializeField] private ReplacementRule[] _rules;
        [SerializeField] private LSettings _settings;

        public ReplacementRule[] Rules { get => _rules; }
        public LSettings Settings { get => _settings; }
    }

}

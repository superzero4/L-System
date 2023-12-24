using UnityEngine;

namespace Scripts.L2D
{
    public struct Context2D
    {
        private float rot;
        public Vector2 pos;

        public float Rot { get => rot + 0; set => rot = value; }
    }
}

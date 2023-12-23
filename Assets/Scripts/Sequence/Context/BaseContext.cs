using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Sequence.Context
{

    public class BaseContext
    {

    }
    public struct Context2D
    {
        private float rot;
        public Vector2 pos;

        public float Rot { get => rot + 0; set => rot = value; }
    }
    public struct Context3D
    {
        public Quaternion rot;
        public Vector3 pos;
    }
}

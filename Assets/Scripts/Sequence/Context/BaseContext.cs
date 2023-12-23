using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Sequence.Context{
    
    public class BaseContext
    {
        
    }
    public struct Context2D 
    {
        public float rot;
        public Vector2 pos;
    }
    public struct Context3D
    {
        public Quaternion rot;
        public Vector3 pos;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Sequence.Context{
    
    public class BaseContext
    {
        
    }
    public class Context2D : BaseContext
    {
        public float rot;
        public Vector2 pos;
    }
    public class Context3D : BaseContext
    {
        public Quaternion rot;
        public Vector3 pos;
    }
}

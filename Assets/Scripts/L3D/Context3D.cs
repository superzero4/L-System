using UnityEngine;

namespace Scripts.L3D
{
    public struct Context3D
    {
        public Vector3 dir;
        public Vector3 pos;

        public Context3D(Vector3? dir=null)
        {
            this.dir = dir.HasValue ? dir.Value :  Vector3.up;
            this.pos = Vector3.zero;
        }

        public override string ToString()
        {
            return $"pos : {pos}, orientation {dir}";
        }
    }
}

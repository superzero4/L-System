
using Scripts.Common.Rendering;
using Scripts.L2D;
using Scripts.L3D;
using Scripts.Sequence.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;

namespace Scripts.Rendering
{
    public class SpawnerRenderer : MonoBehaviour, IRenderer<Context2D>, IRenderer<Context3D>
    {
        [SerializeField] private GameObject _prefab;
        [HideInInspector]
        public GameObject first = null;
        public Transform CreateObject(Vector3 localPos,Vector3 localScale,Quaternion localRotation)
        {
            var o = Instantiate(_prefab, transform);
            o.transform.localPosition = localPos;
            o.transform.localScale = localScale;//Add scale used in action forward
            if (!first)
                first = o;
            o.transform.localRotation = localRotation;
            return o.transform;
        }
        public void UpdateRender(Context2D context)
        {
            var o = CreateObject(context.pos, Vector3.one, Quaternion.Euler((Vector3.forward * context.Rot)));
        }

        public void UpdateRender(Context3D c)
        {
            //We could offset directly quaternion by 90 shift on correct axis but this approeach is easier, the right vector of our prefab is the branch going forward so we match the 0 degree angle on the trigo cirlce
            var o =CreateObject(c.pos, Vector3.one, Quaternion.identity);
            o.transform.right = c.dir;
        }
    }

}

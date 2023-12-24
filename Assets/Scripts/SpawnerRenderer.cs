
using Scripts.Common.Rendering;
using Scripts.Sequence.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Rendering
{
    public class SpawnerRenderer : MonoBehaviour, IRenderer<Context2D>, IRenderer<Context3D>
    {
        [SerializeField] private GameObject _prefab;
        [HideInInspector]
        public GameObject first = null;
        public void CreateObject(Vector3 localPos,Vector3 localScale,Quaternion localRotation)
        {
            var o = Instantiate(_prefab, transform);
            o.transform.localPosition = localPos;
            o.transform.localScale = localScale;//Add scale used in action forward
            if (!first)
                first = o;
            o.transform.localRotation = localRotation;
        }
        public void UpdateRender(Context2D context)
        {
            CreateObject(context.pos, Vector3.one, Quaternion.Euler((Vector3.forward * context.Rot)));
        }

        public void UpdateRender(Context3D c)
        {
            CreateObject(c.pos, Vector3.one, c.rot);
        }
    }

}

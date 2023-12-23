﻿
using Scripts.Sequence.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

namespace Scripts.Rendering
{
    public interface IRenderer<Context>
    {
        public void UpdateRender(Context c);
    }

    public class SpawnerRenderer : MonoBehaviour, IRenderer<Context2D>, IRenderer<Context3D>
    {
        [SerializeField] private GameObject _prefab;
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

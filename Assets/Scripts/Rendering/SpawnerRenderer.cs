
using Scripts.Sequence.Context;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Rendering
{

    public class SpawnerRenderer : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        internal GameObject UpdateRender(Context2D context)
        {
            var o = Instantiate(_prefab, transform);
            o.transform.localPosition = context.pos;
            o.transform.localScale = Vector3.one;//Add scale used in action forward
            o.transform.localEulerAngles = (Vector3.forward * context.Rot);
            return o;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

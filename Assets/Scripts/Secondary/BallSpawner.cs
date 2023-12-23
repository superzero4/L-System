using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Scripts.Secondary
{

    public class BallSpawner : MonoBehaviour
    {
        [SerializeField]
        private GameObject _ball;
        [SerializeField, Range(1, 1000)]
        private int _nb;
        [SerializeField]
        private Vector2 _xSpread;
        [SerializeField]
        private Vector2 _ySpread;
        [SerializeField]
        private Vector2 _zSpread;
        //Event
        public void SpawnBalls(GameObject origin)
        {
            var socket = origin.transform.GetChild(origin.transform.childCount - 1);
            for (int i = 0; i < _nb; i++)
            {
                var t = GameObject.Instantiate(_ball, socket).transform;
                t.localPosition = new Vector3(Lerp(_xSpread), Lerp(_ySpread), Lerp(_zSpread));
                t.GetComponentInChildren<Renderer>().material.color = UnityEngine.Random.ColorHSV();
            }
        }

        private float Lerp(Vector2 v)
        {
            return Mathf.Lerp(v.x, v.y, UnityEngine.Random.value);
        }
    }

}

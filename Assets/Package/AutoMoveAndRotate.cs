using System;
using UnityEngine;
namespace UnityStandardAssets.Utility
{
    public class AutoMoveAndRotate : MonoBehaviour
    {
				//Object has script must be child object of one parent
				//Rotate Action use parent object to rotate around
        public Vector3ANDSpace moveUnitsPerSecond;
        public Vector3ANDSpace rotateDegreesPerSecond;
        [Tooltip("Use Realtime instead of Time.time")]
        public bool ignoreTimescale;
        private float _mLastRealTime;
        private Vector3 pos,startpos;
        private void Start()
        {
            _mLastRealTime = Time.realtimeSinceStartup;
            startpos = transform.position;
        }
        private void Update()
        {
            float deltaTime = Time.deltaTime;
            if (ignoreTimescale)
            {
                deltaTime = (Time.realtimeSinceStartup - _mLastRealTime);
                _mLastRealTime = Time.realtimeSinceStartup;
            }
            if (moveUnitsPerSecond.pingPong)
            {
                pos.x = Mathf.Sin(Time.time * moveUnitsPerSecond.speed)*moveUnitsPerSecond.value.x;
                pos.y = Mathf.Sin(Time.time * moveUnitsPerSecond.speed)*moveUnitsPerSecond.value.y;
                pos.z = Mathf.Sin(Time.time * moveUnitsPerSecond.speed)*moveUnitsPerSecond.value.z;
                transform.position = new Vector3(startpos.x+pos.x,startpos.y+pos.y,startpos.z+pos.z);
            }
            else
            {
                transform.Translate(moveUnitsPerSecond.value * (deltaTime * moveUnitsPerSecond.speed), moveUnitsPerSecond.space);
            }
            if (rotateDegreesPerSecond.pingPong)
            {
                pos.x = Mathf.Sin(Time.time * rotateDegreesPerSecond.speed)*rotateDegreesPerSecond.value.x;
                pos.y = Mathf.Sin(Time.time * rotateDegreesPerSecond.speed)*rotateDegreesPerSecond.value.y;
                pos.z = Mathf.Sin(Time.time * rotateDegreesPerSecond.speed)*rotateDegreesPerSecond.value.z;
                transform.Rotate(pos,rotateDegreesPerSecond.space);
            }
            else
            {
                transform.Rotate(rotateDegreesPerSecond.value * (deltaTime * rotateDegreesPerSecond.speed), rotateDegreesPerSecond.space);
            }
        }
        [Serializable]
        public class Vector3ANDSpace
        {
            [Tooltip("Vector3 adds to Transform")]
            public Vector3 value;
            [Tooltip("Local or Global")]
            public Space space = Space.Self;
            [Range(0f,10f)] [Tooltip("Time multiplication by Movement Speed")]
            public float speed;
            [Tooltip("Reverse Movement after reaching the point")]
            public bool pingPong;
        }
    }
}
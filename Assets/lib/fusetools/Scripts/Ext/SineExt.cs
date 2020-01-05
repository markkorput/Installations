using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FuseTools {
    public class SineExt : MonoBehaviour
    {
        [System.Serializable]
		public class Evts
		{
            public FloatEvent ValueEvent = new FloatEvent();
        }

        [Tooltip("Hz")]
        public float Frequency = 1.0f;
        public float Offset = 0.0f;
        public float Radius = 1.0f;
        public float ZeroValue = 0.0f;
        public Evts Events = new Evts();
        
        private float t = 0.0f;

        void Update() {
            t += Time.deltaTime;
            var val = ZeroValue + Mathf.Sin((t+Offset) * Mathf.PI * 2 * this.Frequency) * this.Radius;
            this.Events.ValueEvent.Invoke(val);
        }
    }
}
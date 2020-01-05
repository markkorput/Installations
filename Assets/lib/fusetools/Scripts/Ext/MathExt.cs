using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FuseTools {
    public class MathExt : MonoBehaviour
    {
        // [System.Serializable]
		// public class Evts
		// {
            
        // }

        [System.Serializable]
		public class PerlinNoiseOpts {
            public bool InvokeOnUpdate = false;
            public Vector2 Position = new Vector2(0,0);
            public Vector2 Step = new Vector2(0.1f, 0.1f);
            public FloatEvent OnValue = new FloatEvent();
            public float Multiply = 1.0f;
            public float Add = 0.0f;
        }

        public PerlinNoiseOpts PerlinNoiseOptions = new PerlinNoiseOpts();

        void Update() {
            if (this.PerlinNoiseOptions.InvokeOnUpdate) {
                this.InvokePerlineNoiseValue();
            }
        }

        public void InvokePerlineNoiseValue() {
            if (this.PerlinNoiseOptions.InvokeOnUpdate) {
                var val = Mathf.PerlinNoise(this.PerlinNoiseOptions.Position.x, this.PerlinNoiseOptions.Position.y);
                val = val * this.PerlinNoiseOptions.Multiply + this.PerlinNoiseOptions.Add;
                this.PerlinNoiseOptions.OnValue.Invoke(val);
                this.PerlinNoiseOptions.Position += this.PerlinNoiseOptions.Step;
            }
        }
    }
}
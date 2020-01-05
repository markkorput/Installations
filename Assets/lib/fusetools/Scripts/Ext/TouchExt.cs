using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace FuseTools
{
	public class TouchExt : MonoBehaviour {
        public enum When { Never, OnUpdate };

        [System.Serializable]
		public class Evts
		{
            public Vector2Event OnTouchDeltaPosition = new Vector2Event();
        }

        public When InvokeTouchDeltaPosition = When.Never;

        public float TouchSensitivityMultiplier = 1.0f;
        public Vector2 TouchAxesMultiplier = new Vector2(1.0f, 1.0f);

        public Evts Events = new Evts();
        bool bTouchDeltaPosition = false;
        Vector2 lastPos;

        // #region Unity Methods
        void Update() {
            if (this.InvokeTouchDeltaPosition.Equals(When.OnUpdate)) {
                var touches = (from t in Input.touches
                    where t.phase != TouchPhase.Ended && t.phase != TouchPhase.Canceled
                    select t);
            
                if (touches.Count() == 1) {
                    if (!bTouchDeltaPosition) {
                        bTouchDeltaPosition = true;
                        lastPos = touches.ToArray()[0].position;
                    } else {
                        var p = touches.ToArray()[0].position;
                        var delta = p - lastPos;
                        lastPos = p;
                        // var delta = touches.ToArray()[0].deltaPosition;
                        // var deltaTime = touches.ToArray()[0].deltaTime;
                        delta = new Vector2(
                            delta.x * this.TouchSensitivityMultiplier * this.TouchAxesMultiplier.x,
                            delta.y * this.TouchSensitivityMultiplier * this.TouchAxesMultiplier.y);
                        this.Events.OnTouchDeltaPosition.Invoke(delta);
                    }
                } else {
                    bTouchDeltaPosition = false;
                }
            }
        }
    }
}
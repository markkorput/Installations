using UnityEngine;
using UnityEngine.Events;

namespace FuseTools
{
    [AddComponentMenu("Fusetools/MouseExt")]
	public class MouseExt : MonoBehaviour {
        public enum AxesWhen { Never, AlwaysOnUpdate, OnUpdateWhenPrimaryButtonDown };
        [System.Serializable]
		public class Evts
		{
            public UnityEvent OnMouseDown = new UnityEvent();
            public FloatEvent OnAxisX = new FloatEvent();
            public FloatEvent OnAxisY = new FloatEvent();
            public Vector2Event OnAxes = new Vector2Event();
            public BoolEvent OnPrimaryMouseButton = new BoolEvent();
        }

        public AxesWhen InvokeAxesWhen = AxesWhen.Never;
        public bool InvokePrimaryMouseButtonOnUpdate = false;

        public float SensitivityMultiplier = 1.0f;
        public Vector2 AxesFactors = new Vector2(1.0f, 1.0f);

        public Evts Events = new Evts();

        public float InputMouseX { get { return Input.GetAxis("Mouse X") * this.SensitivityMultiplier * AxesFactors.x; }}
        public float InputMouseY { get { return Input.GetAxis("Mouse Y") * this.SensitivityMultiplier * AxesFactors.y; }}

        private bool primaryWasDown = false;

        #region Unity Methods
        void Update() {
            if (this.InvokeAxesWhen.Equals(AxesWhen.AlwaysOnUpdate) ||
                (this.InvokeAxesWhen.Equals(AxesWhen.OnUpdateWhenPrimaryButtonDown) && Input.GetMouseButton(0))) {
                this.InvokeAxisXY();
            }

            if (this.InvokePrimaryMouseButtonOnUpdate) {
                var down = Input.GetMouseButton(0);
                if (down != primaryWasDown) {
                    this.Events.OnPrimaryMouseButton.Invoke(down);
                    this.primaryWasDown = down;
                }
            }
        }

        void OnMouseDown(){
            this.Events.OnMouseDown.Invoke();
        }
        #endregion

        #region Public Action Methods
        public void InvokeAxisX() {
            this.Events.OnAxisX.Invoke(InputMouseX);
        }

        public void InvokeAxisY() {
            this.Events.OnAxisY.Invoke(InputMouseY);
        }

        public void InvokeAxisXY() {
            var vec2 = new Vector2(InputMouseX, InputMouseY);
            this.Events.OnAxisX.Invoke(vec2.x);
            this.Events.OnAxisY.Invoke(vec2.y);
            this.Events.OnAxes.Invoke(vec2);
        }

        #endregion
    }
}
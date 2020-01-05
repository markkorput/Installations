using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Playables;

namespace FuseTools
{
	/// <summary>
	/// 
	/// </summary>
	/// 
	[AddComponentMenu("FuseTools/UiRawImageExt")]
	public class UiRawImageExt : MonoBehaviour
	{
		[Tooltip("Defaults to first PlayableDirector found on this GameObject")]
		public UnityEngine.UI.RawImage RawImage;
		public Color[] Colors;

		private UnityEngine.UI.RawImage Resolved { get { return this.RawImage != null ? this.RawImage : this.GetComponentInChildren<UnityEngine.UI.RawImage>();}}

		//[System.Serializable]
		//public class Evts
		//{
		//	public UnityEvent Played;
		//}
      
		//public Evts Events;

		//private void OnDestroy()
		//{
		//}
      
		#region Public Methods
		public void SetColor(int idx) {
			if (this.Resolved != null) this.Resolved.color = this.Colors[idx];
		}

		public void CloneMaterial() {
			this.Resolved.material = new Material(this.Resolved.material);
		}

		public void SetAlpha(float alpha) {
			var resolved = this.Resolved;
			if (resolved == null) return;
			resolved.color = new Color(resolved.color.r, resolved.color.g, resolved.color.b, alpha);
		}

		public void TranslateUV_U(float u) {
			var rect = Resolved.uvRect;
			rect.x += u;
			Resolved.uvRect = rect;
		}

		public void TranslateUV_V(float v) {
			var rect = Resolved.uvRect;
			rect.y += v;
			Resolved.uvRect = rect;
		}

		public void TranslateUV(Vector3 uv) {
			var rect = Resolved.uvRect;
			rect.x += uv.x;
			rect.y += uv.y;
			Resolved.uvRect = rect;
		}
		#endregion
	}
}
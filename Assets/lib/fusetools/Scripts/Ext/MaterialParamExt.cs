using UnityEngine;
using UnityEngine.Events;

namespace FuseTools
{
	[AddComponentMenu("FuseTools/MaterialParamExt")]
	public class MaterialParamExt : MonoBehaviour {
		
		public Material TheMaterial;
		public UnityEngine.UI.RawImage RawImage;
		public MeshRenderer MeshRenderer;
		public string ParamName;
		public bool CreateMaterialClone = true;

		private Material m = null;
		private Color originalColor;
		private bool originalColorSet = false;

		public Material resolved { get {
			if (this.m != null) return this.m;

			if (this.TheMaterial != null) {
				this.m = this.TheMaterial;
				return this.m;
			}

			if (this.RawImage != null) {
				if (this.CreateMaterialClone) this.RawImage.material = new Material(this.RawImage.material);
				this.m = this.RawImage.material;
				return this.m;
			}

			if (this.MeshRenderer != null) {
				if (this.CreateMaterialClone) this.MeshRenderer.material = new Material(this.MeshRenderer.material);
				this.m = this.MeshRenderer.material;
				return this.m;
			}

			return null;
		}}

		public void SetFLoat(float v) {
			this.resolved.SetFloat(this.ParamName, v);
		}

		public void AddFLoat(float v) {
			this.resolved.SetFloat(this.ParamName, this.resolved.GetFloat(this.ParamName)+v);
		}

		public void SetColorAlpha(float v) {
			if (!originalColorSet) {
				originalColor = this.resolved.GetColor(this.ParamName);
				originalColorSet = true;
			}

			var clr = new Color(originalColor.r, originalColor.g, originalColor.b, v);
			this.resolved.SetColor(this.ParamName, clr);
		}

		public void SetBrightness(float v) {
			if (!originalColorSet) {
				originalColor = this.resolved.GetColor(this.ParamName);
				originalColorSet = true;
			}

			var clr = new Color(originalColor.r*v, originalColor.g*v, originalColor.b*v);
			this.resolved.SetColor(this.ParamName, clr);
		}

		public void SetTextureOffset(Vector2 vec) {
			this.resolved.SetTextureOffset(this.ParamName, vec);
		}

		public void SetTextureOffset_X(float x) {
			var offset = this.resolved.GetTextureOffset(this.ParamName);
			// var names = this.resolved.GetTexturePropertyNames();
			// var ids = this.resolved.GetTexturePropertyNameIDs();
			this.resolved.SetTextureOffset(this.ParamName, new Vector2(x, offset.y));
		}

		public void SetTextureOffset_Y(float y) {
			var offset = this.resolved.GetTextureOffset(this.ParamName);
			// var names = this.resolved.GetTexturePropertyNames();
			// var ids = this.resolved.GetTexturePropertyNameIDs();
			this.resolved.SetTextureOffset(this.ParamName, new Vector2(offset.x, y));
		}
	}
}
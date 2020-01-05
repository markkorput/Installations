using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

namespace FuseTools
{
	public class ScreenExt : MonoBehaviour
	{
		#region Public Action Methods
		public void SetResolutionWindowed(Vector2Int res)
		{
			Screen.SetResolution(res.x, res.y, false);         
		}

		public void SetResolutionFullscreen(Vector2Int res)
		{
			Screen.SetResolution(res.x, res.y, true);
    }

		public void SetAutorotateToLandscapeLeft(bool val) {
			Screen.autorotateToLandscapeLeft = val;
		}
		public void SetAutorotateToLandscapeRight(bool val) {
			Screen.autorotateToLandscapeRight = val;
		}
		public void SetAutorotateToPortrait(bool val) {
			Screen.autorotateToPortrait = val;
		}
		public void SetAutorotateToPortraitUpsideDown(bool val) {
			Screen.autorotateToPortraitUpsideDown = val;
		}
		#endregion
	}
}

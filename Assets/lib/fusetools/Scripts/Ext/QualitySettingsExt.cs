using System;
using UnityEngine;

namespace FuseTools
{
	public class QualitySettingsExt : MonoBehaviour
	{
    public bool ApplyExpensiveChanges;

		#region Public Action Methods
		public void SetQualityLevel(int qualityLevelIndex)
		{
      QualitySettings.SetQualityLevel(qualityLevelIndex, this.ApplyExpensiveChanges);
		}
		#endregion
	}
}

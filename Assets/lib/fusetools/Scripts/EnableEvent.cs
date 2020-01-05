using UnityEngine;
using UnityEngine.Events;

namespace FuseTools
{
	/// <summary>
	/// Simple component that triggers an event when it enables
	/// </summary>
	/// 
	[AddComponentMenu("FuseTools/EnableEvent")]
	public class EnableEvent : MonoBehaviour
	{
		public UnityEvent Enable;

		void OnEnable()
		{
			this.Enable.Invoke();
		}
	}
}
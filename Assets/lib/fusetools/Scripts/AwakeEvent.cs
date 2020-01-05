using UnityEngine;
using UnityEngine.Events;

namespace FuseTools
{
	/// <summary>
	/// Simple component that triggers an event when it awakes
	/// </summary>
	/// 
	[AddComponentMenu("FuseTools/AwakeEvent")]
	public class AwakeEvent : MonoBehaviour
	{
		public UnityEvent OnAwake;

		void Awake()
		{
			this.OnAwake.Invoke();
		}
	}
}
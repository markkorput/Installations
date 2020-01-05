using UnityEngine;
using UnityEngine.Events;

namespace FuseTools
{
	/// <summary>
	/// Simple component that triggers an event when it updates
	/// </summary>
	/// 
	[AddComponentMenu("FuseTools/UpdateEvent")]
	public class UpdateEvent : MonoBehaviour
	{
		public UnityEvent OnUpdate;
		public UnityEvent OnFixedUpdate;

		void Update()
		{
			this.OnUpdate.Invoke();
		}

		void FixedUpdate()
		{
			this.OnFixedUpdate.Invoke();
		}
	}
}
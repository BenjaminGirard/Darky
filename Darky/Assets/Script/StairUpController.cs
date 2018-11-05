using System.Runtime.Remoting.Messaging;
using UnityEngine;

namespace Script
{
	public class StairUpController : MonoBehaviour {
		public void OnTriggerStay2D(Collider2D other)
		{
			if (!other.gameObject.CompareTag("Player"))
				return;				
			var rigBody = other.GetComponent<Rigidbody2D>();
			var animator = other.GetComponent<Animator>();

			animator.applyRootMotion = true;
			rigBody.gravityScale = 0;
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			
			if (!other.gameObject.CompareTag("Player"))
				return;
			
			var rigBody = other.GetComponent<Rigidbody2D>();
			var animator = other.GetComponent<Animator>();

			animator.applyRootMotion = false;
			rigBody.gravityScale = 1;
		}
	}
}

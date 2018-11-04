using UnityEngine;

namespace Script
{
	public class StairUpController : MonoBehaviour {
		public void OnTriggerStay2D(Collider2D other)
		{
			var rigBody = other.GetComponent<Rigidbody2D>();

			rigBody.gravityScale = 0;
		}

		private void OnTriggerExit2D(Collider2D other)
		{
			var rigBody = other.GetComponent<Rigidbody2D>();

			rigBody.gravityScale = 1;
		}
	}
}

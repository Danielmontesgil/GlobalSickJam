using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ai {
	public class AIAttack : MonoBehaviour {

		public EnemyStats enemyStats;
		[SerializeField] private float seconds;
		
		/*void OnTriggerStay (Collider other) {
			var destrutable = other.GetComponent<Health> ();
			if (destrutable == null)
				return;

			destrutable.TakeDamage (enemyStats.attackDamage);
		}*/
	}
}
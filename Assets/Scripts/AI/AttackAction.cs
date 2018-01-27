using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ai {
	[CreateAssetMenu (menuName = "AI/Actions/Attack")]
	public class AttackAction : Action {

		public override void Act (StateController controller) {
			Attack (controller);
		}

		private void Attack (StateController controller) {

			if (controller.chaseTarget != null) {
				controller.dist = Vector3.Distance (controller.chaseTarget.transform.position, controller.transform.position);

				if (controller.dist <= controller.enemyStats.attackRange) {
					if (controller.CheckIfCountDownElapse (controller.enemyStats.attackRate)) {


						
					}
				}
			}
		}
	}
}
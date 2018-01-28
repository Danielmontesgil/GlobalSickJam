using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ai {
	[CreateAssetMenu (menuName = "AI/Actions/Patrol")]
	public class PatrolAction : Action {

		public override void Act (StateController controller) {
			Patrol (controller);
		}

		private void Patrol (StateController controller) {
			if (controller.wayPointList == null) return;
            controller.transform.position = Vector2.MoveTowards(controller.transform.position, controller.wayPointList[controller.nextWayPoint].transform.position, controller.enemyStats.moveSpeed * controller.delta);

            if (controller.transform.position == controller.wayPointList[controller.nextWayPoint].transform.position)
            {
                controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Length;
            }
		}
	}
}
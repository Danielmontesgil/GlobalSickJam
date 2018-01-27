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
            Vector2 targetDir = controller.wayPointList[controller.nextWayPoint].transform.position - controller.vision.transform.position;

            Quaternion targetRot = Quaternion.LookRotation(targetDir);

            controller.vision.transform.rotation = Quaternion.RotateTowards(controller.vision.transform.rotation, targetRot, controller.enemyStats.turnSpeed * controller.delta);

            if (controller.transform.position == controller.wayPointList[controller.nextWayPoint].transform.position) {
				controller.nextWayPoint = (controller.nextWayPoint + 1) % controller.wayPointList.Length;
			}
		}

	}
}
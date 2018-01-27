using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ai {
    [CreateAssetMenu(menuName = "AI/Actions/Chase")]
    public class ChaseAction : Action {

        public override void Act(StateController controller) {
            Chase(controller);
        }

        private void Chase(StateController controller) {
            if (controller.chaseTarget != null) {
                controller.transform.position = Vector2.MoveTowards(controller.gameObject.transform.position, 
                    controller.chaseTarget.transform.position, controller.enemyStats.moveSpeed * controller.delta);

                Vector2 targetDir = controller.chaseTarget.transform.position - controller.vision.transform.position;

                targetDir.x = 0;

                Quaternion targetRot = Quaternion.LookRotation(targetDir);
                controller.vision.transform.rotation = Quaternion.RotateTowards(controller.vision.transform.rotation, targetRot, controller.enemyStats.turnSpeed * controller.delta);
            }
        }
	}
}
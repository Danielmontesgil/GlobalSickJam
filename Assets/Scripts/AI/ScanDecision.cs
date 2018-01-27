using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ai {
	[CreateAssetMenu (menuName = "AI/Decisions/Scan")]
	public class ScanDecision : Decision {

		public override bool Decide (StateController controller) {
			bool noEnemySight = Scan (controller);
			return noEnemySight;
		}

		private bool Scan (StateController controller) {
			Vector3 targetDir = controller.transform.position;
			return controller.CheckIfCountDownElapse (controller.enemyStats.shearchDuration);
		}

	}
}
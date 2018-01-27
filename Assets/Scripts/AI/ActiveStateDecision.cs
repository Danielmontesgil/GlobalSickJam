using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ai {
	[CreateAssetMenu (menuName = "AI/Decisions/ActiveState")]
	public class ActiveStateDecision : Decision {

		public override bool Decide (StateController controller) {
			if (controller.chaseTarget != null) {
				bool chaseTargetActive = controller.chaseTarget.gameObject.activeSelf;
				return chaseTargetActive;
			}
			return false;
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ai {
	[CreateAssetMenu (menuName = "AI/Decisions/Look")]
	public class LookDecision : Decision {

		public override bool Decide (StateController controller) {
			bool targetVisible = Look (controller);
			return targetVisible;
		}

		private bool Look (StateController controller) {

			if (controller.chaseTarget != null) {
				return true;
			} else {
				return false;
			}
		}
	}
}
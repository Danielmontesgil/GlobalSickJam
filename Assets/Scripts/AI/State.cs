﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ai {
	[CreateAssetMenu (menuName = "AI/State")]
	public class State : ScriptableObject {

		public Action[] actions;
		public Transition[] transitions;
		public Color sceneGizmoColor = Color.white;

		public void UpdateState (StateController controller) {
			DoActions (controller);
			CheckTransitions (controller);
		}

		private void DoActions (StateController controller) {
			for (int i = 0; i < actions.Length; i++) {
				actions[i].Act (controller);
			}
		}

		private void CheckTransitions (StateController controller) {
			for (int i = 0; i < transitions.Length; i++) {
				bool decisionSucceded = transitions[i].decision.Decide (controller);

				if (decisionSucceded) {
					controller.TransitionToState (transitions[i].trueState);
				} else {
					controller.TransitionToState (transitions[i].falseState);
				}
			}
		}

	}
}
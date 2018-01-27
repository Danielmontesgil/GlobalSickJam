using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ai {
    [CreateAssetMenu (menuName = "AI/Actions/Random Patrol")]
    public class RandomPatrolAction : Action {

        public override void Act (StateController controller) {
            RandomPatrol (controller);
        }

        public void RandomPatrol (StateController controller) { }

    }
}
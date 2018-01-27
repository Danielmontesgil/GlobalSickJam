using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Ai {
	public class EnemyAnimation : MonoBehaviour {

        public EnemyStats enemyStats;

		public float deadZone = 5f;
		public float speedDampTime = 0.1f;
		public float angularSpeedDampTime = 0.7f;
		public float angleResponseTime = 0.6f;

		Transform player;
		Animator animator;

		float speed;
		float angle;

		public void Init () {
			animator = GetComponent<Animator> ();

			deadZone *= Mathf.Deg2Rad;
		}

		public void Tick () {
            Setup();
		}

		void OnAnimatorMove () {
			//navMeshAgent.velocity = animator.deltaPosition / Time.deltaTime;
			transform.rotation = animator.rootRotation;
		}

		void Setup () {
			animator.SetFloat ("vertical",transform.position.x, speedDampTime, Time.deltaTime);
			animator.SetFloat ("horizontal", transform.position.y, angularSpeedDampTime, Time.deltaTime);
		}

		float FindAngle (Vector2 fromVector, Vector2 toVector) {

			if (toVector == Vector2.zero) return 0f; 

			float angle = Vector2.Angle (fromVector, toVector);

			Vector2 normal = Vector3.Cross (fromVector, toVector);

			return angle;
		}
	}
}
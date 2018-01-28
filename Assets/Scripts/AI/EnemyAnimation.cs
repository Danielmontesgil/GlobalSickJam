using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Ai {
	public class EnemyAnimation : MonoBehaviour {

        private Rigidbody2D rb;

        public EnemyStats enemyStats;
        public StateController stateController;
        public GameObject attackArea;

		public float speedDampTime = 0.1f;

		Transform player;
		Animator animator;

		float speed;
		float angle;

		public void Init () {
			animator = GetComponent<Animator> ();
            rb = GetComponent<Rigidbody2D>();
            stateController = GetComponent<StateController>();
		}

		public void Tick () {
            Setup();

        }

		void Setup () {

            Vector2 targetDir = stateController.chaseTarget.transform.position - transform.position;


            animator.SetFloat("vertical",  -targetDir.normalized.y, speedDampTime, Time.deltaTime);
            animator.SetFloat("horizontal", targetDir.normalized.x, speedDampTime, Time.deltaTime);

            if (attackArea == null) return;
            if (-targetDir.normalized.x > .5f)
            {
                Vector2 position = new Vector2(-3.26f, -2.26f);
                attackArea.transform.localPosition = position;
                Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 90f));
                attackArea.transform.localRotation = rotation;
            }
            else if (-targetDir.normalized.x < -.5f)
            {
                Vector2 position = new Vector2(3.26f, -2.26f);
                attackArea.transform.localPosition = position;
                Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 270f));
                attackArea.transform.localRotation = rotation;
            }
            else if (targetDir.normalized.y > .01f)
            {
                Vector2 position = new Vector2(0.08f, 4.09f);
                attackArea.transform.localPosition = position;
                Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 0f));
                attackArea.transform.localRotation = rotation;
            }
            else if (targetDir.normalized.y < -.01f)
            {
                Vector2 position = new Vector2(0.31f, -5.86f);
                attackArea.transform.localPosition = position;
                Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, 180f));
                attackArea.transform.localRotation = rotation;
            }
        }
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Ai {

    public class StateController : MonoBehaviour {

    public State currentState;
    public EnemyStats enemyStats;
    public State remainState;
    public Transform[] wayPointList;
    public Collider[] colliders;
    public AudioSource audioSource;
    public AudioClip audioSuJuejo;

    [HideInInspector] public int nextWayPoint;
    [HideInInspector] public int randomAttack;
    [HideInInspector] public GameObject chaseTarget;
    [HideInInspector] public float stateTimeElapsed;
    [HideInInspector] public float dist;

    [HideInInspector] public new Transform transform;

    [HideInInspector] public float delta;

    bool wasRang = false;

    private EnemyAnimation _enemyAnimation;
    public EnemyAnimation enemyAnimation {
      get {
        if (_enemyAnimation == null)
          _enemyAnimation = GetComponent<EnemyAnimation> ();
        return _enemyAnimation;
      }
    }

    void Awake () {
      transform = GetComponent<Transform> ();
            audioSource = GetComponent<AudioSource>();

      enemyAnimation.Init();

      if (chaseTarget == null)
      chaseTarget = GameObject.FindGameObjectWithTag ("Player");

      GameObject[] wayPointObjects = GameObject.FindGameObjectsWithTag ("Waypoint");
      wayPointList = new Transform[wayPointObjects.Length];

      for (int i = 0; i < wayPointList.Length; ++i) {
        wayPointList[i] = wayPointObjects[i].transform;

        Debug.Log (wayPointList.Length);
      }
    }

    public void Update () {
      delta = Time.deltaTime;

      currentState.UpdateState (this);

            enemyAnimation.Tick();
            UpdateLife();
    }

    void UpdateLife()
        {
            if (GameManagers.Instance.lifes == 50 && !wasRang)
            {
                if (audioSource.isPlaying) return;
                if (audioSuJuejo == null) return;
                audioSource.PlayOneShot(audioSuJuejo, 1f);
                wasRang = true;
            }
        }

      public void TransitionToState (State nextState) {
      if (nextState != remainState) {
        currentState = nextState;
        OnExitState ();
      }
    }

    public bool CheckIfCountDownElapse (float duration) {
      stateTimeElapsed += Time.deltaTime;
      return (stateTimeElapsed >= duration);
    }

        public void OnExitState()
        {
            stateTimeElapsed = 0;
        }
    }
}
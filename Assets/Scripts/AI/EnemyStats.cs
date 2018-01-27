using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Ai {
  [CreateAssetMenu (menuName = "AI/EnemyStats")]
  public class EnemyStats : ScriptableObject {

    public float moveSpeed = 1f;
    public float turnSpeed = 40f;
    public float lookRange = 40f;
    public float lookSphereCastRadius = 1f;

    public float attackRange = 1f;
    public float attackRate = 1f;
    public float attackForce = 15f;
    public int attackDamage = 10;

    public float shearchDuration = 4f;
    public float searchingTurnSpeed = 120f;

  }
}
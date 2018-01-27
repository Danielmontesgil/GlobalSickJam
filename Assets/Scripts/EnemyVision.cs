using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour {

    [Range(0, 360)]
    public float viewAngle;
    public float range;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    [HideInInspector]
    public List<Transform> visibleTargets = new List<Transform>();

    void Update()
    {
        FindVisibleTargets();
    }

    private void FindVisibleTargets()
    {
        visibleTargets.Clear();
        Collider[] targertsInViewRadius = Physics.OverlapSphere(transform.position, range, targetMask);
        RaycastHit hit;

        for (int i = 0; i < targertsInViewRadius.Length; i++)
        {
            Transform target = targertsInViewRadius[i].transform;
            Vector2 dirToTarget = (target.position - transform.position).normalized;
            if (Vector2.Angle(transform.forward, dirToTarget) < viewAngle / 2)
            {
                if (Physics.Raycast(transform.position, dirToTarget, out hit, range))
                {
                    if (hit.transform.name == target.transform.name)
                    {

                    }
                }
            }
        }
    }

    public virtual Vector2 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
    {
        if (!angleIsGlobal)
        {
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector2(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
}

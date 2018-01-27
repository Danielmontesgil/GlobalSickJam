using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour {

    [Range(0, 360)]
    public float viewAngle;
    public float range;
    public Collider2D[] targertsInViewRadius;
    private Vector2 dirToTarget;
    private Transform target;

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public Weapons currentWeapon;

    void Update()
    {
        FindVisibleTargets();
    }

    public void FindVisibleTargets()
    {
        targertsInViewRadius = Physics2D.OverlapCircleAll(transform.position, range, targetMask);
        RaycastHit2D hit;

        for (int i = 0; i < targertsInViewRadius.Length; i++)
        {
            target = targertsInViewRadius[i].transform;
            dirToTarget = (target.position - transform.position).normalized;
            if (Vector2.Angle(transform.up, dirToTarget) < viewAngle / 2)
            {
                hit = Physics2D.Raycast(transform.position, dirToTarget, range);
                if (hit!=null)
                {
                    if (hit.transform.name == target.transform.name)
                    {
                        
                        Interaction(target.gameObject);
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

    public void Interaction(GameObject cosa)
    {
        if (Input.GetButtonDown(StaticsInput.interaction)) //RECOGER----------------------
        {
            Weapons weapons = cosa.GetComponent<Weapons>();
            if (weapons != null)
            {
                WeaponManager.Instance.AddWeapon(weapons.data);
                currentWeapon = weapons;
            }
        }
        
        if (Input.GetButtonDown(StaticsInput.interaction)) 
        {
            Spotsitos spot = cosa.GetComponent<Spotsitos>();
            if (spot != null)
            {
                currentWeapon.Attack(Interactions.CanInteract(currentWeapon.data, spot.spotType));
            }
        }
    }
}


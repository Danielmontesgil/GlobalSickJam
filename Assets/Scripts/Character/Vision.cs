using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{

    [Range(0, 360)]
    public float viewAngle;
    public float range;
    public Collider2D[] targertsInViewRadius;
    private Vector2 dirToTarget;
    private Transform target;
    public List<GameObject> targets = new List<GameObject>();

    public LayerMask targetMask;
    public LayerMask obstacleMask;

    public Weapons currentWeapon ;

	private static Vision instance;
	public static Vision Instance{
	
		get{
			return instance;
		}
	
	}
	public void Awake(){
		if (instance == null) {
			instance = this;
		} else {
			Destroy (this.gameObject);
		}

	}

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
                hit = Physics2D.Raycast(transform.position, dirToTarget, range, targetMask);
                if (hit)
                {
                    Debug.Log(hit.transform.name);
                    if (hit.transform.name == target.transform.name)
                    {
                        targets.Add(target.transform.gameObject);
                    }
                }
            }
        }
        if (targets.Count != 0)
        {
            Interaction(targets);
            for (int i = 0; i < targets.Count; i++)
            {
                targets.RemoveAt(0);
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

    public void Interaction(List<GameObject> cosa)
    {
        if (Input.GetButtonDown(StaticsInput.pickUp)) //RECOGER----------------------
        {
            Weapons weapons = cosa[0].GetComponent<Weapons>();
            if (weapons != null)
            {
                if (currentWeapon != null)
                {
                    WeaponManager.Instance.AddWeapon(Interactions.GetNewWeapon(GetComponentInParent<MovementController>().gameObject, weapons, currentWeapon));
                }
                else
                {
                    WeaponManager.Instance.AddWeapon(Interactions.GetNewWeapon(GetComponentInParent<MovementController>().gameObject, weapons));
                }
                currentWeapon = weapons;
            }
        }

        if (Input.GetButtonDown(StaticsInput.interaction))
        {
            Spotsitos spot = cosa[0].GetComponent<Spotsitos>();
            if (spot != null)
            {
				if (currentWeapon != null) {
					WeaponManager.Instance.PlaySound ();
					currentWeapon.Attack(Interactions.CanInteract(currentWeapon.data, spot.spotType), cosa);
				}
            }
        }
    }

	public void LoseWeapon()
	{
		currentWeapon = null;
		//currentWeapon = Vision.lastWeapon;
	}
}


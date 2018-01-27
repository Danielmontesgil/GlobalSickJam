using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Syringe : Weapons {

    [SerializeField]
	Collider2D[] hitColliders;
    [SerializeField]
    Vector2 center;
    [SerializeField]
    float radius;
    [SerializeField]
    int iSee;
    [SerializeField]
    BoxCollider2D syringe;
    [SerializeField]
    LayerMask layerMask;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        center = transform.position;
        
    }

	public override void Attack(InteractResponse response)
    {
        print(response.canInteract);
        if (response.canInteract)
        {
            hitColliders = Physics2D.OverlapCircleAll(center, radius,layerMask);
            iSee = 0;
            if (hitColliders.Length < 2)
            {
                Debug.Log("no te vieron");
            }
            else
            {
                Debug.Log("te vieron");
            }
        }
    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(center, radius);
    }
    IEnumerator Disable()
    {
        yield return new WaitForSeconds(1f);
        syringe.enabled = false;
    }
}

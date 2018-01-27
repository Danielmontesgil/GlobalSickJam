using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : MonoBehaviour {

    [SerializeField]
    protected int index;
    [SerializeField] public ObjectInformation data;

    public virtual void Attack(InteractResponse response)
    {

    }
}

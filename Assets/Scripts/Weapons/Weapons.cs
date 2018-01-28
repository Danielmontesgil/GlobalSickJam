using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Weapons : MonoBehaviour {

    [SerializeField] public ObjectInformation data;

    public virtual void Attack(InteractResponse response,List<GameObject> targets=null)
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(fileName = "Inventory", menuName = "Objects", order = 1)]
public class ObjectsData : ScriptableObject {
	[SerializeField] private List<ObjectInformation> objectsInformation;
}

[Serializable]
public class ObjectInformation
{
	[SerializeField] public int index;
	[SerializeField] public bool helpYou;
	[SerializeField] public string name;
	[SerializeField] public GSJEnums.objectType objectType;
	[SerializeField] public GSJEnums.illnesses illness;
	[SerializeField] public Sprite sprite;
}

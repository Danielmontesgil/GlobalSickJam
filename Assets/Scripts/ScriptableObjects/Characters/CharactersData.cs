using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu(menuName ="Characters/Player Data")]
public class CharactersData : ScriptableObject {
	[SerializeField] public List<CharactersInformation> characters;
}

[Serializable]
public class CharactersInformation
{
	[SerializeField] public int index;
	[SerializeField] public Animator playerAnimator;
	[SerializeField] public Sprite icon;
}

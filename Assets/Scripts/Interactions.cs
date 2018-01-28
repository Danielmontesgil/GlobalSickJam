using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions {

	private static InteractResponse CantInteract(InteractResponse response, ObjectInformation data)
	{
		response.canInteract = false;
		response.killYou = false;
		response.loseObject = false;
		response.score = -2;
		response.message = string.Format("Tu arma, {0}, no puede utilizarse en este sitio. Te vieron, pierdes {1}", data.name, response.score);

		return response;
	}

	public static Weapons GetNewWeapon(GameObject player, Weapons weaponToGet, Weapons currentWeapon = null)
	{
		if (currentWeapon != null) {
			DropWeapon (player,currentWeapon, weaponToGet);
		}
		return weaponToGet;
	}

	private static void DropWeapon(GameObject player,Weapons backWeapon, Weapons weaponToGet)
    {
        if (backWeapon != null)
        {
            backWeapon.transform.position = weaponToGet.gameObject.transform.position;
            backWeapon.gameObject.SetActive(true);
        }
	}

	private static void LoseWeapon()
	{
		
	}

	public static InteractResponse CanInteract(ObjectInformation data, GSJEnums.spots spot)
	{
		InteractResponse response = new InteractResponse();
		switch (spot) {
		case GSJEnums.spots.jara:
			response.canInteract = true;
			response.killYou = false;
			response.loseObject = true;
			response.score = 0;
			response.message = "El jara ha tomado prestado por siempre tu objeto";
                Debug.Log("aora io soi pior");
                break;
		case GSJEnums.spots.mono:
			response.canInteract = true;
			response.killYou = true;
			response.loseObject = true;
                response.score = -999999999;
                response.message = "Tu arma es efectiva pero el mono es PIOR";
                Debug.Log("soi pior");
			break;
		case GSJEnums.spots.ducha:
			if (data.objectType == GSJEnums.objectType.soap) {
				response.canInteract = true;
				response.killYou = false;
				response.loseObject = true;
				response.score = 1;
				response.message = string.Format ("Has infectado la ducha con {0}", data.illness);
			}
			else {
				response = CantInteract (response, data);
			}
			break;
		case GSJEnums.spots.group:
			if (data.objectType == GSJEnums.objectType.gas) {
				response.canInteract = true;
				response.killYou = false;
				response.loseObject = true;
				response.score = 3;
				response.message = string.Format("Has infectado a la multitud con {0}", data.illness);
			}else {
				response = CantInteract (response, data);
			}
			break;
		case GSJEnums.spots.pizza:
			if (data.objectType == GSJEnums.objectType.polvo) {
				response.canInteract = true;
				response.killYou = false;
				response.loseObject = true;
				response.score = 5;
				response.message = string.Format("Has infectado la pizza con {0}", data.illness);
			}else {
				response = CantInteract (response, data);
			}
			break;
		case GSJEnums.spots.single:
			if (data.objectType == GSJEnums.objectType.syringe) {
				response.canInteract = true;
				response.killYou = false;
				response.loseObject = true;
				response.score = 1;
				response.message = string.Format("Has infectado a la multitud con {0}", data.illness);
			}else {
				response = CantInteract (response, data);
			}
			break;
		case GSJEnums.spots.tinto:
			if (data.objectType == GSJEnums.objectType.liquido) {
				response.canInteract = true;
				response.killYou = false;
				response.loseObject = true;
				response.score = 1;
				response.message = string.Format("Has infectado a la máquina de tinto con {0}", data.illness);
			}else {
				response = CantInteract (response, data);
			}
			break;
		case GSJEnums.spots.voidChair:
			if (data.objectType == GSJEnums.objectType.chinche) {
				response.canInteract = true;
				response.killYou = false;
				response.loseObject = true;
				response.score = 2;
				response.message = string.Format("Has puesto {0} en la silla", data.illness);
			}else {
				response = CantInteract (response, data);
			}
			break;
		}
		return response;
	}
}

public class InteractResponse
{
	public int score;
	public bool canInteract;
	public bool killYou;
	public bool loseObject;
	public string message;
}

public class InteractObject
{

}

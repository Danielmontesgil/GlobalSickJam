﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactions {

	private static InteractResponse CantInteract(InteractResponse response, ObjectInformation data)
	{
		response.canInteract = false;
		response.killYou = false;
		response.loseObject = false;
		response.message = string.Format("Tu arma, {0}, no puede utilizarse en este sitio", data.name);

		return response;
	}

	public static InteractResponse CanInteract(ObjectInformation data, GSJEnums.spots spot)
	{
		InteractResponse response = new InteractResponse();
		switch (spot) {
		case GSJEnums.spots.jara:
			response.canInteract = false;
			response.killYou = false;
			response.loseObject = true;
			response.message = "El jara ha tomado prestado por siempre tu objeto";
			break;
		case GSJEnums.spots.mono:
			response.canInteract = false;
			response.killYou = true;
			response.loseObject = true;
			response.message = "Tu arma es efectiva pero el mono es PIOR";
			break;
		case GSJEnums.spots.ducha:
			if (data.objectType == GSJEnums.objectType.soap) {
				response.canInteract = true;
				response.killYou = false;
				response.loseObject = false;
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
				response.message = string.Format("Has infectado a la máquina de tinto con {0}", data.illness);
			}else {
				response = CantInteract (response, data);
			}
			break;
		case GSJEnums.spots.voidChair:
			if (data.objectType == GSJEnums.objectType.chinche) {
				response.canInteract = true;
				response.killYou = true;
				response.loseObject = true;
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
	public bool canInteract;
	public bool killYou;
	public bool loseObject;
	public string message;
}
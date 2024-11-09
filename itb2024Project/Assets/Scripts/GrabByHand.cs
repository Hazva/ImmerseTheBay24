using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GrabByHand : XRGrabInteractable
{
	protected override void OnSelectEntered(XRBaseInteractor interactor)
	{

		Debug.Log(interactor);

		base.OnSelectEntered(interactor);
	}
}

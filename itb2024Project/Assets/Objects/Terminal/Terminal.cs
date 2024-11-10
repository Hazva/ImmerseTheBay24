using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Terminal : MonoBehaviour
{
    TMP_InputField inputField;

	GameObject startScreen;
	GameObject inputScreen;

	private void Awake()
	{
		inputField = GetComponent<TMP_InputField>();
		inputField.onSubmit.AddListener(Submit);
	}

	public void Submit(string text)
	{
		inputScreen.SetActive(false);
	}

}

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Terminal : MonoBehaviour
{
    public TMP_InputField inputField;

	public GameObject startScreen;
	public GameObject inputScreen;
	public GameObject keyboard;
	ChatGPT gpt;

	private void Awake()
	{
		gpt = GetComponent<ChatGPT>();
		inputField.onSubmit.AddListener(Submit);
	}

	public void SwapToKeyboard()
	{
		startScreen.SetActive(false);
		inputScreen.SetActive(true);
		keyboard.SetActive(true);
	}

	public void Submit(string text)
	{
		inputScreen.SetActive(false);
		keyboard.SetActive(false);
		StartCoroutine(gpt.PostResponse(text));
		StartCoroutine(EndScene());
	}

	IEnumerator EndScene()
	{
		yield return new WaitForSeconds(5);
		SceneManager.LoadScene("Ending");
	}

}

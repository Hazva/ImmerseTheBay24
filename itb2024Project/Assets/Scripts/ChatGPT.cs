using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class ChatGPT : MonoBehaviour
{

	// I spent five dollars.

	const string URL = "https://api.openai.com/v1/chat/completions";
	// shhhhh
	const string TOKEN = "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";

	UnityEvent<string> textEvent;
	Regex regex = new Regex("/[ A-Za-z0-9_@./&+-]$/");
	public TextMeshProUGUI outputText;

	private void Start()
	{
		// StartCoroutine(PostResponse("Tell me the history of carpet"));
	}

	public IEnumerator PostResponse(string input)
	{
		UnityWebRequest request = new UnityWebRequest(URL, "POST");

		request.SetRequestHeader("Content-Type", "application/json");
		request.SetRequestHeader("Authorization", "Bearer " + TOKEN);

		// This is the worst.
		string body =
		"{" +
			"\"model\": \"gpt-3.5-turbo\"," +
			"\"messages\": [" +
				"{" +
					"\"role\": \"system\"," +
					"\"content\": \"What do you wish to know?\"" +
				"}," +
				"{" +
					"\"role\": \"user\"," +
					"\"content\": \"Speak with a verbose, somewhat archaic, imposing tone.\"" +
				"}," +
				"{" +
					"\"role\": \"system\"," +
					"\"content\": \"Understood. My utterances shall be those occluded to the unwit.\"" +
				"}," +
				"{" +
					"\"role\": \"user\"," +
					"\"content\": \"" + input + "\"" + 
				"}" +
			"]" +
		"}";

		byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(body);
		request.uploadHandler = new UploadHandlerRaw(bodyRaw);
		request.downloadHandler = new DownloadHandlerBuffer();

		

		yield return request.SendWebRequest();

		if (request.result != UnityWebRequest.Result.Success)
		{
			Debug.LogError("Error: " + request.error);
		}
		else
		{
			HandleText(regex.Match(request.downloadHandler.text).ToString());
		}
	}

	IEnumerator TextCoroutine(string text)
	{
		int i = 0;
		while (i < text.Length)
		{
			outputText.text = text.Substring(0, i);
			yield return new WaitForSeconds(0.016f);
		}
	}

	private void HandleText(string text)
	{
		StartCoroutine(TextCoroutine(text));
	}
}

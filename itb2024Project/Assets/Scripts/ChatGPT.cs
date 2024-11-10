using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Purchasing.MiniJSON;

public class EvilRobot : MonoBehaviour
{

	// I spent five dollars.

	const string URL = "https://api.openai.com/v1/chat/completions";
	// shhhhh
	const string TOKEN = "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";

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
			"\"model\": \"gpt-4o-mini\"," +
			"\"messages\": [" +
				"{" +
					"\"role\": \"system\"," +
					"\"content\": \"What do you wish to know?\"" +
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
			HandleText(request.downloadHandler.text);
		}
	}

	private void HandleText(string text)
	{
		Debug.Log(text);
	}
}

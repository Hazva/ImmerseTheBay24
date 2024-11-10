using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundOnCollide : MonoBehaviour
{
    public AudioClip sound;
    public float volume = 0.1f;
	public float forceCoefficient = 0.1f;
    public float maxVolume = 3;
    public float minForce = 1;

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.impulse.magnitude > minForce)
		{
			AudioSource.PlayClipAtPoint(sound, collision.GetContact(0).point, Mathf.Min(maxVolume, volume + forceCoefficient * collision.GetContact(0).impulse.magnitude));
		}
	}
}

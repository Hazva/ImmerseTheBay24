using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    public bool toggle = false;
	public UnityEvent pressEvent;
	public UnityEvent unpressEvent;
	public AudioSource sound;
	public float releaseTime = 0.1f;

	Animator animator;

	Coroutine releaseCoroutine;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.isTrigger)
		{
			sound.Play();
		}
	}

	private void OnTriggerStay(Collider other)
	{
		if (!other.isTrigger)
		{
			animator.SetBool("Press", true);
			if (releaseCoroutine != null )
				StopCoroutine(releaseCoroutine);
			releaseCoroutine = StartCoroutine(ReleaseCoroutine());
		}
	}

	IEnumerator ReleaseCoroutine()
	{
		yield return new WaitForSeconds(releaseTime);
		animator.SetBool("Press", false);
		sound.Play();
	}

	public void Press()
	{
		pressEvent.Invoke();
	}

	//private void OnTriggerExit(Collider other)
	//{
	//	if (!other.isTrigger && !toggle)
	//	{
	//		animator.SetTrigger("Unpress");
	//		sound.Play();
	//	}
	//}

	public void Unpress()
	{
		unpressEvent.Invoke();
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PressurePlate : MonoBehaviour
{
    public bool toggle = false;
	public UnityEvent pressEvent;
	public UnityEvent unpressEvent;
	public AudioSource sound;

	Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.isTrigger)
		{
			animator.SetTrigger("Press");
			sound.Play();
		}
	}

	public void Press()
	{
		pressEvent.Invoke();
	}

	private void OnTriggerExit(Collider other)
	{
		if (!other.isTrigger && !toggle)
		{
			animator.SetTrigger("Unpress");
			sound.Play();
		}
	}

	public void Unpress()
	{
		unpressEvent.Invoke();
	}
}

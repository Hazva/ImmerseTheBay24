using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject rooms;
    public GameObject finalRoom;

	Animator animator;

	private void Awake()
	{
		animator = GetComponent<Animator>();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (!other.isTrigger && other.CompareTag("Player"))
		{
			animator.SetTrigger("Close");
		}
	}

	public void SwapRooms()
	{
		rooms.SetActive(false);
		finalRoom.SetActive(true);
	}
}

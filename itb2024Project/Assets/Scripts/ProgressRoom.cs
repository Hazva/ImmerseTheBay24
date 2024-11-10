using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProgressRoom : MonoBehaviour
{
    public Material activeMaterial;
    public Material inactiveMaterial;
    public GameObject[] targetObjects;
    public int numTargets;
    public int currentPresses;
    public GameObject exitDoor; 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Press()
    {
        currentPresses += 1;
        targetObjects[currentPresses-1].GetComponent<MeshRenderer>().material = activeMaterial;
        if (currentPresses >= numTargets)
        {
            exitDoor.SetActive(false);
        }
    }

    public void Unpress()
    {
        currentPresses -= 1;
        targetObjects[currentPresses].GetComponent<MeshRenderer>().material = inactiveMaterial;
    }
}

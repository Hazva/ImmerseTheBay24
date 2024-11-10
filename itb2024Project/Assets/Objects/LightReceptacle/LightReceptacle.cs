using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightReceptacle : MonoBehaviour
{
    public bool toggle;
    public Material onMaterial;
    public Material offMaterial;
    public MeshRenderer mesh;
	public AudioSource sound;

	public UnityEvent onActivate;
    public UnityEvent onDeactivate;

    Coroutine deactivateCoroutine;

    bool active;

    public void Activate()
    {
        mesh.material = onMaterial;
        if (!active)
        {
            active = true;
            onActivate.Invoke();
			sound.Play();
		}
		if (!toggle)
        {
            if (deactivateCoroutine != null) 
                StopCoroutine(deactivateCoroutine);
            deactivateCoroutine = StartCoroutine(DeactivateCoroutine());
        }
    }

    public void Deactivate()
    {
        if (!toggle)
        {
            active = false;
            mesh.material = offMaterial;
            onDeactivate.Invoke();
        }
    }

    IEnumerator DeactivateCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        Deactivate();
    }
}

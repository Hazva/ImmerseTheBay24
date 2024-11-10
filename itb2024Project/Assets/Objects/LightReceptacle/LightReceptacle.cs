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

    public UnityEvent onActivate;
    public UnityEvent onDeactivate;

    public void Activate()
    {
        mesh.material = onMaterial;
        onActivate.Invoke();
    }

    public void Deactivate()
    {
        if (!toggle)
        {
            mesh.material = offMaterial;
            onDeactivate.Invoke();
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightBeam : MonoBehaviour
{

	public LineRenderer line;
    public Transform pointLight;
    public Light refractLight;
    int depthLimit = 50;

	// Update is called once per frame

	private void Awake()
	{
		line.useWorldSpace = true;
	}
	void Update()
    {
        RaycastHit ray;
        int i = 1;
        List<Vector3> positions = new List<Vector3>()
        {
            transform.position
        };
        Vector3 currentPosition = transform.position;
        Vector3 direction = transform.TransformDirection(Vector3.forward);
		do
        {
            Physics.Raycast(currentPosition + direction * 0.01f, direction, out ray, 500f);
            Vector3 finalPoint;
            if (ray.collider)
            {
                finalPoint = ray.point;
                if (ray.collider.CompareTag("Water Bottle"))
				{
                    refractLight.gameObject.SetActive(true);
                    refractLight.transform.position = finalPoint;
                    refractLight.transform.rotation = Quaternion.LookRotation(direction);
				}
                else
                {
                    refractLight.gameObject.SetActive(false);
                }
            }
            else
            {
				refractLight.gameObject.SetActive(false);
				finalPoint = direction * 500f;
			}
            LightReceptacle receptacle;
			if (ray.collider && ray.collider.TryGetComponent(out receptacle))
            {
                receptacle.Activate();
            }
			positions.Add(finalPoint);
			direction = Vector3.Reflect(direction, ray.normal);
            currentPosition = finalPoint;
			i++;
        } while (i <= depthLimit && ray.collider && (ray.collider.CompareTag("Mirror")));
        line.positionCount = positions.Count;
        line.SetPositions(positions.ToArray());
        pointLight.position = positions[positions.Count - 1] + direction.normalized * 0.1f;
	}
}

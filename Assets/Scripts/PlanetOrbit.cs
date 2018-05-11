using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetOrbit : MonoBehaviour {

    public Transform orbitingObject;
    public Ellipse orbitPath;

    public GameObject orbitCenter;


    [Range(0f, 1f)]
    public float orbitProgress = 0f;
    public float orbitPeriod = 3f;
    public bool orbitActive = true;

    // Use this for initialization
    void Start () {
        if(orbitingObject == null)
        {
            orbitActive = false;
            return;
        }

        setOrbitingObjectPosition();
        StartCoroutine(AnimateOrbit());
    
		
	}

    void setOrbitingObjectPosition()
    {
        float centerX = orbitCenter.transform.position.x;
        float centerY = orbitCenter.transform.position.z;


        Vector2 orbitPos = orbitPath.Evaluate(orbitProgress);
        orbitingObject.localPosition = new Vector3(centerX + orbitPos.x, orbitCenter.transform.position.y, centerY + orbitPos.y);
    }

    IEnumerator AnimateOrbit()
    {
        if (orbitPeriod < 0.1f)
            orbitPeriod = 0.1f;

        float orbitSpeed = 1f / orbitPeriod;

        while(orbitActive)
        {
            orbitProgress += Time.deltaTime * orbitSpeed;
            orbitProgress %= 1f;
            setOrbitingObjectPosition();
            yield return null;
        }
    }
	
}

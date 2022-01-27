using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class Orbiting : MonoBehaviour
{
    public Transform targetSP; //target star or planet to orbit

    public int pathResolution = 32;
    public float radius = 10;

    private LineRenderer path;

    [Range(0, 3)]
    public float speed = 1;
    
    public float gameTimeS;

    // Start is called before the first frame update
    void Start()
    {
        path = GetComponent<LineRenderer>();
        UpdateOrbitPath();
    }

    // Update is called once per frame
    void Update()
    {
        gameTimeS = Time.time;

        float x = radius * Mathf.Cos(speed * gameTimeS);
        float z = radius * Mathf.Sin(speed * gameTimeS);

        transform.position = new Vector3(x, 0, z) + targetSP.position;

        if (targetSP.hasChanged) UpdateOrbitPath();
    }

    void UpdateOrbitPath()
    {
        float pathMath = (2 * Mathf.PI / pathResolution);

        Vector3[] pts = new Vector3[pathResolution];

        for (int i = 0; i < pts.Length; i++)
        {
            float x = radius * Mathf.Cos(i * pathMath);
            float z = radius * Mathf.Sin(i * pathMath);

            pts[i] = new Vector3(x, 0, z) + targetSP.position;
        }

        path.positionCount = pathResolution;
        path.SetPositions(pts);

    }
}

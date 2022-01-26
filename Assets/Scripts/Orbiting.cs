using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbiting : MonoBehaviour
{

    public Transform targetSP; //target star or planet to orbit

    public float radius = 10;

    [Range(0, 3)]
    public float speed = 1;

    public float gameTimeS;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        gameTimeS = 0;

        float x = radius * Mathf.Cos(speed * gameTimeS);
        float z = radius * Mathf.Sin(speed * gameTimeS);

        transform.position = new Vector3(x, 0, z) + targetSP.position;
    }
}

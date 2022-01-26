using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPM : MonoBehaviour
{
    [Range(0, 5)]
    public float speedR;

    public float gameTimeR;

    private Vector3 startingTilt;
    public Vector3 rotationVec;


    // Start is called before the first frame update
    void Start()
    {
        transform.rotation *= Quaternion.Euler(rotationVec);
    }

    // Update is called once per frame
    void Update()
    {
        gameTimeR = Time.time;
        rotationVec = new Vector3((speedR), Random.Range(5, 15), 0);

        transform.rotation *= Quaternion.Euler(rotationVec);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationPM : MonoBehaviour
{
    [Range(0, 5)]
    public float speedR;

    public float gameTimeR;
    private float startingTilt;

    public Vector3 rotationVec;

    // Start is called before the first frame update
    void Start()
    {
        startingTilt = Random.Range(5, 15);
        transform.rotation *= Quaternion.Euler(rotationVec);
    }

    // Update is called once per frame
    void Update()
    {
        gameTimeR = Time.time;
        rotationVec = new Vector3((speedR), startingTilt, 0);

        transform.rotation *= Quaternion.Euler(rotationVec);
    }
}

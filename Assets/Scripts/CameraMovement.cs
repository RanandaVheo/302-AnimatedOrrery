using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float perc1Sec = 0.015f;

    public static int targetP;

    public float cameraAngle = 51.114f;

    // Start is called before the first frame update
    void Start()
    {
        targetP = 0; // 0 = default, 1 = 1. etc...
    }

    void Update()
    {
        cMovement(targetP);
    }

    // Update is called once per frame
    void cMovement(int targetPoint)
    {

        if (targetPoint == 0)
        {
            Transform cameraTarget = GameObject.Find("CameraPoint - 0").transform;

            Vector3 pos = AnimMath.Lerp(transform.position, cameraTarget.position, perc1Sec, false);
            Quaternion rot = cameraTarget.rotation;

            transform.position = pos;
            transform.rotation = rot;
        }
        else
        {

            Transform cameraTarget = GameObject.Find("CameraPoint - " + targetPoint).transform;
            Transform cameraRotTarget = GameObject.Find("Sun").transform;

            //Debug.Log(GameObject.Find("Camera Point - " + targetPoint).transform.position.z);

            GameObject.Find("CameraPoint - " + targetPoint).GetComponent<PointOrbiting>().enabled = false;
            GameObject.Find("Planet " + targetPoint).GetComponent<Orbiting>().enabled = false;

            // set this object's position to the lerp result
            Vector3 pos = AnimMath.Lerp(transform.position, cameraTarget.position, perc1Sec, false);
            Quaternion rot = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(cameraRotTarget.position - transform.position), perc1Sec);

            Debug.Log(rot.x);
            float ang = AnimMath.Map(cameraAngle, 0, 360, 0, 1);
            Debug.Log(ang);

            transform.position = pos;
            transform.rotation = rot;
        }
    }
}

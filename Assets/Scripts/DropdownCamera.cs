using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropdownCamera : MonoBehaviour
{
    // my dropdown box is a tmp one, so this is that variable type
    public TMPro.TMP_Dropdown myDrop;

    // used to know when the player chooses a view setting on the dropdown box
    public static int index;
    public static int prevIndex;

    void Start()
    {

    }

    void Update()
    {
        // sets the index variable to the selected drop box's index variable
        index = myDrop.value;

        //Debug.Log(index + " " + prevIndex);

        if(prevIndex != index)
        {
            CameraMovement.targetP = index;

            //Debug.Log(index);

            if (prevIndex != 0)
            {
                GameObject.Find("CameraPoint - " + prevIndex).GetComponent<PointOrbiting>().enabled = true;
                GameObject.Find("Planet " + prevIndex).GetComponent<Orbiting>().enabled = true;
            }

            prevIndex = index;
        }

        prevIndex = index;
    }

}
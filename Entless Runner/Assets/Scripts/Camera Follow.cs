using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    Vector3 distance;
    public float followSpped;
    [SerializeField]
    [Range(0, 1f)] float lerpTime;
    [SerializeField] Color[] myColors;
    int colorIndex=0;
    float change = 0;
    int len;

    void Start()
    {
        distance = target.position - transform.position;
        len = myColors.Length;

    }

    // Update is called once per frame
    void Update()
    {
        if (target.position.y >= 0)
        {
            Follow();
        }
        Camera.main.backgroundColor = Color.Lerp(Camera.main.backgroundColor, myColors[colorIndex], lerpTime*Time.deltaTime);

        change=Mathf.Lerp(change,1,lerpTime*Time.deltaTime);
        if (change > 0.9f)
        {
            change = 0;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }
       
    }
    void Follow()
    {
        Vector3 currentPose=transform.position;
        Vector3 targetpose = target.position - distance;
        transform.position=Vector3.Lerp(currentPose, targetpose, followSpped*Time.deltaTime);
    }
}

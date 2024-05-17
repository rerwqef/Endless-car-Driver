using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatFormSpawner : MonoBehaviour
{
    public GameObject platFormPrefab;
    public Transform lastPlatForm;
    public bool stop;
    Vector3 lastPos;
    Vector3 newPose;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = lastPlatForm.position;
        StartCoroutine(SpawnPlatForms());
        
    }

 

    void GenatePos()
    {
        newPose = lastPos;
        int rand = Random.Range(0, 2);
        if (rand > 0)
        {
            newPose.x += 2f;
        }
        else
        {
            newPose.z += 2f;
        }
   
      
    } 
    IEnumerator SpawnPlatForms()
    {
        while (!stop)
        {
           GenatePos();
            Instantiate(platFormPrefab,newPose,Quaternion.identity);
            lastPos = newPose;
            yield return new WaitForSeconds(0.2f);
        }
    }
}

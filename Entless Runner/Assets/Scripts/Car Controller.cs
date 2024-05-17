using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public float moveSpeed;
    bool  faceLeft=false, firstTab;
    // Start is called before the first frame update
  

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.isGameStarted)
        {
            Move();
            CheckInput();
        }
        if (transform.position.y < -2)
        {
            GameManager.Instance.GameOver();
        }
    }
    void Move()
    {
        transform.position += transform.forward * moveSpeed * Time.deltaTime;
    }
    void CheckInput()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0)) 
        {
            ChangeDirection();
        
        
        }
    }
    void ChangeDirection()
    {
        if (faceLeft)
        {
            faceLeft=false;
            transform.rotation=Quaternion.Euler(0,90,0);
        }
        else
        {
            faceLeft = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
}

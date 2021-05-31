using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
   
    public float speed = 5;
    public float movementX;
    // Update is called once per frame
    void Update()
    {
        movementX = transform.position.x+Input.GetAxis("Horizontal")*speed*Time.deltaTime;

        transform.position = new Vector2(movementX,transform.position.y);
    }
}

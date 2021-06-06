using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
   
    public float speed = 5;
    public float movementX;
    public float playerInput;

    public int playMode = 0;

    float top,bot,left,right;
    void Start()
    {
        Vector3 thing = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height,0));
        top = thing.y;
        right = thing.x;
        thing = Camera.main.ScreenToWorldPoint(new Vector3(0, 0,0));
        bot = thing.y;
        left = thing.x;
    }

    // Update is called once per frame
    void Update()
    {
        if(playMode == 0)
        {
            PlayerControll();
        }else if(playMode == 1){
            AIControll();
        }

        if(transform.position.x > right){transform.position = new Vector2( right, transform.position.y);}
        if(transform.position.x < left){transform.position = new Vector2( left, transform.position.y);}
    }
    void PlayerControll()
    {
        playerInput = Input.GetAxis("Horizontal");
        movementX = transform.position.x+playerInput*speed*Time.deltaTime;

        transform.position = new Vector2(movementX,transform.position.y);
    }
    void AIControll()
    {
        movementX = transform.position.x+(NeralNetManager.outputs[0]*2-1)*speed*Time.deltaTime;

        transform.position = new Vector2(movementX,transform.position.y);
    }
}

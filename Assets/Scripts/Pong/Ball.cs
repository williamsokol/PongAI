using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float vx =1  ,vy =1;
    float top,bot,left,right;
    
    // Start is called before the first frame update
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
        transform.position = new Vector2(transform.position.x+vx*Time.deltaTime,transform.position.y+vy*Time.deltaTime);
        if(transform.position.x+vx*Time.deltaTime > right || transform.position.x+vx*Time.deltaTime < left)
        {
            vx = -vx;
        }
        if(transform.position.y+vy*Time.deltaTime > top )
        {
            vy = -vy; 
        }
        if( transform.position.y+vy*Time.deltaTime < bot)
        {
            print("you lose");
            vy = -vy; 
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
//        print("hit");
        Paddle paddle = other.gameObject.GetComponent<Paddle>();
        if(paddle != null)
        {

            vx = vx/2+(paddle.playerInput/2);
            //vy = -(vy/2 + paddle.movementX/2);  
        }
        
        vy = -vy;  
    }
}

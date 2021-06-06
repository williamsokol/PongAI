using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debug : MonoBehaviour
{
    public JsonManager jsonManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TrainData thing = jsonManager.CollectData();
        thing.RotateData();
        transform.position = new Vector2(thing.inputs[1],thing.inputs[2]);
    }
}

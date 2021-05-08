using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    public float speed;
    public float size;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        iTween.RotateTo(gameObject, iTween.Hash("x", size, "speed", speed, "easeType", iTween.EaseType.easeInOutSine, "looptype", iTween.LoopType.pingPong));
    }
}

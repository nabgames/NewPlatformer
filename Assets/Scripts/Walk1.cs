using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk1 : MonoBehaviour {

    public PlayerScript bScript;
   public GameObject bGameObject;

    // Use this for initialization
    void Start () {
       
        bScript = bGameObject.GetComponent<PlayerScript>();
        
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (bScript.walk > 5)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 0f, 310f);
        }
    }
}

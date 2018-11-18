using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk2 : MonoBehaviour {

    public PlayerScript cScript;
   public GameObject cGameObject;

    // Use this for initialization
    void Start () {
       
        cScript = cGameObject.GetComponent<PlayerScript>();
        
    }

    // Update is called once per frame
    void FixedUpdate () {
        if (cScript.walk > 5)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 310f);
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
        }
    }
}

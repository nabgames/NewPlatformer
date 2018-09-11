using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

    public GameObject player;
    public PlayerScript aScript;

	// Use this for initialization
	void Start () {
        aScript = player.GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = new Vector3(aScript.playerHealth, 1f, 1f);
	}
}

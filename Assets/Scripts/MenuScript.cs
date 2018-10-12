using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScript : MonoBehaviour {

    public int select;
    public int specific;
    public int rangeMin = 1;
    public int rangeMax = 5;
    public string level;

	// Use this for initialization
	void Start () {
        select = 1;
	}
	
	// Update is called once per frame
	void Update () {
        if(Input.GetKeyDown(KeyCode.S)){
            select++;
        }
        if(Input.GetKeyDown(KeyCode.W)){
            select--;
        }
        if (select==specific){
            GetComponent<TextMesh>().color = new Color(1.0f, 0.0f, 0.2f);
        }
        else{
            GetComponent<TextMesh>().color = new Color(1.0f, 1.0f, 1.0f);
        }
        if (select<rangeMin){
            select = rangeMax; 
        }
        if (select > rangeMax)
        {
            select = rangeMin;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            print(specific);
            UnityEngine.SceneManagement.SceneManager.LoadScene(level);
        }
        }
	}


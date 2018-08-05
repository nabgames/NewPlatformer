using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Don't use this script!!!! (But please keep it for now)
public class EnemyRadiusScript : MonoBehaviour {

    public GameObject Enemy;
    public EnemyScript enemyScript;

    // Use this for initialization
    [ExecuteInEditMode]
    void Start () {
        enemyScript = Enemy.GetComponent<EnemyScript>();
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = new Vector3(enemyScript.startX, enemyScript.startY, 0.0f);
        transform.localScale = new Vector3(enemyScript.xMax - enemyScript.xMin, enemyScript.yMax - enemyScript.yMin, 0.0f);
	}
}

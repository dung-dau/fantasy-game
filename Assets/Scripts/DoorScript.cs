using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour {

	[SerializeField] Transform posToGo;

	bool playerDetected; 
	GameObject playerGO;
	public GameObject cameraGO;
    // Start is called before the first frame update
    void Start() {
    	playerDetected = false;
    }

    // Update is called once per frame
    void Update() {
    	if(playerDetected) {
    		Debug.Log("Update");
    		playerGO.transform.position = posToGo.position;
    		if(Input.GetKey(KeyCode.LeftArrow)) {
    			playerGO.transform.position -= new Vector3(2,0,0);
    			cameraGO.transform.position -= new Vector3(50,0,0);
    		} else if(Input.GetKey(KeyCode.RightArrow)) {
    			playerGO.transform.position += new Vector3(2,0,0);
    			cameraGO.transform.position += new Vector3(50,0,0);
    		}
    		playerDetected = false;
    	}
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
    	Debug.Log("OnTriggerEnter2D");
    	if(collision.CompareTag("Player")) {
    		playerDetected = true;
    		playerGO = collision.gameObject;
    	}
    }

    private void OnTriggerExit2D(Collider2D collision) {
    	Debug.Log("OnTriggerExit2D");
    	if(collision.CompareTag("Player")) {
    		playerDetected = false;
    	}
    }
}

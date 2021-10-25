using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour {

	[SerializeField] private GameObject projectilePrefab;
	[SerializeField] private float speed = 5.0f;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
    	if(Input.GetKeyDown(KeyCode.C)) {
    		Instantiate(projectilePrefab,transform.position,Quaternion.identity);
    	}

    	if(Input.GetKeyDown(KeyCode.LeftArrow)) {
    		transform.Rotate(Vector3.forward * speed * Time.deltaTime);
    	}

    	if(Input.GetKeyDown(KeyCode.RightArrow)) {
    		transform.Rotate(-Vector3.forward * speed * Time.deltaTime);
    	}
        
    }
}

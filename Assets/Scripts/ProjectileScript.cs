using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour {

	public float projectileSpeed;
	private Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start() {
    	rigidbody = GetComponent<Rigidbody2D>();
    	rigidbody.velocity = transform.right * projectileSpeed;
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
    	if(collision.tag == "Enemy") {
    		Destroy(collision.gameObject);
    		Destroy(gameObject);
    	}
    }
}

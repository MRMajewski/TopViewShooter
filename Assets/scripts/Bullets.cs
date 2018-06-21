using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Activator))]

public class Bullets : MonoBehaviour {


    public int Amount = 10;
	// Use this for initialization
	void Start () {
       GetComponent<Activator>(). OnActivated += () =>
        {
            FindObjectOfType<PlayerShooting>().
            CollectBullets(Amount);
            Destroy(gameObject);

        };
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

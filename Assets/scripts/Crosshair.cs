using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crosshair : MonoBehaviour {

    UnityEngine.Camera Camera;


	// Use this for initialization
	void Start ()
    {
        Camera = FindObjectOfType<UnityEngine.Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        var mousePosition = Input.mousePosition; // pobieramy pozycje kursora
        var worldPosition = Camera.ScreenToWorldPoint(mousePosition); //konwersja z pozycji z przestrzenie ekranowej na przestrzeń świata 3D
        transform.position = (Vector2)worldPosition;
        //konwersja na wektor 2 ustaliła nam  position Z na 0 


    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GUI : MonoBehaviour {

    [SerializeField]
    Text BulletCounter;

    [SerializeField]
    Text HealthCounter;

    // Use this for initialization
    void Awake () { //funckja Awake wywołuje się przed Start

        FindObjectOfType<Player>().GetComponent<Entity>().
            OnHealthChanged += health => //subskrybcja zdarzenia (?)
        {
            HealthCounter.text = health.ToString();

        };


        FindObjectOfType<PlayerShooting>().OnBulletsChanged += bullets => //subskrybcja zdarzenia (?)
        {
            BulletCounter.text = bullets.ToString();

        };
	}
	

}

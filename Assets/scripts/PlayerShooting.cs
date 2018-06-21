using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour {

    [SerializeField]
    GameObject BulletPrefab;

    [SerializeField]
    float BulletSpeed = 5f;

    [SerializeField]
    Vector2 ShootPoint;

    // public float ShootPeriod = 0.5f;
    // float LastShootTime = 0;

    private int bullets = 5;

    public int Bullets //właściwość , ilość pocisków może modyfikować tylko gracz, a odczytywać tę wartośc może każy

    {
        get
        {
            return bullets;
        }

        private set
        {
            bullets = value;
            if (OnBulletsChanged != null) // jeśli zdarzenie jest subskrybowane to wywołujemy je
                OnBulletsChanged.Invoke(bullets);
                ;
        }
    }

    public event Action<int> OnBulletsChanged; //zdarzenie

    // Use this for initialization
    void Start () {
        Bullets = 5;
	}
	
	// Update is called once per frame
	void Update () {


        // if (Time.timeSinceLevelLoad - LastShootTime < ShootPeriod) return;
        //porównujemy czas od włączenia gry minus czas ostatniego strzału do Cooldownu działa
        //  LastShootTime = Time.timeSinceLevelLoad;

       

        if (Input.GetMouseButtonDown(0))
            ShootBullet();
    }

    void ShootBullet()
    {
        if (Bullets == 0) return;

        Bullets--;
       
        var bullet = Instantiate(BulletPrefab); // tworzenie pocisku
        bullet.transform.position = transform.position + transform.rotation*(Vector3)ShootPoint; //w miejscu gdzie znajduje się obiekt gracza
        bullet.transform.rotation = transform.rotation; // obrócony o taki kąt jak gracz






        var bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = transform.right * BulletSpeed;


    }

    public void CollectBullets ( int amount)
    {

        Bullets += amount;
    }
	
}

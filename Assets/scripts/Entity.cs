using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour {

    [SerializeField]
    float InitialHealth = 3f;

    private float health;
    public float Health
    {
        get
        {
            return health;
        }

        set
        {
            health = value;

      

           
            if (OnHealthChanged != null)
                OnHealthChanged.Invoke(health);

            if (health <= 0)
            {
                if (OnKilled != null)
                    OnKilled.Invoke();
                Destroy(gameObject);
            }

        }
    }

    public event Action<float> OnHealthChanged;
    public event Action OnKilled;


    // Use this for initialization
    void Start () {
        Health = InitialHealth;
	}
	

}

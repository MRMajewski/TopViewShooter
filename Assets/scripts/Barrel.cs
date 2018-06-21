using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[RequireComponent(typeof(Entity))]
public class Barrel : MonoBehaviour
{
    [SerializeField]
    float ExplosionRadius = 4f;

    [SerializeField]
    float ExplosionDamage = 15f;



    // Use this for initialization
    void Start ()
    {
        GetComponent<Entity>().OnKilled += () => Explode();

		
	}
	
	void Explode ()
    {
        EntityDoDamage();
        Destroy(gameObject);
	}

    void EntityDoDamage()
    {
        Physics2D.OverlapCircleAll(transform.position, ExplosionRadius)
            .Select(obj => obj.GetComponent<Entity>())
            .Where(obj => obj != null)
            .Where(obj => obj.transform.name != transform.name)
            .ToList()
            .ForEach(obj => obj.Health -= ExplosionDamage);


            //zwraca obiekty znajdujące się wewnątrz koła
            //wyciągamy z nich obiekty typu Entity
            //tylko te które posiadają entity stąd warunek !=null
            //warunek aby nie zadawać obrażeń samemu obiektowi co zadaje obrażenia
            //konwertujemy do listy
            //dla każdego z tych obiektów odejmujemy żyćko o wartość obrażeń
    }
}

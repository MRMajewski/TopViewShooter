using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]

public class Zombie : MonoBehaviour {

    Rigidbody2D Rigidbody;
    Vector2 TargetPosition;
    Player TargetPlayer;

    [SerializeField]
    float Speed = 1f;

    void Start () {

        Rigidbody = GetComponent<Rigidbody2D>();
        StartCoroutine(ChangeTargetPositionCoroutine());
	}

    IEnumerator ChangeTargetPositionCoroutine() //zomie będzie zmieniać kierunek co jakiś czas
    {
        while(true)
        {
            TargetPosition = (Vector2)transform.position + Random.insideUnitCircle *10f;//mnożymy żeby zombie szedł na dalszą odległość
            yield return new WaitForSeconds(Random.Range(5, 10));
        }

    }
	

	void Update () {
        var targetSpeed = Speed;

        if (TargetPlayer != null)
        {
            TargetPosition = TargetPlayer.transform.position;
            targetSpeed *= 4f;

        }


        //kierunek zombi to różnica między obecnym położeniem, a docelowym kierunkiem
        var direction = (Vector3)TargetPosition - transform.position;       
        var targetVelocity = direction.normalized * targetSpeed; //otrzymujemy wektor jednostkowy znormalizowany

        Rigidbody.velocity = Vector3.Lerp(Rigidbody.velocity, targetVelocity, Time.deltaTime / 2f);

        transform.right = direction;//zombie będzie zwrócony w kierunku którym idzie
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if (player != null) 
        TargetPlayer = player;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        var player = collision.gameObject.GetComponent<Player>();

        if (player != null)
        TargetPlayer = null;
    }
}




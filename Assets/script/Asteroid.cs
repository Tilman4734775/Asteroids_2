using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour

{public int size = 3;

public GameManager gamemanager;
    // Start is called before the first frame update
    void Start() {
        transform.localScale = 0.5f * size * Vector3.one;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.value, Random.value).normalized;
        float spawnspeed = Random.Range(4f - size, 5f - size);
        rb.AddForce(direction * spawnspeed, ForceMode2D.Impulse);

        gamemanager.asteroidCount++;
         

    }


}
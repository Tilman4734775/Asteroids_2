using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour

{public int size = 3;
[SerializeField] private ParticleSystem destroyedParticles;
public GameManager gameManager;

audiomanager audioManager;

private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<audiomanager>();
    }

    // Start is called before the first frame update
    void Start() {
        transform.localScale = 0.5f * size * Vector3.one;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direction = new Vector2(Random.value, Random.value).normalized;
        float spawnspeed = Random.Range(4f - size, 5f - size);
        rb.AddForce(direction * spawnspeed, ForceMode2D.Impulse);

        gameManager.asteroidCount++;
         

    }


    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.CompareTag("Bullet")) {

            gameManager.asteroidCount--;

            Destroy(collision.gameObject);

            if(size > 1) {
                for (int i = 0; i < 2; i++) {
                    Asteroid newAsteroid = Instantiate(this, transform.position, Quaternion.identity);
                    newAsteroid.size = size - 1;
                    newAsteroid.gameManager = gameManager;
                }
            }
            Instantiate(destroyedParticles, transform.position, Quaternion.identity);
            audioManager.PlaySound(audioManager.meteordestroy);
            gameManager.AddToScore();


            Destroy(gameObject);

        }
    }


}
 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{ 
    
[SerializeField] private Asteroid asteroidPrefab;
[SerializeField] private TMPro.TextMeshProUGUI scoreText;
[SerializeField] private TMPro.TextMeshProUGUI gameOverScore;
[SerializeField] private Canvas gameOverCanvas;

public int asteroidCount = 0;
private int score = 0;
private int level = 0;

    // Update is called once per frame
    void Update() 
    {if (asteroidCount == 0) {

        level++;

        int numAsteroids = 2 + (2 * level);
        for(int i = 0; i < numAsteroids; i++) {
            spawnAsteroids();
        }
    }
        
    }
    private void spawnAsteroids() {

        float offset = Random.Range(0f, 1f);
        Vector2 viewportSpawnPosition = Vector2.zero;

        int edge = Random.Range(0, 4);
        if (edge == 0) {
            viewportSpawnPosition = new Vector2(offset, 0);
        } else if (edge == 1) {
          viewportSpawnPosition = new Vector2(offset, 1);  
        } else if (edge == 2) {
          viewportSpawnPosition = new Vector2(0, offset);  
        } else if (edge == 3) {
          viewportSpawnPosition = new Vector2(1, offset);  
        }

        Vector2 worldSpawnPosition = Camera.main.ViewportToWorldPoint(viewportSpawnPosition);
        Asteroid asteroid = Instantiate(asteroidPrefab, worldSpawnPosition, Quaternion.identity);
        asteroid.gameManager = this;
    }

    public void AddToScore() {
      score += 10;
      scoreText.text = score.ToString();
    }




    public void GameOver() {
      StartCoroutine(Restart());
    }

    private IEnumerator Restart() {
      Debug.Log("Game Over");

      yield return new WaitForSeconds(1f);
      Time.timeScale = 0f;
      scoreText.enabled = false;
      gameOverScore.text = "you scored " +score.ToString();
      gameOverCanvas.gameObject.SetActive(true);

      yield return null;
    }

    public void Retry() {
      Time.timeScale = 1f;
      SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Quit() {
      Time.timeScale = 1f;
      SceneManager.LoadScene(1);
    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Sprite[] enemySprites;
   	public float startWait = 1.0f;
	public float spawnInterval = 2.0f;
    private Vector2 screenBounds;

    // Use this for initialization
    void Start () 
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(EnemyWave());
    }

    private void SpawnEnemy()
    {
        int arrayIndex = Random.Range(0, enemySprites.Length);
        Sprite enemySprite = enemySprites[arrayIndex];
        string enemyName = enemySprite.name;
        GameObject enemy = ObjectPooler.SharedInstance.GetPooledObject("enemy"); 
        if(enemy!=null)
        {
            enemy.name = enemyName;
            enemy.GetComponent<Enemy>().enemyName = enemyName;
            enemy.GetComponent<SpriteRenderer>().sprite = enemySprite;
            enemy.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x),screenBounds.y );
            enemy.SetActive(true);
        }
    }

    IEnumerator EnemyWave()
    {
        yield return new WaitForSeconds (startWait);
		while (true) 
        {
            SpawnEnemy();
            yield return new WaitForSeconds (spawnInterval);
		} 
	}
}

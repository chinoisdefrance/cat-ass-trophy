using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public Transform enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountDownText;

    private int waveIndex = 0;

    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(spawnWave());
            //spawnWave();
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        waveCountDownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator spawnWave ()
    {
      //  Debug.Log("CAT ASTROPHE !!!");

        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            spawnEnnemy();
            yield return new WaitForSeconds(0.5f);
        }

       
    }

    void spawnEnnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}

using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

public class WaveSpawner : MonoBehaviour
{
    public Transform[] enemyPrefab;

    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;

    public Text waveCountDownText;

    [SerializeField] private int waveIndex = 0;
    public int waveMax = 5;
    public UnityEvent waveEnd;

    //show time counter 
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountDownText.text = string.Format("{0:00.00}", countdown);
    }

    //seconds during each ennemies spawning and numbers of waves
    IEnumerator SpawnWave()
    {
        if (waveIndex > waveMax)
        {
            waveEnd.Invoke();
            enabled = false;
        }
        else
        {

            waveIndex++;

            for (int i = 0; i < waveIndex; i++)
            {
                SpawnEnnemy();
                yield return new WaitForSeconds(0.5f);
            }
        }

    }

    //instantiate random ennemies at each wave
    void SpawnEnnemy()
    {
        Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnPoint.position, spawnPoint.rotation);
    }
}

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
    void Update()
    {
        if (countdown <= 0f)
        {
            StartCoroutine(spawnWave());
            //spawnWave();
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountDownText.text = string.Format("{0:00.00}", countdown);
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

       if(waveIndex == waveMax)
        {
            waveEnd.Invoke();
        }
    }

    void spawnEnnemy()
    {
        Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnPoint.position, spawnPoint.rotation);
    }
}

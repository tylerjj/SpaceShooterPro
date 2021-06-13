using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager_Section07 : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private float _spawnTimer;
    [SerializeField]
    private GameObject _enemyContainer;
    private bool _stopSpawning = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("SpawnRoutine");
    }


    IEnumerator SpawnRoutine()
    {

        while (!_stopSpawning)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
            newEnemy.transform.parent = _enemyContainer.transform;
            yield return new WaitForSeconds(_spawnTimer);
        }
    }

    public void OnPlayerDeath()
    {
        _stopSpawning = true;
    }
}

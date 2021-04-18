using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyCar;

    [SerializeField]
    private Transform enemiesParent;

    [SerializeField]
    private float spawnDistance = 50f;

    [SerializeField]
    private float spawnTimeMin = 0.5f;

    [SerializeField]
    private float spawnTimeMax = 2f;

    private Transform _convoy;
    private Transform _road;
    private float nextSpawnTime = 3f;

    private void Start()
    {
        _convoy = GameObject.FindGameObjectWithTag("Convoy").transform;
        if (_convoy == null)
            Debug.LogError("'Convoy' has not found");

        _road = GameObject.FindGameObjectWithTag("Road").transform;
        if (_road == null)
            Debug.LogError("'Road' has not found");
    }

    public void Spawn()
    {
        var rndX = Random.Range(-_road.localScale.x / 2 + 0.5f, _road.localScale.x / 2 - 0.5f);
        var spawnPosition = new Vector3(rndX, enemyCar.transform.position.y, Mathf.Min(_convoy.position.z + spawnDistance, _road.localScale.z));

        Instantiate(enemyCar, spawnPosition, new Quaternion(_convoy.rotation.x, _convoy.rotation.y + 180f, _convoy.rotation.z, _convoy.rotation.w), enemiesParent);
    }

    private void Update()
    {
        Debug.Log(nextSpawnTime);
        if (GameManager.Instance.HasGameStart)
        {
            if (Time.timeSinceLevelLoad > nextSpawnTime)
            {
                nextSpawnTime += Random.Range(spawnTimeMin, spawnTimeMax);
                Spawn();
            }
        }
    }
}

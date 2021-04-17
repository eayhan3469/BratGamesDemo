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

    private Transform _convoy;
    private Transform _road;
    private float nextSpawnTime = 0f;
    private float spawnTimeMin = 0.5f;
    private float spawnTimeMax = 4f;

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
        var spawnPosition = new Vector3(rndX, enemyCar.transform.position.y, _convoy.position.z + spawnDistance);

        Instantiate(enemyCar, spawnPosition, new Quaternion(_convoy.rotation.x, _convoy.rotation.y + 180f, _convoy.rotation.z, _convoy.rotation.w), enemiesParent);
    }

    private void Update()
    {
        if (GameManager.Instance.HasGameStart)
        {
            if (Time.time > nextSpawnTime)
            {
                nextSpawnTime += Random.Range(spawnTimeMin, spawnTimeMax);
                Spawn();
            }
        }
    }
}

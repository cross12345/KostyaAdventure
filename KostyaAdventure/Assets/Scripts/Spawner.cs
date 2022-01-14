using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] List<GameObject> SpawnObjects = new List<GameObject>();
    [SerializeField] float cooldown;
    private float nextAttack;

    private void Update()
    {
        if (Time.time > nextAttack)
        {
            SpawnObject();
            nextAttack = Time.time + 1f / cooldown;
        }
    }
    public void SpawnObject()
    {
        GetComponent<Animator>().Play("SpawnerOpen");
        Invoke("Spawn", 0.5f);
    }
    private void Spawn()
    {
        Instantiate(SpawnObjects[Random.Range(0, SpawnObjects.Count)], transform.position, transform.rotation);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    private GameObject tilePrefab;

    private List<GameObject> activeTiles;

    private Transform playerTransform;
    private float offset = 14.0f;
    private float tileSpawn = 0.0f;
    private float TilesOnScreen = 7;
    private bool firstTile = false;

    // Start is called before the first frame update
    void Start()
    {
        tilePrefab = GameObject.FindWithTag("tile-original");
        playerTransform = GameObject.FindWithTag("Player").transform;
        // activeTiles = new List<GameObject>();
        //for(int i = 0; TilesOnScreen > i; i++) {
            spawnTile();
        //}
    }

    private void spawnTile() {
        tileSpawn += offset;
        GameObject go;
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + offset);
        go = Instantiate(tilePrefab, newPos, transform.rotation);
        // activeTiles.Add(go);
    }

    // void OnTriggerEnter(Collider other) {
    //     Collider[] colliders = GetComponents<Collider>();
    //     foreach(Collider collider in colliders) {
    //         if (collider.name == "tileSpawner") {
    //             Debug.Log("Found Collider 1");
    //             Vector3 newPos = new Vector3(transform.position.x, transform.position.y, transform.position.z + offset);
    //             GameObject newTile = Instantiate(tilePrefab, newPos, Quaternion.identity);
    //             activeTiles.Add(newTile);
    //         } else if (collider.name == "tileDelete") {
    //             Destroy(activeTiles[0]);
    //             activeTiles.RemoveAt(0);
    //             Debug.Log("Found Collider 2");
    //         }
    //     }
    // }

    // Update is called once per frame
    void Update()
    {

    }
}
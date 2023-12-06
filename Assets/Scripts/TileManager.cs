using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    //List of tile objects
    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 20.0f;
    private int tilesOnScreen = 7;
    private float safeZone = 40.0f;

    //List to store tiles which will be deleted later.
    private List<GameObject> activeTiles;

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindWithTag("Player").transform;
        for(int i = 0; tilesOnScreen > i; i++)
            spawnTile();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - safeZone > (spawnZ - tilesOnScreen * tileLength)) {
            spawnTile();
            deleteTile();
        }
    }

    private void spawnTile(int prefabIndex = -1) {
        spawnZ += tileLength;
        GameObject go;
        go = Instantiate(tilePrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        activeTiles.Add(go);
    }

    private void deleteTile() {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }
}

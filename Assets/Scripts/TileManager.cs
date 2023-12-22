using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    //List of tile objects
    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float spawnZ = 0.0f;
    private float tileLength = 60.0f;
    private int tilesOnScreen = 3;
    private float safeZone = 120.0f;
    private int lastPrefabIndex = 0;

    //List to store tiles which will be deleted later.
    private List<GameObject> activeTiles;

    // Start is called before the first frame update
    void Start()
    {
        activeTiles = new List<GameObject>();
        // playerTransform = GameObject.FindWithTag("Player").transform;
        playerTransform = GameObject.FindGameObjectWithTag("characterSelect").GetComponent<CharacterSelect>().getTransform();
        Debug.Log(playerTransform);
        for(int i = 0; tilesOnScreen > i; i++)
            spawnTile();
    }

    // Update is called once per frame
    public void Update()
    {
        if(playerTransform.position.z - safeZone > (spawnZ - tilesOnScreen * tileLength)) {
            spawnTile();
            deleteTile();
        }
    }

    private void spawnTile(int prefabIndex = -1) {
        spawnZ += tileLength;
        GameObject go;
        go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * spawnZ;
        activeTiles.Add(go);
    }

    private void deleteTile() {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    private int RandomPrefabIndex() {
        if(tilePrefabs.Length <= 1) return 0;
        int randomIndex = lastPrefabIndex;
        while(randomIndex == lastPrefabIndex) {
            randomIndex = Random.Range(0, tilePrefabs.Length);
        }
        lastPrefabIndex = randomIndex;
        return randomIndex;
    }
}
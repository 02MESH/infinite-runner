using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTile : MonoBehaviour
{
    private GameObject Tile;
    private float offset = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        Tile = GameObject.Find("Tile");
    }


    void OnTriggerEnter(Collider other)
    {
        //add a new block relative to the z position of the current block
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y, (float)(transform.position.z + offset));
        Instantiate(Tile, newPos, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
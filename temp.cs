public class SpawnTile : MonoBehaviour
{
    private GameObject tilePrefab;
    private GameObject previousTile;
    private GameObject currentTile;
    private List<GameObject> activeTiles;
    private float offset = 14.0f;
    private bool firstTile;


    // Start is called before the first frame update
    void Start()
    {
        firstTile = true;
        activeTiles = new List<GameObject>();
        tilePrefab = GameObject.FindWithTag("tile-original");
        spawnNewTile();
    }

    // Spawn a new tile
    void spawnNewTile()
    {
        Vector3 newPos;
        if (firstTile)
        {
            newPos = new Vector3(0.0f, 0.0f, 0.0f);
            currentTile = Instantiate(tilePrefab, newPos, transform.rotation);
            firstTile = false;
        }
        else
        {
            previousTile = currentTile;
            newPos = new Vector3(transform.position.x, transform.position.y, (float)(transform.position.z + offset));
            currentTile = Instantiate(tilePrefab, newPos, transform.rotation);
        }
        activeTiles.Add(currentTile);
    }

    //Destroys the current tile to prevent clutter
    void destroyPreviousTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }

    void OnTriggerEnter(Collider other)
    {
        //delete the previous block
        Collider[] colliders = GetComponents<Collider>();
        foreach (Collider collider in colliders)
        {
            if (collider.name == "tileSpawner")
            {
                //add a new block relative to the z position of the current block
                spawnNewTile();
                Debug.Log("Found Collider 1");
            }
            // else if (collider.name == "tileDelete")
            // {
            //     destroyPreviousTile();
            //     Debug.Log("Found Collider 2");
            // }
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
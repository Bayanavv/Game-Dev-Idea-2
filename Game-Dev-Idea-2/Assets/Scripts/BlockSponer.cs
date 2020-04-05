
using UnityEngine;

public class BlockSponer : MonoBehaviour
{
    /*transform is how we reference an object that we want to do some kind of position or 
     rotation chekes with*/
    public Transform[] spwnPoints;

    public GameObject blockPrefab;

    private float timeToSpawn = 2f;

    public float timeBetweenWaves = 1f;

   
    void Start()
    {
       
    }
    void Update()
    {
        if(Time.time >= timeToSpawn)
        {
            SpawnBlocks();
            timeToSpawn = Time.time + timeBetweenWaves;
        }
        
    }
    void SpawnBlocks()
    {   
        /*selecting a random spawn point
         */
        int randomIndex = Random.Range(0, spwnPoints.Length);

        for (int i = 0; i < spwnPoints.Length; i++)
        {
            if (randomIndex != i)
            {
                Instantiate(blockPrefab, spwnPoints[i].position, Quaternion.identity);
            }
        }
    }

} 

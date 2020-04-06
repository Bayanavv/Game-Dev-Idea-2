
using UnityEngine;

public class BlockSponer : MonoBehaviour
{
    /*transform is how we reference an object that we want to do some kind of position or 
     rotation chekes with*/
    public Transform[] spwnPoints;

    public GameObject blockPrefab;

    private float timeToSpawn = 2f; // after we start the game how long the first block will spawn

    public float timeBetweenWaves = 1f;

   
    void Start()
    {
       
    }
    void Update()
    {
        /*Time.time unity variable that basically it is just the amounth of seconds that has passed by since we started the game*/
        if(Time.time >= timeToSpawn) 
        {
            /*spawing a block wave*/
            SpawnBlocks();
            /*the time to spawn the new blockes*/
            timeToSpawn = Time.time + timeBetweenWaves;
        }
        
    }
    void SpawnBlocks()
    {   
        /*selecting a random spawn point
         this unity way of getting a random number betwen zero of the array to the array length# 
         */
        int randomIndex = Random.Range(0, spwnPoints.Length);

        /*looping threw all the spawn points*/
        for (int i = 0; i < spwnPoints.Length; i++)
        {
            /*do thonting X amount of times
             
             loop prooper
             
             so if this time that we are looping over this index that we reach this spawn point should be the one selected in randomIndex
             if its the one that we chose the random single one that we dont want to spawn a block if that the case well then we dont want to do anything*/
            if (randomIndex != i)
            {
                /*here its not equal to that then we want to spawn in a block*/
                Instantiate(blockPrefab, spwnPoints[i].position, Quaternion.identity);
            }
        }
    }

} 

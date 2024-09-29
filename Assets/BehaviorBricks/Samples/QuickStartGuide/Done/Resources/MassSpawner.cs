using UnityEngine;
using System.Collections.Generic;
using BBSamples.PQSG;
/// <summary>
/// Component that is responsible for spawning many GameObjects in a certain area. 
/// Each Gameobject instaciated will be assigned a behavior to move around the area randomly.
/// </summary>
public class MassSpawner : MonoBehaviour
{
    ///<value>The gameobject that will be respawned</value>
    public GameObject prefab;
    ///<value>Area where the Gameobjects will move</value>
    public GameObject wanderArea;

    ///<value>Maximum number of prefabs to keep active</value>
    public int maxPrefabs = 5;
    List<GameObject> entities;

    public GameObject Mainlight;
    DoneDayNightCycle dayNightCycleChecker;

    /// <summary>
    /// Initialize the entities to pass them to the behaviors
    /// </summary>
    void Start()
    {
        dayNightCycleChecker = Mainlight.GetComponent<DoneDayNightCycle>();
        entities = new List<GameObject>();
        while (entities.Count < maxPrefabs)
        {
            Spawn();
        }

        InvokeRepeating("CheckAndSpawn", 0f, 1.0f); // Check every second

    }

    /// <summary>
    /// Method that checks how many prefabs are active and spawns more if needed.
    /// </summary>
    void CheckAndSpawn()
    {
        if (!dayNightCycleChecker.isNight) return;

        // Remove null entries (destroyed prefabs)
        entities.RemoveAll(e => e == null);


        // If there are less than the required prefabs, spawn the missing ones
        while (entities.Count < maxPrefabs)
        {
            Spawn();
        }
    }

    /// <summary>
    /// Method that instantiates Gameobject, adds the behavior Executor component and sets the behavior parameters.
    /// </summary>
    void Spawn()
    {
        GameObject instance = Instantiate(prefab, GetRandomPosition(), Quaternion.identity) as GameObject;
        BehaviorExecutor component = instance.GetComponent<BehaviorExecutor>();
        component.SetBehaviorParam("wanderArea", wanderArea);
        component.SetBehaviorParam("player", GetRandomEntity());

        entities.Add(instance);
    }

    private GameObject GetRandomEntity()
    {
        if (entities.Count > 0)
        {
            return entities[Random.Range(0, entities.Count)];
        }
        return null;
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 randomPosition = Vector3.zero;
        BoxCollider boxCollider = wanderArea.GetComponent<BoxCollider>();
        if (boxCollider != null)
        {
            randomPosition = new Vector3(Random.Range(wanderArea.transform.position.x - wanderArea.transform.localScale.x * boxCollider.size.x * 0.5f,
                                                      wanderArea.transform.position.x + wanderArea.transform.localScale.x * boxCollider.size.x * 0.5f),
                                         wanderArea.transform.position.y,
                                         Random.Range(wanderArea.transform.position.z - wanderArea.transform.localScale.z * boxCollider.size.z * 0.5f,
                                                      wanderArea.transform.position.z + wanderArea.transform.localScale.z * boxCollider.size.z * 0.5f));
        }

        return randomPosition;
    }
}

using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

    public Transform point1;
    public Transform point2;
    public float spawnTime;
    public GameObject enemy;
    public WomenCounter womanCounter;

    Vector3 spawnLine;

    void Start ()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    void Spawn()
    {
        var p = Vector3.Lerp(point1.position, point2.position, Random.value);
        Instantiate(enemy, p, point1.rotation);
        womanCounter.AddWoman();
    }
}

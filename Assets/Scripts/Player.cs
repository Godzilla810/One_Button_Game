using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject bananaPrefab;
    public Transform spawnPoint;
    private Rigidbody RB;

    public float throwAngle = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ThrowWithForce(int count){
        var banana = Instantiate(bananaPrefab, spawnPoint.position, Quaternion.identity);
        RB = banana.GetComponent<Rigidbody>();
        //拋物線
        Quaternion rotation = Quaternion.Euler(0f, 0f, throwAngle);
        Vector3 forceDirection = rotation * transform.forward;
        Vector3 force = forceDirection * count;
        //平丟
        // Vector3 force = transform.right * count;
        RB.AddForce(force, ForceMode.Impulse);
    }
}

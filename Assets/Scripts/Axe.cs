using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public float throwAngle = 45f;

    private GameManager gameManager;
    private Rigidbody RB;
    private Vector3 startPos;
    public float distance;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        RB = this.GetComponent<Rigidbody>();
    }

    public void ThrowWithForce(int count){
        //拋物線
        Quaternion rotation = Quaternion.Euler(0f, 0f, throwAngle);
        Vector3 forceDirection = rotation * transform.right;
        Vector3 force = forceDirection * count;
        //平丟
        // Vector3 force = transform.right * count;
        RB.AddForce(force, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (gameManager.isFly){
            RB.velocity = Vector3.zero;
            RB.angularVelocity = Vector3.zero;
            gameManager.End();
        }
    }
    //計距離
    public float GetDistance(){
        Vector3 end_x = new Vector3 (transform.position.x, 0f, 0f);
        Vector3 start_x = new Vector3 (startPos.x, 0f, 0f);
        distance = Vector3.Distance(end_x, start_x) * 10;
        return distance;
    }
}
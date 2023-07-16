using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    public float throwAngle = 45f;
    public float distance;
    private GameManager gameManager;
    private Rigidbody RB;
    private float startPos_x;
    private float endPos_x;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        startPos_x = transform.position.x;
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
            //清空速度
            RB.velocity = Vector3.zero;
            RB.angularVelocity = Vector3.zero;
            gameManager.End();
        }
    }
    //計距離
    public float GetDistance(){
        endPos_x = transform.position.x;
        distance = (endPos_x - startPos_x) * 10;
        return distance;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Axe : MonoBehaviour
{
    private Rigidbody RB;
    public float throwAngle = 30f;
    public bool isThrow = false;
    public bool isStop = false;

    private Count countScript;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        countScript = GameObject.Find("GameManager").GetComponent<Count>();
        RB = this.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void Throw(){
        isThrow = true;
        int count = countScript.GetCount();
        Quaternion rotation = Quaternion.Euler(0f, 0f, throwAngle);
        Vector3 forceDirection = rotation * transform.right;
        Vector3 force = forceDirection * count;
        RB.AddForce(force, ForceMode.Impulse);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (isThrow){
            isThrow = false;
            isStop = true;
            gameManager.EndGame();
        }
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountButton : MonoBehaviour
{
    public bool isCount = false;
    public int count;
    private float time;

    public GameObject ball;
    public Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("a")){
            StartTimer();
        }
        if (isCount){
            time += Time.deltaTime;
            if (Input.anyKeyDown){
                count++;
                Debug.Log(count);
            }
        }
    }
    public void StartTimer(){
        time = 0f;
        count = 0;
        isCount = true;
        StartCoroutine(Countdown());
    }
    public void StopTimer(){
        isCount = false;
        Debug.Log("Score:" + count);
        Quaternion rotation = Quaternion.Euler(0f, 0f, 30f);
        Vector3 forceDirection = rotation * transform.right;

        Vector3 force = forceDirection * count;
        rb.AddForce(force, ForceMode.Impulse);
    }
    IEnumerator Countdown(){
        yield return new WaitForSeconds(5);
        StopTimer();
    }
}

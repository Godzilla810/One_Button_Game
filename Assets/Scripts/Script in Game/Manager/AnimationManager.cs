using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public GameObject devil;
    public GameObject hit;
    public GameObject mainCamera;

    private Animator devilAnimator;
    private Animator hitAnimator;
    private Animator mainCameraAnimator;

    private GameManager gameManager;

    private bool isHit;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        devilAnimator = devil.GetComponent<Animator>();
        hitAnimator = hit.GetComponent<Animator>();
        mainCameraAnimator = mainCamera.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isReady){

        }
        else if (gameManager.isChargeUp){
            devilAnimator.SetTrigger("Start");
            mainCameraAnimator.SetTrigger("Transition_ChargeUp");
        }
        else if (gameManager.isFly){
            devilAnimator.SetTrigger("Throw");
        }
        else if (gameManager.isEnd){

        }

        if (Input.GetKeyDown("space") && gameManager.isChargeUp){
            hitAnimator.Play("Hit", 0, 0f);
        }
    }
}

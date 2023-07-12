using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public GameObject devil;
    public GameObject hit;
    public GameObject mainCamera;
    public GameObject subCamera;

    private Animator devilAnimator;
    private Animator hitAnimator;
    private Animator mainCameraAnimator;
    private Animator subCameraAnimator;

    private GameManager gameManager;

    private bool isHit;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        devilAnimator = devil.GetComponent<Animator>();
        hitAnimator = hit.GetComponent<Animator>();
        mainCameraAnimator = mainCamera.GetComponent<Animator>();
        subCameraAnimator = subCamera.GetComponent<Animator>();
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
            // mainCamera.SetActive(false);
            // subCamera.SetActive(true);
        }
        else if (gameManager.isEnd){

        }

        if (Input.GetKeyDown("space") && gameManager.isChargeUp){
            hitAnimator.Play("Hit", 0, 0f);
            // devilAnimator.Play("power", 0, 0f);
        }
    }
    // IEnumerator Countdown_05s(){
    //     yield return new WaitForSeconds(0.5f);
    // }
}

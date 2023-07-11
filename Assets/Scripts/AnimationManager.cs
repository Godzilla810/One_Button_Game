using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    public GameObject devil;
    public GameObject banana;
    public GameObject mainCamera;
    public GameObject subCamera;

    private Animator devilAnimator;
    private Animator mainCameraAnimator;
    private Animator subCameraAnimator;

    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
        devilAnimator = devil.GetComponent<Animator>();
        mainCameraAnimator = mainCamera.GetComponent<Animator>();
        subCameraAnimator = subCamera.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isMenu){

        }
        else if (gameManager.isChargeUp){
            devilAnimator.SetTrigger("Start");
            mainCameraAnimator.SetTrigger("Transition_ChargeUp");
        }
        else if (gameManager.isFly){
            devilAnimator.SetTrigger("Throw");
            StartCoroutine(Countdown_05s());

        }
        else if (gameManager.isEnd){

        }
    }
    IEnumerator Countdown_05s(){
        yield return new WaitForSeconds(0.5f);
        mainCamera.SetActive(false);
        subCamera.SetActive(true);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _AnimationManager : MonoBehaviour
{
    public GameObject devil;
    public GameObject mainCamera;

    private Animator devilAnimator;
    private Animator mainCameraAnimator;

    private bool isHit;
    // Start is called before the first frame update
    void Start()
    {
        devilAnimator = devil.GetComponent<Animator>();
        mainCameraAnimator = mainCamera.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    }
}

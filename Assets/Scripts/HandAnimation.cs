using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimation : MonoBehaviour
{
    // Start is called before the first frame update
    public InputActionProperty pinchAnimationAction;
    public InputActionProperty gripAnimationAction;
    public GameObject cigarette;
    public GameObject cigaretteEmiter;
    public Transform camerapos;
    public Animator handAnimator;
    void Start()
    {
        cigarette.SetActive(false);
        cigaretteEmiter.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
       float triggerValue = pinchAnimationAction.action.ReadValue<float>();
       float gripValue = gripAnimationAction.action.ReadValue<float>();
        
       if(triggerValue > 0.90)  cigarette.SetActive(true);
       else cigarette.SetActive(false);

       if(Vector3.Distance(cigarette.transform.position, camerapos.position) < 0.15) cigaretteEmiter.SetActive(true);
       else cigaretteEmiter.SetActive(false);

       Debug.Log(triggerValue);
       handAnimator.SetFloat("Trigger", triggerValue);
       handAnimator.SetFloat("Grip", gripValue);
    }
}

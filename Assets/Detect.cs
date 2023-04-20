using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.ARFoundation;

public class Detect : MonoBehaviour
{
    [SerializeField]
    ParticleSystem particleSystem;

    [SerializeField]
    ARRaycastManager raycastManager;
    [SerializeField]
    Camera ARCam;

    [SerializeField]
    AudioSource player;
    [SerializeField]
    AudioClip spellSFX;

    [SerializeField]
    Text information;

    private void Start()
    {
        particleSystem.Stop();
    }

    void Awake()
    {
        //player = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(Input.touchCount > 0)
        {
            
            RaycastHit _hit;
            Ray ray = ARCam.ScreenPointToRay(Input.GetTouch(0).position);
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {
                if (Physics.Raycast(ray, out _hit))
                {
                    if (_hit.collider.CompareTag("spellPainting1"))
                    {
                        player.PlayOneShot(spellSFX);
                    }
                }
            }

        }
    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    
    //}
    //
    //private void OnTriggerStay(Collider other)
    //{
    //    
    //}
}
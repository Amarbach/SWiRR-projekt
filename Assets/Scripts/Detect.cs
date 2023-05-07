using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
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
    ARSessionOrigin origin;
    [SerializeField]
    ARTrackedImageManager imageManager;

    [SerializeField]
    AudioSource player;
    

    [SerializeField]
    Text information;

    [SerializeField]
    private BeansController beansController;


    void Awake()
    {
        
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
                        var painting = _hit.collider.gameObject.GetComponent<PaintingController>();
                        beansController.AddBeans();
                        if (painting != null)
                        {
                            if (painting.SFX != null) player.PlayOneShot(painting.SFX);
                            painting.OnEnchanted();
                        }
                    }
                }
            }
        }
        {
            RaycastHit _hit;
            Ray ray = new Ray(ARCam.transform.position, ARCam.transform.forward);
            if(Physics.Raycast(ray, out _hit))
            {
                if (_hit.collider.CompareTag("spellPainting1"))
                {
                    var painting = _hit.collider.gameObject.GetComponent<PaintingController>();
                    if (!particleSystem.isPlaying && painting.Castable) particleSystem.Play();
                }
            }
            else
            {
                if (particleSystem.isPlaying) particleSystem.Stop();
            }
        }
    }
}
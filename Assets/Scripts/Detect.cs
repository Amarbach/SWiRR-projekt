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
    ARSessionOrigin origin;
    [SerializeField]
    ARTrackedImageManager imageManager;

    [SerializeField]
    AudioSource player;
    [SerializeField]
    AudioClip spellSFX;

    [SerializeField]
    Text information;

    [SerializeField]
    private BeansController beansController;
    
    private void Start()
    {
        beansController.AddBeans();
    }

    void Awake()
    {
        //player = GetComponent<AudioSource>();
        //imageManager.trackedImagesChanged += OnDetect;
    }

    void OnDetect(ARTrackedImagesChangedEventArgs e)
    {
        
    }

    private void Update()
    {
        information.text = particleSystem.isPlaying.ToString();
        if(Input.touchCount > 0)
        {
            //if (particleSystem.isPlaying) particleSystem.Stop();
            //else particleSystem.Play();
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
        {
            RaycastHit _hit;
            Ray ray = new Ray(ARCam.transform.position, ARCam.transform.forward);
            //information.text = ray.direction.ToString();
            if(Physics.Raycast(ray, out _hit))
            {
                if (_hit.collider.CompareTag("spellPainting1"))
                {
                    if (!particleSystem.isPlaying) particleSystem.Play();
                }
            }
            else
            {
                if (particleSystem.isPlaying) particleSystem.Stop();
            }
        }
        //information.text = ARCam.transform.position.ToString();
    }

    //private void OnTriggerStay(Collider other)
    //{
    //    information.text = (ARCam.transform.position - other.transform.position).ToString();
    //}
}
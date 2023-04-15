using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

[RequireComponent(typeof(ARTrackedImageManager))]
public class Detect : MonoBehaviour
{
    [SerializeField]
    ARTrackedImageManager m_TrackedImageManager;

    [SerializeField]
    ParticleSystem particleSystem;

    private void Start()
    {
        particleSystem.Stop();
    }

    void Awake()
    {
        m_TrackedImageManager = GetComponent<ARTrackedImageManager>();
    }

    void OnEnable()
    {
        m_TrackedImageManager.trackedImagesChanged += OnTrackedImagesChanged;
    }

    void OnDisable()
    {
        m_TrackedImageManager.trackedImagesChanged -= OnTrackedImagesChanged;
    }


    void UpdateInfo(ARTrackedImage trackedImage)
    {

        if (trackedImage.trackingState != TrackingState.None)
        {
            particleSystem.Play();
        }
        else
        {
            //particleSystem.Stop();
        }
    }

    void OnTrackedImagesChanged(ARTrackedImagesChangedEventArgs eventArgs)
    {

        //bool isAnyTracked = (eventArgs.added.Count > 0 || eventArgs.updated.Count > 0);

        foreach (var trackedImage in eventArgs.added)
        {
            // Give the initial image a reasonable default scale

            UpdateInfo(trackedImage);
        }

        foreach (var trackedImage in eventArgs.updated)
            UpdateInfo(trackedImage);
    }
    //private void Start()
    //{
    //    particleSystem.Stop();
    //}
    //void OnEnable() => m_TrackedImageManager.trackedImagesChanged += OnChanged;

    //void OnDisable() => m_TrackedImageManager.trackedImagesChanged -= OnChanged;

    //void OnChanged(ARTrackedImagesChangedEventArgs eventArgs)
    //{
    //    foreach (var newImage in eventArgs.added)
    //    {
    //        // Handle added event
    //        particleSystem.Play();
    //    }

    //    foreach (var updatedImage in eventArgs.updated)
    //    {
    //        // Handle updated event
    //    }

    //    foreach (var removedImage in eventArgs.removed)
    //    {
    //        // Handle removed event
    //        particleSystem.Stop();
    //    }

    //    if(eventArgs.updated.Count > 0 || eventArgs.added.Count > 0)
    //    {
    //        particleSystem.Play();
    //    }
    //    else
    //    {
    //        particleSystem.Stop();
    //    }
    //}
}
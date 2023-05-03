using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.UI;
using UnityEngine.XR.ARSubsystems;

public class PictureManager : MonoBehaviour
{
    [SerializeField]
    private ARTrackedImageManager imageManager;
    [SerializeField]
    private XRReferenceImageLibrary imageLibrary;


    [SerializeField]
    private Text information;
    [SerializeField]
    private GameObject[] prefabs;
    Transform tracks;

    private Dictionary<string, GameObject> arObjects = new Dictionary<string, GameObject>();
    
    void Awake()
    {
        foreach(var prefab in prefabs)
        {
            GameObject newObj = Instantiate(prefab, Vector3.zero, Quaternion.identity);
            newObj.name = prefab.name;
            newObj.SetActive(false);
            arObjects.Add(newObj.name, newObj);
        }
    }

    private void OnEnable()
    {
        imageManager.trackedImagesChanged += OnDetect;
    }

    private void OnDisable()
    {
        imageManager.trackedImagesChanged -= OnDetect;
    }
    private void OnDetect(ARTrackedImagesChangedEventArgs args)
    {
        foreach(var trackable in args.added)
        {
            UpdateImage(trackable);
        }
        foreach(var trackable in args.updated)
        {
            UpdateImage(trackable);
        }
        foreach(var trackable in args.removed)
        {
            arObjects[trackable.name].SetActive(false);
        }
        information.text = args.removed.Count.ToString();
    }

    private void UpdateImage(ARTrackedImage image)
    {
        if(arObjects != null)
        {
            var curObj = arObjects[image.referenceImage.name];
            curObj.SetActive(image.trackingState == TrackingState.Tracking);
            curObj.transform.position = image.transform.position;
            //information.text = image.transform.rotation.x.ToString() + ":" + image.transform.rotation.y.ToString() + ":" + image.transform.rotation.z.ToString() + ":" + image.transform.rotation.w.ToString();
        }
    }
}

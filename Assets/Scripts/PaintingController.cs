using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingController : MonoBehaviour
{
    [SerializeField]
    AudioClip spellSFX;
    public AudioClip SFX { get { return spellSFX; } }

    public void OnEnchanted()
    {
        //co� z obrazkiem zrobi� jak zostanie zaczarowany?
    }
}

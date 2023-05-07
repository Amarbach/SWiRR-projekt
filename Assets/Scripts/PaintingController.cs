using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingController : MonoBehaviour
{
    [SerializeField]
    AudioClip spellSFX;
    public AudioClip SFX { get { return spellSFX; } }

    private bool castable = true;
    public bool Castable { get { return castable; } set { castable = value; } }

    public void OnEnchanted()
    {
        castable = false;
    }


}

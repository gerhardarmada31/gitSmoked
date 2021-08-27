using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFMOD : MonoBehaviour
{
    private void PlaySound(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
    }
}

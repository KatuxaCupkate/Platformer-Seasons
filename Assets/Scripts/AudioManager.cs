using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource[] collectedAudio;

    private void OnEnable()
    {
        EventBus.ItemPickedUpEvent += PlayItemAudio;
    }

    private void OnDisable()
    {
        EventBus.ItemPickedUpEvent -= PlayItemAudio;
    }
    public void PlayItemAudio(string name)
    {
        switch (name)
        {

            case "Key":
                collectedAudio[0].Play();
                break;
            case "Coin":
                collectedAudio[1].Play();
                break;
            default:
                break;
           
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera vCamera;

    public void Initialize(GameObject Player)
    {
        vCamera = FindAnyObjectByType<CinemachineVirtualCamera>();
        vCamera.Follow = Player.transform;
    }
}

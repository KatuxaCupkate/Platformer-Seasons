using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera vCamera;
   GameObject _player;
   private float baseSize = 8f;
   private float zoomInSize = 6f;
    public void Initialize(GameObject Player)
    {
        vCamera = FindAnyObjectByType<CinemachineVirtualCamera>();
        vCamera.Follow = Player.transform;
        _player = Player;
    }
    
    public void LookAt(GameObject traps)
    {
        vCamera.m_Lens.OrthographicSize = zoomInSize;
        vCamera.Follow = traps.transform; 
    }

    public void ResetCamera()
    {
        vCamera.m_Lens.OrthographicSize = baseSize;
        vCamera.Follow = _player.transform;
    }
}

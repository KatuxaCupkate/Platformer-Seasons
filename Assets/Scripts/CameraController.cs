using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    private CinemachineVirtualCamera vCamera;
    [SerializeField] GameObject[] traps;

    public void Initialize(GameObject Player)
    {
        vCamera = FindAnyObjectByType<CinemachineVirtualCamera>();
        vCamera.Follow = Player.transform;
    }
    private void OnEnable()
    {
        //EventBus.AllEnemiesDeadEvent += LookAt;
    }
    private void OnDisable()
    {
       // EventBus.AllEnemiesDeadEvent -= LookAt;
        
    }
    public void LookAt(GameObject traps)
    {
        vCamera.LookAt = traps.GetComponentInChildren<Transform>();
       
    }
}

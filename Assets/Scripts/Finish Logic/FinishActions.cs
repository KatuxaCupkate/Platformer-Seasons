using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishActions : MonoBehaviour
{
    [SerializeField] GameObject HomeDoor;
    [SerializeField] WaypointFollower Platform;
    [SerializeField] GameObject[] TrapsUp;
    [SerializeField] GameObject[] TrapsDown;
    

    GameObject Player;
    CameraController cameraController;

    public void Initialize(GameObject Player,CameraController vCamera)
    {
        this.Player = Player;
        cameraController = vCamera;
    }

    private void OnEnable()
    {
        EventBus.FinishActionTriggerEvent += OpenTheDoorAction;
        EventBus.FinishActionTriggerEvent += ActivatePlatform;
        EventBus.FinishActionTriggerEvent += ActivateSnowballs;
        EventBus.AllEnemiesDeadEvent += ReleaseTraps;
    }
    private void OnDisable()
    {
        EventBus.FinishActionTriggerEvent -= OpenTheDoorAction;
        EventBus.FinishActionTriggerEvent -= ActivatePlatform;
        EventBus.AllEnemiesDeadEvent -= ReleaseTraps;
        EventBus.FinishActionTriggerEvent -= ActivateSnowballs;
        
    }
    private void OpenTheDoorAction(bool isKey)
    {
        if (isKey)
        {
         HomeDoor.SetActive(true);

        }
    }

    private void ActivatePlatform(bool isKey)
    {
        if(Platform != null)
        {
            Platform.enabled = !isKey;
        }

    }

    private void ReleaseTraps()
    {
        StartCoroutine(ReleaseTrapsEnumerator());
    }

    private IEnumerator ReleaseTrapsEnumerator()
    {
        foreach (var trap in TrapsDown)
        {
            cameraController.LookAt(trap);
            var startPosition = trap.transform.position;
            var endPosition = (Vector2)startPosition+Vector2.down/2f; 
            var distance = (endPosition - (Vector2) startPosition).magnitude;
            var duration = distance / 0.5f;

            var t = 0f;
            while (t < 1)
            {
                trap.transform.position = Vector2.Lerp(startPosition, endPosition, t);
                t += Time.deltaTime / duration;
                yield return null;
            }
           trap.SetActive(false);
            yield return new WaitForSeconds(0.7f);
        }

        foreach (var trap in TrapsUp)
        {
            cameraController.LookAt(trap);
            var startPosition = trap.transform.position;
            var endPosition = (Vector2)trap.transform.position + Vector2.up;
            var distance = (endPosition - (Vector2) startPosition).magnitude;
            var duration = distance / 0.5f;

            var t = 0f;
            while (t < 1)
            {
                trap.transform.position = Vector2.Lerp(startPosition, endPosition, t);
                t += Time.deltaTime / duration;
                yield return null;
            }
           trap.SetActive(false);
        
            yield return new WaitForSeconds(0.7f);
        }

        cameraController.ResetCamera();
    }


    private void ActivateSnowballs(bool isNPC)
    {
        Player.GetComponent<SnowBallWeapon>().enabled = true;
    }
}

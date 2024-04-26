
using UnityEngine;

public class Coins : MonoBehaviour 
{
    private int _pickedAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            _pickedAmount++;
            EventBus.OnItemPickedUpEvent(gameObject.tag,_pickedAmount);
            Destroy(gameObject);
        }
        if (collision.CompareTag("NPC"))
        {
            
            Destroy(gameObject);
        }
    }

}

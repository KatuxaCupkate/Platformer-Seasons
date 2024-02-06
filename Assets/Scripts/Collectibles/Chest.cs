using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] AudioSource _openSound;
    Animator _animator;
    private bool _isOpen;
    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")&&!_isOpen)
        {
           
            _openSound.Play();
            _isOpen = true;
            _animator.SetBool("IsOpen", _isOpen);
            EventBus.OnChestIsOpenEvent();

        }
    }
}

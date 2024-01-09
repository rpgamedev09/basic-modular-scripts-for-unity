using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip audioClip;
    
    [SerializeField] private new string tag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(tag))
        {
            OnCollected();  
        }
    }
    private void OnCollected()
    {
        if (audioSource != null || audioClip != null) 
            audioSource.PlayOneShot(audioClip);

        Destroy(gameObject);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            PerformPickUp();
            GameManager.Instance.audioManager.Play("pop");
        }
    }

    public virtual void PerformPickUp()
    {

    }
}

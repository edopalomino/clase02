using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DangerZone : MonoBehaviour
{
    
    public delegate void OnPlayerDeath();
    public static event OnPlayerDeath PlayerDeath;
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            Destroy(other.gameObject);

            PlayerDeath?.Invoke();
        }
    }
}

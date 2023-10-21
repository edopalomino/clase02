using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;
    private Transform spawnPoint;
    [SerializeField]
    private GameObject explosionPrefab;

    private void SpawnPlayer(){
        spawnPoint = GameObject.FindGameObjectWithTag("Respawn").transform;
        Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation);
        StartCoroutine(Explosion());
    }

    private IEnumerator Explosion(){
        Transform player = GameObject.FindGameObjectWithTag("Player").transform;
        GameObject explosionClone = Instantiate(explosionPrefab, player.position, player.rotation);

        yield return new WaitForSeconds(3.5f);
        Destroy(explosionClone);
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnPlayer();
    }

    private void OnEnable(){
        DangerZone.PlayerDeath += SpawnPlayer;
    }

    private void OnDisable(){
        DangerZone.PlayerDeath -= SpawnPlayer;
    }
}

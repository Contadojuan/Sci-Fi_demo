using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    private Player player;
    [SerializeField]
    private AudioClip _audio;

    void OnTriggerStay(Collider other)
    {

        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.CompareTag("Player"))
        {
            player = other.GetComponent<Player>();
            if (player != null)
            {
                player.hasCoin = true;
                AudioSource.PlayClipAtPoint(_audio, Camera.main.transform.position, 1f);
                Destroy(this.gameObject);
            }
        }
    }

}

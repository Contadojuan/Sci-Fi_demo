using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponShop : MonoBehaviour
{
    [SerializeField]
    private Player myPlayer;
    [SerializeField]
    private AudioClip _sellWeaponSound;

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            myPlayer = other.GetComponent<Player>();

            if (Input.GetKeyDown(KeyCode.E) && myPlayer.hasCoin == true)
            {
                if (myPlayer != null)
                {
                    AudioSource.PlayClipAtPoint(_sellWeaponSound, Camera.main.transform.position);
                    myPlayer.myWeapon.gameObject.SetActive(true);
                    myPlayer.hasWeapon = true;
                    myPlayer.hasCoin = false;
                }
            }
        }
    }

}

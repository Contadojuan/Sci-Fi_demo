using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private CharacterController _controller;
    [SerializeField]
    private float _speed = 3.5f;
    [SerializeField]
    private float _gravity = 9.81f;
    [SerializeField]
    private GameObject muzzleFlash;
    [SerializeField]
    private GameObject _hitMarkerPrefab;
    [SerializeField]
    private AudioSource _shotSound;
    [SerializeField]
    private int _currentAmmo;
    private int _maxAmmo = 50;
    private bool isReloading = false;
    private UI_Manager uiManager;
    public bool hasCoin = false;
    public bool hasWeapon = false;
    [SerializeField]
    public GameObject myWeapon;
    
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        _controller = GetComponent<CharacterController>();
        _shotSound = GetComponent<AudioSource>();
        uiManager = GameObject.FindWithTag("UI_Manager").GetComponent<UI_Manager>();
        Debug.Log(uiManager.name);
        _currentAmmo = _maxAmmo;

    }

    // Update is called once per frame
    void Update()
    {
        if (hasCoin == true)
        {
            uiManager.coinImage.gameObject.SetActive(true);
        }
        else if (hasCoin == false)
        {
            uiManager.coinImage.gameObject.SetActive(false);
        }

        if (hasWeapon == true)
        {
            if (Input.GetMouseButton(0) && _currentAmmo > 0 && isReloading == false)
            {
                _currentAmmo--;
                uiManager.UpdateAmmo(_currentAmmo);

                Ray rayOrigin = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)); // vector saying that the ray origin will be on the middle of X and Y of my viewport
                RaycastHit hitInfo;

                if (Physics.Raycast(rayOrigin, out hitInfo))
                {
                    GameObject hitMarker = Instantiate(_hitMarkerPrefab, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                    Destroy(hitMarker, 0.5f);

                    Destructable crate = hitInfo.transform.GetComponent<Destructable>();
                    if (crate != null){
                        crate.DestroyCrate();
                    }


                }
                muzzleFlash.SetActive(true);
                if (_shotSound != null)
                {
                    if (_shotSound.isPlaying == false)
                    {
                        _shotSound.Play();
                    }
                }
            }

            else if (Input.GetMouseButtonUp(0) || _currentAmmo == 0 || isReloading == true)
            {
                muzzleFlash.SetActive(false);

                if (_shotSound != null)
                {
                    _shotSound.Stop();
                }
            }
            if (Input.GetKeyDown(KeyCode.R) && isReloading == false)
            {
                isReloading = true;
                StartCoroutine(reloadWeapon());

            }
        }
        HideCursor();
        CalculateMovement();
    }

    void CalculateMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontalInput, 0, verticalInput);
        Vector3 velocity = direction * _speed;
        velocity.y -= _gravity;
        velocity = transform.TransformDirection(velocity);
        _controller.Move(velocity * Time.deltaTime);
    }
    void HideCursor()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && (Cursor.visible == false))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }

    }
    IEnumerator reloadWeapon()
    {
        yield return new WaitForSeconds(1.5f);
        _currentAmmo = _maxAmmo;
        isReloading = false;
        uiManager.UpdateAmmo(_currentAmmo);
    }
}

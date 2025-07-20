using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class Shooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject normalBulletPrefab;
    public GameObject waterBulletPrefab;
    public GameObject fireBulletPrefab;
    public InputActionReference shootAction;
    

    private void OnEnable()
    {
        shootAction.action.performed += OnShootPerformed;
        shootAction.action.Enable();
    }

    private void OnDisable()
    {
        shootAction.action.performed -= OnShootPerformed;
        shootAction.action.Disable();
    }

    private void OnShootPerformed(InputAction.CallbackContext context)
    {
        Shoot();
    }



    private void Shoot()
    {
         PlayerPowers powers = gameObject.GetComponent<PlayerPowers>();

        if (powers.isFireActive)
        {
            Instantiate(fireBulletPrefab, firePoint.position, firePoint.rotation);
        }
        else if (powers.isWaterActive)
        {
            Instantiate(waterBulletPrefab, firePoint.position, firePoint.rotation);
        } else
        {
            Instantiate(normalBulletPrefab, firePoint.position, firePoint.rotation);
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private Transform muzzleTransform;

    [SerializeField]
    private ParticleSystem muzzleFlash;

    [SerializeField]
    private AudioSource audioSource;

    [SerializeField]
    private GameObject projectilePrefab;

    [SerializeField]
    private float projectileForce;

    private Rigidbody projectileRigidbody;
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        muzzleFlash = GetComponentInChildren<ParticleSystem>();
    }
    public void Fire()
    {
        GameObject currentProjectile = Instantiate(projectilePrefab,
            muzzleTransform.position, Quaternion.LookRotation(muzzleTransform.forward));

        projectileRigidbody = currentProjectile.GetComponent<Rigidbody>();
        projectileRigidbody.AddForce(muzzleTransform.forward * projectileForce);

        audioSource.Play();

        muzzleFlash.Play();

        Destroy(currentProjectile, 5);
    }
}

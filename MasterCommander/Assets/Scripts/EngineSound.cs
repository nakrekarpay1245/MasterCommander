using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineSound : MonoBehaviour
{
    [SerializeField]
    private AudioSource engineSource;

    [SerializeField]
    private float maxPitch = 1.5f;
    [SerializeField]
    private float minPitch = 0.25f;
    [SerializeField]
    private float currentPitch = 0.35f;

    private void Awake()
    {
        engineSource = GetComponent<AudioSource>();
    }

    public void IncreaseSpeed()
    {
        currentPitch += Time.deltaTime;
    }
    public void DecreaseSpeed()
    {
        currentPitch -= Time.deltaTime;
    }
    private void Update()
    {
        currentPitch = Mathf.Clamp(currentPitch, minPitch, maxPitch);
        engineSource.pitch = currentPitch;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{
    [SerializeField]
    private int maxHealth;
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private Bar healthBar;

    [SerializeField]
    private string projectileTag;

    [SerializeField]
    private GameObject hitImpactParticlePrefab;

    public bool isAlive = true;
    private void Start()
    {
        // healthBar = GetComponentInChildren<Bar>();
        healthBar.SetMaxValue(maxHealth);
        SetCurrentHealth(maxHealth);
        isAlive = true;
    }

    public void SetCurrentHealth(int value)
    {
        currentHealth = value;
        healthBar.SetCurrentValue(currentHealth);
        // Debug.Log(gameObject.name + " health: " + currentHealth);

        if (currentHealth <= 0)
        {
            Debug.Log("DEAD");
            isAlive = false;
        }
    }

    public void TakeDamage()
    {
        SetCurrentHealth(currentHealth - 1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(projectileTag))
        {
            GameObject hitImpactParticle = Instantiate(hitImpactParticlePrefab,
                other.transform.position, Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(hitImpactParticle.gameObject, 2);
            TakeDamage();
        }
    }
}

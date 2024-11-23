using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Transform healthPopUpObject;

    public int playerMaxHealth = 100;

    private HealthSystem healthSystem;

    private void Start()
    {
        healthSystem = new HealthSystem(playerMaxHealth);

        healthBar.Setup(healthSystem);
        healthSystem.OnHealthZero += HealthSystem_OnHealthZero;
    }

    private void HealthSystem_OnHealthZero(object sender, EventArgs e)
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damageAmount)
    {
        healthSystem.Damage(damageAmount);
        HealthPopup.Create(healthPopUpObject, transform.position, -damageAmount);
    }

    public void AddHealth(int healAmount)
    {
        healthSystem.Heal(healAmount);
        HealthPopup.Create(healthPopUpObject, transform.position, healAmount);
    }
}

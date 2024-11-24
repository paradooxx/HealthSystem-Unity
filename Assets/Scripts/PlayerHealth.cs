using System;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    [SerializeField] private Transform healthPopUpObject;

    //set your own max health for player
    //if you want other scripts to influence maxHealth remove { get; private set; } (not recommended)
    public int playerMaxHealth { get; private set; } = 100;

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
        //since this function takes out health we set isDamage = true in below function
        HealthPopup.Create(healthPopUpObject, transform.position, damageAmount, true);
    }

    public void AddHealth(int healAmount)
    {
        healthSystem.Heal(healAmount);
        HealthPopup.Create(healthPopUpObject, transform.position, healAmount, false);
    }
}

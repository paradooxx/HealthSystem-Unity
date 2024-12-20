using System;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private HealthSystem healthSystem;

    //set the gameobject which acts as your healthbar whose size will increase/decrease
    [SerializeField] private GameObject healthBarLife;

    public void Setup(HealthSystem healthSystem)
    {
        this.healthSystem = healthSystem;
        healthSystem.OnHealthChanged += HealthSystem_OnHealthChanged;
    }

    private void HealthSystem_OnHealthChanged(object sender, EventArgs e)
    {
        if(healthBarLife != null)
            healthBarLife.transform.localScale = new Vector3(healthSystem.GetHealthPercent(), 1);
        else
            return;
    }
}
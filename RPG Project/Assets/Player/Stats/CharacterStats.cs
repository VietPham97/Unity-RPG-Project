using UnityEngine;

public class CharacterStats : MonoBehaviour 
{
    public int maxHealth = 100;
    public int CurrentHealth { get; private set; }

    public Stat damage;
    public Stat armor;

    private void Awake()
    {
        CurrentHealth = maxHealth;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damageAmount)
    {
        damageAmount -= armor.GetValue();
        damageAmount = Mathf.Clamp(damageAmount, 0, int.MaxValue);

        CurrentHealth -= damageAmount;
        Debug.Log(transform.name + " takes " + damageAmount + " damage.");

        if (CurrentHealth <= 0)
        {
            Die();
        }
    }

    /// <summary>
    /// Die in some way.
    /// This method is meant to be overwritten.
    /// </summary>
    public virtual void Die()
    {
        Debug.Log(transform.name + " died.");
    }
}

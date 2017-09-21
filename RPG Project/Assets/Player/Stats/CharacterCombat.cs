﻿using UnityEngine;

[RequireComponent(typeof(CharacterStats))]
public class CharacterCombat : MonoBehaviour 
{
    CharacterStats myStats;

    private void Start()
    {
        myStats = GetComponent<CharacterStats>();
    }

    public void Attack (CharacterStats targetStats)
    {
        targetStats.TakeDamage(myStats.damage.GetValue());
    }
}

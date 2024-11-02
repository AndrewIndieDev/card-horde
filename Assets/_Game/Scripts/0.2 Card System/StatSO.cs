using UnityEngine;

[CreateAssetMenu(fileName = "New Stat Block", menuName = "Card System/Stat Block")]
public class StatSO : ScriptableObject
{
    public int health = 100;
    public int damage = 10;
    public float decisionTime = 2f;
    public float moveSpeed = 5f;

    public void Copy(StatSO other)
    {
        health = other.health;
        damage = other.damage;
        decisionTime = other.decisionTime;
        moveSpeed = other.moveSpeed;
    }
}

public struct Stats
{
    public int ModifiedHealth => Mathf.CeilToInt(health * healthModifier);
    public int ModifiedDamage => Mathf.CeilToInt(damage * damageModifier);
    public float ModifiedDecisionTime => decisionTime * decisionSpeedModifier;
    public float ModifiedMoveSpeed => moveSpeed * moveSpeedModifier;

    public int health;
    public int damage;
    public float decisionTime;
    public float moveSpeed;

    public float healthModifier;
    public float damageModifier;
    public float decisionSpeedModifier;
    public float moveSpeedModifier;

    public Stats(StatSO statSO)
    {
        health = statSO.health;
        damage = statSO.damage;
        decisionTime = statSO.decisionTime;
        moveSpeed = statSO.moveSpeed;

        healthModifier = 1;
        damageModifier = 1;
        decisionSpeedModifier = 1;
        moveSpeedModifier = 1;
    }

    // Modifiers are added on UnitSO Init(). After this, it shouldn't be changed!
    public void AddModifiers(IStatModifier _modifier)
    {
        healthModifier *= _modifier.HealthModifier / 100;
        damageModifier *= _modifier.DamageModifier / 100;
        decisionSpeedModifier *= _modifier.DecisionSpeedModifier / 100;
        moveSpeedModifier *= _modifier.MoveSpeedModifier / 100;
    }
}
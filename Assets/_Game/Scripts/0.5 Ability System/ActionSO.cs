using Cysharp.Threading.Tasks;
using DrewDev.GridSystem;
using System;
using UnityEngine;

public abstract class ActionSO : ScriptableObject
{
    [Flags]
    public enum EAbilityTag
    {
        AreaOfEffect = 1 << 0,
        DamageOverTime = 1 << 1,
        SingleTarget = 1 << 2,
        MultiTarget = 1 << 3,
        Projectile = 1 << 4,
        Instant = 1 << 5,
        TargetAllies = 1 << 6,
        TargetEnemies = 1 << 7
    }

    public string Name => _name;
    public bool OnCooldown => _cooldown > 0f;

    private GridComponent _grid => GridComponent.Instance;

    [Header("Base Settings")]
    [SerializeField] private string _name;
    [SerializeField] private float _cooldown;
    [SerializeField] private bool _debugging;
    [SerializeField] private EAbilityTag _tags;

    public async virtual UniTask Execute(CardObject card) { await UniTask.Yield(); }
    public async virtual UniTask<float> CalculateValue(CardObject card) { await UniTask.Yield(); return 0f; }

    public virtual void Tick(float deltaTime)
    {
        if (_cooldown > 0f)
        {
            _cooldown -= deltaTime;
        }
    }
}

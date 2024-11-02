using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardObject : MonoBehaviour, IGridCellOccupier
{
    public UnitSO unit;
    public Image artwork;
    public Image border;

    public List<ActionSO> AvailableActions => actions;

    private CardStateMachine stateMachine;
    private List<ActionSO> actions;

    public Vector2 GridPosition => GridComponent.Instance.Grid.WorldToGridPosition(transform.position);

    private void Awake()
    {
        InitializeUnit();
        UpdateVisuals();
    }

    private void OnValidate()
    {
        UpdateVisuals();
    }

    public void Start()
    {
        stateMachine = new CardStateMachine(this);
        stateMachine.ChangeState(new IdleCardState());
    }

    public void Update()
    {
        stateMachine?.Update(Time.deltaTime);
    }

    private void InitializeUnit()
    {
        UnitSO other = ScriptableObject.CreateInstance<UnitSO>();
        other.Copy(unit);
        unit = other;

        actions = new List<ActionSO>();
        actions.AddRange(unit.speciesSO._actions);
        actions.AddRange(unit.titleSO._actions);
    }

    // Mainly used to update artworks in the editor. Can be used to update at runtime.
    public void UpdateVisuals()
    {
        if (unit == null) return;

        artwork.sprite = unit.artwork;
        border.sprite = unit.speciesSO != null ? unit.speciesSO._borderArtwork : null;

        if (unit.speciesSO == null)
            border.color = new Color(1, 1, 1, 0);
        else
            border.color = new Color(1, 1, 1, 1);

        if (unit.artwork == null)
            artwork.color = new Color(1, 1, 1, 0);
        else
            artwork.color = new Color(1, 1, 1, 1);
    }
}

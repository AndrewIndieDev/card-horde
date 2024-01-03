using DrewDev.GridSystem;
using UnityEngine;

public class CraftingTower : MonoBehaviour
{
    private MyGrid Grid => GridComponent.Instance.Grid;

    private void Start()
    {
        float x, z;
        x = Random.Range(-5f, 5f);
        z = Random.Range(-5f, 5f);
        transform.position += new Vector3(x, 0, z);
        transform.position = Grid.GetCell(transform.position).CenterWorldPosition;
    }
}

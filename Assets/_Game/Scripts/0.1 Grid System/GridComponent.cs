using UnityEngine;
using GridSystem;

public class GridComponent : MonoBehaviour
{
    public static GridComponent Instance { get; private set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    [SerializeField] bool showGrid;
    [SerializeField] private Vector2 gridSize;
    [SerializeField] private Vector2 cellSize;
    [Range(0.1f, 1f)][SerializeField] float updateGridTime;

    private float updateGridTimer;
    public MyGrid Grid => grid;
    private MyGrid grid;

    private void Start()
    {
        grid = new MyGrid((int)gridSize.x, (int)gridSize.y, cellSize.x, cellSize.y, this);
    }

    private void Update()
    {
        updateGridTimer -= Time.deltaTime;
        if (updateGridTimer <= 0)
        {
            grid.UpdateCells();
            updateGridTimer = updateGridTime;
        }
    }

    public Vector2 GetGridCellSize()
    {
        return new Vector2(grid.CellWidth, grid.CellHeight);
    }

    private void OnDrawGizmos()
    {
        if (grid == null || !showGrid)
            return;

        GridCell cell = grid.Cells[0, 0];
        for (int x = 0; x < grid.Cells.GetLength(0); x++)
        {
            for (int y = 0; y < grid.Cells.GetLength(1); y++)
            {
                cell = grid.Cells[x, y];
                if (!cell.IsWalkable)
                    continue;
                Gizmos.color = (cell.IsGridEdge || cell.IsSpawnBlocked) ? Color.blue : (cell.IsWalkableEdge || cell.IsEnemySpawnable) ? Color.red : Color.white;
                Gizmos.DrawWireCube(cell.CenterWorldPosition, new Vector3(grid.CellWidth - 0.3f, 0, grid.CellHeight - 0.3f));
            }
        }
    }
}

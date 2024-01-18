using UnityEngine;
using DrewDev.GridSystem;

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

    [Header("Grid")]
    [SerializeField] bool showGrid;
    [SerializeField] private Vector2 gridSize;
    [SerializeField] private Vector2 cellSize;
    [Range(0.1f, 1f)][SerializeField] float updateGridTime;

    [Space(20)]
    [Header("Gizmos")]
    [SerializeField] private Color walkableColor = Color.white;
    [SerializeField] private Color walkableEdgeOrEnemySpawnerColor = Color.red;
    [SerializeField] private Color gridEdgeOrSpawnBlockedColor = Color.blue;
    [SerializeField] private float gizmosAlpha = 0.5f;

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
            //grid.UpdateCells();
            updateGridTimer = updateGridTime;
        }

        // DEBUG: For testing quickly
        if (Input.GetKeyDown(KeyCode.Alpha1))
            Time.timeScale = 1;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            Time.timeScale = 3;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            Time.timeScale = 6;
        if (Input.GetKeyDown(KeyCode.Alpha4))
            Time.timeScale = 10;
        if (Input.GetKeyDown(KeyCode.Alpha5))
            Time.timeScale = 20;
        // DEBUG: For testing quickly
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
                Color alphaChange = new Color(1, 1, 1, gizmosAlpha);
                if (cell.IsOccupied)
                    Gizmos.color = Color.yellow * alphaChange;
                else
                    Gizmos.color = ((cell.IsGridEdge || cell.IsSpawnBlocked) ? gridEdgeOrSpawnBlockedColor : (cell.IsWalkableEdge || cell.IsEnemySpawnable) ? walkableEdgeOrEnemySpawnerColor : walkableColor) * alphaChange;
                Gizmos.DrawWireCube(cell.CenterWorldPosition, new Vector3(grid.CellWidth - 0.3f, 0, grid.CellHeight - 0.3f));
            }
        }
    }
}

using UnityEngine;

namespace GridSystem
{
    public class MyGrid
    {
        public GridCell[,] Cells { get { return cells; } }

        public int GridWidth;
        public int GridHeight;
        public float CellWidth;
        public float CellHeight;

        private Vector3 gridStartingPosition => gridComponent.transform.position;

        private GridComponent gridComponent;
        private GridCell[,] cells;

        public MyGrid(int gridWidth, int gridHeight, float cellWidth, float cellHeight, GridComponent gridComponent)
        {
            GridWidth = gridWidth;
            GridHeight = gridHeight;
            CellWidth = cellWidth;
            CellHeight = cellHeight;
            this.gridComponent = gridComponent;

            cells = new GridCell[gridWidth, gridHeight];

            for (int x = 0; x < gridWidth; x++)
            {
                for (int y = 0; y < gridHeight; y++)
                {
                    Vector2 gridPosition = new Vector2(x, y);
                    GridCell cell = new GridCell(this, gridPosition);
                    cells[x, y] = cell;
                }
            }

            UpdateCells();
        }

        public GridCell GetCell(Vector3 worldPosition)
        {
            Vector2 gridPosition = WorldToGridPosition(worldPosition);
            return GetCell(gridPosition);
        }

        public GridCell GetCell(Vector2 gridPosition)
        {
            return cells[(int)gridPosition.x, (int)gridPosition.y];
        }

        public Vector2 WorldToGridPosition(Vector3 worldPosition)
        {
            Vector3 offsetWorldPosition = worldPosition - gridStartingPosition;
            float x = offsetWorldPosition.x / CellWidth;
            float y = offsetWorldPosition.z / CellHeight;
            return new Vector2(Mathf.FloorToInt(x), Mathf.FloorToInt(y));
        }

        public Vector3 GridToWorldPosition(Vector2 gridPosition)
        {
            float x = gridPosition.x * CellWidth;
            float y = gridPosition.y * CellHeight;
            return new Vector3(x, 0, y) + gridStartingPosition;
        }

        public void UpdateCells()
        {
            foreach (GridCell cell in cells)
            {
                cell.UpdateIsWalkable();
                cell.UpdateWalkableEdge();
                cell.UpdateSpawnBlocked();
                cell.UpdateIsEnemySpawnable();
            }
        }
    }
}
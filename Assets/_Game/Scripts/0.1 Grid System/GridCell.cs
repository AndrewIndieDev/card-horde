using UnityEngine;

namespace DrewDev.GridSystem
{
    public class GridCell
    {
        public Vector2 GridPosition { get; private set; }
        public Vector3 WorldPosition { get { return associatedGrid.GridToWorldPosition(GridPosition); } }
        public Vector3 CenterWorldPosition { get { return WorldPosition + new Vector3(associatedGrid.CellWidth / 2, 0, associatedGrid.CellHeight / 2); } }
        public float WalkWeight { get; }
        public bool IsWalkable { get; set; }
        public bool IsWalkableEdge { get; set; }
        public bool IsGridEdge { get { return GridPosition.x == 0 || GridPosition.x == associatedGrid.GridWidth - 1 || GridPosition.y == 0 || GridPosition.y == associatedGrid.GridHeight - 1; } }
        public bool IsSpawnBlocked { get; private set; }
        public bool IsEnemySpawnable { get; private set; }
        public bool IsOccupied { get { return Occupier != null; } }

        public IGridCellOccupier Occupier { get { return occupier; } set { occupier = value; } }
        private IGridCellOccupier occupier;

        private MyGrid associatedGrid;

        public GridCell(MyGrid associatedGrid, Vector2 gridPosition)
        {
            this.associatedGrid = associatedGrid;
            GridPosition = gridPosition;
        }

        public void UpdateIsWalkable()
        {
            IsWalkable = Physics.Raycast(CenterWorldPosition + Vector3.up * 100, Vector3.down, 110, LayerMask.GetMask("Walkable"));
        }

        public void UpdateIsEnemySpawnable()
        {
            IsEnemySpawnable = Physics.Raycast(CenterWorldPosition + Vector3.up * 100, Vector3.down, 110, LayerMask.GetMask("EnemySpawn"));
        }

        public void UpdateWalkableEdge()
        {
            bool isEdge = false;
            for (int x = -1; x <= 1; x++)
            {
                if (isEdge)
                    break;

                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                        continue;

                    Vector2 neighborGridPosition = GridPosition + new Vector2(x, y);
                    if (!associatedGrid.WithinGrid(neighborGridPosition))
                    {
                        isEdge = true;
                        break;
                    }

                    GridCell neighborCell = associatedGrid.GetCell(neighborGridPosition);
                    if (!neighborCell.IsWalkable)
                    {
                        isEdge = true;
                        break;
                    }
                }
            }

            IsWalkableEdge = isEdge;
        }

        public void UpdateSpawnBlocked()
        {
            IsSpawnBlocked = Physics.Raycast(CenterWorldPosition + Vector3.up * 100, Vector3.down, out RaycastHit hit, 110, LayerMask.GetMask("SpawnBlocked"));
        }

        public void SetOccupier(Card card)
        {
            Occupier = card;
        }

        public void ClearOccupier()
        {
            Occupier = null;
        }
    }
}
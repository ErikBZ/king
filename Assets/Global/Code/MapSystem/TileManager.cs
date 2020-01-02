using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Tilemaps;
using King.UnitSystem;
using King.MapSystem.Tiles;

namespace King.MapSystem
{
    public class TileManager : MonoBehaviour
    {
        // wrapper class for Vector3Int and Step
        private class MoveStepBundle
        {
            // How far the unit has moved for this tile
            public int Step;
            public Vector3Int Point;

            public MoveStepBundle(int step, Vector3Int point)
            {
                Step = step;
                Point = point;
            }
        }

        public Tilemap tilemap;
        Dictionary<Vector3Int, TileState> tileStates;

        private void Awake()
        {
            tileStates = InitTileState();
        }

        public bool TryGetTilePoint(Vector3 mousePos, out Vector3Int tilePoint)
        {
            var point = Camera.main.ScreenToWorldPoint(mousePos);
            var boardPoint = new Vector3Int(Mathf.FloorToInt(point.x), Mathf.FloorToInt(point.y), 0);
            bool tileFound = tilemap.HasTile(boardPoint);

            tilePoint = tilemap.HasTile(boardPoint) ? boardPoint : new Vector3Int(0, 0, 0);
            return tileFound;
        }

        public TileState GetTileState(Vector3Int point)
        {
            if (tileStates.ContainsKey(point))
            {
                return tileStates[point];
            }

            return null;
        }

        // this may need to go in start() instead of awake(). I'll experiment later
        private Dictionary<Vector3Int, TileState> InitTileState()
        {
            var states = new Dictionary<Vector3Int, TileState>();
            foreach (Vector3Int pos in tilemap.cellBounds.allPositionsWithin)
            {
                // why am i doing this?
                var local = new Vector3Int(pos.x, pos.y, pos.z);
                if (tilemap.HasTile(local))
                {
                    states.Add(local, new TileState());
                }
            }

            // get team starting positions here

            return states;
        }

        public List<Vector3Int> GetMoveRange(Vector3Int start, Unit unit)
        {
            Dictionary<Vector3Int, int> tileRangeCost = new Dictionary<Vector3Int, int>();
            Queue<MoveStepBundle> queue = new Queue<MoveStepBundle>();

            queue.Enqueue(new MoveStepBundle(0, start));
            tileRangeCost[start] = 0;

            // Not checking for unit move here since no points should be added once max move has been reached
            while (queue.Count != 0)
            {
                var stepBundle = queue.Dequeue();
                var point = stepBundle.Point;
                var step = stepBundle.Step;

                var adjPoints = GetValidMoveNeighbors(point, unit);
                foreach (Vector3Int adjPoint in adjPoints)
                {
                    // every tile costs at least 1 to move
                    var adjPointStep = step + 1 + ((MapTile)tilemap.GetTile(adjPoint)).AdditionalMoveCost;
                    if (adjPointStep <= unit.MaxMove ||
                        (tileRangeCost.ContainsKey(adjPoint) && tileRangeCost[adjPoint] > step))
                    {
                        queue.Enqueue(new MoveStepBundle(adjPointStep, adjPoint));
                        tileRangeCost[adjPoint] = adjPointStep;
                    }
                }
            }

            return tileRangeCost.Keys.ToList();
        }

        // this should check if a unit can traverse a tile, or if there's an enemy unit
        private List<Vector3Int> GetValidMoveNeighbors(Vector3Int point, Unit unit)
        {
            Vector3Int[] adjacentPoints = new Vector3Int[]
            {
            new Vector3Int(point.x + 1, point.y, point.z),
            new Vector3Int(point.x - 1, point.y, point.z),
            new Vector3Int(point.x, point.y + 1, point.z),
            new Vector3Int(point.x, point.y - 1, point.z)
            };

            List<Vector3Int> neighbors = new List<Vector3Int>();
            foreach (Vector3Int adjacentPoint in adjacentPoints)
            {
                if (tilemap.HasTile(adjacentPoint) &&
                   // check if the unit is not blocked by an enemy
                   (tileStates[point].Unit == null || tileStates[point].Unit.Team == unit.Team) &&
                   // making sure that the unit can move on the tile
                   ((unit.MoveType & ((MapTile)tilemap.GetTile(adjacentPoint)).MoveConstraints) != 0))
                {
                    neighbors.Add(adjacentPoint);
                }
            }

            return neighbors;
        }
    }
}

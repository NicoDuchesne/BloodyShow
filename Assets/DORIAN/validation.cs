using System.Collections.Generic;
using UnityEngine;

public class PathValidator : MonoBehaviour
{
    [SerializeField] public Tile[,] grid; // Grille 2D des tuiles
    public Vector2Int startPoint;
    public Vector2Int endPoint;

    // Vérifie si un chemin est valide
    public bool CheckPath()
    {
        Queue<Vector2Int> queue = new Queue<Vector2Int>();
        HashSet<Vector2Int> visited = new HashSet<Vector2Int>();

        queue.Enqueue(startPoint);
        visited.Add(startPoint);

        while (queue.Count > 0)
        {
            Vector2Int current = queue.Dequeue();
            if (current == endPoint)
                return true;

            Tile currentTile = grid[current.x, current.y];
            CheckAndAddNeighbor(current.x - 1, current.y, currentTile.connectLeft, queue, visited); // Gauche
            CheckAndAddNeighbor(current.x + 1, current.y, currentTile.connectRight, queue, visited); // Droite
            CheckAndAddNeighbor(current.x, current.y - 1, currentTile.connectDown, queue, visited); // Bas
            CheckAndAddNeighbor(current.x, current.y + 1, currentTile.connectUp, queue, visited); // Haut
        }

        return false; // Aucun chemin trouvé
    }

    // Vérifie les voisins et les ajoute à la file d'attente si valide
    private void CheckAndAddNeighbor(int x, int y, bool hasConnection, Queue<Vector2Int> queue, HashSet<Vector2Int> visited)
    {
        if (x >= 0 && x < grid.GetLength(0) && y >= 0 && y < grid.GetLength(1) && !visited.Contains(new Vector2Int(x, y)) && hasConnection)
        {
            queue.Enqueue(new Vector2Int(x, y));
            visited.Add(new Vector2Int(x, y));
        }
    }
}
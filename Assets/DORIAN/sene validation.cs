using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] public bool connectUp;
    [SerializeField] public bool connectDown;
    [SerializeField] public bool connectLeft;
    [SerializeField] public bool connectRight;

 

    // Peut �tre utile pour v�rifier la position et l'orientation de la tuile
    public Vector2Int position;

    public void SetConnections(bool up, bool down, bool left, bool right)
    {
        connectUp = up;
        connectDown = down;
        connectLeft = left;
        connectRight = right;
    }
}

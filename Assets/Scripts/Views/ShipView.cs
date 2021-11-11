using UnityEngine;
using Views.Enemies;

/// <summary>
/// Представление корабля.
/// </summary>
public class ShipView : View
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out EnemyView enemy))
        {
            Model.Destroy();
        }
    }
}

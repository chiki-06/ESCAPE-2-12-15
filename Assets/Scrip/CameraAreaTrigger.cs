using UnityEngine;

public class CameraAreaTrigger : MonoBehaviour
{
    [SerializeField] private int IndexCamara;
    [SerializeField] private Transform PlayerSpawn;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CameraPositionManager camManager = Object.FindFirstObjectByType<CameraPositionManager>();
            if (camManager != null)
            {
                // 👇 Ahora le pasamos también la referencia del jugador
                camManager.SetCameraPosition(IndexCamara, other.transform);
            }

            // Opcional: mover al jugador al punto de spawn
            if (PlayerSpawn != null)
            {
                other.transform.position = PlayerSpawn.position;
                other.transform.rotation = PlayerSpawn.rotation;
            }
        }
    }
}

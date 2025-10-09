using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class CameraPositionManager : MonoBehaviour
{
    [SerializeField] private List<Transform> PosicionCamara = new List<Transform>();
    [SerializeField] private float CambioVelocidad = 2f; // Puedes ignorar esto ahora.

    private Transform jugador; // Guardamos la referencia del jugador.

    void Start()
    {
        // Opcional: Coloca la cámara en la primera posición al inicio.
        if (PosicionCamara.Count > 0)
        {
            // Solo posiciona, la rotación inicial se maneja en Update si hay jugador.
            transform.position = PosicionCamara[0].position;
        }
    }

    void Update()
    {
        // 🚨 CLAVE: Si tenemos un jugador, la cámara siempre lo mira.
        // Esto mantiene la cámara "fija" en su posición pero con la rotación 
        // siguiendo al jugador, manteniendo el encuadre.
        if (jugador != null)
        {
            // La cámara rota instantáneamente para mirar al jugador.
            transform.LookAt(jugador);
        }
        // Nota: Ya no hay Lerp/Slerp aquí, por lo que no hay transiciones.
    }

    // Se llama desde CameraAreaTrigger.
    public void SetCameraPosition(int index, Transform jugadorRef)
    {
        if (index >= 0 && index < PosicionCamara.Count)
        {
            // 1. Asigna la referencia del jugador
            jugador = jugadorRef;

            // 2. Mueve la cámara INSTANTÁNEAMENTE a la nueva posición
            transform.position = PosicionCamara[index].position;

            // 3. Opcional: Asegúrate de que mire inmediatamente al jugador
            // (Aunque Update() lo hace en el siguiente frame, esto es inmediato).
            if (jugador != null)
            {
                transform.LookAt(jugador);
            }
        }
    }
}

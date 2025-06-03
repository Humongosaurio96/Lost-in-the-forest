using UnityEngine;
using UnityEngine.SceneManagement; // Importa el namespace para la gestión de escenas

public class CambiarEscena : MonoBehaviour
{
    // Nombre de la escena a la que cambiar
    public string nombreEscena;

    void Update()
    {
        // Detecta si el jugador presiona una tecla (por ejemplo, la tecla "R")
        if (Input.GetKeyDown(KeyCode.R)) 
        {
            CargarEscena();
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CargarEscena();
        }
    }
    // Método para cargar la escena
    public void CargarEscena()
    {
        // Cambia a la escena especificada
        SceneManager.LoadScene(nombreEscena);
    }
}

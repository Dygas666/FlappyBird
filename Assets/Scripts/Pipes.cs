using UnityEngine; // Importuje przestrzeń nazw UnityEngine

public class Pipes : MonoBehaviour // Deklaracja klasy Pipes dziedziczącej po MonoBehaviour
{
    public float speed = 5f; // Deklaracja publicznego pola typu float z domyślną wartością 5

    private float leftEdge; // Deklaracja prywatnego pola typu float

    private void Start() // Metoda wywoływana przy uruchomieniu skryptu
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 1f; // Ustalenie lewej krawędzi ekranu w jednostkach świata
    }

    private void Update() // Metoda wywoływana co klatkę
    {
        transform.position += Vector3.left * speed * Time.deltaTime; // Przesunięcie obiektu w lewo

        if (transform.position.x < leftEdge) { // Sprawdzenie, czy obiekt jest poza lewą krawędzią ekranu
            Destroy(gameObject); // Zniszczenie obiektu
        }
    }

}

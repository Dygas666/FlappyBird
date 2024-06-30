using UnityEngine; // Importuje przestrzeń nazw UnityEngine

public class Spawner : MonoBehaviour // Deklaracja klasy Spawner dziedziczącej po MonoBehaviour
{
    public GameObject prefab; // Deklaracja publicznego pola typu GameObject
    public float spawnRate = 1f; // Deklaracja publicznego pola typu float z domyślną wartością 1
    public float minHeight = -1f; // Deklaracja publicznego pola typu float z domyślną wartością -1
    public float maxHeight = 2f; // Deklaracja publicznego pola typu float z domyślną wartością 2

    private void OnEnable() // Metoda wywoływana przy włączeniu obiektu
    {
        InvokeRepeating(nameof(Spawn), spawnRate, spawnRate); // Regularne wywoływanie metody Spawn
    }

    private void OnDisable() // Metoda wywoływana przy wyłączeniu obiektu
    {
        CancelInvoke(nameof(Spawn)); // Anulowanie regularnego wywoływania metody Spawn
    }

    private void Spawn() // Metoda tworząca nowe obiekty
    {
        GameObject pipes = Instantiate(prefab, transform.position, Quaternion.identity); // Utworzenie nowego obiektu prefab
        pipes.transform.position += Vector3.up * Random.Range(minHeight, maxHeight); // Przesunięcie obiektu w pionie o losową wartość
    }

}

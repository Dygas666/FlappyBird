using UnityEngine; // Importuje przestrzeń nazw UnityEngine

public class Parallax : MonoBehaviour // Deklaracja klasy Parallax dziedziczącej po MonoBehaviour
{
    public float animationSpeed = 1f; // Deklaracja publicznego pola typu float z domyślną wartością 1
    private MeshRenderer meshRenderer; // Deklaracja prywatnego pola typu MeshRenderer

    private void Awake() // Metoda wywoływana przy uruchomieniu skryptu
    {
        meshRenderer = GetComponent<MeshRenderer>(); // Pobranie komponentu MeshRenderer
    }

    private void Update() // Metoda wywoływana co klatkę
    {
        meshRenderer.material.mainTextureOffset += new Vector2(animationSpeed * Time.deltaTime, 0); // Przesunięcie tekstury w osi X
    }

}

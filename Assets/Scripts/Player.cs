using UnityEngine; // Importuje przestrzeń nazw UnityEngine

public class Player : MonoBehaviour // Deklaracja klasy Player dziedziczącej po MonoBehaviour
{
    private SpriteRenderer spriteRenderer; // Deklaracja prywatnego pola typu SpriteRenderer
    public Sprite[] sprites; // Deklaracja publicznego pola tablicy typu Sprite
    private int spriteIndex; // Deklaracja prywatnego pola typu int
    private Vector3 direction; // Deklaracja prywatnego pola typu Vector3
    public float gravity = -9.8f; // Deklaracja publicznego pola typu float z domyślną wartością -9.8
    public float strength = 5f; // Deklaracja publicznego pola typu float z domyślną wartością 5

    private void Awake() // Metoda wywoływana przy uruchomieniu skryptu
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); // Pobranie komponentu SpriteRenderer
    }

    private void Start() // Metoda wywoływana na początku
    {
        InvokeRepeating(nameof(AnimateSprite), 0.15f, 0.15f); // Regularne wywoływanie metody AnimateSprite
    }

    private void OnEnable() // Metoda wywoływana przy włączeniu obiektu
    {
        Vector3 position = transform.position; // Pobranie pozycji obiektu
        position.y = 0f; // Ustawienie pozycji y na 0
        transform.position = position; // Ustawienie nowej pozycji obiektu
        direction = Vector3.up * strength; // Ustawienie kierunku ruchu w górę
    }

    private void Update() // Metoda wywoływana co klatkę
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) // Sprawdzenie, czy naciśnięto spację lub lewy przycisk myszy
        {
            direction = Vector3.up * strength; // Ustawienie kierunku ruchu w górę
        }

        if (Input.touchCount > 0) // Sprawdzenie, czy jest jakikolwiek dotyk
        {
            Touch touch = Input.GetTouch(0); // Pobranie pierwszego dotyku

            if (touch.phase == TouchPhase.Began) // Sprawdzenie, czy dotyk się rozpoczął
            {
                direction = Vector3.up * strength; // Ustawienie kierunku ruchu w górę
            }
        }

        direction.y += gravity * Time.deltaTime; // Dodanie grawitacji do kierunku ruchu
        transform.position += direction * Time.deltaTime; // Aktualizacja pozycji obiektu
    }

    private void AnimateSprite() // Metoda animująca sprite
    {
        spriteIndex++; // Zwiększenie indeksu sprite
        if (spriteIndex >= sprites.Length) // Sprawdzenie, czy indeks nie przekracza długości tablicy sprite
        {
            spriteIndex = 0; // Resetowanie indeksu
        }
        spriteRenderer.sprite = sprites[spriteIndex]; // Ustawienie nowego sprite
    }

    private void OnTriggerEnter2D(Collider2D other) // Metoda wywoływana przy kolizji 2D
    {
        if (other.gameObject.tag == "Obstacle") // Sprawdzenie, czy obiekt ma tag "Obstacle"
        {
            FindObjectOfType<GameManager>().GameOver(); // Wywołanie metody GameOver w GameManager
        }
        else if (other.gameObject.tag == "Scoring") // Sprawdzenie, czy obiekt ma tag "Scoring"
        {
            FindObjectOfType<GameManager>().IncreaseScore(); // Wywołanie metody IncreaseScore w GameManager
        }
    }
}

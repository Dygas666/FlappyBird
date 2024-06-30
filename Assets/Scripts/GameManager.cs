using UnityEngine; // Importuje przestrzeń nazw UnityEngine
using UnityEngine.UI; // Importuje przestrzeń nazw UnityEngine.UI

public class GameManager : MonoBehaviour // Deklaracja klasy GameManager dziedziczącej po MonoBehaviour
{

    public Player player; // Deklaracja publicznego pola typu Player
    public Text scoreText; // Deklaracja publicznego pola typu Text
    public GameObject playButton; // Deklaracja publicznego pola typu GameObject
    public GameObject gameOver; // Deklaracja publicznego pola typu GameObject1

    private int score; // Deklaracja prywatnego pola typu int

    private void Awake() // Metoda wywoływana przy uruchomieniu skryptu
    {
        Application.targetFrameRate = 60; // Ustawienie maksymalnej liczby klatek na sekundę na 60
        Pause(); // Wywołanie metody Pause
    }

    public void Play() // Metoda publiczna Play
    {
        score = 0; // Zresetowanie wyniku na 0
        scoreText.text = score.ToString(); // Aktualizacja tekstu wyniku

        playButton.SetActive(false); // Ukrycie przycisku play
        gameOver.SetActive(false); // Ukrycie komunikatu game over

        Time.timeScale = 1f; // Wznowienie czasu gry
        player.enabled = true; // Włączenie sterowania graczem

        Pipes[] pipes = FindObjectsOfType<Pipes>(); // Znalezienie wszystkich obiektów typu Pipes

        for (int i = 0; i < pipes.Length; i++) { // Pętla przez wszystkie znalezione obiekty Pipes
            Destroy(pipes[i].gameObject); // Zniszczenie każdego obiektu Pipes
        }
    }

    public void Pause() // Metoda publiczna Pause
    {
        Time.timeScale = 0f; // Wstrzymanie czasu gry
        player.enabled = false; // Wyłączenie sterowania graczem
    }

    public void GameOver() // Metoda publiczna GameOver
    {
        gameOver.SetActive(true); // Wyświetlenie komunikatu game over
        playButton.SetActive(true); // Wyświetlenie przycisku play

        Pause(); // Wywołanie metody Pause
    }

    public void IncreaseScore() // Metoda publiczna IncreaseScore
    {
        score++; // Zwiększenie wyniku o 1
        scoreText.text = score.ToString(); // Aktualizacja tekstu wyniku
    }

}

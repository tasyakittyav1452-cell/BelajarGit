using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public GameObject tombolPlay;
    public GameObject panelGameOver;
    public Transform bola;

    // Variabel penting untuk membuka kunci pergerakan peluru
    public bool isGameActive = false;

    private Vector3 posisiAwalBola;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        if (bola != null) posisiAwalBola = bola.position;
        if (panelGameOver != null) panelGameOver.SetActive(false);
        if (tombolPlay != null) tombolPlay.SetActive(true);

        isGameActive = false; // Game belum mulai di awal
    }

    // Fungsi ini HARUS dipanggil oleh tombol PLAY di Canvas kamu
    public void GameDimulai()
    {
        if (tombolPlay != null) tombolPlay.SetActive(false);
        isGameActive = true; // Mengaktifkan pergerakan peluru!
    }

    public void TriggerGameOver()
    {
        if (panelGameOver != null) panelGameOver.SetActive(true);
        isGameActive = false;

        Rigidbody2D rb = bola.GetComponent<Rigidbody2D>();
        if (rb != null) rb.linearVelocity = Vector2.zero;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
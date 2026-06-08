using UnityEngine;

public class Bullet_1 : MonoBehaviour
{
    public float speed = 20f; // Kecepatan tinggi agar meluncur secepat bola
    public float lifeTime = 3f; // Peluru otomatis mati setelah 3 detik agar hemat memori
    private float timer;

    void OnEnable()
    {
        // Reset waktu hidup peluru setiap kali ditembakkan dari pool
        timer = lifeTime;
    }

    void Update()
    {
        // Kunci: Peluru hanya bergerak jika game sudah aktif setelah menekan tombol Play
        if (GameManager.instance == null || !GameManager.instance.isGameActive)
        {
            gameObject.SetActive(false);
            return;
        }

        // PERGERAKAN: Peluru meluncur lurus horizontal dari bawah ke ATAS (Vector2.up)
        transform.Translate(Vector2.up * speed * Time.deltaTime);

        // Hitung mundur untuk menyembunyikan peluru jika keluar dari layar atas
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            gameObject.SetActive(false);
        }
    }

    // DETEKSI TABRAKAN: Jika peluru mengenai Bola, memicu Game Over!
    void OnTriggerEnter2D(Collider2D collision)
    {
        // Pastikan objek bola kamu memiliki Tag bernama "Bola" di Inspector
        if (collision.CompareTag("Bola"))
        {
            gameObject.SetActive(false); // Sembunyikan pelurunya kembali ke pool

            // Panggil fungsi Game Over bawaan dari GameManager kamu!
            if (GameManager.instance != null)
            {
                GameManager.instance.TriggerGameOver();
            }
        }
    }
}
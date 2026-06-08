using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 10f;

    // Tambahkan variabel gerak bawaan paddle kamu di sini jika ada (seperti rigidBody/input)

    void Update()
    {
        // Kunci: Jangan bisa menembak sebelum game dimulai
        if (GameManager.instance == null || !GameManager.instance.isGameActive) return;

        // --- MASUKKAN KODINGAN GERAK PADDLE ATAS-BAWAH KAMU DI SINI ---
        // Biarkan logika pergerakan paddle lamamu tetap berada di sini agar bisa digerakkan


        // Kunci Tembak: Klik kiri mouse langsung memanggil fungsi Shoot() tanpa batas
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (ObjectPool.Instance != null)
        {
            GameObject bullet = ObjectPool.Instance.GetPooledObject();
            if (bullet != null)
            {
                // Mengatur posisi awal peluru tepat keluar dari koordinat paddle saat ini
                bullet.transform.position = transform.position;
                bullet.transform.rotation = Quaternion.identity;
                bullet.SetActive(true);
            }
        }
    }
}
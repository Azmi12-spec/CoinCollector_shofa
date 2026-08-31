using UnityEngine;

public class PenerimaEvent : MonoBehaviour
{
    private void Onenable()
    {
        PemancarEvent.SaatTombolDiTekan += Respon;
    }

    private void OnDisable()
    {
        PemancarEvent.SaatTombolDiTekan -= Respon;
    }

    void Respon ()
    {
        Debug.Log("Tombol Di Tekan");
    }
}

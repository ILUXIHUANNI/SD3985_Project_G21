using TMPro;
using UnityEngine;

public class DeathCount : MonoBehaviour
{
    [SerializeField] TMP_Text _textMeshPro;

    private void Start()
    {
        loadDeathCount();
    }

    void loadDeathCount()
    {
        SaveManager.instance.Load();
        _textMeshPro.text = SaveManager.instance.saveFile.deathCount.ToString();
    }
}

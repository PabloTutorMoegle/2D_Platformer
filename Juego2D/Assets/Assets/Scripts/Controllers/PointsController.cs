using TMPro;
using UnityEngine;

public class PointsController : MonoBehaviour
{
    [SerializeField] private PointsSystem _ps;
    [SerializeField] private TMP_Text _pointsText;

    private void OnEnable()
    {
        ConnectToPointsSystem();
    }

    private void ConnectToPointsSystem()
    {
        if (_ps != null)
        {
            _ps.OnPointsChanged -= UpdateScore;
        }

        PlayerController player = PlayerPersistence.PersistentPlayer;

        if (player == null)
        {
            player = FindFirstObjectByType<PlayerController>();
        }

        if (player != null)
        {
            _ps = player.GetComponent<PointsSystem>();
        }

        if (_ps != null)
        {
            _ps.OnPointsChanged += UpdateScore;

            UpdateScore(_ps.GetPoints());
        }
        else
        {
            Debug.Log("Error");
        }
    }

    private void OnDisable()
    {
        if (_ps != null)
        {
            _ps.OnPointsChanged -= UpdateScore;
        }
    }

    private void UpdateScore(float points)
    {
        if (_pointsText != null)
        {
            _pointsText.text = points.ToString();
        }
    }
}
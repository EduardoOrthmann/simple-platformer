using Core.Shared;
using TMPro;
using UnityEngine;

namespace Presentation.UI
{
    public class HUDView : MonoBehaviour, IHUDView
    {
        [SerializeField] private TextMeshProUGUI _scoreText;
        // ... other UI elements like a health slider

        public void SetScore(int score)
        {
            _scoreText.text = $"Score: {score}";
        }

        public void SetHealth(int current, int max)
        {
            // Logic to update a health slider
        }
    }
}
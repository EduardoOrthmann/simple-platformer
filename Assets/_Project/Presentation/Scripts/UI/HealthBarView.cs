using UnityEngine;

namespace _Project.Presentation.Scripts.UI
{
    public class HealthBarView : MonoBehaviour
    {
        [SerializeField] private RectTransform fillTransform;

        private float _maxWidth;

        private void Awake()
        {
            _maxWidth = fillTransform.sizeDelta.x;
        }

        public void SetHealthFraction(float fraction)
        {
            var size = fillTransform.sizeDelta;
            size.x = _maxWidth * Mathf.Clamp01(fraction);
            fillTransform.sizeDelta = size;
        }
    }
}
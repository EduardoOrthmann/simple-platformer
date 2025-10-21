using Core.Domain;
using Core.Shared;
using Zenject;

namespace Presentation.ViewModels
{
    public class HUDPresenter
    {
        private readonly IHUDView _view;
        private readonly ScoreManager _scoreManager;

        public HUDPresenter(IHUDView view, ScoreManager scoreManager, SignalBus signalBus)
        {
            _view = view;
            _scoreManager = scoreManager;

            // Subscribe to events to update the UI
            // signalBus.Subscribe<ScoreUpdatedSignal>(OnScoreUpdated);

            // Initialize UI
            OnScoreUpdated();
        }

        private void OnScoreUpdated()
        {
            // _view.SetScore(_scoreManager.CurrentScore);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using _Project.Application.Interfaces;
using _Project.Application.States.GameStates;

namespace _Project.Application.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IGameState> _states;
        private IGameState _currentState;

        public GameStateMachine(List<IGameState> states)
        {
            _states = states.ToDictionary(s => s.GetType(), s => s);
        }

        public void ChangeState(Type newStateType)
        {
            _currentState?.Exit();
            _currentState = _states[newStateType];
            _currentState.Enter();
        }

        public void TogglePause()
        {
            ChangeState(_currentState switch
            {
                PlayingState => typeof(PausedState),
                PausedState => typeof(PlayingState),
                _ => throw new ArgumentOutOfRangeException()
            });
        }
    }
}
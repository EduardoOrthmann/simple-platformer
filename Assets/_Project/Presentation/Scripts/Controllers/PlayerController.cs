using _Project.Application.Commands;
using _Project.Application.States;
using _Project.Application.UseCases;
using _Project.Domain.Entities;
using UnityEngine;
using Zenject;

namespace _Project.Presentation.Scripts.Controllers
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerInputState _input;
        private PlayerUseCase _useCase;
        private Rigidbody2D _rb;
        private SpriteRenderer _spriteRenderer;

        private CommandProcessor _commandProcessor;
        private MoveCommand.Factory _moveFactory;
        private JumpCommand.Factory _jumpFactory;

        private const float FlipThreshold = 0.01f;

        [Inject]
        public void Construct(
            PlayerInputState input,
            PlayerUseCase useCase,
            PlayerData playerData,
            CommandProcessor commandProcessor,
            MoveCommand.Factory moveFactory,
            JumpCommand.Factory jumpFactory)
        {
            _input = input;
            _useCase = useCase;
            _commandProcessor = commandProcessor;
            _moveFactory = moveFactory;
            _jumpFactory = jumpFactory;
        }

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        private void FixedUpdate()
        {
            ExecuteCommand(CreateMoveCommand());

            UpdateSpriteFacing(_input.Move.x);

            HandleJumpInput();

            _useCase.UpdateJumpAndFallState(_rb);
        }

        private ICommand CreateMoveCommand() =>
            _moveFactory.Create(transform, _input.Move);

        private ICommand CreateJumpCommand() =>
            _jumpFactory.Create(_rb);

        private void ExecuteCommand(ICommand command)
        {
            if (command == null) return;
            _commandProcessor.ExecuteCommand(command);
        }

        private void HandleJumpInput()
        {
            if (!_input.JumpPressed) return;
            ExecuteCommand(CreateJumpCommand());
            _input.JumpPressed = false;
        }

        private void UpdateSpriteFacing(float moveX)
        {
            if (Mathf.Abs(moveX) <= FlipThreshold) return;
            _spriteRenderer.flipX = moveX < 0f;
        }

    }
}
using _Project.Core.Application.Facades;
using _Project.Core.Application.Services;
using _Project.Core.Domain.Components;
using _Project.Core.Domain.Entities;
using _Project.Core.Infrastructure;
using _Project.Presentation.Components;
using UnityEngine;
using Zenject;

namespace _Project.Presentation.Actors
{
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(PlayerInputReader))]
    public class PlayerActor : MonoBehaviour
    {
        [SerializeField] private MovementData playerMovementData;
        [SerializeField] private HealthData playerHealthData;

        private PlayerFacade _facade;

        [Inject]
        private void Construct(PlayerEntity.Factory entityFactory, MovementService movement, HealthService health, PlayerInputState input)
        {
            var entity = entityFactory.Create(playerMovementData, playerHealthData);

            _facade = new PlayerFacade(
                entity,
                input,
                movement,
                health,
                GetComponent<Rigidbody2D>()
            );
        }

        private void FixedUpdate()
        {
            _facade.FixedTick();
        }
    }
}
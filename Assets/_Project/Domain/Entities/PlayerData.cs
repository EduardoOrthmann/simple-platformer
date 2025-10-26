using UnityEngine;

namespace _Project.Domain.Entities
{
    [CreateAssetMenu(menuName = "Data/PlayerData")]
    public class PlayerData : ScriptableObject
    {
        public float speed = 5f;
        public float jumpForce = 8f;
    }
}
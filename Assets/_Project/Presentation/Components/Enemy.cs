using UnityEngine;
using Zenject;

namespace _Project.Presentation.Components
{
    public class Enemy : MonoBehaviour
    {
        // This is boilerplate for a Zenject factory
        public class Factory : PlaceholderFactory<Enemy> { }
    }
}
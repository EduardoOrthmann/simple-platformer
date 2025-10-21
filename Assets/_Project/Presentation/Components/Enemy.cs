using UnityEngine;
using Zenject;

namespace Presentation.Components
{
    public class Enemy : MonoBehaviour
    {
        // This is boilerplate for a Zenject factory
        public class Factory : PlaceholderFactory<Enemy> { }
    }
}
using System;
using System.Threading.Tasks;
using Core;
using Input;
using Platform;
using UnityEngine;

namespace Services
{
    public class InputService : Service
    {
        public event Action ShootEvent;
        public event Action<Vector2> RunEvent;
    
        private PlayerInput _playerInput;
        private PlayerInput.PlayerActions _playerActions;
        
        public override Task InitializeServiceAsync()
        {
            _playerInput = new PlayerInput();
            _playerActions = _playerInput.Player;
            _playerInput.Enable();

            Engine.Behaviour.BehaviourUpdateEvent += OnUpdate;
            
            return Task.CompletedTask;
        }

        public override void ResetService()
        {
        }

        public override void DestroyService()
        {
            _playerInput.Disable();
        }

        private void OnUpdate()
        {
            if (_playerActions.Shoot.triggered)
            {
                ShootEvent?.Invoke();
            }
        
            RunEvent?.Invoke(_playerActions.Run.ReadValue<Vector2>());
        }
    }
}
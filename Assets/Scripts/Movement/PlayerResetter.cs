using System;
using GameEvents.Game;
using GameEvents.Generic;
using UnityEngine;

namespace DefaultNamespace.Movement
{
    public class PlayerResetter : MonoBehaviour, IGameEventListener
    {
        public GameEvent resetLevel;
        public Vector3 startingPosition;
        public Quaternion startingRotation;

        private void Awake()
        {
            resetLevel.RegisterListener(this);
        }

        private void Start()
        {
            startingPosition = transform.position;
            startingRotation = transform.rotation;
        }

        public void RaiseGameEvent()
        {
            transform.position = startingPosition;
            transform.rotation = startingRotation;
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            GetComponent<Rigidbody2D>().angularVelocity = 0f;
            GetComponent<PlayerMovement>().StopMovement();
            GetComponent<Collider2D>().enabled = true;
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
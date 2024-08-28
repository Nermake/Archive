﻿using System;
using System.Collections;
using UnityEngine;

namespace Mori.Patterns.DesignPattern.ObjectPool.Example
{
    public class Unit : MonoBehaviour
    {
        [SerializeField] private float _lifeTime = 2f;

        private void OnEnable() => StartCoroutine(nameof(LifeRoutine));

        private void OnDisable() => StopCoroutine(nameof(LifeRoutine));

        private IEnumerator LifeRoutine()
        {
            yield return new WaitForSecondsRealtime(_lifeTime);
            
            Deactivate();
        }

        private void Deactivate() => gameObject.SetActive(false);
    }
}
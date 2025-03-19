using System;
using ScarFramework.UI;
using UnityEngine;

namespace MergeGame.UI
{
    public class LoadingScreen : UIScreen
    {
        [SerializeField] private RectTransform loadingIndicator;
        [SerializeField] private float rotationSpeed = 10f;

        private void Update()
        {
            loadingIndicator.Rotate(loadingIndicator.forward, rotationSpeed * Time.deltaTime);
        }
     
    }
}
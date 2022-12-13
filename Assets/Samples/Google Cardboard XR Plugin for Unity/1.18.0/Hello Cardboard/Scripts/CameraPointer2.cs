//-----------------------------------------------------------------------
// <copyright file="CameraPointer.cs" company="Google LLC">
// Copyright 2020 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// </copyright>
//-----------------------------------------------------------------------

using System.Collections;
using UnityEngine;
using Unity.Profiling;
using System.Text;

/// <summary>
/// Sends messages to gazed GameObject.
/// </summary>
public class CameraPointer2 : MonoBehaviour
{
    public TMPro.TextMeshProUGUI statOverlay;
    private const float _maxDistance = 10;
    private GameObject _gazedAtObject = null;
    public double count = 0.0f;
    public double fps = 0.0;
    public double fps2 = 0.0;
    public int framesCount = 0;
    private float framesTime = 0, lastFPS;
    public double timeCount = 0.0f;

    /// <summary>
    /// Update is called once per frame.
    /// </summary>
    public void Await()
    {
        
    }
    public void Start()
    {

    }
    public void Update()
    {

        // Casts ray towards camera's forward direction, to detect if a GameObject is being gazed
        // at.
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _maxDistance))
        {
            // GameObject detected in front of the camera.
            if (_gazedAtObject != hit.transform.gameObject)
            {
                // New GameObject.
                _gazedAtObject?.SendMessage("OnPointerExit");
                _gazedAtObject = hit.transform.gameObject;
                _gazedAtObject.SendMessage("OnPointerEnter");
            }
        }
        else
        {
            // No GameObject detected in front of the camera.
            _gazedAtObject?.SendMessage("OnPointerExit");
            _gazedAtObject = null;
        }
        //movecar2.test();
        // Checks for screen touches.
        if (Google.XR.Cardboard.Api.IsTriggerPressed)
        {
            _gazedAtObject?.SendMessage("OnPointerClick");
        }
    }
}

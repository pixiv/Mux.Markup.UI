// Copyright 2019 pixiv Inc.
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

using Xamarin.Forms;

namespace Mux.Markup
{
    /// <summary>A <see cref="Behaviour{T}" /> that represents <see cref="T:UnityEngine.EventSystems.EventSystem" />.</summary>
    public class EventSystem : Behaviour<UnityEngine.EventSystems.EventSystem>
    {
        /// <summary>Backing store for the <see cref="FirstSelectedGameObject" /> property.</summary>
        public static readonly BindableProperty FirstSelectedGameObjectProperty = CreateBindableBodyProperty<UnityEngine.GameObject>(
            "FirstSelectedGameObject",
            typeof(EventSystem),
            (body, value) => body.firstSelectedGameObject = value);

        /// <summary>Backing store for the <see cref="SendNavigationEvents" /> property.</summary>
        public static readonly BindableProperty SendNavigationEventsProperty = CreateBindableBodyProperty<bool>(
            "SendNavigationEvents",
            typeof(EventSystem),
            (body, value) => body.sendNavigationEvents = value,
            true);

        /// <summary>Backing store for the <see cref="PixelDragThreshold" /> property.</summary>
        public static readonly BindableProperty PixelDragThresholdProperty = CreateBindableBodyProperty<int>(
            "PixelDragThreshold",
            typeof(EventSystem),
            (body, value) => body.pixelDragThreshold = value,
            10);

        /// <summary>A property that represents <see cref="P:UnityEngine.EventSystems.EventSystem.firstSelectedGameObject" />.</summary>
        public UnityEngine.GameObject FirstSelectedGameObject
        {
            get
            {
                return (UnityEngine.GameObject)GetValue(FirstSelectedGameObjectProperty);
            }

            set
            {
                SetValue(FirstSelectedGameObjectProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.EventSystems.EventSystem.sendNavigationEvents" />.</summary>
        public bool SendNavigationEvents
        {
            get
            {
                return (bool)GetValue(SendNavigationEventsProperty);
            }

            set
            {
                SetValue(SendNavigationEventsProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.EventSystems.EventSystem.pixelDragThreshold" />.</summary>
        public int PixelDragThreshold
        {
            get
            {
                return (int)GetValue(PixelDragThresholdProperty);
            }

            set
            {
                SetValue(PixelDragThresholdProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.firstSelectedGameObject = FirstSelectedGameObject;
            Body.sendNavigationEvents = SendNavigationEvents;
            Body.pixelDragThreshold = PixelDragThreshold;

            base.AwakeInMainThread();
        }
    }
}

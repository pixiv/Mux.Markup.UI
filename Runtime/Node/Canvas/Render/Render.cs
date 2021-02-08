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

using System;
using Xamarin.Forms;

namespace Mux.Markup
{
    /// <summary>
    /// An abstract class that represents rendering properties of <see cref="T:UnityEngine.Canvas" />.
    /// </summary>
    public abstract class Render : Canvas.Modifier
    {
        /// <summary>Backing store for the <see cref="SortingOrder" /> property.</summary>
        public static readonly BindableProperty SortingOrderProperty = BindableProperty.Create(
            "SortingOrder",
            typeof(int),
            typeof(Render),
            0,
            BindingMode.OneWay,
            null,
            OnSortingOrderChanged);

        /// <summary>Backing store for the <see cref="OverrideSorting" /> property.</summary>
        public static readonly BindableProperty OverrideSortingProperty = BindableProperty.Create(
            "OverrideSorting",
            typeof(bool),
            typeof(Render),
            false,
            BindingMode.OneWay,
            null,
            OnOverrideSortingChanged);

        /// <summary>Backing store for the <see cref="TargetDisplay" /> property.</summary>
        public static readonly BindableProperty TargetDisplayProperty = BindableProperty.Create(
            "TargetDisplay",
            typeof(int),
            typeof(Render),
            0,
            BindingMode.OneWay,
            null,
            OnTargetDisplayChanged);

        private static void OnPixelPerfectChanged(BindableObject sender, object oldValue, object newValue)
        {
            var body = ((Render)sender).Body;

            if (body != null)
            {
                Forms.mainThread.Send(state => body.pixelPerfect = (bool)state, newValue);
            }
        }

        private static void OnOverridePixelPerfectChanged(BindableObject sender, object oldValue, object newValue)
        {
            var body = ((Render)sender).Body;

            if (body != null)
            {
                Forms.mainThread.Send(state => body.overridePixelPerfect = (bool)state, newValue);
            }
        }

        private static void OnWorldCameraChanged(BindableObject sender, object oldValue, object newValue)
        {
            var body = ((Render)sender).Body;

            if (body != null)
            {
                Forms.mainThread.Send(state => body.worldCamera = (UnityEngine.Camera)state, newValue);
            }
        }

        private static void OnPlaneDistanceChanged(BindableObject sender, object oldValue, object newValue)
        {
            var body = ((Render)sender).Body;

            if (body != null)
            {
                Forms.mainThread.Send(state => body.planeDistance = (float)state, newValue);
            }
        }

        private static void OnSortingLayerChanged(BindableObject sender, object oldValue, object newValue)
        {
            var body = ((Render)sender).Body;

            if (body != null)
            {
                Forms.mainThread.Send(state => body.sortingLayerID = (int)state, newValue);
            }
        }

        private static void OnSortingOrderChanged(BindableObject sender, object oldValue, object newValue)
        {
            var body = ((Render)sender).Body;

            if (body != null)
            {
                Forms.mainThread.Send(state => body.sortingOrder = (int)state, newValue);
            }
        }

        private static void OnOverrideSortingChanged(BindableObject sender, object oldValue, object newValue)
        {
            var body = ((Render)sender).Body;

            if (body != null)
            {
                Forms.mainThread.Send(state => body.overrideSorting = (bool)state, newValue);
            }
        }

        private static void OnTargetDisplayChanged(BindableObject sender, object oldValue, object newValue)
        {
            var body = ((Render)sender).Body;

            if (body != null)
            {
                Forms.mainThread.Send(state => body.targetDisplay = (int)state, newValue);
            }
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BindableProperty" /> class
        /// that represents <see cref="P:UnityEngine.Canvas.pixelPerfect" />.
        /// </summary>
        protected static BindableProperty CreateBindablePixelPerfectProperty(Type declarer)
        {
            return BindableProperty.Create(
                "PixelPerfect",
                typeof(bool),
                declarer,
                false,
                BindingMode.OneWay,
                null,
                OnPixelPerfectChanged);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BindableProperty" /> class
        /// that represents <see cref="P:UnityEngine.Canvas.overridePixelPerfect" />.
        /// </summary>
        protected static BindableProperty CreateBindableOverridePixelPerfectProperty(Type declarer)
        {
            return BindableProperty.Create(
                "OverridePixelPerfect",
                typeof(bool),
                declarer,
                false,
                BindingMode.OneWay,
                null,
                OnOverridePixelPerfectChanged);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BindableProperty" /> class
        /// that represents <see cref="P:UnityEngine.Canvas.worldCamera" />.
        /// </summary>
        protected static BindableProperty CreateBindableWorldCameraProperty(Type declarer)
        {
            return BindableProperty.Create(
                "WorldCamera",
                typeof(UnityEngine.Camera),
                declarer,
                null,
                BindingMode.OneWay,
                null,
                OnWorldCameraChanged);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BindableProperty" /> class
        /// that represents <see cref="P:UnityEngine.Canvas.planeDistance" />.
        /// </summary>
        protected static BindableProperty CreateBindablePlaneDistanceProperty(Type declarer)
        {
            return BindableProperty.Create(
                "PlaneDistance",
                typeof(float),
                declarer,
                100f,
                BindingMode.OneWay,
                null,
                OnPlaneDistanceChanged);
        }

        /// <summary>
        /// Creates a new instance of the <see cref="BindableProperty" /> class
        /// that represents <see cref="P:UnityEngine.Canvas.sortingLayerID" />.
        /// </summary>
        protected static BindableProperty CreateBindableSortingLayerProperty(Type declarer)
        {
            return BindableProperty.Create(
                "SortingLayer",
                typeof(int),
                declarer,
                0,
                BindingMode.OneWay,
                null,
                OnSortingLayerChanged);
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.Canvas.sortingOrder" />.</summary>
        public int SortingOrder
        {
            get
            {
                return (int)GetValue(SortingOrderProperty);
            }

            set
            {
                SetValue(SortingOrderProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.Canvas.overrideSorting" />.</summary>
        public bool OverrideSorting
        {
            get
            {
                return (bool)GetValue(OverrideSortingProperty);
            }

            set
            {
                SetValue(OverrideSortingProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.Canvas.targetDisplay" />.</summary>
        public int TargetDisplay
        {
            get
            {
                return (int)GetValue(TargetDisplayProperty);
            }

            set
            {
                SetValue(TargetDisplayProperty, value);
            }
        }

        internal abstract UnityEngine.RenderMode Mode { get; }

        /// <inheritdoc />
        protected override void InitializeBodyInMainThread()
        {
            Body.overrideSorting = OverrideSorting;
            Body.sortingOrder = SortingOrder;
            Body.targetDisplay = TargetDisplay;
        }
    }
}

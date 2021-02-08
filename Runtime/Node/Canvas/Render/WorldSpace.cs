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
    /// <summary>
    /// A class that represents <see cref="T:UnityEngine.RenderMode.WorldSpace" />
    /// and its rendering properties.
    /// </summary>
    public class WorldSpace : Render
    {
        /// <summary>Backing store for the <see cref="WorldCamera" /> property.</summary>
        public static readonly BindableProperty WorldCameraProperty =
            CreateBindableWorldCameraProperty(typeof(WorldSpace));

        /// <summary>Backing store for the <see cref="SortingLayer" /> property.</summary>
        public static readonly BindableProperty SortingLayerProperty =
            CreateBindableSortingLayerProperty(typeof(WorldSpace));

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.Canvas.worldCamera" />.
        /// </summary>
        public UnityEngine.Camera WorldCamera
        {
            get
            {
                return (UnityEngine.Camera)GetValue(WorldCameraProperty);
            }

            set
            {
                SetValue(WorldCameraProperty, value);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.Canvas.sortingLayerID" />.
        /// </summary>
        [TypeConverter(typeof(LayerTypeConverter))]
        public int SortingLayer
        {
            get
            {
                return (int)GetValue(SortingLayerProperty);
            }

            set
            {
                SetValue(SortingLayerProperty, value);
            }
        }

        internal sealed override UnityEngine.RenderMode Mode => UnityEngine.RenderMode.WorldSpace;

        /// <inheritdoc />
        protected sealed override void InitializeBodyInMainThread()
        {
            base.InitializeBodyInMainThread();
            Body.worldCamera = WorldCamera;
            Body.sortingLayerID = SortingLayer;
        }
    }
}

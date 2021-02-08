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
    /// A class that represents <see cref="T:UnityEngine.RenderMode.ScreenSpaceOverlay" />
    /// and its rendering properties.
    /// </summary>
    public class ScreenSpaceOverlay : Render
    {
        /// <summary>Backing store for the <see cref="PixelPerfect" /> property.</summary>
        public static readonly BindableProperty PixelPerfectProperty =
            CreateBindablePixelPerfectProperty(typeof(ScreenSpaceOverlay));

        /// <summary>Backing store for the <see cref="OverridePixelPerfect" /> property.</summary>
        public static readonly BindableProperty OverridePixelPerfectProperty =
            CreateBindableOverridePixelPerfectProperty(typeof(ScreenSpaceOverlay));

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.Canvas.pixelPerfect" />.
        /// </summary>
        public bool PixelPerfect
        {
            get
            {
                return (bool)GetValue(PixelPerfectProperty);
            }

            set
            {
                SetValue(PixelPerfectProperty, value);
            }
        }

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.Canvas.overridePixelPerfect" />.
        /// </summary>
        public bool OverridePixelPerfect
        {
            get
            {
                return (bool)GetValue(OverridePixelPerfectProperty);
            }

            set
            {
                SetValue(OverridePixelPerfectProperty, value);
            }
        }

        internal sealed override UnityEngine.RenderMode Mode => UnityEngine.RenderMode.ScreenSpaceOverlay;

        /// <inheritdoc />
        protected sealed override void InitializeBodyInMainThread()
        {
            base.InitializeBodyInMainThread();
            Body.pixelPerfect = PixelPerfect;
            Body.overridePixelPerfect = OverridePixelPerfect;
        }
    }
}

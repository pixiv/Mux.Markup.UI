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
    /// <summary>An <see cref="Graphic{T}" /> that represents <see cref="T:UnityEngine.UI.RawImage" />.</summary>
    /// <example>
    /// <code language="xaml">
    /// <![CDATA[
    /// <m:RectTransform
    ///     xmlns="http://xamarin.com/schemas/2014/forms"
    ///     xmlns:m="clr-namespace:Mux.Markup;assembly=Mux.Markup"
    ///     xmlns:mu="clr-namespace:Mux.Markup;assembly=Mux.Markup.UI"
    ///     xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">
    ///     <mu:StandaloneInputModule />
    ///     <mu:Canvas />
    ///     <mu:CanvasScaler UiScale="{mu:ConstantPhysicalSize}" />
    ///     <mu:GraphicRaycaster />
    ///     <mu:RawImage />
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public class RawImage : Graphic<UnityEngine.UI.RawImage>
    {
        /// <summary>Backing store for the <see cref="Texture" /> property.</summary>
        public static readonly BindableProperty TextureProperty = CreateBindableBodyProperty<UnityEngine.Texture>(
            "Texture",
            typeof(RawImage),
            (body, value) => body.texture = value);

        /// <summary>Backing store for the <see cref="UvRect" /> property.</summary>
        public static readonly BindableProperty UvRectProperty = CreateBindableBodyProperty<UnityEngine.Rect>(
            "UvRect",
            typeof(RawImage),
            (body, value) => body.uvRect = value,
            new UnityEngine.Rect(0, 0, 1, 1));

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.RawImage.texture" />.</summary>
        public UnityEngine.Texture Texture
        {
            get
            {
                return (UnityEngine.Texture)GetValue(TextureProperty);
            }

            set
            {
                SetValue(TextureProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.RawImage.uvRect" />.</summary>
        public UnityEngine.Rect UvRect
        {
            get
            {
                return (UnityEngine.Rect)GetValue(UvRectProperty);
            }

            set
            {
                SetValue(UvRectProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.texture = Texture;
            Body.uvRect = UvRect;

            base.AwakeInMainThread();
        }
    }
}

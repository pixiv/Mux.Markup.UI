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
    /// <summary>A <see cref="Graphic{T}" /> that represents <see cref="T:UnityEngine.UI.Image" />.</summary>
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
    ///     <mu:Image />
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public class Image : Graphic<UnityEngine.UI.Image>
    {
        /// <summary>Backing store for the <see cref="Sprite" /> property.</summary>
        public static readonly BindableProperty SpriteProperty = CreateBindableBodyProperty<UnityEngine.Sprite>(
            "Sprite",
            typeof(Image),
            (body, value) => body.sprite = value);

        /// <summary>Backing store for the <see cref="Type" /> property.</summary>
        public static readonly BindableProperty TypeProperty = CreateBindableBodyProperty<UnityEngine.UI.Image.Type>(
            "Type",
            typeof(Image),
            (body, value) => body.type = value,
            UnityEngine.UI.Image.Type.Simple);

        /// <summary>Backing store for the <see cref="FillCenter" /> property.</summary>
        public static readonly BindableProperty FillCenterProperty = CreateBindableBodyProperty<bool>(
            "FillCenter",
            typeof(Image),
            (body, value) => body.fillCenter = value,
            true);

        /// <summary>Backing store for the <see cref="FillMethod" /> property.</summary>
        public static readonly BindableProperty FillMethodProperty = CreateBindableBodyProperty<UnityEngine.UI.Image.FillMethod>(
            "FillMethod",
            typeof(Image),
            (body, value) => body.fillMethod = value,
            UnityEngine.UI.Image.FillMethod.Radial360);

        /// <summary>Backing store for the <see cref="FillOrigin" /> property.</summary>
        public static readonly BindableProperty FillOriginProperty = CreateBindableBodyProperty<int>(
            "FillOrigin",
            typeof(Image),
            (body, value) => body.fillOrigin = value,
            0);

        /// <summary>Backing store for the <see cref="FillClockwise" /> property.</summary>
        public static readonly BindableProperty FillClockwiseProperty = CreateBindableBodyProperty<bool>(
            "FillClockwise",
            typeof(Image),
            (body, value) => body.fillClockwise = value,
            true);

        /// <summary>Backing store for the <see cref="FillAmount" /> property.</summary>
        public static readonly BindableProperty FillAmountProperty = CreateBindableBodyProperty<float>(
            "FillAmount",
            typeof(Image),
            (body, value) => body.fillAmount = value,
            1f);

        /// <summary>Backing store for the <see cref="PreserveAspect" /> property.</summary>
        public static readonly BindableProperty PreserveAspectProperty = CreateBindableBodyProperty<bool>(
            "PreserveAspect",
            typeof(Image),
            (body, value) => body.preserveAspect = value,
            false);

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Image.sprite" />.</summary>
        public UnityEngine.Sprite Sprite
        {
            get
            {
                return (UnityEngine.Sprite)GetValue(SpriteProperty);
            }

            set
            {
                SetValue(SpriteProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Image.type" />.</summary>
        public UnityEngine.UI.Image.Type Type
        {
            get
            {
                return (UnityEngine.UI.Image.Type)GetValue(TypeProperty);
            }

            set
            {
                SetValue(TypeProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Image.fillCenter" />.</summary>
        public bool FillCenter
        {
            get
            {
                return (bool)GetValue(FillCenterProperty);
            }

            set
            {
                SetValue(FillCenterProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Image.fillMethod" />.</summary>
        public UnityEngine.UI.Image.FillMethod FillMethod
        {
            get
            {
                return (UnityEngine.UI.Image.FillMethod)GetValue(FillMethodProperty);
            }

            set
            {
                SetValue(FillMethodProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Image.fillOrigin" />.</summary>
        public int FillOrigin
        {
            get
            {
                return (int)GetValue(FillOriginProperty);
            }

            set
            {
                SetValue(FillOriginProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Image.fillClockwise" />.</summary>
        public bool FillClockwise
        {
            get
            {
                return (bool)GetValue(FillClockwiseProperty);
            }

            set
            {
                SetValue(FillClockwiseProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Image.fillAmount" />.</summary>
        public float FillAmount
        {
            get
            {
                return (float)GetValue(FillAmountProperty);
            }

            set
            {
                SetValue(FillAmountProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Image.preserveAspect" />.</summary>
        public bool PreserveAspect
        {
            get
            {
                return (bool)GetValue(PreserveAspectProperty);
            }

            set
            {
                SetValue(PreserveAspectProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.sprite = Sprite;
            Body.type = Type;
            Body.fillCenter = FillCenter;
            Body.fillMethod = FillMethod;
            Body.fillOrigin = FillOrigin;
            Body.fillClockwise = FillClockwise;
            Body.fillAmount = FillAmount;
            Body.preserveAspect = PreserveAspect;

            base.AwakeInMainThread();
        }
    }
}

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
using System.Runtime.InteropServices;
using Xamarin.Forms;

namespace Mux.Markup
{
    /// <summary>A <see cref="Selectable{T}" /> that represents <see cref="T:UnityEngine.UI.Slider" />.</summary>
    /// <example>
    /// <code language="xaml">
    /// <![CDATA[
    /// <m:RectTransform
    ///     xmlns="http://xamarin.com/schemas/2014/forms"
    ///     xmlns:m="clr-namespace:Mux.Markup;assembly=Mux.Markup"
    ///     xmlns:mu="clr-namespace:Mux.Markup;assembly=Mux.Markup.UI"
    ///     xmlns:mue="clr-namespace:Mux.Markup.Extras;assembly=Mux.Markup.UI"
    ///     xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml">
    ///     <mu:StandaloneInputModule />
    ///     <mu:Canvas />
    ///     <mu:CanvasScaler UiScale="{mu:ConstantPhysicalSize}" />
    ///     <mu:GraphicRaycaster />
    ///     <!--
    ///         You have to give property name "Path" to Binding and "Name" to x:Reference
    ///         only when you compile the interpreter with IL2CPP.
    ///         It is because ContentPropertyAttribute does not work with IL2CPP.
    ///     -->
    ///     <mu:Slider
    ///         FillRect="{Binding Path=Body, Source={x:Reference Name=fill}}"
    ///         HandleRect="{Binding Path=Body, Source={x:Reference Name=handle}}"
    ///         TargetGraphic="{Binding Path=Body, Source={x:Reference Name=targetGraphic}}" />
    ///     <m:RectTransform X="{m:Stretch OffsetMin=2, OffsetMax=-2}">
    ///         <m:RectTransform x:Name="fill" X="{m:Sized SizeDelta=4}" Y="{m:Stretch}">
    ///             <mu:Image Color="{m:Color R=0, G=0, B=1}" />
    ///         </m:RectTransform>
    ///     </m:RectTransform>
    ///     <m:RectTransform X="{m:Stretch OffsetMin=4, OffsetMax=-4}">
    ///         <m:RectTransform x:Name="handle" X="{m:Sized SizeDelta=8}" Y="{m:Stretch}">
    ///             <mu:Image x:Name="targetGraphic" Color="{m:Color R=0, G=1, B=0}" />
    ///         </m:RectTransform>
    ///     </m:RectTransform>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public class Slider : Selectable<UnityEngine.UI.Slider>
    {
        /// <summary>Backing store for the <see cref="FillRect" /> property.</summary>
        public static readonly BindableProperty FillRectProperty = CreateBindableBodyProperty<UnityEngine.RectTransform>(
            "FillRect",
            typeof(Slider),
            (body, value) => body.fillRect = value);

        /// <summary>Backing store for the <see cref="HandleRect" /> property.</summary>
        public static readonly BindableProperty HandleRectProperty = CreateBindableBodyProperty<UnityEngine.RectTransform>(
            "HandleRect",
            typeof(Slider),
            (body, value) => body.handleRect = value);

        /// <summary>Backing store for the <see cref="Direction" /> property.</summary>
        public static readonly BindableProperty DirectionProperty = CreateBindableBodyProperty<UnityEngine.UI.Slider.Direction>(
            "Direction",
            typeof(Slider),
            (body, value) => body.direction = value,
            UnityEngine.UI.Slider.Direction.LeftToRight);

        /// <summary>Backing store for the <see cref="MinValue" /> property.</summary>
        public static readonly BindableProperty MinValueProperty = CreateBindableBodyProperty<float>(
            "MinValue",
            typeof(Slider),
            (body, value) => body.minValue = value,
            0f);

        /// <summary>Backing store for the <see cref="MaxValue" /> property.</summary>
        public static readonly BindableProperty MaxValueProperty = CreateBindableBodyProperty<float>(
            "MaxValue",
            typeof(Slider),
            (body, value) => body.maxValue = value,
            1f);

        /// <summary>Backing store for the <see cref="WholeNumbers" /> property.</summary>
        public static readonly BindableProperty WholeNumbersProperty = CreateBindableBodyProperty<bool>(
            "WholeNumbers",
            typeof(Slider),
            (body, value) => body.wholeNumbers = value,
            false);

        /// <summary>Backing store for the <see cref="Value" /> property.</summary>
        public static readonly BindableProperty ValueProperty = CreateBindableBodyProperty<float>(
            "Value",
            typeof(Slider),
            (body, value) =>
            {
                var old = body.onValueChanged;
                body.onValueChanged = new UnityEngine.UI.Slider.SliderEvent();

                try
                {
                    body.value = value;
                }
                finally
                {
                    body.onValueChanged = old;
                }
            },
            0f,
            BindingMode.TwoWay);

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Slider.fillRect" />.</summary>
        /// <seealso cref="RectTransform" />
        public UnityEngine.RectTransform FillRect
        {
            get
            {
                return (UnityEngine.RectTransform)GetValue(FillRectProperty);
            }

            set
            {
                SetValue(FillRectProperty, value);
            }
        }

        /// <summary>A property that represents <see href="P:UnityEngine.UI.Slider.handleRect" />.</summary>
        /// <seealso cref="RectTransform" />
        public UnityEngine.RectTransform HandleRect
        {
            get
            {
                return (UnityEngine.RectTransform)GetValue(HandleRectProperty);
            }

            set
            {
                SetValue(HandleRectProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Slider.direction" />.</summary>
        public UnityEngine.UI.Slider.Direction Direction
        {
            get
            {
                return (UnityEngine.UI.Slider.Direction)GetValue(DirectionProperty);
            }

            set
            {
                SetValue(DirectionProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Slider.minValue" />.</summary>
        public float MinValue
        {
            get
            {
                return (float)GetValue(MinValueProperty);
            }

            set
            {
                SetValue(MinValueProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Slider.maxValue" />.</summary>
        public float MaxValue
        {
            get
            {
                return (float)GetValue(MaxValueProperty);
            }

            set
            {
                SetValue(MaxValueProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Slider.wholeNumbers" />.</summary>
        public bool WholeNumbers
        {
            get
            {
                return (bool)GetValue(WholeNumbersProperty);
            }

            set
            {
                SetValue(WholeNumbersProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Slider.value" />.</summary>
        public float Value
        {
            get
            {
                return (float)GetValue(ValueProperty);
            }

            set
            {
                SetValue(ValueProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.fillRect = FillRect;
            Body.handleRect = HandleRect;
            Body.direction = Direction;
            Body.minValue = MinValue;
            Body.maxValue = MaxValue;
            Body.wholeNumbers = WholeNumbers;
            Body.value = Value;
            Body.onValueChanged.AddListener(newValue => SetValueCore(ValueProperty, newValue));

            base.AwakeInMainThread();
        }
    }
}

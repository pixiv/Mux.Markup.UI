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
    /// <summary>A <see cref="Selectable{T}" /> that represents <see cref="T:UnityEngine.UI.Scrollbar" />.</summary>
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
    ///     <mu:Scrollbar HandleRect="{Binding Path=Body, Source={x:Reference Name=handle}}" />
    ///     <m:RectTransform x:Name="handle">
    ///         <mu:Image Color="{m:Color R=0, G=0, B=1}" />
    ///     </m:RectTransform>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public class Scrollbar : Selectable<UnityEngine.UI.Scrollbar>
    {
        /// <summary>Backing store for the <see cref="HandleRect" /> property.</summary>
        public static readonly BindableProperty HandleRectProperty = CreateBindableBodyProperty<UnityEngine.RectTransform>(
            "HandleRect",
            typeof(Scrollbar),
            (body, value) => body.handleRect = value);

        /// <summary>Backing store for the <see cref="Direction" /> property.</summary>
        public static readonly BindableProperty DirectionProperty = CreateBindableBodyProperty<UnityEngine.UI.Scrollbar.Direction>(
            "Direction",
            typeof(Scrollbar),
            (body, value) => body.direction = value,
            UnityEngine.UI.Scrollbar.Direction.LeftToRight);

        /// <summary>Backing store for the <see cref="Value" /> property.</summary>
        public static readonly BindableProperty ValueProperty = CreateBindableBodyProperty<float>(
            "Value",
            typeof(Scrollbar),
            (body, value) => body.value = value,
            0f,
            BindingMode.TwoWay);

        /// <summary>Backing store for the <see cref="Size" /> property.</summary>
        public static readonly BindableProperty SizeProperty = CreateBindableBodyProperty<float>(
            "Size",
            typeof(Scrollbar),
            (body, value) => body.size = value,
            0.2f);

        /// <summary>Backing store for the <see cref="NumberOfSteps" /> property.</summary>
        public static readonly BindableProperty NumberOfStepsProperty = CreateBindableBodyProperty<int>(
            "NumberOfSteps",
            typeof(Scrollbar),
            (body, value) => body.numberOfSteps = value,
            0);

        /// <summary>A property that represents <see cref="T:UnityEngine.UI.Scrollbar.handleRect" />.</summary>
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

        /// <summary>A property that represents <see cref="T:UnityEngine.UI.Scrollbar.direction" />.</summary>
        /// <seealso cref="RectTransform" />
        public UnityEngine.UI.Scrollbar.Direction Direction
        {
            get
            {
                return (UnityEngine.UI.Scrollbar.Direction)GetValue(DirectionProperty);
            }

            set
            {
                SetValue(DirectionProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Scrollbar.value" />.</summary>
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

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Scrollbar.size" />.</summary>
        public float Size
        {
            get
            {
                return (float)GetValue(SizeProperty);
            }

            set
            {
                SetValue(SizeProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Scrollbar.numberOfSteps" />.</summary>
        public int NumberOfSteps
        {
            get
            {
                return (int)GetValue(NumberOfStepsProperty);
            }

            set
            {
                SetValue(NumberOfStepsProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.handleRect = HandleRect;
            Body.direction = Direction;
            Body.value = Value;
            Body.size = Size;
            Body.numberOfSteps = NumberOfSteps;
            Body.onValueChanged.AddListener(newValue => SetValueCore(ValueProperty, newValue));

            base.AwakeInMainThread();
        }
    }
}

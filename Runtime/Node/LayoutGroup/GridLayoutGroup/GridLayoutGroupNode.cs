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
    /// <summary>A <see cref="LayoutGroup{T}" /> that represents <see cref="T:UnityEngine.UI.GridLayoutGroup" />.</summary>
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
    ///     <mu:GridLayoutGroup Constraint="{mu:FixedColumnCount Count=2}" />
    ///     <m:RectTransform><mu:Image Color="{m:Color R=0, G=0, B=1}" /></m:RectTransform>
    ///     <m:RectTransform><mu:Image Color="{m:Color R=0, G=1, B=0}" /></m:RectTransform>
    ///     <m:RectTransform><mu:Image Color="{m:Color R=1, G=0, B=0}" /></m:RectTransform>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public class GridLayoutGroup : LayoutGroup<UnityEngine.UI.GridLayoutGroup>
    {
        /// <summary>Backing store for the <see cref="CellSize" /> property.</summary>
        public static readonly BindableProperty CellSizeProperty = CreateBindableBodyProperty<UnityEngine.Vector2>(
            "CellSize",
            typeof(GridLayoutGroup),
            (body, value) => body.cellSize = value,
            new UnityEngine.Vector2(100, 100));

        /// <summary>Backing store for the <see cref="Spacing" /> property.</summary>
        public static readonly BindableProperty SpacingProperty = CreateBindableBodyProperty<UnityEngine.Vector2>(
            "Spacing",
            typeof(GridLayoutGroup),
            (body, value) => body.spacing = value,
            UnityEngine.Vector2.zero);

        /// <summary>Backing store for the <see cref="StartCorner" /> property.</summary>
        public static readonly BindableProperty StartCornerProperty = CreateBindableBodyProperty<UnityEngine.UI.GridLayoutGroup.Corner>(
            "StartCorner",
            typeof(GridLayoutGroup),
            (body, value) => body.startCorner = value,
            UnityEngine.UI.GridLayoutGroup.Corner.UpperLeft);

        /// <summary>Backing store for the <see cref="StartAxis" /> property.</summary>
        public static readonly BindableProperty StartAxisProperty = CreateBindableBodyProperty<UnityEngine.UI.GridLayoutGroup.Axis>(
            "StartAxis",
            typeof(GridLayoutGroup),
            (body, value) => body.startAxis = value,
            UnityEngine.UI.GridLayoutGroup.Axis.Horizontal);

        /// <summary>Backing store for the <see cref="Constraint" /> property.</summary>
        public static readonly BindableProperty ConstraintProperty = CreateBindableModifierProperty(
            "Constraint",
            typeof(GridLayoutGroup),
            sender => new Flexible());

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.GridLayoutGroup.cellSize" />.</summary>
        /// <seealso cref="Vector2" />
        public UnityEngine.Vector2 CellSize
        {
            get
            {
                return (UnityEngine.Vector2)GetValue(CellSizeProperty);
            }

            set
            {
                SetValue(CellSizeProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.GridLayoutGroup.spacing" />.</summary>
        /// <seealso cref="Vector2" />
        public UnityEngine.Vector2 Spacing
        {
            get
            {
                return (UnityEngine.Vector2)GetValue(SpacingProperty);
            }

            set
            {
                SetValue(SpacingProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.GridLayoutGroup.startCorner" />.</summary>
        public UnityEngine.UI.GridLayoutGroup.Corner StartCorner
        {
            get
            {
                return (UnityEngine.UI.GridLayoutGroup.Corner)GetValue(StartCornerProperty);
            }

            set
            {
                SetValue(StartCornerProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.GridLayoutGroup.startAxis" />.</summary>
        public UnityEngine.UI.GridLayoutGroup.Axis StartAxis
        {
            get
            {
                return (UnityEngine.UI.GridLayoutGroup.Axis)GetValue(StartAxisProperty);
            }

            set
            {
                SetValue(StartAxisProperty, value);
            }
        }

        /// <summary>A property that represents the constraint for <see cref="T:UnityEngine.UI.GridLayoutGroup" />.</summary>
        /// <seealso cref="Flexible" />
        /// <seealso cref="FixedColumnCount" />
        /// <seealso cref="FixedRowCount" />
        public Modifier Constraint
        {
            get
            {
                return (Modifier)GetValue(ConstraintProperty);
            }

            set
            {
                SetValue(ConstraintProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void OnBindingContextChanged()
        {
            base.OnBindingContextChanged();
            SetInheritedBindingContext(Constraint, BindingContext);
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.cellSize = CellSize;
            Body.spacing = Spacing;
            Body.startCorner = StartCorner;
            Body.startAxis = StartAxis;
            Constraint.Body = Body;

            base.AwakeInMainThread();
        }

        /// <inheritdoc />
        protected override void DestroyMuxInMainThread()
        {
            base.DestroyMuxInMainThread();
            Constraint.DestroyMux();
        }
    }
}

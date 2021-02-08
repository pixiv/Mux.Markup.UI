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
    /// <summary>A <see cref="Graphic{T}" /> that represents <see cref="T:UnityEngine.UI.Text" />.</summary>
    /// <example>
    /// <code language="xaml">
    /// <![CDATA[
    /// <m:RectTransform
    ///     xmlns="http://xamarin.com/schemas/2014/forms"
    ///     xmlns:m="clr-namespace:Mux.Markup;assembly=Mux.Markup"
    ///     xmlns:mu="clr-namespace:Mux.Markup;assembly=Mux.Markup.UI"
    ///     xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    ///     xmlns:playground="clr-namespace:Mux.Playground;assembly=Assembly-CSharp"
    ///     xmlns:DataType="playground:PlaygroundViewModel">
    ///     <!--
    ///       Note that you can use "using" scheme instead of "clr-namespace" to omit assembly
    ///       specification if:
    ///       - the referenced type is in an assembly already loaded. (interpreter)
    ///       - the referenced type is in the assembly containing the compiled XAML. (compiler)
    ///     -->
    ///     <mu:StandaloneInputModule />
    ///     <mu:Canvas />
    ///     <mu:CanvasScaler UiScale="{mu:ConstantPhysicalSize}" />
    ///     <mu:GraphicRaycaster />
    ///     <mu:Text Font="{Binding Path=Resources.Font}">
    ///         <mu:Text.Content>
    /// You have to give property name "Path" to Binding only when you compile
    /// the interpreter with IL2CPP. It is because ContentPropertyAttribute does
    /// not work with IL2CPP.
    ///         </mu:Text.Content>
    ///     </mu:Text>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public class Text : Graphic<UnityEngine.UI.Text>
    {
        /// <summary>Backing store for the <see cref="Content" /> property.</summary>
        public static readonly BindableProperty ContentProperty = CreateBindableBodyProperty<string>(
            "Content",
            typeof(Text),
            (body, value) => body.text = value,
            "New Text");

        /// <summary>Backing store for the <see cref="Font" /> property.</summary>
        public static readonly BindableProperty FontProperty = CreateBindableBodyProperty<UnityEngine.Font>(
            "Font",
            typeof(Text),
            (body, value) => body.font = value);

        /// <summary>Backing store for the <see cref="FontSize" /> property.</summary>
        public static readonly BindableProperty FontSizeProperty = CreateBindableBodyProperty<int>(
            "FontSize",
            typeof(Text),
            (body, value) => body.fontSize = value,
            14);

        /// <summary>Backing store for the <see cref="FontStyle" /> property.</summary>
        public static readonly BindableProperty FontStyleProperty = CreateBindableBodyProperty<UnityEngine.FontStyle>(
            "FontStyle",
            typeof(Text),
            (body, value) => body.fontStyle = value,
            UnityEngine.FontStyle.Normal);

        /// <summary>Backing store for the <see cref="ResizeTextForBestFit" /> property.</summary>
        public static readonly BindableProperty ResizeTextForBestFitProperty = CreateBindableBodyProperty<bool>(
            "ResizeTextForBestFit",
            typeof(Text),
            (body, value) => body.resizeTextForBestFit = value,
            false);

        /// <summary>Backing store for the <see cref="ResizeTextMinSize" /> property.</summary>
        public static readonly BindableProperty ResizeTextMinSizeProperty = CreateBindableBodyProperty<int>(
            "ResizeTextMinSize",
            typeof(Text),
            (body, value) => body.resizeTextMinSize = value,
            10);

        /// <summary>Backing store for the <see cref="ResizeTextMaxSize" /> property.</summary>
        public static readonly BindableProperty ResizeTextMaxSizeProperty = CreateBindableBodyProperty<int>(
            "ResizeTextMaxSize",
            typeof(Text),
            (body, value) => body.resizeTextMaxSize = value,
            40);

        /// <summary>Backing store for the <see cref="Alignment" /> property.</summary>
        public static readonly BindableProperty AlignmentProperty = CreateBindableBodyProperty<UnityEngine.TextAnchor>(
            "Alignment",
            typeof(Text),
            (body, value) => body.alignment = value,
            UnityEngine.TextAnchor.UpperLeft);

        /// <summary>Backing store for the <see cref="AlignByGeometry" /> property.</summary>
        public static readonly BindableProperty AlignByGeometryProperty = CreateBindableBodyProperty<bool>(
            "AlignByGeometry",
            typeof(Text),
            (body, value) => body.alignByGeometry = value,
            false);

        /// <summary>Backing store for the <see cref="SupportRichText" /> property.</summary>
        public static readonly BindableProperty SupportRichTextProperty = CreateBindableBodyProperty<bool>(
            "SupportRichText",
            typeof(Text),
            (body, value) => body.supportRichText = value,
            true);

        /// <summary>Backing store for the <see cref="HorizontalOverflow" /> property.</summary>
        public static readonly BindableProperty HorizontalOverflowProperty = CreateBindableBodyProperty<UnityEngine.HorizontalWrapMode>(
            "HorizontalOverflow",
            typeof(Text),
            (body, value) => body.horizontalOverflow = value,
            UnityEngine.HorizontalWrapMode.Wrap);

        /// <summary>Backing store for the <see cref="VerticalOverflow" /> property.</summary>
        public static readonly BindableProperty VerticalOverflowProperty = CreateBindableBodyProperty<UnityEngine.VerticalWrapMode>(
            "VerticalOverflow",
            typeof(Text),
            (body, value) => body.verticalOverflow = value,
            UnityEngine.VerticalWrapMode.Truncate);

        /// <summary>Backing store for the <see cref="LineSpacing" /> property.</summary>
        public static readonly BindableProperty LineSpacingProperty = CreateBindableBodyProperty<float>(
            "LineSpacing",
            typeof(Text),
            (body, value) => body.lineSpacing = value,
            1f);

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Text.text" />.</summary>
        public string Content
        {
            get
            {
                return (string)GetValue(ContentProperty);
            }

            set
            {
                SetValue(ContentProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Text.font" />.</summary>
        public UnityEngine.Font Font
        {
            get
            {
                return (UnityEngine.Font)GetValue(FontProperty);
            }

            set
            {
                SetValue(FontProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Text.fontSize" />.</summary>
        public int FontSize
        {
            get
            {
                return (int)GetValue(FontSizeProperty);
            }

            set
            {
                SetValue(FontSizeProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Text.fontStyle" />.</summary>
        public UnityEngine.FontStyle FontStyle
        {
            get
            {
                return (UnityEngine.FontStyle)GetValue(FontStyleProperty);
            }

            set
            {
                SetValue(FontStyleProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Text.resizeTextForBestFit" />.</summary>
        public bool ResizeTextForBestFit
        {
            get
            {
                return (bool)GetValue(ResizeTextForBestFitProperty);
            }

            set
            {
                SetValue(ResizeTextForBestFitProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Text.resizeTextMinSize" />.</summary>
        public int ResizeTextMinSize
        {
            get
            {
                return (int)GetValue(ResizeTextMinSizeProperty);
            }

            set
            {
                SetValue(ResizeTextMinSizeProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Text.resizeTextMaxSize" />.</summary>
        public int ResizeTextMaxSize
        {
            get
            {
                return (int)GetValue(ResizeTextMaxSizeProperty);
            }

            set
            {
                SetValue(ResizeTextMaxSizeProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Text.alignment" />.</summary>
        public UnityEngine.TextAnchor Alignment
        {
            get
            {
                return (UnityEngine.TextAnchor)GetValue(AlignmentProperty);
            }

            set
            {
                SetValue(AlignmentProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Text.alignByGeometry" />.</summary>
        public bool AlignByGeometry
        {
            get
            {
                return (bool)GetValue(AlignByGeometryProperty);
            }

            set
            {
                SetValue(AlignByGeometryProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Text.supportRichText" />.</summary>
        public bool SupportRichText
        {
            get
            {
                return (bool)GetValue(SupportRichTextProperty);
            }

            set
            {
                SetValue(SupportRichTextProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Text.horizontalOverflow" />.</summary>
        public UnityEngine.HorizontalWrapMode HorizontalOverflow
        {
            get
            {
                return (UnityEngine.HorizontalWrapMode)GetValue(HorizontalOverflowProperty);
            }

            set
            {
                SetValue(HorizontalOverflowProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Text.verticalOverflow" />.</summary>
        public UnityEngine.VerticalWrapMode VerticalOverflow
        {
            get
            {
                return (UnityEngine.VerticalWrapMode)GetValue(VerticalOverflowProperty);
            }

            set
            {
                SetValue(VerticalOverflowProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Text.lineSpacing" />.</summary>
        public float LineSpacing
        {
            get
            {
                return (float)GetValue(LineSpacingProperty);
            }

            set
            {
                SetValue(LineSpacingProperty, value);
            }
        }

        public Text()
        {
            SetValueCore(ColorProperty, new UnityEngine.Color32(50, 50, 50, 255));
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.text = Content;
            Body.font = Font;
            Body.fontSize = FontSize;
            Body.fontStyle = FontStyle;
            Body.resizeTextForBestFit = ResizeTextForBestFit;
            Body.resizeTextMinSize = ResizeTextMinSize;
            Body.resizeTextMaxSize = ResizeTextMaxSize;
            Body.alignment = Alignment;
            Body.alignByGeometry = AlignByGeometry;
            Body.supportRichText = SupportRichText;
            Body.horizontalOverflow = HorizontalOverflow;
            Body.verticalOverflow = VerticalOverflow;
            Body.lineSpacing = LineSpacing;

            base.AwakeInMainThread();
        }
    }
}

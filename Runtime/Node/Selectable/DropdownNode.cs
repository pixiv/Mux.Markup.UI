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
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Xamarin.Forms;

namespace Mux.Markup
{
    /// <summary>
    /// A <see cref="BindableObject" /> that represents <see cref="T:UnityEngine.UI.Dropdown.OptionData" />.
    /// </summary>
    /// <remarks>
    /// You cannot add this to multiple <see cref="Dropdown" />.
    ///
    /// The lifetime will be bound to the lifetime of the <see cref="Dropdown" />.
    /// </remarks>
    public class DropdownOptionData : BindableObject
    {
        /// <summary>Backing store for the <see cref="Image" /> property.</summary>
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(
            "Image",
            typeof(UnityEngine.Sprite),
            typeof(DropdownOptionData),
            null,
            BindingMode.OneWay,
            null,
            OnImageChanged);

        /// <summary>Backing store for the <see cref="Text" /> property.</summary>
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            "Text",
            typeof(string),
            typeof(DropdownOptionData),
            null,
            BindingMode.OneWay,
            null,
            OnTextChanged);

        internal Dropdown dropdown = null;

        private static void OnImageChanged(BindableObject sender, object oldValue, object newValue)
        {
            Forms.mainThread.Send(state =>
            {
                var data = (DropdownOptionData)state;
                data.data.image = data.Image;
                data.dropdown?.Body?.RefreshShownValue();
            }, sender);
        }

        private static void OnTextChanged(BindableObject sender, object oldValue, object newValue)
        {
            Forms.mainThread.Send(state =>
            {
                var data = (DropdownOptionData)state;
                data.data.text = data.Text;
                data.dropdown?.Body?.RefreshShownValue();
            }, sender);
        }

        internal readonly UnityEngine.UI.Dropdown.OptionData data = new UnityEngine.UI.Dropdown.OptionData();

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Dropdown.OptionData.image" />.</summary>
        public UnityEngine.Sprite Image
        {
            get
            {
                return (UnityEngine.Sprite)GetValue(ImageProperty);
            }

            set
            {
                SetValue(ImageProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Dropdown.OptionData.text" />.</summary>
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }

            set
            {
                SetValue(TextProperty, value);
            }
        }
    }

    /// <summary>A <see cref="Selectable{T}" /> that represents <see cref="T:UnityEngine.UI.Dropdown" />.</summary>
    /// <example>
    /// <code language="xaml">
    /// <![CDATA[
    /// <m:RectTransform
    ///     xmlns="http://xamarin.com/schemas/2014/forms"
    ///     xmlns:m="clr-namespace:Mux.Markup;assembly=Mux.Markup"
    ///     xmlns:mu="clr-namespace:Mux.Markup;assembly=Mux.Markup.UI"
    ///     xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    ///     xmlns:playgroundMarkup="clr-namespace:Mux.Playground.Markup;assembly=Assembly-CSharp">
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
    ///     <playgroundMarkup:TextTransform TextComponent="{Binding Path=CaptionText, Source={x:Reference Name=dropdown}}">
    ///         <mu:ContentSizeFitter VerticalFit="PreferredSize" />
    ///         <mu:Dropdown x:Name="dropdown">
    ///             <mu:Dropdown.Options>
    ///                 <mu:DropdownOptionData Text="A" />
    ///                 <mu:DropdownOptionData Text="B" />
    ///             </mu:Dropdown.Options>
    ///         </mu:Dropdown>
    ///         <m:RectTransform ActiveSelf="False" Body="{Binding Path=Template, Source={x:Reference Name=dropdown}}" X="{m:Stretch}" Y="{m:Sized AnchoredPosition=2, SizeDelta=150, Anchor=0, Pivot=1}">
    ///             <m:RectTransform x:Name="viewport" X="{m:Stretch Pivot=0, OffsetMax=-18}" Y="{m:Stretch Pivot=1}">
    ///                 <m:RectTransform x:Name="content" Y="{m:Sized SizeDelta=28, Anchor=1, Pivot=1}">
    ///                     <m:RectTransform X="{m:Stretch}" Y="{m:Sized SizeDelta=21}">
    ///                         <mu:Toggle
    ///                             Graphic="{Binding Path=Body, Source={x:Reference Name=itemGraphic}}"
    ///                             TargetGraphic="{Binding Path=Body, Source={x:Reference Name=itemTargetGraphic}}" />
    ///                         <mu:Image x:Name="itemTargetGraphic" />
    ///                         <m:RectTransform X="{m:Stretch}" Y="{m:Stretch}">
    ///                             <mu:Image x:Name="itemGraphic" Color="{m:Color R=0, G=0, B=1, A=0.5}" />
    ///                         </m:RectTransform>
    ///                         <playgroundMarkup:TextTransform
    ///                             TextComponent="{Binding Path=ItemText, Source={x:Reference Name=dropdown}}"
    ///                             X="{m:Stretch}"
    ///                             Y="{m:Stretch}" />
    ///                     </m:RectTransform>
    ///                 </m:RectTransform>
    ///             </m:RectTransform>
    ///             <mu:ScrollRect
    ///                 Viewport="{Binding Path=Body, Source={x:Reference Name=viewport}}"
    ///                 Content="{Binding Path=Body, Source={x:Reference Name=content}}" />
    ///         </m:RectTransform>
    ///     </playgroundMarkup:TextTransform>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    [ContentProperty("Options")]
    public class Dropdown : Selectable<UnityEngine.UI.Dropdown>
    {
        private sealed class TemplatableUnityOptionData : TemplatableCollectionList<UnityEngine.UI.Dropdown.OptionData>
        {
            public readonly List<UnityEngine.UI.Dropdown.OptionData> list = new List<UnityEngine.UI.Dropdown.OptionData>();

            protected override IList<UnityEngine.UI.Dropdown.OptionData> GetList()
            {
                return list;
            }

            public override void InsertListRange(int index, IEnumerable<UnityEngine.UI.Dropdown.OptionData> enumerable)
            {
                list.InsertRange(index, enumerable);
            }

            public override void RemoveListRange(int index, int count)
            {
                list.RemoveRange(index, count);
            }
        }

        private sealed class TemplatableOptionData : TemplatableCollection<DropdownOptionData>
        {
            private readonly ImmutableList<TemplatedItem<DropdownOptionData>>.Builder _builder =
                ImmutableList.CreateBuilder<TemplatedItem<DropdownOptionData>>();

            public readonly TemplatableUnityOptionData data = new TemplatableUnityOptionData();

            public TemplatableOptionData(BindableObject container) : base(container)
            {
            }

            protected override IList<TemplatedItem<DropdownOptionData>> GetList()
            {
                return _builder;
            }

            public override void ClearList()
            {
                base.ClearList();
                data.ClearList();
                RefreshShownValue();
            }

            public override void InsertListRange(int index, IEnumerable<TemplatedItem<DropdownOptionData>> enumerable)
            {
                foreach (var item in enumerable)
                {
                    item.Content.dropdown = (Dropdown)container;
                }

                _builder.InsertRange(index, enumerable);
                data.InsertListRange(index, enumerable.Select(item => item.Content.data));
                RefreshShownValue();
            }

            public override void MoveListRange(int from, int to, int count)
            {
                base.MoveListRange(from, to, count);
                data.MoveListRange(from, to, count);
                RefreshShownValue();
            }

            public override void RemoveListRange(int index, int count)
            {
                data.RemoveListRange(index, count);

                while (count > 0)
                {
                    _builder.RemoveAt(index);
                    count--;
                }

                RefreshShownValue();
            }

            public override void ReplaceListRange(int index, int count, IEnumerable<TemplatedItem<DropdownOptionData>> enumerable)
            {
                foreach (var item in enumerable)
                {
                    item.Content.dropdown = (Dropdown)container;
                }

                base.ReplaceListRange(index, count, enumerable);
                data.ReplaceListRange(index, count, enumerable.Select(item => item.Content.data));
                RefreshShownValue();
            }

            private void RefreshShownValue()
            {
                var body = ((Dropdown)container).Body;

                if (body != null)
                {
                    Forms.mainThread.Send(state => body.RefreshShownValue(), null);
                }
            }

            public ImmutableList<TemplatedItem<DropdownOptionData>> ToImmutable()
            {
                return _builder.ToImmutable();
            }
        }

        /// <summary>Backing store for the <see cref="Template" /> property.</summary>
        public static readonly BindableProperty TemplateProperty = CreateBindableBodyProperty<UnityEngine.RectTransform>(
            "Template",
            typeof(Dropdown),
            (body, value) => body.template = value);

        /// <summary>Backing store for the <see cref="CaptionText" /> property.</summary>
        public static readonly BindableProperty CaptionTextProperty = CreateBindableBodyProperty<UnityEngine.UI.Text>(
            "CaptionText",
            typeof(Dropdown),
            (body, value) => body.captionText = value);

        /// <summary>Backing store for the <see cref="CaptionImage" /> property.</summary>
        public static readonly BindableProperty CaptionImageProperty = CreateBindableBodyProperty<UnityEngine.UI.Image>(
            "CaptionImage",
            typeof(Dropdown),
            (body, value) => body.captionImage = value);

        /// <summary>Backing store for the <see cref="ItemText" /> property.</summary>
        public static readonly BindableProperty ItemTextProperty = CreateBindableBodyProperty<UnityEngine.UI.Text>(
            "ItemText",
            typeof(Dropdown),
            (body, value) => body.itemText = value);

        /// <summary>Backing store for the <see cref="ItemImage" /> property.</summary>
        public static readonly BindableProperty ItemImageProperty = CreateBindableBodyProperty<UnityEngine.UI.Image>(
            "ItemImage",
            typeof(Dropdown),
            (body, value) => body.itemImage = value);

        /// <summary>Backing store for the <see cref="Value" /> property.</summary>
        public static readonly BindableProperty ValueProperty = CreateBindableBodyProperty<int>(
            "Value",
            typeof(Dropdown),
            (body, value) =>
            {
                var old = body.onValueChanged;
                body.onValueChanged = new UnityEngine.UI.Dropdown.DropdownEvent();

                try
                {
                    body.value = value;
                }
                finally
                {
                    body.onValueChanged = old;
                }
            },
            0,
            BindingMode.TwoWay);

        /// <summary>Backing store for the <see cref="Options" /> property.</summary>
        /// <remarks>
        /// You cannot add the same <see cref="DropdownOptionData" /> to this property of multiple instances.
        ///
        /// This binds the lifetime of <see cref="DropdownOptionData" /> to the lifetime of the instance.
        /// </remarks>
        public static readonly BindableProperty OptionsProperty = BindableProperty.CreateReadOnly(
            "Options",
            typeof(ICollection<DropdownOptionData>),
            typeof(Dropdown),
            null,
            BindingMode.OneWayToSource,
            null,
            null,
            null,
            null,
            CreateDefaultOptions).BindableProperty;

        /// <summary>Backing store for the <see cref="OptionsSource" /> property.</summary>
        public static readonly BindableProperty OptionsSourceProperty = BindableProperty.Create(
            "OptionsSource",
            typeof(IEnumerable),
            typeof(Dropdown),
            null,
            BindingMode.OneWay,
            null,
            OnOptionsSourceChanged);

        /// <summary>Backing store for the <see cref="OptionTemplate" /> property.</summary>
        public static readonly BindableProperty OptionTemplateProperty = BindableProperty.Create(
            "OptionTemplate",
            typeof(DataTemplate),
            typeof(Dropdown),
            null,
            BindingMode.OneWay,
            null,
            OnOptionTemplateChanged);

        private static object CreateDefaultOptions(BindableObject sender)
        {
            return ((Dropdown)sender)._options;
        }

        private static void OnOptionsSourceChanged(BindableObject sender, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                ((Dropdown)sender)._options.ChangeSource((IEnumerable)newValue);
            }
        }

        private static void OnOptionTemplateChanged(BindableObject sender, object oldValue, object newValue)
        {
            ((Dropdown)sender)._options.ChangeTemplate((DataTemplate)newValue);
        }

        private readonly TemplatableOptionData _options;

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Dropdown.template" />.</summary>
        public UnityEngine.RectTransform Template
        {
            get
            {
                return (UnityEngine.RectTransform)GetValue(TemplateProperty);
            }

            set
            {
                SetValue(TemplateProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Dropdown.captionText" />.</summary>
        public UnityEngine.UI.Text CaptionText
        {
            get
            {
                return (UnityEngine.UI.Text)GetValue(CaptionTextProperty);
            }

            set
            {
                SetValue(CaptionTextProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Dropdown.captionImage" />.</summary>
        public UnityEngine.UI.Image CaptionImage
        {
            get
            {
                return (UnityEngine.UI.Image)GetValue(CaptionImageProperty);
            }

            set
            {
                SetValue(CaptionImageProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Dropdown.itemText" />.</summary>
        public UnityEngine.UI.Text ItemText
        {
            get
            {
                return (UnityEngine.UI.Text)GetValue(ItemTextProperty);
            }

            set
            {
                SetValue(ItemTextProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Dropdown.itemImage" />.</summary>
        public UnityEngine.UI.Image ItemImage
        {
            get
            {
                return (UnityEngine.UI.Image)GetValue(ItemImageProperty);
            }

            set
            {
                SetValue(ItemImageProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Dropdown.value" />.</summary>
        public int Value
        {
            get
            {
                return (int)GetValue(ValueProperty);
            }

            set
            {
                SetValue(ValueProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Dropdown.options" />.</summary>
        /// <remarks>This is the content property; you can write as child elements in XAML.</remarks>
        public ICollection<DropdownOptionData> Options => (ICollection<DropdownOptionData>)GetValue(OptionsProperty);

        /// <summary>Gets or sets the source of options to template and display.</summary>
        public IEnumerable OptionsSource
        {
            get
            {
                return (IEnumerable)GetValue(OptionsSourceProperty);
            }

            set
            {
                SetValue(OptionsSourceProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="DataTemplate" /> to apply to the <see cref="OptionsSource" />.
        /// </summary>
        public DataTemplate OptionTemplate
        {
            get
            {
                return (DataTemplate)GetValue(OptionTemplateProperty);
            }

            set
            {
                SetValue(OptionTemplateProperty, value);
            }
        }

        public Dropdown()
        {
            _options = new TemplatableOptionData(this);
            _options.ChangeSource(OptionsSource);
            _options.ChangeTemplate(OptionTemplate);
        }

        /// <inheritdoc />
        protected override void OnBindingContextChanged()
        {
            foreach (var option in _options.ToImmutable())
            {
                SetInheritedBindingContext(option.Content, BindingContext);
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.template = Template;
            Body.captionText = CaptionText;
            Body.captionImage = CaptionImage;
            Body.itemText = ItemText;
            Body.itemImage = ItemImage;
            Body.onValueChanged.AddListener(value => SetValueCore(ValueProperty, value));
            Body.options = _options.data.list;
            Body.value = Value;
            Body.RefreshShownValue();

            base.AwakeInMainThread();
        }
    }
}

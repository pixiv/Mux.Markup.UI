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
    /// <summary>An abstract class to represent <see cref="T:UnityEngine.UI.Selectable" /> or its subclass.</summary>
    public abstract class Selectable<T> : Behaviour<T> where T : UnityEngine.UI.Selectable
    {
        /// <summary>Backing store for the <see cref="Interactable" /> property.</summary>
        public static readonly BindableProperty InteractableProperty = CreateBindableBodyProperty<bool>(
            "Interactable",
            typeof(Selectable<T>),
            (body, value) => body.interactable = value,
            true);

        /// <summary>Backing store for the <see cref="TargetGraphic" /> property.</summary>
        public static readonly BindableProperty TargetGraphicProperty = CreateBindableBodyProperty<UnityEngine.UI.Graphic>(
            "TargetGraphic",
            typeof(Selectable<T>),
            (body, value) => body.targetGraphic = value);

        /// <summary>Backing store for the <see cref="Transition" /> property.</summary>
        public static readonly BindableProperty TransitionProperty = CreateBindableBodyProperty<UnityEngine.UI.Selectable.Transition>(
            "Transition",
            typeof(Selectable<T>),
            (body, value) => body.transition = value,
            UnityEngine.UI.Selectable.Transition.ColorTint);

        /// <summary>Backing store for the <see cref="Colors" /> property.</summary>
        public static readonly BindableProperty ColorsProperty = CreateBindableBodyProperty<UnityEngine.UI.ColorBlock>(
            "Colors",
            typeof(Selectable<T>),
            (body, value) => body.colors = value,
            UnityEngine.UI.ColorBlock.defaultColorBlock);

        /// <summary>Backing store for the <see cref="SpriteState" /> property.</summary>
        public static readonly BindableProperty SpriteStateProperty = CreateBindableBodyProperty<UnityEngine.UI.SpriteState>(
            "SpriteState",
            typeof(Selectable<T>),
            (body, value) => body.spriteState = value);

        /// <summary>Backing store for the <see cref="AnimationTriggers" /> property.</summary>
        public static readonly BindableProperty AnimationTriggersProperty = CreateBindableBodyProperty<UnityEngine.UI.AnimationTriggers>(
            "AnimationTriggers",
            typeof(Selectable<T>),
            (body, value) => body.animationTriggers = value,
            null,
            BindingMode.OneWay,
            bindable => new UnityEngine.UI.AnimationTriggers());

        /// <summary>Backing store for the <see cref="Navigation" /> property.</summary>
        public static readonly BindableProperty NavigationProperty = CreateBindableBodyProperty<UnityEngine.UI.Navigation>(
            "Navigation",
            typeof(Selectable<T>),
            (body, value) => body.navigation = value,
            UnityEngine.UI.Navigation.defaultNavigation);

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Selectable.interactable" />.</summary>
        public bool Interactable
        {
            get
            {
                return (bool)GetValue(InteractableProperty);
            }

            set
            {
                SetValue(InteractableProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Selectable.targetGraphic" />.</summary>
        /// <seealso cref="Graphic{T}" />
        public UnityEngine.UI.Graphic TargetGraphic
        {
            get
            {
                return (UnityEngine.UI.Graphic)GetValue(TargetGraphicProperty);
            }

            set
            {
                SetValue(TargetGraphicProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Selectable.transition" />.</summary>
        public UnityEngine.UI.Selectable.Transition Transition
        {
            get
            {
                return (UnityEngine.UI.Selectable.Transition)GetValue(TransitionProperty);
            }

            set
            {
                SetValue(TransitionProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Selectable.colors" />.</summary>
        /// <seealso cref="ColorBlock" />
        public UnityEngine.UI.ColorBlock Colors
        {
            get
            {
                return (UnityEngine.UI.ColorBlock)GetValue(ColorsProperty);
            }

            set
            {
                SetValue(ColorsProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Selectable.spriteState" />.</summary>
        public UnityEngine.UI.SpriteState SpriteState
        {
            get
            {
                return (UnityEngine.UI.SpriteState)GetValue(SpriteStateProperty);
            }

            set
            {
                SetValue(SpriteStateProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Selectable.animationTriggers" />.</summary>
        /// <seealso cref="AnimationTriggers" />
        public UnityEngine.UI.AnimationTriggers AnimationTriggers
        {
            get
            {
                return (UnityEngine.UI.AnimationTriggers)GetValue(AnimationTriggersProperty);
            }

            set
            {
                SetValue(AnimationTriggersProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Selectable.navigation" />.</summary>
        public UnityEngine.UI.Navigation Navigation
        {
            get
            {
                return (UnityEngine.UI.Navigation)GetValue(NavigationProperty);
            }

            set
            {
                SetValue(NavigationProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void AddToInMainThread(UnityEngine.GameObject gameObject)
        {
            base.AddToInMainThread(gameObject);

            Body.interactable = Interactable;
            Body.targetGraphic = TargetGraphic;
            Body.transition = Transition;
            Body.colors = Colors;
            Body.spriteState = SpriteState;
            Body.animationTriggers = AnimationTriggers;
            Body.navigation = Navigation;
        }
    }

    /// <summary>A class to represent <see cref="T:UnityEngine.UI.Selectable" />.</summary>
    public class Selectable : Selectable<UnityEngine.UI.Selectable>
    {
    }
}

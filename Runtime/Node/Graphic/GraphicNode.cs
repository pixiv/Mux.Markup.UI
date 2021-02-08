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
    /// <summary>An abstract class that represents <see cref="T:UnityEngine.UI.Graphic" />.</summary>
    public abstract class Graphic<T> : Behaviour<T> where T : UnityEngine.UI.Graphic
    {
        /// <summary>Backing store for the <see cref="Color" /> property.</summary>
        public static readonly BindableProperty ColorProperty = CreateBindableBodyProperty<UnityEngine.Color>(
            "Color",
            typeof(Graphic<T>),
            (body, value) => body.color = value,
            UnityEngine.Color.white);

        /// <summary>Backing store for the <see cref="Material" /> property.</summary>
        public static readonly BindableProperty MaterialProperty = CreateBindableBodyProperty<UnityEngine.Material>(
            "Material",
            typeof(Graphic<T>),
            (body, value) => body.material = value);

        /// <summary>Backing store for the <see cref="RaycastTarget" /> property.</summary>
        public static readonly BindableProperty RaycastTargetProperty = CreateBindableBodyProperty<bool>(
            "RaycastTarget",
            typeof(Graphic<T>),
            (body, value) => body.raycastTarget = value,
            true);

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Graphic.color" />.</summary>
        /// <seealso cref="Color" />
        /// <seealso cref="Color32" />
        public UnityEngine.Color Color
        {
            get
            {
                return (UnityEngine.Color)GetValue(ColorProperty);
            }

            set
            {
                SetValue(ColorProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Graphic.material" />.</summary>
        public UnityEngine.Material Material
        {
            get
            {
                return (UnityEngine.Material)GetValue(MaterialProperty);
            }

            set
            {
                SetValue(MaterialProperty, value);
            }
        }

        /// <summary>A property that represents <see cref="P:UnityEngine.UI.Graphic.raycastTarget" />.</summary>
        public bool RaycastTarget
        {
            get
            {
                return (bool)GetValue(RaycastTargetProperty);
            }

            set
            {
                SetValue(RaycastTargetProperty, value);
            }
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.color = Color;
            Body.material = Material;
            Body.raycastTarget = RaycastTarget;

            base.AwakeInMainThread();
        }
    }
}

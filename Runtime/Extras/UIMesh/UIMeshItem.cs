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
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using Xamarin.Forms;

namespace Mux.Markup.Extras
{
    /// <summary>A class that represents vertices and triangles.</summary>
    public abstract class UIMeshItem : BindableObject, IDisposable
    {
        internal UIMesh mesh;
        internal abstract void AddTo(UnityEngine.UI.VertexHelper helper);

        /// <summary>
        /// A method that maps position in <see cref="T:UnityEngine.RectTransform" />
        /// normalized into [0, 1] to local space.
        /// </summary>
        protected UnityEngine.UIVertex Map(UnityEngine.UIVertex vertex)
        {
            var rect = ((UnityEngine.RectTransform)mesh.Body.transform).rect;

            vertex.position.x *= rect.width;
            vertex.position.y *= rect.height;

            return vertex;
        }

        public virtual void Dispose()
        {
            UnapplyBindings();
            mesh = null;
        }
    }

    /// <summary>
    /// A <see cref="UIMeshItem" /> with utilities useful to handle
    /// <see cref="ICollection{T}" />.
    /// </summary>
    public abstract class UIMeshItemWithCollection : UIMeshItem
    {
        /// <summary>
        /// A convenient method to create a new instance of the <see cref="BindableProperty" />
        /// class that represents a field or property of a <see cref="ICollection{T}" />.
        /// </summary>
        protected static BindableProperty CreateBindableCollectionProperty<T>(string name, Type declarer)
        {
            return BindableProperty.Create(
                name,
                typeof(ICollection<T>),
                declarer,
                null,
                BindingMode.OneWay,
                null,
                OnCollectionChanged,
                null,
                null,
                sender => CreateDefaultCollection<T>(sender));
        }

        private static ObservableCollection<T> CreateDefaultCollection<T>(BindableObject sender)
        {
            var collection = new ObservableCollection<T>();
            collection.CollectionChanged += ((UIMeshItemWithCollection)sender)._collectionHandler;
            return collection;
        }

        private static void OnCollectionChanged(BindableObject sender, object oldValue, object newValue)
        {
            var notifyingOld = oldValue as INotifyCollectionChanged;
            var notifyingNew = newValue as INotifyCollectionChanged;
            var item = (UIMeshItemWithCollection)sender;

            if (notifyingOld != null)
            {
                notifyingOld.CollectionChanged -= item._collectionHandler;
            }

            if (notifyingNew != null)
            {
                notifyingNew.CollectionChanged += item._collectionHandler;
            }

            var body = item.mesh?.Body;

            if (body != null)
            {
                body.SetVerticesDirty();
            }
        }

        private readonly NotifyCollectionChangedEventHandler _collectionHandler;

        public UIMeshItemWithCollection()
        {
            var weak = new WeakReference<UIMeshItemWithCollection>(this);
            NotifyCollectionChangedEventHandler handler = null;

            handler = (sender, args) =>
            {
                UIMeshItemWithCollection strong;

                if (weak.TryGetTarget(out strong))
                {
                    var body = strong.mesh?.Body;

                    if (body != null)
                    {
                        body.SetVerticesDirty();
                    }
                }
                else
                {
                    ((INotifyCollectionChanged)sender).CollectionChanged -= handler;
                }
            };

            _collectionHandler = handler;
        }

        internal void Unsubscribe(object collection)
        {
            var notifying = collection as INotifyCollectionChanged;

            if (notifying != null)
            {
                notifying.CollectionChanged -= _collectionHandler;
            }
        }
    }

    /// <summary>A <see cref="UIMeshItem" /> that represents a quad.</summary>
    /// <seealso cref="M:UnityEngine.UI.VertexHelper.AddUIVertexQuad" />
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
    ///     <mue:UIMesh>
    ///         <!--
    ///             You have to wrap items with mue:UIMesh.Items only when you
    ///             compile the interpreter with IL2CPP.
    ///             It is because ContentPropertyAttribute does not work with IL2CPP.
    ///         -->
    ///         <mue:UIMesh.Items>
    ///             <mue:UIVertexQuad>
    ///                 <!-- Wrapping with mue:UIVertexQuad.Verts for the same reason -->
    ///                 <mue:UIVertexQuad.Verts>
    ///                     <m:UIVertex Color="{m:Color R=0, G=0, B=0}" Position="{m:Vector3 X=-0.5, Y=-0.5, Z=0}" />
    ///                     <m:UIVertex Color="{m:Color R=0, G=0, B=1}" Position="{m:Vector3 X=-0.5, Y=0.5, Z=0}" />
    ///                     <m:UIVertex Color="{m:Color R=0, G=1, B=0}" Position="{m:Vector3 X=0.5, Y=0.5, Z=0}" />
    ///                     <m:UIVertex Color="{m:Color R=1, G=0, B=0}" Position="{m:Vector3 X=0.5, Y=-0.5, Z=0}" />
    ///                 </mue:UIVertexQuad.Verts>
    ///             </mue:UIVertexQuad>
    ///         </mue:UIMesh.Items>
    ///     </mue:UIMesh>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    [ContentProperty("Verts")]
    public class UIVertexQuad : UIMeshItemWithCollection
    {
        /// <summary>Backing store for <see cref="Verts" />.</summary>
        public static readonly BindableProperty VertsProperty =
            CreateBindableCollectionProperty<UnityEngine.UIVertex>("Verts", typeof(UIVertexQuad));

        /// <summary>4 Vertices representing the quad.</summary>
        public ICollection<UnityEngine.UIVertex> Verts
        {
            get
            {
                return (ICollection<UnityEngine.UIVertex>)GetValue(VertsProperty);
            }

            set
            {
                SetValue(VertsProperty, value);
            }
        }

        internal sealed override void AddTo(UnityEngine.UI.VertexHelper helper)
        {
            if (Verts != null)
            {
                var count = helper.currentVertCount;

                foreach (var vert in Verts)
                {
                    helper.AddVert(Map(vert));
                }

                helper.AddTriangle(count, count + 1, count + 2);
                helper.AddTriangle(count + 2, count + 3, count);
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            Unsubscribe(Verts);
        }
    }

    /// <summary>
    /// A <see cref="UIMeshItem" /> that represents a stream of custom
    /// <see cref="T:UnityEngine.UIVertex" /> and corresponding indices.
    /// </summary>
    /// <seealso cref="M:UnityEngine.UI.VertexHelper.AddUIVertexStream" />
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
    ///     <mue:UIMesh>
    ///         <!--
    ///             You have to wrap items with mue:UIMesh.Items only when you
    ///             compile the interpreter with IL2CPP.
    ///             It is because ContentPropertyAttribute does not work with IL2CPP.
    ///         -->
    ///         <mue:UIMesh.Items>
    ///             <mue:UIVertexStream>
    ///                 <mue:UIVertexStream.Verts>
    ///                     <m:UIVertex Color="{m:Color R=0, G=0, B=1}" Position="{m:Vector3 X=-0.5, Y=-0.5, Z=0}" />
    ///                     <m:UIVertex Color="{m:Color R=0, G=1, B=0}" Position="{m:Vector3 X=0, Y=0.5, Z=0}" />
    ///                     <m:UIVertex Color="{m:Color R=1, G=0, B=0}" Position="{m:Vector3 X=0.5, Y=-0.5, Z=0}" />
    ///                 </mue:UIVertexStream.Verts>
    ///                 <mue:UIVertexStream.Indices>
    ///                     <x:Int32>0</x:Int32>
    ///                     <x:Int32>1</x:Int32>
    ///                     <x:Int32>2</x:Int32>
    ///                 </mue:UIVertexStream.Indices>
    ///             </mue:UIVertexStream>
    ///         </mue:UIMesh.Items>
    ///     </mue:UIMesh>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    public class UIVertexStream : UIMeshItemWithCollection
    {
        /// <summary>Backing store for <see cref="Verts" />.</summary>
        public static readonly BindableProperty VertsProperty =
            CreateBindableCollectionProperty<UnityEngine.UIVertex>("Verts", typeof(UIVertexStream));

        /// <summary>Backing store for <see cref="Indices" />.</summary>
        public static readonly BindableProperty IndicesProperty =
            CreateBindableCollectionProperty<int>("Indices", typeof(UIVertexStream));

        /// <summary>
        /// The custom stream of verts to add to the <see cref="UIMesh" /> internal data.
        /// </summary>
        public ICollection<UnityEngine.UIVertex> Verts
        {
            get
            {
                return (ICollection<UnityEngine.UIVertex>)GetValue(VertsProperty);
            }

            set
            {
                SetValue(VertsProperty, value);
            }
        }

        /// <summary>
        /// The custom stream of indices to add to the <see cref="UIMesh" /> internal data.
        /// </summary>
        public ICollection<int> Indices
        {
            get
            {
                return (ICollection<int>)GetValue(IndicesProperty);
            }

            set
            {
                SetValue(IndicesProperty, value);
            }
        }

        internal sealed override void AddTo(UnityEngine.UI.VertexHelper helper)
        {
            if (Verts != null && Indices != null)
            {
                helper.AddUIVertexStream(Verts.Select(Map).ToList(), Indices.ToList());
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            Unsubscribe(Verts);
            Unsubscribe(Indices);
        }
    }

    /// <summary>A <see cref="UIMeshItem" /> that represents a list of triangles.</summary>
    /// <seealso cref="M:UnityEngine.UI.VertexHelper.AddUIVertexTriangleStream" />
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
    ///     <mue:UIMesh>
    ///         <!--
    ///             You only have to wrap items with mue:UIMesh.Items
    ///             when you compile the interpreter with IL2CPP.
    ///             It is because ContentPropertyAttribute does not work with IL2CPP.
    ///         -->
    ///         <mue:UIMesh.Items>
    ///             <mue:UIVertexTriangleStream>
    ///                 <!-- Wrapping with mue:UIVertexTriangleStream.Verts for the same reason -->
    ///                 <mue:UIVertexTriangleStream.Verts>
    ///                     <m:UIVertex Color="{m:Color R=0, G=0, B=1}" Position="{m:Vector3 X=-0.5, Y=-0.5, Z=0}" />
    ///                     <m:UIVertex Color="{m:Color R=0, G=1, B=0}" Position="{m:Vector3 X=0, Y=0.5, Z=0}" />
    ///                     <m:UIVertex Color="{m:Color R=1, G=0, B=0}" Position="{m:Vector3 X=0.5, Y=-0.5, Z=0}" />
    ///                 </mue:UIVertexTriangleStream.Verts>
    ///             </mue:UIVertexTriangleStream>
    ///         </mue:UIMesh.Items>
    ///     </mue:UIMesh>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    [ContentProperty("Verts")]
    public class UIVertexTriangleStream : UIMeshItemWithCollection
    {
        /// <summary>Backing store for <see cref="Verts" />.</summary>
        public static readonly BindableProperty VertsProperty =
            CreateBindableCollectionProperty<UnityEngine.UIVertex>("Verts", typeof(UIVertexStream));

        /// <summary>Vertices to add. Length should be divisible by 3.</summary>
        public ICollection<UnityEngine.UIVertex> Verts
        {
            get
            {
                return (ICollection<UnityEngine.UIVertex>)GetValue(VertsProperty);
            }

            set
            {
                SetValue(VertsProperty, value);
            }
        }

        internal sealed override void AddTo(UnityEngine.UI.VertexHelper helper)
        {
            if (Verts != null)
            {
                helper.AddUIVertexTriangleStream(Verts.Select(Map).ToList());
            }
        }

        /// <inheritdoc />
        public override void Dispose()
        {
            Unsubscribe(Verts);
        }
    }

    /// <summary>A <see cref="UIMeshItem" /> that represents a triangle.</summary>
    /// <seealso cref="M:UnityEngine.UI.VertexHelper.AddTriangle" />
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
    ///     <mue:UIMesh>
    ///         <!--
    ///             You only have to wrap items with mue:UIMesh.Items
    ///             when you compile the interpreter with IL2CPP.
    ///             It is because ContentPropertyAttribute does not work with IL2CPP.
    ///         -->
    ///         <mue:UIMesh.Items>
    ///             <mue:Triangle Indices="{m:Vector3Int X=0, Y=1, Z=2}" />
    ///             <mue:Vert Value="{m:UIVertex Color={m:Color R=0, G=0, B=1}, Position={m:Vector3 X=-0.5, Y=-0.5, Z=0}}" />
    ///             <mue:Vert Value="{m:UIVertex Color={m:Color R=0, G=1, B=0}, Position={m:Vector3 X=0, Y=0.5, Z=0}}" />
    ///             <mue:Vert Value="{m:UIVertex Color={m:Color R=1, G=0, B=0}, Position={m:Vector3 X=0.5, Y=-0.5, Z=0}}" />
    ///         </mue:UIMesh.Items>
    ///     </mue:UIMesh>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    [ContentProperty("Indices")]
    public class Triangle : UIMeshItem
    {
        /// <summary>Backing store for <see cref="Indices" />.</summary>
        public static readonly BindableProperty IndicesProperty = BindableProperty.Create(
            "Indices",
            typeof(UnityEngine.Vector3Int),
            typeof(Triangle),
            UnityEngine.Vector3Int.zero,
            BindingMode.OneWay,
            null,
            OnIndicesChanged);

        private static void OnIndicesChanged(BindableObject sender, object oldValue, object newValue)
        {
            var body = ((Triangle)sender).mesh?.Body;

            if (body != null)
            {
                body.SetVerticesDirty();
            }
        }

        /// <summary>Indicies into the positions array.</summary>
        public UnityEngine.Vector3Int Indices
        {
            get
            {
                return (UnityEngine.Vector3Int)GetValue(IndicesProperty);
            }

            set
            {
                SetValue(IndicesProperty, value);
            }
        }

        internal sealed override void AddTo(UnityEngine.UI.VertexHelper helper)
        {
            helper.AddTriangle(Indices.x, Indices.y, Indices.z);
        }
    }

    /// <summary>A <see cref="UIMeshItem" /> that represents a single vertex.</summary>
    /// <seealso cref="M:UnityEngine.UI.VertexHelper.AddVert" />
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
    ///     <mue:UIMesh>
    ///         <!--
    ///             You only have to wrap items with mue:UIMesh.Items
    ///             when you compile the interpreter with IL2CPP.
    ///             It is because ContentPropertyAttribute does not work with IL2CPP.
    ///         -->
    ///         <mue:UIMesh.Items>
    ///             <mue:Triangle Indices="{m:Vector3Int X=0, Y=1, Z=2}" />
    ///             <mue:Vert Value="{m:UIVertex Color={m:Color R=0, G=0, B=1}, Position={m:Vector3 X=-0.5, Y=-0.5, Z=0}}" />
    ///             <mue:Vert Value="{m:UIVertex Color={m:Color R=0, G=1, B=0}, Position={m:Vector3 X=0, Y=0.5, Z=0}}" />
    ///             <mue:Vert Value="{m:UIVertex Color={m:Color R=1, G=0, B=0}, Position={m:Vector3 X=0.5, Y=-0.5, Z=0}}" />
    ///         </mue:UIMesh.Items>
    ///     </mue:UIMesh>
    /// </m:RectTransform>
    /// ]]>
    /// </code>
    /// </example>
    [ContentProperty("Value")]
    public class Vert : UIMeshItem
    {
        /// <summary>Backing store for <see cref="Value" />.</summary>
        public static readonly BindableProperty ValueProperty = BindableProperty.Create(
            "Value",
            typeof(UnityEngine.UIVertex),
            typeof(Vert),
            UnityEngine.UIVertex.simpleVert,
            BindingMode.OneWay,
            null,
            OnValueChanged);

        private static void OnValueChanged(BindableObject sender, object oldValue, object newValue)
        {
            var body = ((Vert)sender).mesh?.Body;

            if (body != null)
            {
                body.SetVerticesDirty();
            }
        }

        /// <summary>A property that represents a vertex.</summary>
        public UnityEngine.UIVertex Value
        {
            get
            {
                return (UnityEngine.UIVertex)GetValue(ValueProperty);
            }

            set
            {
                SetValue(ValueProperty, value);
            }
        }

        internal sealed override void AddTo(UnityEngine.UI.VertexHelper helper)
        {
            helper.AddVert(Map(Value));
        }
    }
}

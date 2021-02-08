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

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Xamarin.Forms;

namespace Mux.Markup.Extras
{
    internal sealed class UIMeshItemCollection : TemplatableCollection<UIMeshItem>
    {
        private readonly ImmutableList<TemplatedItem<UIMeshItem>>.Builder _builder =
            ImmutableList.CreateBuilder<TemplatedItem<UIMeshItem>>();

        public UIMeshItemCollection(UIMesh container) : base(container)
        {
        }

        protected override IList<TemplatedItem<UIMeshItem>> GetList()
        {
            return _builder;
        }

        public override void ClearList()
        {
            foreach (var item in _builder)
            {
                item.Content.Dispose();
            }

            base.ClearList();
            ((UIMesh)container).Body?.SetVerticesDirty();
        }

        public override void InsertListRange(int index, IEnumerable<TemplatedItem<UIMeshItem>> enumerable)
        {
            var mesh = (UIMesh)container;
            var oldCount = _builder.Count;

            _builder.InsertRange(index, enumerable);

            foreach (var item in _builder.Skip(oldCount))
            {
                BindableObject.SetInheritedBindingContext(item.Content, mesh.BindingContext);
                item.Content.mesh = mesh;
            }

            mesh.Body?.SetVerticesDirty();
        }

        public override void MoveListRange(int from, int to, int count)
        {
            base.MoveListRange(from, to, count);
            ((UIMesh)container).Body?.SetVerticesDirty();
        }

        public override void RemoveListRange(int index, int count)
        {
            while (count > 0)
            {
                _builder[index].Content.Dispose();
                _builder.RemoveAt(index);
            }

            ((UIMesh)container).Body?.SetVerticesDirty();
        }

        public override void ReplaceListRange(int index, int count, IEnumerable<TemplatedItem<UIMeshItem>> enumerable)
        {
            var mesh = (UIMesh)container;

            foreach (var item in _builder.Skip(index).Take(count))
            {
                item.Content.Dispose();
            }

            base.ReplaceListRange(index, count, enumerable);

            foreach (var item in _builder.Skip(index).Take(count))
            {
                BindableObject.SetInheritedBindingContext(item.Content, mesh.BindingContext);
                item.Content.mesh = mesh;
            }

            mesh.Body?.SetVerticesDirty();
        }

        public ImmutableList<TemplatedItem<UIMeshItem>> ToImmutable()
        {
            return _builder.ToImmutable();
        }
    }
}

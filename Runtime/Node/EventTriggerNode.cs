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

using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Mux.Markup
{
    /// <summary>
    /// A <see cref="BindableObject" /> that represents <see cref="T:UnityEngine.EventSystems.EventTrigger.Entry" />.
    /// </summary>
    public class EventTriggerEntry : BindableObject
    {
        /// <summary>Backing store for the <see cref="EventID" /> property.</summary>
        public static readonly BindableProperty EventIDProperty = BindableProperty.Create(
            "EventID",
            typeof(UnityEngine.EventSystems.EventTriggerType),
            typeof(EventTriggerEntry),
            UnityEngine.EventSystems.EventTriggerType.PointerEnter,
            BindingMode.OneWay,
            null,
            OnEventIDChanged);

        private static void OnEventIDChanged(BindableObject sender, object oldValue, object newValue)
        {
            ((EventTriggerEntry)sender).entry.eventID = (UnityEngine.EventSystems.EventTriggerType)newValue;
        }

        internal readonly UnityEngine.EventSystems.EventTrigger.Entry entry = new UnityEngine.EventSystems.EventTrigger.Entry
        {
            eventID = UnityEngine.EventSystems.EventTriggerType.PointerEnter
        };

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.EventSystems.EventTrigger.Entry.eventID" />.
        /// </summary>
        public UnityEngine.EventSystems.EventTriggerType EventID
        {
            get
            {
                return (UnityEngine.EventSystems.EventTriggerType)GetValue(EventIDProperty);
            }

            set
            {
                SetValue(EventIDProperty, value);
            }
        }

        /// <summary>
        /// An event that represents <see cref="P:UnityEngine.EventSystems.EventTrigger.Entry.callback" />.
        /// </summary>
        public event UnityEngine.Events.UnityAction<UnityEngine.EventSystems.BaseEventData> Callback
        {
            add
            {
                Forms.mainThread.Send(state => entry.callback.AddListener(value), null);
            }

            remove
            {
                Forms.mainThread.Send(state => entry.callback.RemoveListener(value), null);
            }
        }
    }

    /// <summary>
    /// An <see cref="Behaviour{T}" /> that represents <see cref="T:UnityEngine.EventSystems.EventTrigger" />.
    /// </summary>
    [ContentProperty("Triggers")]
    public class EventTrigger : Behaviour<UnityEngine.EventSystems.EventTrigger>
    {
        private sealed class UnityTriggerCollection : TemplatableCollectionList<UnityEngine.EventSystems.EventTrigger.Entry>
        {
            public readonly List<UnityEngine.EventSystems.EventTrigger.Entry> list = new List<UnityEngine.EventSystems.EventTrigger.Entry>();

            protected override IList<UnityEngine.EventSystems.EventTrigger.Entry> GetList()
            {
                return list;
            }

            public override void InsertListRange(int index, IEnumerable<UnityEngine.EventSystems.EventTrigger.Entry> enumerable)
            {
                list.InsertRange(index, enumerable);
            }

            public override void RemoveListRange(int index, int count)
            {
                list.RemoveRange(index, count);
            }
        }

        private sealed class TriggerCollection : TemplatableCollection<EventTriggerEntry>
        {
            private readonly ImmutableList<TemplatedItem<EventTriggerEntry>>.Builder _builder =
                ImmutableList.CreateBuilder<TemplatedItem<EventTriggerEntry>>();

            public readonly UnityTriggerCollection _entries = new UnityTriggerCollection();

            private static IEnumerable<UnityEngine.EventSystems.EventTrigger.Entry> SelectEntries(IEnumerable<TemplatedItem<EventTriggerEntry>> enumerable)
            {
                foreach (var item in enumerable)
                {
                    yield return item.Content.entry;
                }
            }

            public TriggerCollection(BindableObject container) : base(container)
            {
            }

            protected override IList<TemplatedItem<EventTriggerEntry>> GetList()
            {
                return _builder;
            }

            public override void ClearList()
            {
                base.ClearList();
                Forms.mainThread.Send(state => _entries.ClearList(), null);
            }

            public override void InsertListRange(int index, IEnumerable<TemplatedItem<EventTriggerEntry>> enumerable)
            {
                _builder.InsertRange(index, enumerable);
                Forms.mainThread.Send(state => _entries.InsertListRange(index, SelectEntries(enumerable)), null);
            }

            public override void MoveListRange(int from, int to, int count)
            {
                base.MoveListRange(from, to, count);
                Forms.mainThread.Send(state => _entries.MoveListRange(from, to, count), null);
            }

            public override void RemoveListRange(int index, int count)
            {
                for (var remaining = count; remaining > 0; remaining--)
                {
                    _builder.RemoveAt(index);
                }

                Forms.mainThread.Send(state => _entries.RemoveListRange(index, count), null);
            }

            public override void ReplaceListRange(int index, int count, IEnumerable<TemplatedItem<EventTriggerEntry>> enumerable)
            {
                base.ReplaceListRange(index, count, enumerable);
                Forms.mainThread.Send(state => _entries.ReplaceListRange(index, count, SelectEntries(enumerable)), null);
            }

            public ImmutableList<TemplatedItem<EventTriggerEntry>> ToImmutable()
            {
                return _builder.ToImmutable();
            }
        }

        /// <summary>Backing store for the <see cref="Triggers" /> property.</summary>
        public static readonly BindableProperty TriggersProperty = BindableProperty.CreateReadOnly(
            "Triggers",
            typeof(ICollection<EventTriggerEntry>),
            typeof(EventTrigger),
            null,
            BindingMode.OneWayToSource,
            null,
            null,
            null,
            null,
            CreateDefaultTriggers).BindableProperty;

        /// <summary>Backing store for the <see cref="TriggersSource" /> property.</summary>
        public static readonly BindableProperty TriggersSourceProperty = BindableProperty.Create(
            "TriggersSource",
            typeof(IEnumerable),
            typeof(EventTrigger),
            null,
            BindingMode.OneWay,
            null,
            OnTriggersSourceChanged);

        /// <summary>Backing store for the <see cref="TriggerTemplate" /> property.</summary>
        public static readonly BindableProperty TriggerTemplateProperty = BindableProperty.Create(
            "TriggerTemplate",
            typeof(DataTemplate),
            typeof(EventTrigger),
            null,
            BindingMode.OneWay,
            null,
            OnTriggerTemplateChanged);

        private static object CreateDefaultTriggers(BindableObject sender)
        {
            return ((EventTrigger)sender)._triggers;
        }

        private static void OnTriggersSourceChanged(BindableObject sender, object oldValue, object newValue)
        {
            ((EventTrigger)sender)._triggers.ChangeSource((IEnumerable)newValue);
        }

        private static void OnTriggerTemplateChanged(BindableObject sender, object oldValue, object newValue)
        {
            ((EventTrigger)sender)._triggers.ChangeTemplate((DataTemplate)newValue);
        }

        private readonly TriggerCollection _triggers;

        /// <summary>
        /// A property that represents <see cref="P:UnityEngine.EventSystems.EventTrigger.triggers" />.
        /// </summary>
        /// <remarks>This is the content property; you can write as child elements in XAML.</remarks>
        public ICollection<EventTriggerEntry> Triggers => (ICollection<EventTriggerEntry>)GetValue(TriggersProperty);

        /// <summary>Gets or sets the source of entries to template and display.</summary>
        public IEnumerable TriggersSource
        {
            get
            {
                return (IEnumerable)GetValue(TriggersSourceProperty);
            }

            set
            {
                SetValue(TriggersSourceProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="T:DataTemplate" /> to apply to the <see cref="TriggersSource" />.
        /// </summary>
        public DataTemplate TriggerTemplate
        {
            get
            {
                return (DataTemplate)GetValue(TriggerTemplateProperty);
            }

            set
            {
                SetValue(TriggerTemplateProperty, value);
            }
        }

        public EventTrigger()
        {
            _triggers = new TriggerCollection(this);
            _triggers.ChangeSource(TriggersSource);
            _triggers.ChangeTemplate(TriggerTemplate);
        }

        /// <inheritdoc />
        protected override void AwakeInMainThread()
        {
            Body.triggers = _triggers._entries.list;
            base.AwakeInMainThread();
        }

        /// <inheritdoc />
        protected override void OnBindingContextChanged()
        {
            foreach (var trigger in _triggers.ToImmutable())
            {
                SetInheritedBindingContext(trigger.Content, BindingContext);
            }
        }
    }
}

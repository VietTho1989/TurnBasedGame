using frame8.Logic.Misc.Visual.UI.ScrollRectItemsAdapter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;

namespace frame8.ScrollRectItemsAdapter.Util
{
	/// <summary>
	/// <para>Very handy List implementation that delays object creation until it's accessed,</para>
	/// <para>although the underlying List is still allocated with all slots from the beginning, only that they have default values - default(T)</para>
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class LazyList<T>
	{
		public T this[int key]
		{
			get
			{
				T res = _BackingList[key];
				if (res == null)
					_BackingList[key] = res = _NewValueCreator(key);

				//if (_BackingList.TryGetValue(key, out res))
				//	return res;

				//res = _NewValueCeator(key);
				//_BackingList[key] = res;

				////if (IndexOfFirstExistingValue > key)
				////	IndexOfFirstExistingValue = key;

				////if (IndexOfLastExistingValue < key)
				////	IndexOfLastExistingValue = key;

				return res;
			}
			set { _BackingList[key] = value; }
		}

		//public ICollection<int> Keys { get { return _BackingDictionary.Keys; } }

		//public ICollection<TValue> Values { get { return _BackingDictionary.Values; } }

		public int Count { get { return _BackingList.Count; } }

		/// <summary>
		/// Returns an enumerable version of this list, which only contains the already-cached values
		/// </summary>
		public EnumerableLazyList AsEnumerableForExistingItems { get { return new EnumerableLazyList(this); } }
		//public int InitializedCount { get; private set; }

		//public int VirtualCount
		//{
		//	get { return _VirtualCount; }
		//	private set
		//	{
		//		_VirtualCount = value;

		//		IndexOfFirstExistingValue = IndexOfLastExistingValue = -1;
		//	}
		//}
		//public int IndexOfFirstExistingValue { get; private set; }
		//public int IndexOfLastExistingValue { get; private set; }

		//public bool IsReadOnly { get { return false; } }


		//IDictionary<int, TValue> BackingDictionaryAsInterface { get { return (_BackingDictionary as IDictionary<int, TValue>); } }

		List<T> _BackingList = new List<T>();
		Func<int, T> _NewValueCreator;
		//int _VirtualCount;


		public LazyList(Func<int, T> newValueCreator, int initialCount)
		{
			initialCount = initialCount > 0 ? initialCount : 0;
			_NewValueCreator = newValueCreator;
			InitWithNewCount(initialCount);
		}

		public void InitWithNewCount(int newCount) { _BackingList = new List<T>(Array.CreateInstance(typeof(T), newCount) as T[]); }
		public void Add(int count) { _BackingList.AddRange(Array.CreateInstance(typeof(T), count) as T[]); }
		public void InsertAtStart(int count) { _BackingList.InsertRange(0, Array.CreateInstance(typeof(T), count) as T[]); }
		public void Insert(int index, int count) { _BackingList.InsertRange(index, Array.CreateInstance(typeof(T), count) as T[]); }
		public void Clear() { _BackingList.Clear(); }
		public void Remove(T value) { _BackingList.Remove(value); }
		public void RemoveAt(int index) { _BackingList.RemoveAt(index); }

		public int IndexOf(T value){
			return _BackingList.IndexOf (value);
		}

		IEnumerator<T> GetEnumeratorForExistingItems()
		{
			for (int i = 0; i < Count; ++i)
			{
				var v = _BackingList[i];
				if (v != null)
					yield return v;
			}
			yield break;
		}


		public class EnumerableLazyList : IEnumerable<T>
		{
			LazyList<T> _LazyList;


			internal EnumerableLazyList(LazyList<T> lazyList) { _LazyList = lazyList; }

			public IEnumerator<T> GetEnumerator() { return _LazyList.GetEnumeratorForExistingItems(); }

			IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
		}

		//public void Add(int key, TValue value) { _BackingDictionary.Add(key, value); }
		//public void Add(KeyValuePair<int, TValue> item) { BackingDictionaryAsInterface.Add(item); }
		//public bool Contains(KeyValuePair<int, TValue> item) { return _BackingDictionary.Contains(item); }
		//public bool ContainsKey(int key) { return key >= FirstIndex && key <= LastIndex; }
		//public void CopyTo(KeyValuePair<int, TValue>[] array, int arrayIndex) { BackingDictionaryAsInterface.CopyTo(array, arrayIndex); }
		//public IEnumerator<KeyValuePair<int, TValue>> GetEnumerator() { return _BackingDictionary.GetEnumerator(); }
		//public bool Remove(int key) { return if (_BackingList.Remove(key); }
		//public bool Remove(KeyValuePair<int, TValue> item) { return BackingDictionaryAsInterface.Remove(item); }
		//public bool TryGetValue(int key, out TValue value) { return _BackingDictionary.TryGetValue(key, out value); }
		//IEnumerator IEnumerable.GetEnumerator() { return GetEnumerator(); }
	}
}

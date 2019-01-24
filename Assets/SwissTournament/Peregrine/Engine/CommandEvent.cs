using System.Collections.Generic;
using System.Linq;

namespace Peregrine.Engine
{
	/// <summary>
	/// A raw event loaded from an event store.
	/// </summary>
	public class CommandEvent
	{
		public readonly int Sequence;
		public readonly string AggregateId;
		public readonly string Name;
		// public readonly IReadOnlyDictionary<string, string> Properties;
		public readonly Dictionary<string, string> Properties;

		public CommandEvent(int sequence, string aggregateId, string name, IEnumerable<KeyValuePair<string, string>> properties)
		{
			Sequence = sequence;
			AggregateId = aggregateId;
			Name = name;
			Properties = (properties ?? Enumerable.Empty<KeyValuePair<string, string>>())
				.ToDictionary(kvp => kvp.Key, kvp => kvp.Value);
		}
	}
}

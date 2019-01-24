
namespace Peregrine.Engine
{
	public class RemovePlayerCommand
	{
		public readonly Player Player;

		public RemovePlayerCommand(Player player)
		{
			Player = player;
		}
	}
}

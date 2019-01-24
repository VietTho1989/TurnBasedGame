
namespace Peregrine.Engine
{
	public class AddPlayerCommand
	{
		public readonly Player Player;

		public AddPlayerCommand(Player player)
		{
			Player = player;
		}
	}
}

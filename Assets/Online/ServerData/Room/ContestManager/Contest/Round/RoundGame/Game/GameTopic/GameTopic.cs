using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameTopic : Topic
{

	#region Constructor

	public enum Property
	{

	}

	public GameTopic() : base()
	{

	}

	#endregion

	public override Type getType ()
	{
		return Type.Game;
	}

	public override bool isCanSendNormalMessage (uint userId)
	{
		return true;
	}

	#region add message

	public void addGameMove(Turn turn, GameMove gameMove)
	{
		if (gameMove.isCanMakeMoveMessage ()) {
			ChatRoom chatRoom = this.findDataInParent<ChatRoom> ();
			if (chatRoom != null) {
				// Make new message
				ChatMessage chatMessage = new ChatMessage ();
				{
					chatMessage.uid = chatRoom.messages.makeId ();
					// state
					chatMessage.state.v = ChatMessage.State.Normal;
					// time
					chatMessage.time.v = Global.getRealTimeInMiliSeconds ();
					// content
					{
						ChatGameMoveContent content = new ChatGameMoveContent ();
						{
							content.uid = chatMessage.content.makeId ();
							// turn
							{
								Turn cloneTurn = (Turn)DataUtils.cloneData (turn);
								{
									cloneTurn.uid = 0;
								}
								content.turn.v = cloneTurn;
							}
							// gameMove
							{
								GameMove cloneGameMove = (GameMove)DataUtils.cloneData (gameMove);
								{
									cloneGameMove.uid = 0;
								}
								content.gameMove.v = cloneGameMove;
							}
						}
						chatMessage.content.v = content;
					}
				}
				// Add
				chatRoom.messages.add (chatMessage);
			} else {
				Debug.LogError ("chatRoom null: " + this);
			}
		}
	}

	#endregion

}
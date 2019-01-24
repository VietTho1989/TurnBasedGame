using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GlobalChat : Data
{

	public VP<ChatRoom> general;

	public VP<ChatRoom> shortQuestion;

	public VP<ChatRoom> suggestion;

	public VP<ChatRoom> bugReport;

	public VP<ChatRoom> offTopic;

	#region Constructor

	public enum Property
	{
		general,
		shortQuestion,
		suggestion,
		bugReport,
		offTopic
	}

	public GlobalChat()
	{
		// general
		{
			ChatRoom chatRoom = new ChatRoom ();
			{
				chatRoom.topic.v = new GeneralTopic ();
			}
			this.general = new VP<ChatRoom> (this, (byte)Property.general, chatRoom);
		}
		// shortQuestion
		{
			ChatRoom chatRoom = new ChatRoom ();
			{
				chatRoom.topic.v = new ShortQuestionTopic ();
			}
			this.shortQuestion = new VP<ChatRoom> (this, (byte)Property.shortQuestion, chatRoom);
		}
		// suggestion
		{
			ChatRoom chatRoom = new ChatRoom ();
			{
				chatRoom.topic.v = new SuggestionTopic();
			}
			this.suggestion = new VP<ChatRoom> (this, (byte)Property.suggestion, chatRoom);
		}
		// bugReport
		{
			ChatRoom chatRoom = new ChatRoom ();
			{
				chatRoom.topic.v = new BugTopic ();
			}
			this.bugReport = new VP<ChatRoom> (this, (byte)Property.bugReport, chatRoom);
		}
		// offTopic
		{
			ChatRoom chatRoom = new ChatRoom ();
			{
				chatRoom.topic.v = new OffTopic ();
			}
			this.offTopic = new VP<ChatRoom> (this, (byte)Property.offTopic, chatRoom);
		}
	}

	#endregion

	public List<ChatRoom> getEnableChatRooms()
	{
		List<ChatRoom> ret = new List<ChatRoom> ();
		{
			// general
			{
				ChatRoom general = this.general.v;
				if (general != null) {
					if (general.isEnable.v) {
						ret.Add (general);
					}
				} else {
					Debug.LogError ("general null: " + this);
				}
			}
			// shortQuestion
			{
				ChatRoom shortQuestion = this.shortQuestion.v;
				if (shortQuestion != null) {
					if (shortQuestion.isEnable.v) {
						ret.Add (shortQuestion);
					}
				} else {
					Debug.LogError ("shortQuestion null: " + this);
				}
			}
			// suggestion
			{
				ChatRoom suggestion = this.suggestion.v;
				if (suggestion != null) {
					if (suggestion.isEnable.v) {
						ret.Add (suggestion);
					}
				} else {
					Debug.LogError ("suggestion null: " + this);
				}
			}
			// bugReport
			{
				ChatRoom bugReport = this.bugReport.v;
				if (bugReport != null) {
					if (bugReport.isEnable.v) {
						ret.Add (bugReport);
					}
				} else {
					Debug.LogError ("bugReport null: " + this);
				}
			}
			// offTopic
			{
				ChatRoom offTopic = this.offTopic.v;
				if (offTopic != null) {
					if (offTopic.isEnable.v) {
						ret.Add (offTopic);
					}
				} else {
					Debug.LogError ("offTopic null: " + this);
				}
			}
		}
		return ret;
	}

}
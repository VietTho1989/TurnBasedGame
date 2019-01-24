using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Foundation.Tasks;
using AdvancedCoroutines;
using Facebook.Unity;

namespace LoginState
{
	public class StepGetDataFacebookUpdate : UpdateBehavior<StepGetDataFacebook>
	{

		#region update

		public override void update ()
		{
			if (dirty) {
				dirty = false;
				if (this.data != null) {
					switch (this.data.state.v) {
					case StepGetDataFacebook.State.Start:
						{
							destroyRoutine (wait);
							StopCoroutine (TaskGetData ());
							this.data.state.v = StepGetDataFacebook.State.Get;
						}
						break;
					case StepGetDataFacebook.State.Get:
						{
							destroyRoutine (wait);
							// task facebook
							{
								StartCoroutine (TaskGetData ());
							}
							this.data.state.v = StepGetDataFacebook.State.Wait;
						}
						break;
					case StepGetDataFacebook.State.Wait:
						{
							// task wait
							{
								if (Routine.IsNull (wait)) {
									wait = CoroutineManager.StartCoroutine (TaskWait (), this.gameObject);
								} else {
									Debug.LogError ("Why routine != null: " + this);
								}
							}
						}
						break;
					default:
						Debug.LogError ("unknown state: " + this.data.state.v + "; " + this);
						break;
					}
				} else {
					Debug.LogError ("data null: " + this);
				}
			}
		}

		public override bool isShouldDisableUpdate ()
		{
			return false;
		}

		#endregion

		#region task getFacebookData

		private Routine getData;

		public IEnumerator TaskGetData()
		{
			ILoginResult waitResult = null;
			// Login Facebook
			{
				var perms = new List<string> (){ "public_profile", "email", "user_friends" };
				FB.LogInWithReadPermissions (perms,
					result => {
						waitResult = result;
					});	
			}
			// Task wait result
			yield return new WaitUntil(() => waitResult != null);
			// Process result
			{
				if (FB.IsLoggedIn) {
					// Debug.LogError ("FBLogin success: " + waitResult.AccessToken);
					// Debug.LogError ("FBLogin success userId: " + waitResult.AccessToken.UserId);
					// Request Username
					{
						IGraphResult r = null;
						;
						// Facebook request
						FB.API ("/me?fields=first_name,last_name,friends", HttpMethod.GET, delegate (IGraphResult trueR) {
							// Debug.LogError("get facebook information: "+trueR);
							r = trueR;                   
						});
						// Wait
						yield return new WaitUntil (() => r != null);
						// Process data
						{
							string firstName = r.ResultDictionary ["first_name"].ToString ();
							string lastName = r.ResultDictionary ["last_name"].ToString ();
							// Debug.LogError ("firstName, lastName: " + firstName + "; " + lastName);
							// Find AccountFacebookMessage
							AccountFacebook accountFacebook = null;
							{
								if (this.data != null) {
									Login login = this.data.findDataInParent<Login> ();
									if (login != null) {
										if (login.account.v != null && login.account.v is AccountFacebook) {
											accountFacebook = login.account.v as AccountFacebook;
										}
									} else {
										Debug.LogError ("login null: " + this);
									}
								} else {
									Debug.LogError ("data null: " + this);
								}
							}
							if (accountFacebook != null) {
								accountFacebook.userId.v = waitResult.AccessToken.UserId;
								accountFacebook.firstName.v = firstName;
								accountFacebook.lastName.v = lastName;
							} else {
								Debug.LogError ("accountFacebook null: " + this);
							}
						}
					}
					// Chuyen sang step Login
					{
						if (this.data != null) {
							// chuyen sange login step
							{
								Log log = this.data.findDataInParent<Log> ();
								if (log != null) {
									StepLogin stepLogin = new StepLogin ();
									{
										stepLogin.uid = log.step.makeId ();
									}
									log.step.v = stepLogin;
								} else {
									Debug.LogError ("log null: " + this);
								}
							}
						} else {
							Debug.LogError ("data null: " + this);
						}
					}
				} else {
					Debug.LogError ("loginFacebook error: " + waitResult.RawResult);
					// chuyen sang login fail
					if (this.data != null) {
						Login login = this.data.findDataInParent<Login> ();
						if (login != null) {
							None none = new None ();
							{
								none.uid = login.state.makeId ();
								// state
								{
									StateFail stateFail = new StateFail ();
									{
										stateFail.uid = none.state.makeId ();
										stateFail.reason.v = StateFail.Reason.GetFacebookDataFail;
									}
									none.state.v = stateFail;
								}
							}
							login.state.v = none;
						} else {
							Debug.LogError ("login null: " + this);
						}
					} else {
						Debug.LogError ("data null: " + this);
					}
					yield break;
				}
			}
		}

		#endregion

		#region Task wait

		private Routine wait;

		public IEnumerator TaskWait()
		{
			if (this.data != null) {
				yield return new Wait (300f);
				// Login facebook fail
				if (this.data != null) {
					Login login = this.data.findDataInParent<Login> ();
					if (login != null) {
						None none = new None ();
						{
							none.uid = login.state.makeId ();
							// state
							{
								StateFail stateFail = new StateFail ();
								{
									stateFail.uid = none.state.makeId ();
									stateFail.reason.v = StateFail.Reason.GetFacebookDataFail;
								}
								none.state.v = stateFail;
							}
						}
						login.state.v = none;
					} else {
						Debug.LogError ("login null: " + this);
					}
				}
			} else {
				Debug.LogError ("data null: " + this);
			}
		}

		public override List<Routine> getRoutineList ()
		{
			List<Routine> ret = new List<Routine> ();
			{
				ret.Add (wait);
			}
			return ret;
		}

		#endregion

		#region implement callBacks

		public override void onAddCallBack<T> (T data)
		{
			if (data is StepGetDataFacebook) {
				dirty = true;
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onRemoveCallBack<T> (T data, bool isHide)
		{
			if (data is StepGetDataFacebook) {
				StepGetDataFacebook stepGetDataFacebook = data as StepGetDataFacebook;
				{

				}
				this.setDataNull (stepGetDataFacebook);
				return;
			}
			Debug.LogError ("Don't process: " + data + "; " + this);
		}

		public override void onUpdateSync<T> (WrapProperty wrapProperty, List<Sync<T>> syncs)
		{
			if (WrapProperty.checkError (wrapProperty)) {
				return;
			}
			if (wrapProperty.p is StepGetDataFacebook) {
				switch ((StepGetDataFacebook.Property)wrapProperty.n) {
				case StepGetDataFacebook.Property.state:
					dirty = true;
					break;
				default:
					Debug.LogError ("Don't process: " + wrapProperty + "; " + this);
					break;
				}
				return;
			}
			Debug.LogError ("Don't process: " + wrapProperty + "; " + syncs + "; " + this);
		}

		#endregion

	}
}
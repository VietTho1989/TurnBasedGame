#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// System.Object
struct Il2CppObject;
// UnityImageLoader.Utils.AsyncTask/DoInBackgroundDelegate
struct DoInBackgroundDelegate_t2264897953;
// UnityImageLoader.Utils.AsyncTask/OnPostExecuteDelegate
struct OnPostExecuteDelegate_t719276473;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityImageLoader.Utils.AsyncTask
struct  AsyncTask_t1080237985  : public MonoBehaviour_t1158329972
{
public:
	// System.Boolean UnityImageLoader.Utils.AsyncTask::isCompleted
	bool ___isCompleted_2;
	// System.Object UnityImageLoader.Utils.AsyncTask::result
	Il2CppObject * ___result_3;
	// UnityImageLoader.Utils.AsyncTask/DoInBackgroundDelegate UnityImageLoader.Utils.AsyncTask::doInBackground
	DoInBackgroundDelegate_t2264897953 * ___doInBackground_4;
	// UnityImageLoader.Utils.AsyncTask/OnPostExecuteDelegate UnityImageLoader.Utils.AsyncTask::onPostExecute
	OnPostExecuteDelegate_t719276473 * ___onPostExecute_5;

public:
	inline static int32_t get_offset_of_isCompleted_2() { return static_cast<int32_t>(offsetof(AsyncTask_t1080237985, ___isCompleted_2)); }
	inline bool get_isCompleted_2() const { return ___isCompleted_2; }
	inline bool* get_address_of_isCompleted_2() { return &___isCompleted_2; }
	inline void set_isCompleted_2(bool value)
	{
		___isCompleted_2 = value;
	}

	inline static int32_t get_offset_of_result_3() { return static_cast<int32_t>(offsetof(AsyncTask_t1080237985, ___result_3)); }
	inline Il2CppObject * get_result_3() const { return ___result_3; }
	inline Il2CppObject ** get_address_of_result_3() { return &___result_3; }
	inline void set_result_3(Il2CppObject * value)
	{
		___result_3 = value;
		Il2CppCodeGenWriteBarrier(&___result_3, value);
	}

	inline static int32_t get_offset_of_doInBackground_4() { return static_cast<int32_t>(offsetof(AsyncTask_t1080237985, ___doInBackground_4)); }
	inline DoInBackgroundDelegate_t2264897953 * get_doInBackground_4() const { return ___doInBackground_4; }
	inline DoInBackgroundDelegate_t2264897953 ** get_address_of_doInBackground_4() { return &___doInBackground_4; }
	inline void set_doInBackground_4(DoInBackgroundDelegate_t2264897953 * value)
	{
		___doInBackground_4 = value;
		Il2CppCodeGenWriteBarrier(&___doInBackground_4, value);
	}

	inline static int32_t get_offset_of_onPostExecute_5() { return static_cast<int32_t>(offsetof(AsyncTask_t1080237985, ___onPostExecute_5)); }
	inline OnPostExecuteDelegate_t719276473 * get_onPostExecute_5() const { return ___onPostExecute_5; }
	inline OnPostExecuteDelegate_t719276473 ** get_address_of_onPostExecute_5() { return &___onPostExecute_5; }
	inline void set_onPostExecute_5(OnPostExecuteDelegate_t719276473 * value)
	{
		___onPostExecute_5 = value;
		Il2CppCodeGenWriteBarrier(&___onPostExecute_5, value);
	}
};

struct AsyncTask_t1080237985_StaticFields
{
public:
	// System.Object UnityImageLoader.Utils.AsyncTask::locker
	Il2CppObject * ___locker_6;
	// UnityEngine.GameObject UnityImageLoader.Utils.AsyncTask::asyncTaskGo
	GameObject_t1756533147 * ___asyncTaskGo_7;

public:
	inline static int32_t get_offset_of_locker_6() { return static_cast<int32_t>(offsetof(AsyncTask_t1080237985_StaticFields, ___locker_6)); }
	inline Il2CppObject * get_locker_6() const { return ___locker_6; }
	inline Il2CppObject ** get_address_of_locker_6() { return &___locker_6; }
	inline void set_locker_6(Il2CppObject * value)
	{
		___locker_6 = value;
		Il2CppCodeGenWriteBarrier(&___locker_6, value);
	}

	inline static int32_t get_offset_of_asyncTaskGo_7() { return static_cast<int32_t>(offsetof(AsyncTask_t1080237985_StaticFields, ___asyncTaskGo_7)); }
	inline GameObject_t1756533147 * get_asyncTaskGo_7() const { return ___asyncTaskGo_7; }
	inline GameObject_t1756533147 ** get_address_of_asyncTaskGo_7() { return &___asyncTaskGo_7; }
	inline void set_asyncTaskGo_7(GameObject_t1756533147 * value)
	{
		___asyncTaskGo_7 = value;
		Il2CppCodeGenWriteBarrier(&___asyncTaskGo_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

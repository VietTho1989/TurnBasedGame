#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"
#include "UnityEngine_UnityEngine_Vector22243707579.h"
#include "mscorlib_System_Nullable_1_gen339576247.h"

// System.Collections.Generic.Stack`1<System.String>
struct Stack_1_t3116948387;
// System.String
struct String_t;
// UnityEngine.GUIStyle
struct GUIStyle_t1799908754;
// UnityEngine.Texture2D
struct Texture2D_t3542995729;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Facebook.Unity.Example.ConsoleBase
struct  ConsoleBase_t4290192428  : public MonoBehaviour_t1158329972
{
public:
	// System.String Facebook.Unity.Example.ConsoleBase::status
	String_t* ___status_4;
	// System.String Facebook.Unity.Example.ConsoleBase::lastResponse
	String_t* ___lastResponse_5;
	// UnityEngine.Vector2 Facebook.Unity.Example.ConsoleBase::scrollPosition
	Vector2_t2243707579  ___scrollPosition_6;
	// System.Nullable`1<System.Single> Facebook.Unity.Example.ConsoleBase::scaleFactor
	Nullable_1_t339576247  ___scaleFactor_7;
	// UnityEngine.GUIStyle Facebook.Unity.Example.ConsoleBase::textStyle
	GUIStyle_t1799908754 * ___textStyle_8;
	// UnityEngine.GUIStyle Facebook.Unity.Example.ConsoleBase::buttonStyle
	GUIStyle_t1799908754 * ___buttonStyle_9;
	// UnityEngine.GUIStyle Facebook.Unity.Example.ConsoleBase::textInputStyle
	GUIStyle_t1799908754 * ___textInputStyle_10;
	// UnityEngine.GUIStyle Facebook.Unity.Example.ConsoleBase::labelStyle
	GUIStyle_t1799908754 * ___labelStyle_11;
	// UnityEngine.Texture2D Facebook.Unity.Example.ConsoleBase::<LastResponseTexture>k__BackingField
	Texture2D_t3542995729 * ___U3CLastResponseTextureU3Ek__BackingField_12;

public:
	inline static int32_t get_offset_of_status_4() { return static_cast<int32_t>(offsetof(ConsoleBase_t4290192428, ___status_4)); }
	inline String_t* get_status_4() const { return ___status_4; }
	inline String_t** get_address_of_status_4() { return &___status_4; }
	inline void set_status_4(String_t* value)
	{
		___status_4 = value;
		Il2CppCodeGenWriteBarrier(&___status_4, value);
	}

	inline static int32_t get_offset_of_lastResponse_5() { return static_cast<int32_t>(offsetof(ConsoleBase_t4290192428, ___lastResponse_5)); }
	inline String_t* get_lastResponse_5() const { return ___lastResponse_5; }
	inline String_t** get_address_of_lastResponse_5() { return &___lastResponse_5; }
	inline void set_lastResponse_5(String_t* value)
	{
		___lastResponse_5 = value;
		Il2CppCodeGenWriteBarrier(&___lastResponse_5, value);
	}

	inline static int32_t get_offset_of_scrollPosition_6() { return static_cast<int32_t>(offsetof(ConsoleBase_t4290192428, ___scrollPosition_6)); }
	inline Vector2_t2243707579  get_scrollPosition_6() const { return ___scrollPosition_6; }
	inline Vector2_t2243707579 * get_address_of_scrollPosition_6() { return &___scrollPosition_6; }
	inline void set_scrollPosition_6(Vector2_t2243707579  value)
	{
		___scrollPosition_6 = value;
	}

	inline static int32_t get_offset_of_scaleFactor_7() { return static_cast<int32_t>(offsetof(ConsoleBase_t4290192428, ___scaleFactor_7)); }
	inline Nullable_1_t339576247  get_scaleFactor_7() const { return ___scaleFactor_7; }
	inline Nullable_1_t339576247 * get_address_of_scaleFactor_7() { return &___scaleFactor_7; }
	inline void set_scaleFactor_7(Nullable_1_t339576247  value)
	{
		___scaleFactor_7 = value;
	}

	inline static int32_t get_offset_of_textStyle_8() { return static_cast<int32_t>(offsetof(ConsoleBase_t4290192428, ___textStyle_8)); }
	inline GUIStyle_t1799908754 * get_textStyle_8() const { return ___textStyle_8; }
	inline GUIStyle_t1799908754 ** get_address_of_textStyle_8() { return &___textStyle_8; }
	inline void set_textStyle_8(GUIStyle_t1799908754 * value)
	{
		___textStyle_8 = value;
		Il2CppCodeGenWriteBarrier(&___textStyle_8, value);
	}

	inline static int32_t get_offset_of_buttonStyle_9() { return static_cast<int32_t>(offsetof(ConsoleBase_t4290192428, ___buttonStyle_9)); }
	inline GUIStyle_t1799908754 * get_buttonStyle_9() const { return ___buttonStyle_9; }
	inline GUIStyle_t1799908754 ** get_address_of_buttonStyle_9() { return &___buttonStyle_9; }
	inline void set_buttonStyle_9(GUIStyle_t1799908754 * value)
	{
		___buttonStyle_9 = value;
		Il2CppCodeGenWriteBarrier(&___buttonStyle_9, value);
	}

	inline static int32_t get_offset_of_textInputStyle_10() { return static_cast<int32_t>(offsetof(ConsoleBase_t4290192428, ___textInputStyle_10)); }
	inline GUIStyle_t1799908754 * get_textInputStyle_10() const { return ___textInputStyle_10; }
	inline GUIStyle_t1799908754 ** get_address_of_textInputStyle_10() { return &___textInputStyle_10; }
	inline void set_textInputStyle_10(GUIStyle_t1799908754 * value)
	{
		___textInputStyle_10 = value;
		Il2CppCodeGenWriteBarrier(&___textInputStyle_10, value);
	}

	inline static int32_t get_offset_of_labelStyle_11() { return static_cast<int32_t>(offsetof(ConsoleBase_t4290192428, ___labelStyle_11)); }
	inline GUIStyle_t1799908754 * get_labelStyle_11() const { return ___labelStyle_11; }
	inline GUIStyle_t1799908754 ** get_address_of_labelStyle_11() { return &___labelStyle_11; }
	inline void set_labelStyle_11(GUIStyle_t1799908754 * value)
	{
		___labelStyle_11 = value;
		Il2CppCodeGenWriteBarrier(&___labelStyle_11, value);
	}

	inline static int32_t get_offset_of_U3CLastResponseTextureU3Ek__BackingField_12() { return static_cast<int32_t>(offsetof(ConsoleBase_t4290192428, ___U3CLastResponseTextureU3Ek__BackingField_12)); }
	inline Texture2D_t3542995729 * get_U3CLastResponseTextureU3Ek__BackingField_12() const { return ___U3CLastResponseTextureU3Ek__BackingField_12; }
	inline Texture2D_t3542995729 ** get_address_of_U3CLastResponseTextureU3Ek__BackingField_12() { return &___U3CLastResponseTextureU3Ek__BackingField_12; }
	inline void set_U3CLastResponseTextureU3Ek__BackingField_12(Texture2D_t3542995729 * value)
	{
		___U3CLastResponseTextureU3Ek__BackingField_12 = value;
		Il2CppCodeGenWriteBarrier(&___U3CLastResponseTextureU3Ek__BackingField_12, value);
	}
};

struct ConsoleBase_t4290192428_StaticFields
{
public:
	// System.Collections.Generic.Stack`1<System.String> Facebook.Unity.Example.ConsoleBase::menuStack
	Stack_1_t3116948387 * ___menuStack_3;

public:
	inline static int32_t get_offset_of_menuStack_3() { return static_cast<int32_t>(offsetof(ConsoleBase_t4290192428_StaticFields, ___menuStack_3)); }
	inline Stack_1_t3116948387 * get_menuStack_3() const { return ___menuStack_3; }
	inline Stack_1_t3116948387 ** get_address_of_menuStack_3() { return &___menuStack_3; }
	inline void set_menuStack_3(Stack_1_t3116948387 * value)
	{
		___menuStack_3 = value;
		Il2CppCodeGenWriteBarrier(&___menuStack_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

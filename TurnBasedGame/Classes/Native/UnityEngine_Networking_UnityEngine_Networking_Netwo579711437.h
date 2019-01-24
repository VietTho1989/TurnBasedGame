#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Netw3873055601.h"

// UnityEngine.Animator
struct Animator_t69676727;
// UnityEngine.Networking.NetworkSystem.AnimationMessage
struct AnimationMessage_t3934203181;
// UnityEngine.Networking.NetworkSystem.AnimationParametersMessage
struct AnimationParametersMessage_t349763583;
// UnityEngine.Networking.NetworkSystem.AnimationTriggerMessage
struct AnimationTriggerMessage_t949407937;
// UnityEngine.Networking.NetworkWriter
struct NetworkWriter_t560143343;
// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkAnimator
struct  NetworkAnimator_t579711437  : public NetworkBehaviour_t3873055601
{
public:
	// UnityEngine.Animator UnityEngine.Networking.NetworkAnimator::m_Animator
	Animator_t69676727 * ___m_Animator_8;
	// System.UInt32 UnityEngine.Networking.NetworkAnimator::m_ParameterSendBits
	uint32_t ___m_ParameterSendBits_9;
	// System.Int32 UnityEngine.Networking.NetworkAnimator::m_AnimationHash
	int32_t ___m_AnimationHash_13;
	// System.Int32 UnityEngine.Networking.NetworkAnimator::m_TransitionHash
	int32_t ___m_TransitionHash_14;
	// UnityEngine.Networking.NetworkWriter UnityEngine.Networking.NetworkAnimator::m_ParameterWriter
	NetworkWriter_t560143343 * ___m_ParameterWriter_15;
	// System.Single UnityEngine.Networking.NetworkAnimator::m_SendTimer
	float ___m_SendTimer_16;
	// System.String UnityEngine.Networking.NetworkAnimator::param0
	String_t* ___param0_17;
	// System.String UnityEngine.Networking.NetworkAnimator::param1
	String_t* ___param1_18;
	// System.String UnityEngine.Networking.NetworkAnimator::param2
	String_t* ___param2_19;
	// System.String UnityEngine.Networking.NetworkAnimator::param3
	String_t* ___param3_20;
	// System.String UnityEngine.Networking.NetworkAnimator::param4
	String_t* ___param4_21;
	// System.String UnityEngine.Networking.NetworkAnimator::param5
	String_t* ___param5_22;

public:
	inline static int32_t get_offset_of_m_Animator_8() { return static_cast<int32_t>(offsetof(NetworkAnimator_t579711437, ___m_Animator_8)); }
	inline Animator_t69676727 * get_m_Animator_8() const { return ___m_Animator_8; }
	inline Animator_t69676727 ** get_address_of_m_Animator_8() { return &___m_Animator_8; }
	inline void set_m_Animator_8(Animator_t69676727 * value)
	{
		___m_Animator_8 = value;
		Il2CppCodeGenWriteBarrier(&___m_Animator_8, value);
	}

	inline static int32_t get_offset_of_m_ParameterSendBits_9() { return static_cast<int32_t>(offsetof(NetworkAnimator_t579711437, ___m_ParameterSendBits_9)); }
	inline uint32_t get_m_ParameterSendBits_9() const { return ___m_ParameterSendBits_9; }
	inline uint32_t* get_address_of_m_ParameterSendBits_9() { return &___m_ParameterSendBits_9; }
	inline void set_m_ParameterSendBits_9(uint32_t value)
	{
		___m_ParameterSendBits_9 = value;
	}

	inline static int32_t get_offset_of_m_AnimationHash_13() { return static_cast<int32_t>(offsetof(NetworkAnimator_t579711437, ___m_AnimationHash_13)); }
	inline int32_t get_m_AnimationHash_13() const { return ___m_AnimationHash_13; }
	inline int32_t* get_address_of_m_AnimationHash_13() { return &___m_AnimationHash_13; }
	inline void set_m_AnimationHash_13(int32_t value)
	{
		___m_AnimationHash_13 = value;
	}

	inline static int32_t get_offset_of_m_TransitionHash_14() { return static_cast<int32_t>(offsetof(NetworkAnimator_t579711437, ___m_TransitionHash_14)); }
	inline int32_t get_m_TransitionHash_14() const { return ___m_TransitionHash_14; }
	inline int32_t* get_address_of_m_TransitionHash_14() { return &___m_TransitionHash_14; }
	inline void set_m_TransitionHash_14(int32_t value)
	{
		___m_TransitionHash_14 = value;
	}

	inline static int32_t get_offset_of_m_ParameterWriter_15() { return static_cast<int32_t>(offsetof(NetworkAnimator_t579711437, ___m_ParameterWriter_15)); }
	inline NetworkWriter_t560143343 * get_m_ParameterWriter_15() const { return ___m_ParameterWriter_15; }
	inline NetworkWriter_t560143343 ** get_address_of_m_ParameterWriter_15() { return &___m_ParameterWriter_15; }
	inline void set_m_ParameterWriter_15(NetworkWriter_t560143343 * value)
	{
		___m_ParameterWriter_15 = value;
		Il2CppCodeGenWriteBarrier(&___m_ParameterWriter_15, value);
	}

	inline static int32_t get_offset_of_m_SendTimer_16() { return static_cast<int32_t>(offsetof(NetworkAnimator_t579711437, ___m_SendTimer_16)); }
	inline float get_m_SendTimer_16() const { return ___m_SendTimer_16; }
	inline float* get_address_of_m_SendTimer_16() { return &___m_SendTimer_16; }
	inline void set_m_SendTimer_16(float value)
	{
		___m_SendTimer_16 = value;
	}

	inline static int32_t get_offset_of_param0_17() { return static_cast<int32_t>(offsetof(NetworkAnimator_t579711437, ___param0_17)); }
	inline String_t* get_param0_17() const { return ___param0_17; }
	inline String_t** get_address_of_param0_17() { return &___param0_17; }
	inline void set_param0_17(String_t* value)
	{
		___param0_17 = value;
		Il2CppCodeGenWriteBarrier(&___param0_17, value);
	}

	inline static int32_t get_offset_of_param1_18() { return static_cast<int32_t>(offsetof(NetworkAnimator_t579711437, ___param1_18)); }
	inline String_t* get_param1_18() const { return ___param1_18; }
	inline String_t** get_address_of_param1_18() { return &___param1_18; }
	inline void set_param1_18(String_t* value)
	{
		___param1_18 = value;
		Il2CppCodeGenWriteBarrier(&___param1_18, value);
	}

	inline static int32_t get_offset_of_param2_19() { return static_cast<int32_t>(offsetof(NetworkAnimator_t579711437, ___param2_19)); }
	inline String_t* get_param2_19() const { return ___param2_19; }
	inline String_t** get_address_of_param2_19() { return &___param2_19; }
	inline void set_param2_19(String_t* value)
	{
		___param2_19 = value;
		Il2CppCodeGenWriteBarrier(&___param2_19, value);
	}

	inline static int32_t get_offset_of_param3_20() { return static_cast<int32_t>(offsetof(NetworkAnimator_t579711437, ___param3_20)); }
	inline String_t* get_param3_20() const { return ___param3_20; }
	inline String_t** get_address_of_param3_20() { return &___param3_20; }
	inline void set_param3_20(String_t* value)
	{
		___param3_20 = value;
		Il2CppCodeGenWriteBarrier(&___param3_20, value);
	}

	inline static int32_t get_offset_of_param4_21() { return static_cast<int32_t>(offsetof(NetworkAnimator_t579711437, ___param4_21)); }
	inline String_t* get_param4_21() const { return ___param4_21; }
	inline String_t** get_address_of_param4_21() { return &___param4_21; }
	inline void set_param4_21(String_t* value)
	{
		___param4_21 = value;
		Il2CppCodeGenWriteBarrier(&___param4_21, value);
	}

	inline static int32_t get_offset_of_param5_22() { return static_cast<int32_t>(offsetof(NetworkAnimator_t579711437, ___param5_22)); }
	inline String_t* get_param5_22() const { return ___param5_22; }
	inline String_t** get_address_of_param5_22() { return &___param5_22; }
	inline void set_param5_22(String_t* value)
	{
		___param5_22 = value;
		Il2CppCodeGenWriteBarrier(&___param5_22, value);
	}
};

struct NetworkAnimator_t579711437_StaticFields
{
public:
	// UnityEngine.Networking.NetworkSystem.AnimationMessage UnityEngine.Networking.NetworkAnimator::s_AnimationMessage
	AnimationMessage_t3934203181 * ___s_AnimationMessage_10;
	// UnityEngine.Networking.NetworkSystem.AnimationParametersMessage UnityEngine.Networking.NetworkAnimator::s_AnimationParametersMessage
	AnimationParametersMessage_t349763583 * ___s_AnimationParametersMessage_11;
	// UnityEngine.Networking.NetworkSystem.AnimationTriggerMessage UnityEngine.Networking.NetworkAnimator::s_AnimationTriggerMessage
	AnimationTriggerMessage_t949407937 * ___s_AnimationTriggerMessage_12;

public:
	inline static int32_t get_offset_of_s_AnimationMessage_10() { return static_cast<int32_t>(offsetof(NetworkAnimator_t579711437_StaticFields, ___s_AnimationMessage_10)); }
	inline AnimationMessage_t3934203181 * get_s_AnimationMessage_10() const { return ___s_AnimationMessage_10; }
	inline AnimationMessage_t3934203181 ** get_address_of_s_AnimationMessage_10() { return &___s_AnimationMessage_10; }
	inline void set_s_AnimationMessage_10(AnimationMessage_t3934203181 * value)
	{
		___s_AnimationMessage_10 = value;
		Il2CppCodeGenWriteBarrier(&___s_AnimationMessage_10, value);
	}

	inline static int32_t get_offset_of_s_AnimationParametersMessage_11() { return static_cast<int32_t>(offsetof(NetworkAnimator_t579711437_StaticFields, ___s_AnimationParametersMessage_11)); }
	inline AnimationParametersMessage_t349763583 * get_s_AnimationParametersMessage_11() const { return ___s_AnimationParametersMessage_11; }
	inline AnimationParametersMessage_t349763583 ** get_address_of_s_AnimationParametersMessage_11() { return &___s_AnimationParametersMessage_11; }
	inline void set_s_AnimationParametersMessage_11(AnimationParametersMessage_t349763583 * value)
	{
		___s_AnimationParametersMessage_11 = value;
		Il2CppCodeGenWriteBarrier(&___s_AnimationParametersMessage_11, value);
	}

	inline static int32_t get_offset_of_s_AnimationTriggerMessage_12() { return static_cast<int32_t>(offsetof(NetworkAnimator_t579711437_StaticFields, ___s_AnimationTriggerMessage_12)); }
	inline AnimationTriggerMessage_t949407937 * get_s_AnimationTriggerMessage_12() const { return ___s_AnimationTriggerMessage_12; }
	inline AnimationTriggerMessage_t949407937 ** get_address_of_s_AnimationTriggerMessage_12() { return &___s_AnimationTriggerMessage_12; }
	inline void set_s_AnimationTriggerMessage_12(AnimationTriggerMessage_t949407937 * value)
	{
		___s_AnimationTriggerMessage_12 = value;
		Il2CppCodeGenWriteBarrier(&___s_AnimationTriggerMessage_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

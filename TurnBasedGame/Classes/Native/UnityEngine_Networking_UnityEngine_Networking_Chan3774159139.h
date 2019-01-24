#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "UnityEngine_Networking_UnityEngine_Networking_Chan1682596885.h"

// UnityEngine.Networking.NetworkConnection
struct NetworkConnection_t107267906;
// System.Collections.Generic.Queue`1<UnityEngine.Networking.ChannelPacket>
struct Queue_1_t1502253720;
// System.Collections.Generic.List`1<UnityEngine.Networking.ChannelPacket>
struct List_1_t1051718017;
// UnityEngine.Networking.NetworkWriter
struct NetworkWriter_t560143343;
// UnityEngine.Networking.NetBuffer
struct NetBuffer_t3875182795;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.ChannelBuffer
struct  ChannelBuffer_t3774159139  : public Il2CppObject
{
public:
	// UnityEngine.Networking.NetworkConnection UnityEngine.Networking.ChannelBuffer::m_Connection
	NetworkConnection_t107267906 * ___m_Connection_0;
	// UnityEngine.Networking.ChannelPacket UnityEngine.Networking.ChannelBuffer::m_CurrentPacket
	ChannelPacket_t1682596885  ___m_CurrentPacket_1;
	// System.Single UnityEngine.Networking.ChannelBuffer::m_LastFlushTime
	float ___m_LastFlushTime_2;
	// System.Byte UnityEngine.Networking.ChannelBuffer::m_ChannelId
	uint8_t ___m_ChannelId_3;
	// System.Int32 UnityEngine.Networking.ChannelBuffer::m_MaxPacketSize
	int32_t ___m_MaxPacketSize_4;
	// System.Boolean UnityEngine.Networking.ChannelBuffer::m_IsReliable
	bool ___m_IsReliable_5;
	// System.Boolean UnityEngine.Networking.ChannelBuffer::m_AllowFragmentation
	bool ___m_AllowFragmentation_6;
	// System.Boolean UnityEngine.Networking.ChannelBuffer::m_IsBroken
	bool ___m_IsBroken_7;
	// System.Int32 UnityEngine.Networking.ChannelBuffer::m_MaxPendingPacketCount
	int32_t ___m_MaxPendingPacketCount_8;
	// System.Collections.Generic.Queue`1<UnityEngine.Networking.ChannelPacket> UnityEngine.Networking.ChannelBuffer::m_PendingPackets
	Queue_1_t1502253720 * ___m_PendingPackets_12;
	// System.Single UnityEngine.Networking.ChannelBuffer::maxDelay
	float ___maxDelay_15;
	// System.Single UnityEngine.Networking.ChannelBuffer::m_LastBufferedMessageCountTimer
	float ___m_LastBufferedMessageCountTimer_16;
	// System.Int32 UnityEngine.Networking.ChannelBuffer::<numMsgsOut>k__BackingField
	int32_t ___U3CnumMsgsOutU3Ek__BackingField_17;
	// System.Int32 UnityEngine.Networking.ChannelBuffer::<numBufferedMsgsOut>k__BackingField
	int32_t ___U3CnumBufferedMsgsOutU3Ek__BackingField_18;
	// System.Int32 UnityEngine.Networking.ChannelBuffer::<numBytesOut>k__BackingField
	int32_t ___U3CnumBytesOutU3Ek__BackingField_19;
	// System.Int32 UnityEngine.Networking.ChannelBuffer::<numMsgsIn>k__BackingField
	int32_t ___U3CnumMsgsInU3Ek__BackingField_20;
	// System.Int32 UnityEngine.Networking.ChannelBuffer::<numBytesIn>k__BackingField
	int32_t ___U3CnumBytesInU3Ek__BackingField_21;
	// System.Int32 UnityEngine.Networking.ChannelBuffer::<numBufferedPerSecond>k__BackingField
	int32_t ___U3CnumBufferedPerSecondU3Ek__BackingField_22;
	// System.Int32 UnityEngine.Networking.ChannelBuffer::<lastBufferedPerSecond>k__BackingField
	int32_t ___U3ClastBufferedPerSecondU3Ek__BackingField_23;
	// System.Boolean UnityEngine.Networking.ChannelBuffer::m_Disposed
	bool ___m_Disposed_27;
	// UnityEngine.Networking.NetBuffer UnityEngine.Networking.ChannelBuffer::fragmentBuffer
	NetBuffer_t3875182795 * ___fragmentBuffer_28;
	// System.Boolean UnityEngine.Networking.ChannelBuffer::readingFragment
	bool ___readingFragment_29;

public:
	inline static int32_t get_offset_of_m_Connection_0() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___m_Connection_0)); }
	inline NetworkConnection_t107267906 * get_m_Connection_0() const { return ___m_Connection_0; }
	inline NetworkConnection_t107267906 ** get_address_of_m_Connection_0() { return &___m_Connection_0; }
	inline void set_m_Connection_0(NetworkConnection_t107267906 * value)
	{
		___m_Connection_0 = value;
		Il2CppCodeGenWriteBarrier(&___m_Connection_0, value);
	}

	inline static int32_t get_offset_of_m_CurrentPacket_1() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___m_CurrentPacket_1)); }
	inline ChannelPacket_t1682596885  get_m_CurrentPacket_1() const { return ___m_CurrentPacket_1; }
	inline ChannelPacket_t1682596885 * get_address_of_m_CurrentPacket_1() { return &___m_CurrentPacket_1; }
	inline void set_m_CurrentPacket_1(ChannelPacket_t1682596885  value)
	{
		___m_CurrentPacket_1 = value;
	}

	inline static int32_t get_offset_of_m_LastFlushTime_2() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___m_LastFlushTime_2)); }
	inline float get_m_LastFlushTime_2() const { return ___m_LastFlushTime_2; }
	inline float* get_address_of_m_LastFlushTime_2() { return &___m_LastFlushTime_2; }
	inline void set_m_LastFlushTime_2(float value)
	{
		___m_LastFlushTime_2 = value;
	}

	inline static int32_t get_offset_of_m_ChannelId_3() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___m_ChannelId_3)); }
	inline uint8_t get_m_ChannelId_3() const { return ___m_ChannelId_3; }
	inline uint8_t* get_address_of_m_ChannelId_3() { return &___m_ChannelId_3; }
	inline void set_m_ChannelId_3(uint8_t value)
	{
		___m_ChannelId_3 = value;
	}

	inline static int32_t get_offset_of_m_MaxPacketSize_4() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___m_MaxPacketSize_4)); }
	inline int32_t get_m_MaxPacketSize_4() const { return ___m_MaxPacketSize_4; }
	inline int32_t* get_address_of_m_MaxPacketSize_4() { return &___m_MaxPacketSize_4; }
	inline void set_m_MaxPacketSize_4(int32_t value)
	{
		___m_MaxPacketSize_4 = value;
	}

	inline static int32_t get_offset_of_m_IsReliable_5() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___m_IsReliable_5)); }
	inline bool get_m_IsReliable_5() const { return ___m_IsReliable_5; }
	inline bool* get_address_of_m_IsReliable_5() { return &___m_IsReliable_5; }
	inline void set_m_IsReliable_5(bool value)
	{
		___m_IsReliable_5 = value;
	}

	inline static int32_t get_offset_of_m_AllowFragmentation_6() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___m_AllowFragmentation_6)); }
	inline bool get_m_AllowFragmentation_6() const { return ___m_AllowFragmentation_6; }
	inline bool* get_address_of_m_AllowFragmentation_6() { return &___m_AllowFragmentation_6; }
	inline void set_m_AllowFragmentation_6(bool value)
	{
		___m_AllowFragmentation_6 = value;
	}

	inline static int32_t get_offset_of_m_IsBroken_7() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___m_IsBroken_7)); }
	inline bool get_m_IsBroken_7() const { return ___m_IsBroken_7; }
	inline bool* get_address_of_m_IsBroken_7() { return &___m_IsBroken_7; }
	inline void set_m_IsBroken_7(bool value)
	{
		___m_IsBroken_7 = value;
	}

	inline static int32_t get_offset_of_m_MaxPendingPacketCount_8() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___m_MaxPendingPacketCount_8)); }
	inline int32_t get_m_MaxPendingPacketCount_8() const { return ___m_MaxPendingPacketCount_8; }
	inline int32_t* get_address_of_m_MaxPendingPacketCount_8() { return &___m_MaxPendingPacketCount_8; }
	inline void set_m_MaxPendingPacketCount_8(int32_t value)
	{
		___m_MaxPendingPacketCount_8 = value;
	}

	inline static int32_t get_offset_of_m_PendingPackets_12() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___m_PendingPackets_12)); }
	inline Queue_1_t1502253720 * get_m_PendingPackets_12() const { return ___m_PendingPackets_12; }
	inline Queue_1_t1502253720 ** get_address_of_m_PendingPackets_12() { return &___m_PendingPackets_12; }
	inline void set_m_PendingPackets_12(Queue_1_t1502253720 * value)
	{
		___m_PendingPackets_12 = value;
		Il2CppCodeGenWriteBarrier(&___m_PendingPackets_12, value);
	}

	inline static int32_t get_offset_of_maxDelay_15() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___maxDelay_15)); }
	inline float get_maxDelay_15() const { return ___maxDelay_15; }
	inline float* get_address_of_maxDelay_15() { return &___maxDelay_15; }
	inline void set_maxDelay_15(float value)
	{
		___maxDelay_15 = value;
	}

	inline static int32_t get_offset_of_m_LastBufferedMessageCountTimer_16() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___m_LastBufferedMessageCountTimer_16)); }
	inline float get_m_LastBufferedMessageCountTimer_16() const { return ___m_LastBufferedMessageCountTimer_16; }
	inline float* get_address_of_m_LastBufferedMessageCountTimer_16() { return &___m_LastBufferedMessageCountTimer_16; }
	inline void set_m_LastBufferedMessageCountTimer_16(float value)
	{
		___m_LastBufferedMessageCountTimer_16 = value;
	}

	inline static int32_t get_offset_of_U3CnumMsgsOutU3Ek__BackingField_17() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___U3CnumMsgsOutU3Ek__BackingField_17)); }
	inline int32_t get_U3CnumMsgsOutU3Ek__BackingField_17() const { return ___U3CnumMsgsOutU3Ek__BackingField_17; }
	inline int32_t* get_address_of_U3CnumMsgsOutU3Ek__BackingField_17() { return &___U3CnumMsgsOutU3Ek__BackingField_17; }
	inline void set_U3CnumMsgsOutU3Ek__BackingField_17(int32_t value)
	{
		___U3CnumMsgsOutU3Ek__BackingField_17 = value;
	}

	inline static int32_t get_offset_of_U3CnumBufferedMsgsOutU3Ek__BackingField_18() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___U3CnumBufferedMsgsOutU3Ek__BackingField_18)); }
	inline int32_t get_U3CnumBufferedMsgsOutU3Ek__BackingField_18() const { return ___U3CnumBufferedMsgsOutU3Ek__BackingField_18; }
	inline int32_t* get_address_of_U3CnumBufferedMsgsOutU3Ek__BackingField_18() { return &___U3CnumBufferedMsgsOutU3Ek__BackingField_18; }
	inline void set_U3CnumBufferedMsgsOutU3Ek__BackingField_18(int32_t value)
	{
		___U3CnumBufferedMsgsOutU3Ek__BackingField_18 = value;
	}

	inline static int32_t get_offset_of_U3CnumBytesOutU3Ek__BackingField_19() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___U3CnumBytesOutU3Ek__BackingField_19)); }
	inline int32_t get_U3CnumBytesOutU3Ek__BackingField_19() const { return ___U3CnumBytesOutU3Ek__BackingField_19; }
	inline int32_t* get_address_of_U3CnumBytesOutU3Ek__BackingField_19() { return &___U3CnumBytesOutU3Ek__BackingField_19; }
	inline void set_U3CnumBytesOutU3Ek__BackingField_19(int32_t value)
	{
		___U3CnumBytesOutU3Ek__BackingField_19 = value;
	}

	inline static int32_t get_offset_of_U3CnumMsgsInU3Ek__BackingField_20() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___U3CnumMsgsInU3Ek__BackingField_20)); }
	inline int32_t get_U3CnumMsgsInU3Ek__BackingField_20() const { return ___U3CnumMsgsInU3Ek__BackingField_20; }
	inline int32_t* get_address_of_U3CnumMsgsInU3Ek__BackingField_20() { return &___U3CnumMsgsInU3Ek__BackingField_20; }
	inline void set_U3CnumMsgsInU3Ek__BackingField_20(int32_t value)
	{
		___U3CnumMsgsInU3Ek__BackingField_20 = value;
	}

	inline static int32_t get_offset_of_U3CnumBytesInU3Ek__BackingField_21() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___U3CnumBytesInU3Ek__BackingField_21)); }
	inline int32_t get_U3CnumBytesInU3Ek__BackingField_21() const { return ___U3CnumBytesInU3Ek__BackingField_21; }
	inline int32_t* get_address_of_U3CnumBytesInU3Ek__BackingField_21() { return &___U3CnumBytesInU3Ek__BackingField_21; }
	inline void set_U3CnumBytesInU3Ek__BackingField_21(int32_t value)
	{
		___U3CnumBytesInU3Ek__BackingField_21 = value;
	}

	inline static int32_t get_offset_of_U3CnumBufferedPerSecondU3Ek__BackingField_22() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___U3CnumBufferedPerSecondU3Ek__BackingField_22)); }
	inline int32_t get_U3CnumBufferedPerSecondU3Ek__BackingField_22() const { return ___U3CnumBufferedPerSecondU3Ek__BackingField_22; }
	inline int32_t* get_address_of_U3CnumBufferedPerSecondU3Ek__BackingField_22() { return &___U3CnumBufferedPerSecondU3Ek__BackingField_22; }
	inline void set_U3CnumBufferedPerSecondU3Ek__BackingField_22(int32_t value)
	{
		___U3CnumBufferedPerSecondU3Ek__BackingField_22 = value;
	}

	inline static int32_t get_offset_of_U3ClastBufferedPerSecondU3Ek__BackingField_23() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___U3ClastBufferedPerSecondU3Ek__BackingField_23)); }
	inline int32_t get_U3ClastBufferedPerSecondU3Ek__BackingField_23() const { return ___U3ClastBufferedPerSecondU3Ek__BackingField_23; }
	inline int32_t* get_address_of_U3ClastBufferedPerSecondU3Ek__BackingField_23() { return &___U3ClastBufferedPerSecondU3Ek__BackingField_23; }
	inline void set_U3ClastBufferedPerSecondU3Ek__BackingField_23(int32_t value)
	{
		___U3ClastBufferedPerSecondU3Ek__BackingField_23 = value;
	}

	inline static int32_t get_offset_of_m_Disposed_27() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___m_Disposed_27)); }
	inline bool get_m_Disposed_27() const { return ___m_Disposed_27; }
	inline bool* get_address_of_m_Disposed_27() { return &___m_Disposed_27; }
	inline void set_m_Disposed_27(bool value)
	{
		___m_Disposed_27 = value;
	}

	inline static int32_t get_offset_of_fragmentBuffer_28() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___fragmentBuffer_28)); }
	inline NetBuffer_t3875182795 * get_fragmentBuffer_28() const { return ___fragmentBuffer_28; }
	inline NetBuffer_t3875182795 ** get_address_of_fragmentBuffer_28() { return &___fragmentBuffer_28; }
	inline void set_fragmentBuffer_28(NetBuffer_t3875182795 * value)
	{
		___fragmentBuffer_28 = value;
		Il2CppCodeGenWriteBarrier(&___fragmentBuffer_28, value);
	}

	inline static int32_t get_offset_of_readingFragment_29() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139, ___readingFragment_29)); }
	inline bool get_readingFragment_29() const { return ___readingFragment_29; }
	inline bool* get_address_of_readingFragment_29() { return &___readingFragment_29; }
	inline void set_readingFragment_29(bool value)
	{
		___readingFragment_29 = value;
	}
};

struct ChannelBuffer_t3774159139_StaticFields
{
public:
	// System.Collections.Generic.List`1<UnityEngine.Networking.ChannelPacket> UnityEngine.Networking.ChannelBuffer::s_FreePackets
	List_1_t1051718017 * ___s_FreePackets_13;
	// System.Int32 UnityEngine.Networking.ChannelBuffer::pendingPacketCount
	int32_t ___pendingPacketCount_14;
	// UnityEngine.Networking.NetworkWriter UnityEngine.Networking.ChannelBuffer::s_SendWriter
	NetworkWriter_t560143343 * ___s_SendWriter_24;
	// UnityEngine.Networking.NetworkWriter UnityEngine.Networking.ChannelBuffer::s_FragmentWriter
	NetworkWriter_t560143343 * ___s_FragmentWriter_25;

public:
	inline static int32_t get_offset_of_s_FreePackets_13() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139_StaticFields, ___s_FreePackets_13)); }
	inline List_1_t1051718017 * get_s_FreePackets_13() const { return ___s_FreePackets_13; }
	inline List_1_t1051718017 ** get_address_of_s_FreePackets_13() { return &___s_FreePackets_13; }
	inline void set_s_FreePackets_13(List_1_t1051718017 * value)
	{
		___s_FreePackets_13 = value;
		Il2CppCodeGenWriteBarrier(&___s_FreePackets_13, value);
	}

	inline static int32_t get_offset_of_pendingPacketCount_14() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139_StaticFields, ___pendingPacketCount_14)); }
	inline int32_t get_pendingPacketCount_14() const { return ___pendingPacketCount_14; }
	inline int32_t* get_address_of_pendingPacketCount_14() { return &___pendingPacketCount_14; }
	inline void set_pendingPacketCount_14(int32_t value)
	{
		___pendingPacketCount_14 = value;
	}

	inline static int32_t get_offset_of_s_SendWriter_24() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139_StaticFields, ___s_SendWriter_24)); }
	inline NetworkWriter_t560143343 * get_s_SendWriter_24() const { return ___s_SendWriter_24; }
	inline NetworkWriter_t560143343 ** get_address_of_s_SendWriter_24() { return &___s_SendWriter_24; }
	inline void set_s_SendWriter_24(NetworkWriter_t560143343 * value)
	{
		___s_SendWriter_24 = value;
		Il2CppCodeGenWriteBarrier(&___s_SendWriter_24, value);
	}

	inline static int32_t get_offset_of_s_FragmentWriter_25() { return static_cast<int32_t>(offsetof(ChannelBuffer_t3774159139_StaticFields, ___s_FragmentWriter_25)); }
	inline NetworkWriter_t560143343 * get_s_FragmentWriter_25() const { return ___s_FragmentWriter_25; }
	inline NetworkWriter_t560143343 ** get_address_of_s_FragmentWriter_25() { return &___s_FragmentWriter_25; }
	inline void set_s_FragmentWriter_25(NetworkWriter_t560143343 * value)
	{
		___s_FragmentWriter_25 = value;
		Il2CppCodeGenWriteBarrier(&___s_FragmentWriter_25, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

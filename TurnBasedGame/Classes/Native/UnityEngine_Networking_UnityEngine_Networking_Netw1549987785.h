#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Mess2552428296.h"

// UnityEngine.Networking.NetworkSystem.CRCMessageEntry[]
struct CRCMessageEntryU5BU5D_t2803924168;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityEngine.Networking.NetworkSystem.CRCMessage
struct  CRCMessage_t1549987785  : public MessageBase_t2552428296
{
public:
	// UnityEngine.Networking.NetworkSystem.CRCMessageEntry[] UnityEngine.Networking.NetworkSystem.CRCMessage::scripts
	CRCMessageEntryU5BU5D_t2803924168* ___scripts_0;

public:
	inline static int32_t get_offset_of_scripts_0() { return static_cast<int32_t>(offsetof(CRCMessage_t1549987785, ___scripts_0)); }
	inline CRCMessageEntryU5BU5D_t2803924168* get_scripts_0() const { return ___scripts_0; }
	inline CRCMessageEntryU5BU5D_t2803924168** get_address_of_scripts_0() { return &___scripts_0; }
	inline void set_scripts_0(CRCMessageEntryU5BU5D_t2803924168* value)
	{
		___scripts_0 = value;
		Il2CppCodeGenWriteBarrier(&___scripts_0, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_Networking_UnityEngine_Networking_Mess2552428296.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AccountDeviceMessage
struct  AccountDeviceMessage_t2496652612  : public MessageBase_t2552428296
{
public:
	// System.String AccountDeviceMessage::imei
	String_t* ___imei_0;
	// System.String AccountDeviceMessage::deviceName
	String_t* ___deviceName_1;
	// System.Int32 AccountDeviceMessage::deviceType
	int32_t ___deviceType_2;
	// System.String AccountDeviceMessage::customName
	String_t* ___customName_3;

public:
	inline static int32_t get_offset_of_imei_0() { return static_cast<int32_t>(offsetof(AccountDeviceMessage_t2496652612, ___imei_0)); }
	inline String_t* get_imei_0() const { return ___imei_0; }
	inline String_t** get_address_of_imei_0() { return &___imei_0; }
	inline void set_imei_0(String_t* value)
	{
		___imei_0 = value;
		Il2CppCodeGenWriteBarrier(&___imei_0, value);
	}

	inline static int32_t get_offset_of_deviceName_1() { return static_cast<int32_t>(offsetof(AccountDeviceMessage_t2496652612, ___deviceName_1)); }
	inline String_t* get_deviceName_1() const { return ___deviceName_1; }
	inline String_t** get_address_of_deviceName_1() { return &___deviceName_1; }
	inline void set_deviceName_1(String_t* value)
	{
		___deviceName_1 = value;
		Il2CppCodeGenWriteBarrier(&___deviceName_1, value);
	}

	inline static int32_t get_offset_of_deviceType_2() { return static_cast<int32_t>(offsetof(AccountDeviceMessage_t2496652612, ___deviceType_2)); }
	inline int32_t get_deviceType_2() const { return ___deviceType_2; }
	inline int32_t* get_address_of_deviceType_2() { return &___deviceType_2; }
	inline void set_deviceType_2(int32_t value)
	{
		___deviceType_2 = value;
	}

	inline static int32_t get_offset_of_customName_3() { return static_cast<int32_t>(offsetof(AccountDeviceMessage_t2496652612, ___customName_3)); }
	inline String_t* get_customName_3() const { return ___customName_3; }
	inline String_t** get_address_of_customName_3() { return &___customName_3; }
	inline void set_customName_3(String_t* value)
	{
		___customName_3 = value;
		Il2CppCodeGenWriteBarrier(&___customName_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

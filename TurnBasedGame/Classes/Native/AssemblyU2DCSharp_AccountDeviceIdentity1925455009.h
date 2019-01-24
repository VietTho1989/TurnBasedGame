#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// System.String
struct String_t;
// NetData`1<AccountDevice>
struct NetData_1_t2711710164;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AccountDeviceIdentity
struct  AccountDeviceIdentity_t1925455009  : public DataIdentity_t543951486
{
public:
	// System.String AccountDeviceIdentity::imei
	String_t* ___imei_17;
	// System.String AccountDeviceIdentity::deviceName
	String_t* ___deviceName_18;
	// System.Int32 AccountDeviceIdentity::deviceType
	int32_t ___deviceType_19;
	// System.String AccountDeviceIdentity::customName
	String_t* ___customName_20;
	// System.String AccountDeviceIdentity::avatarUrl
	String_t* ___avatarUrl_21;
	// NetData`1<AccountDevice> AccountDeviceIdentity::netData
	NetData_1_t2711710164 * ___netData_22;

public:
	inline static int32_t get_offset_of_imei_17() { return static_cast<int32_t>(offsetof(AccountDeviceIdentity_t1925455009, ___imei_17)); }
	inline String_t* get_imei_17() const { return ___imei_17; }
	inline String_t** get_address_of_imei_17() { return &___imei_17; }
	inline void set_imei_17(String_t* value)
	{
		___imei_17 = value;
		Il2CppCodeGenWriteBarrier(&___imei_17, value);
	}

	inline static int32_t get_offset_of_deviceName_18() { return static_cast<int32_t>(offsetof(AccountDeviceIdentity_t1925455009, ___deviceName_18)); }
	inline String_t* get_deviceName_18() const { return ___deviceName_18; }
	inline String_t** get_address_of_deviceName_18() { return &___deviceName_18; }
	inline void set_deviceName_18(String_t* value)
	{
		___deviceName_18 = value;
		Il2CppCodeGenWriteBarrier(&___deviceName_18, value);
	}

	inline static int32_t get_offset_of_deviceType_19() { return static_cast<int32_t>(offsetof(AccountDeviceIdentity_t1925455009, ___deviceType_19)); }
	inline int32_t get_deviceType_19() const { return ___deviceType_19; }
	inline int32_t* get_address_of_deviceType_19() { return &___deviceType_19; }
	inline void set_deviceType_19(int32_t value)
	{
		___deviceType_19 = value;
	}

	inline static int32_t get_offset_of_customName_20() { return static_cast<int32_t>(offsetof(AccountDeviceIdentity_t1925455009, ___customName_20)); }
	inline String_t* get_customName_20() const { return ___customName_20; }
	inline String_t** get_address_of_customName_20() { return &___customName_20; }
	inline void set_customName_20(String_t* value)
	{
		___customName_20 = value;
		Il2CppCodeGenWriteBarrier(&___customName_20, value);
	}

	inline static int32_t get_offset_of_avatarUrl_21() { return static_cast<int32_t>(offsetof(AccountDeviceIdentity_t1925455009, ___avatarUrl_21)); }
	inline String_t* get_avatarUrl_21() const { return ___avatarUrl_21; }
	inline String_t** get_address_of_avatarUrl_21() { return &___avatarUrl_21; }
	inline void set_avatarUrl_21(String_t* value)
	{
		___avatarUrl_21 = value;
		Il2CppCodeGenWriteBarrier(&___avatarUrl_21, value);
	}

	inline static int32_t get_offset_of_netData_22() { return static_cast<int32_t>(offsetof(AccountDeviceIdentity_t1925455009, ___netData_22)); }
	inline NetData_1_t2711710164 * get_netData_22() const { return ___netData_22; }
	inline NetData_1_t2711710164 ** get_address_of_netData_22() { return &___netData_22; }
	inline void set_netData_22(NetData_1_t2711710164 * value)
	{
		___netData_22 = value;
		Il2CppCodeGenWriteBarrier(&___netData_22, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

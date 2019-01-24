#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// System.Security.Permissions.StrongNamePublicKeyBlob
struct StrongNamePublicKeyBlob_t2860422703;
// System.String
struct String_t;
// System.Version
struct Version_t1755874712;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Security.Permissions.StrongNameIdentityPermission/SNIP
struct  SNIP_t4214504621 
{
public:
	// System.Security.Permissions.StrongNamePublicKeyBlob System.Security.Permissions.StrongNameIdentityPermission/SNIP::PublicKey
	StrongNamePublicKeyBlob_t2860422703 * ___PublicKey_0;
	// System.String System.Security.Permissions.StrongNameIdentityPermission/SNIP::Name
	String_t* ___Name_1;
	// System.Version System.Security.Permissions.StrongNameIdentityPermission/SNIP::AssemblyVersion
	Version_t1755874712 * ___AssemblyVersion_2;

public:
	inline static int32_t get_offset_of_PublicKey_0() { return static_cast<int32_t>(offsetof(SNIP_t4214504621, ___PublicKey_0)); }
	inline StrongNamePublicKeyBlob_t2860422703 * get_PublicKey_0() const { return ___PublicKey_0; }
	inline StrongNamePublicKeyBlob_t2860422703 ** get_address_of_PublicKey_0() { return &___PublicKey_0; }
	inline void set_PublicKey_0(StrongNamePublicKeyBlob_t2860422703 * value)
	{
		___PublicKey_0 = value;
		Il2CppCodeGenWriteBarrier(&___PublicKey_0, value);
	}

	inline static int32_t get_offset_of_Name_1() { return static_cast<int32_t>(offsetof(SNIP_t4214504621, ___Name_1)); }
	inline String_t* get_Name_1() const { return ___Name_1; }
	inline String_t** get_address_of_Name_1() { return &___Name_1; }
	inline void set_Name_1(String_t* value)
	{
		___Name_1 = value;
		Il2CppCodeGenWriteBarrier(&___Name_1, value);
	}

	inline static int32_t get_offset_of_AssemblyVersion_2() { return static_cast<int32_t>(offsetof(SNIP_t4214504621, ___AssemblyVersion_2)); }
	inline Version_t1755874712 * get_AssemblyVersion_2() const { return ___AssemblyVersion_2; }
	inline Version_t1755874712 ** get_address_of_AssemblyVersion_2() { return &___AssemblyVersion_2; }
	inline void set_AssemblyVersion_2(Version_t1755874712 * value)
	{
		___AssemblyVersion_2 = value;
		Il2CppCodeGenWriteBarrier(&___AssemblyVersion_2, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of System.Security.Permissions.StrongNameIdentityPermission/SNIP
struct SNIP_t4214504621_marshaled_pinvoke
{
	StrongNamePublicKeyBlob_t2860422703 * ___PublicKey_0;
	char* ___Name_1;
	Version_t1755874712 * ___AssemblyVersion_2;
};
// Native definition for COM marshalling of System.Security.Permissions.StrongNameIdentityPermission/SNIP
struct SNIP_t4214504621_marshaled_com
{
	StrongNamePublicKeyBlob_t2860422703 * ___PublicKey_0;
	Il2CppChar* ___Name_1;
	Version_t1755874712 * ___AssemblyVersion_2;
};

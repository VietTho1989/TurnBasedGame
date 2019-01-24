#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

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

// System.Security.Policy.StrongNameMembershipCondition
struct  StrongNameMembershipCondition_t552614029  : public Il2CppObject
{
public:
	// System.Int32 System.Security.Policy.StrongNameMembershipCondition::version
	int32_t ___version_0;
	// System.Security.Permissions.StrongNamePublicKeyBlob System.Security.Policy.StrongNameMembershipCondition::blob
	StrongNamePublicKeyBlob_t2860422703 * ___blob_1;
	// System.String System.Security.Policy.StrongNameMembershipCondition::name
	String_t* ___name_2;
	// System.Version System.Security.Policy.StrongNameMembershipCondition::assemblyVersion
	Version_t1755874712 * ___assemblyVersion_3;

public:
	inline static int32_t get_offset_of_version_0() { return static_cast<int32_t>(offsetof(StrongNameMembershipCondition_t552614029, ___version_0)); }
	inline int32_t get_version_0() const { return ___version_0; }
	inline int32_t* get_address_of_version_0() { return &___version_0; }
	inline void set_version_0(int32_t value)
	{
		___version_0 = value;
	}

	inline static int32_t get_offset_of_blob_1() { return static_cast<int32_t>(offsetof(StrongNameMembershipCondition_t552614029, ___blob_1)); }
	inline StrongNamePublicKeyBlob_t2860422703 * get_blob_1() const { return ___blob_1; }
	inline StrongNamePublicKeyBlob_t2860422703 ** get_address_of_blob_1() { return &___blob_1; }
	inline void set_blob_1(StrongNamePublicKeyBlob_t2860422703 * value)
	{
		___blob_1 = value;
		Il2CppCodeGenWriteBarrier(&___blob_1, value);
	}

	inline static int32_t get_offset_of_name_2() { return static_cast<int32_t>(offsetof(StrongNameMembershipCondition_t552614029, ___name_2)); }
	inline String_t* get_name_2() const { return ___name_2; }
	inline String_t** get_address_of_name_2() { return &___name_2; }
	inline void set_name_2(String_t* value)
	{
		___name_2 = value;
		Il2CppCodeGenWriteBarrier(&___name_2, value);
	}

	inline static int32_t get_offset_of_assemblyVersion_3() { return static_cast<int32_t>(offsetof(StrongNameMembershipCondition_t552614029, ___assemblyVersion_3)); }
	inline Version_t1755874712 * get_assemblyVersion_3() const { return ___assemblyVersion_3; }
	inline Version_t1755874712 ** get_address_of_assemblyVersion_3() { return &___assemblyVersion_3; }
	inline void set_assemblyVersion_3(Version_t1755874712 * value)
	{
		___assemblyVersion_3 = value;
		Il2CppCodeGenWriteBarrier(&___assemblyVersion_3, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

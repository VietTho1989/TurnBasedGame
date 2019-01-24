#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Collections.Hashtable
struct Hashtable_t909839986;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Security.Cryptography.CryptoConfig/CryptoHandler
struct  CryptoHandler_t2096418190  : public Il2CppObject
{
public:
	// System.Collections.Hashtable System.Security.Cryptography.CryptoConfig/CryptoHandler::algorithms
	Hashtable_t909839986 * ___algorithms_0;
	// System.Collections.Hashtable System.Security.Cryptography.CryptoConfig/CryptoHandler::oid
	Hashtable_t909839986 * ___oid_1;
	// System.Collections.Hashtable System.Security.Cryptography.CryptoConfig/CryptoHandler::names
	Hashtable_t909839986 * ___names_2;
	// System.Collections.Hashtable System.Security.Cryptography.CryptoConfig/CryptoHandler::classnames
	Hashtable_t909839986 * ___classnames_3;
	// System.Int32 System.Security.Cryptography.CryptoConfig/CryptoHandler::level
	int32_t ___level_4;

public:
	inline static int32_t get_offset_of_algorithms_0() { return static_cast<int32_t>(offsetof(CryptoHandler_t2096418190, ___algorithms_0)); }
	inline Hashtable_t909839986 * get_algorithms_0() const { return ___algorithms_0; }
	inline Hashtable_t909839986 ** get_address_of_algorithms_0() { return &___algorithms_0; }
	inline void set_algorithms_0(Hashtable_t909839986 * value)
	{
		___algorithms_0 = value;
		Il2CppCodeGenWriteBarrier(&___algorithms_0, value);
	}

	inline static int32_t get_offset_of_oid_1() { return static_cast<int32_t>(offsetof(CryptoHandler_t2096418190, ___oid_1)); }
	inline Hashtable_t909839986 * get_oid_1() const { return ___oid_1; }
	inline Hashtable_t909839986 ** get_address_of_oid_1() { return &___oid_1; }
	inline void set_oid_1(Hashtable_t909839986 * value)
	{
		___oid_1 = value;
		Il2CppCodeGenWriteBarrier(&___oid_1, value);
	}

	inline static int32_t get_offset_of_names_2() { return static_cast<int32_t>(offsetof(CryptoHandler_t2096418190, ___names_2)); }
	inline Hashtable_t909839986 * get_names_2() const { return ___names_2; }
	inline Hashtable_t909839986 ** get_address_of_names_2() { return &___names_2; }
	inline void set_names_2(Hashtable_t909839986 * value)
	{
		___names_2 = value;
		Il2CppCodeGenWriteBarrier(&___names_2, value);
	}

	inline static int32_t get_offset_of_classnames_3() { return static_cast<int32_t>(offsetof(CryptoHandler_t2096418190, ___classnames_3)); }
	inline Hashtable_t909839986 * get_classnames_3() const { return ___classnames_3; }
	inline Hashtable_t909839986 ** get_address_of_classnames_3() { return &___classnames_3; }
	inline void set_classnames_3(Hashtable_t909839986 * value)
	{
		___classnames_3 = value;
		Il2CppCodeGenWriteBarrier(&___classnames_3, value);
	}

	inline static int32_t get_offset_of_level_4() { return static_cast<int32_t>(offsetof(CryptoHandler_t2096418190, ___level_4)); }
	inline int32_t get_level_4() const { return ___level_4; }
	inline int32_t* get_address_of_level_4() { return &___level_4; }
	inline void set_level_4(int32_t value)
	{
		___level_4 = value;
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

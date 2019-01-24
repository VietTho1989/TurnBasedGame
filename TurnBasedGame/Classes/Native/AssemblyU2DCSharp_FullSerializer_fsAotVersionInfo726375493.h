#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_ValueType3507792607.h"

// FullSerializer.fsAotVersionInfo/Member[]
struct MemberU5BU5D_t1938319502;
struct Member_t459758263_marshaled_pinvoke;
struct Member_t459758263_marshaled_com;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FullSerializer.fsAotVersionInfo
struct  fsAotVersionInfo_t726375493 
{
public:
	// System.Boolean FullSerializer.fsAotVersionInfo::IsConstructorPublic
	bool ___IsConstructorPublic_0;
	// FullSerializer.fsAotVersionInfo/Member[] FullSerializer.fsAotVersionInfo::Members
	MemberU5BU5D_t1938319502* ___Members_1;

public:
	inline static int32_t get_offset_of_IsConstructorPublic_0() { return static_cast<int32_t>(offsetof(fsAotVersionInfo_t726375493, ___IsConstructorPublic_0)); }
	inline bool get_IsConstructorPublic_0() const { return ___IsConstructorPublic_0; }
	inline bool* get_address_of_IsConstructorPublic_0() { return &___IsConstructorPublic_0; }
	inline void set_IsConstructorPublic_0(bool value)
	{
		___IsConstructorPublic_0 = value;
	}

	inline static int32_t get_offset_of_Members_1() { return static_cast<int32_t>(offsetof(fsAotVersionInfo_t726375493, ___Members_1)); }
	inline MemberU5BU5D_t1938319502* get_Members_1() const { return ___Members_1; }
	inline MemberU5BU5D_t1938319502** get_address_of_Members_1() { return &___Members_1; }
	inline void set_Members_1(MemberU5BU5D_t1938319502* value)
	{
		___Members_1 = value;
		Il2CppCodeGenWriteBarrier(&___Members_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif
// Native definition for P/Invoke marshalling of FullSerializer.fsAotVersionInfo
struct fsAotVersionInfo_t726375493_marshaled_pinvoke
{
	int32_t ___IsConstructorPublic_0;
	Member_t459758263_marshaled_pinvoke* ___Members_1;
};
// Native definition for COM marshalling of FullSerializer.fsAotVersionInfo
struct fsAotVersionInfo_t726375493_marshaled_com
{
	int32_t ___IsConstructorPublic_0;
	Member_t459758263_marshaled_com* ___Members_1;
};

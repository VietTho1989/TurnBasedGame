#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"
#include "AssemblyU2DCSharp_BestHTTP_Authentication_Authenti1276453517.h"

// System.Uri
struct Uri_t19570940;
// System.String
struct String_t;
// System.Collections.Generic.List`1<System.String>
struct List_1_t1398341365;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t3986656710;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BestHTTP.Authentication.Digest
struct  Digest_t59399582  : public Il2CppObject
{
public:
	// System.Uri BestHTTP.Authentication.Digest::<Uri>k__BackingField
	Uri_t19570940 * ___U3CUriU3Ek__BackingField_0;
	// BestHTTP.Authentication.AuthenticationTypes BestHTTP.Authentication.Digest::<Type>k__BackingField
	int32_t ___U3CTypeU3Ek__BackingField_1;
	// System.String BestHTTP.Authentication.Digest::<Realm>k__BackingField
	String_t* ___U3CRealmU3Ek__BackingField_2;
	// System.Boolean BestHTTP.Authentication.Digest::<Stale>k__BackingField
	bool ___U3CStaleU3Ek__BackingField_3;
	// System.String BestHTTP.Authentication.Digest::<Nonce>k__BackingField
	String_t* ___U3CNonceU3Ek__BackingField_4;
	// System.String BestHTTP.Authentication.Digest::<Opaque>k__BackingField
	String_t* ___U3COpaqueU3Ek__BackingField_5;
	// System.String BestHTTP.Authentication.Digest::<Algorithm>k__BackingField
	String_t* ___U3CAlgorithmU3Ek__BackingField_6;
	// System.Collections.Generic.List`1<System.String> BestHTTP.Authentication.Digest::<ProtectedUris>k__BackingField
	List_1_t1398341365 * ___U3CProtectedUrisU3Ek__BackingField_7;
	// System.String BestHTTP.Authentication.Digest::<QualityOfProtections>k__BackingField
	String_t* ___U3CQualityOfProtectionsU3Ek__BackingField_8;
	// System.Int32 BestHTTP.Authentication.Digest::<NonceCount>k__BackingField
	int32_t ___U3CNonceCountU3Ek__BackingField_9;
	// System.String BestHTTP.Authentication.Digest::<HA1Sess>k__BackingField
	String_t* ___U3CHA1SessU3Ek__BackingField_10;

public:
	inline static int32_t get_offset_of_U3CUriU3Ek__BackingField_0() { return static_cast<int32_t>(offsetof(Digest_t59399582, ___U3CUriU3Ek__BackingField_0)); }
	inline Uri_t19570940 * get_U3CUriU3Ek__BackingField_0() const { return ___U3CUriU3Ek__BackingField_0; }
	inline Uri_t19570940 ** get_address_of_U3CUriU3Ek__BackingField_0() { return &___U3CUriU3Ek__BackingField_0; }
	inline void set_U3CUriU3Ek__BackingField_0(Uri_t19570940 * value)
	{
		___U3CUriU3Ek__BackingField_0 = value;
		Il2CppCodeGenWriteBarrier(&___U3CUriU3Ek__BackingField_0, value);
	}

	inline static int32_t get_offset_of_U3CTypeU3Ek__BackingField_1() { return static_cast<int32_t>(offsetof(Digest_t59399582, ___U3CTypeU3Ek__BackingField_1)); }
	inline int32_t get_U3CTypeU3Ek__BackingField_1() const { return ___U3CTypeU3Ek__BackingField_1; }
	inline int32_t* get_address_of_U3CTypeU3Ek__BackingField_1() { return &___U3CTypeU3Ek__BackingField_1; }
	inline void set_U3CTypeU3Ek__BackingField_1(int32_t value)
	{
		___U3CTypeU3Ek__BackingField_1 = value;
	}

	inline static int32_t get_offset_of_U3CRealmU3Ek__BackingField_2() { return static_cast<int32_t>(offsetof(Digest_t59399582, ___U3CRealmU3Ek__BackingField_2)); }
	inline String_t* get_U3CRealmU3Ek__BackingField_2() const { return ___U3CRealmU3Ek__BackingField_2; }
	inline String_t** get_address_of_U3CRealmU3Ek__BackingField_2() { return &___U3CRealmU3Ek__BackingField_2; }
	inline void set_U3CRealmU3Ek__BackingField_2(String_t* value)
	{
		___U3CRealmU3Ek__BackingField_2 = value;
		Il2CppCodeGenWriteBarrier(&___U3CRealmU3Ek__BackingField_2, value);
	}

	inline static int32_t get_offset_of_U3CStaleU3Ek__BackingField_3() { return static_cast<int32_t>(offsetof(Digest_t59399582, ___U3CStaleU3Ek__BackingField_3)); }
	inline bool get_U3CStaleU3Ek__BackingField_3() const { return ___U3CStaleU3Ek__BackingField_3; }
	inline bool* get_address_of_U3CStaleU3Ek__BackingField_3() { return &___U3CStaleU3Ek__BackingField_3; }
	inline void set_U3CStaleU3Ek__BackingField_3(bool value)
	{
		___U3CStaleU3Ek__BackingField_3 = value;
	}

	inline static int32_t get_offset_of_U3CNonceU3Ek__BackingField_4() { return static_cast<int32_t>(offsetof(Digest_t59399582, ___U3CNonceU3Ek__BackingField_4)); }
	inline String_t* get_U3CNonceU3Ek__BackingField_4() const { return ___U3CNonceU3Ek__BackingField_4; }
	inline String_t** get_address_of_U3CNonceU3Ek__BackingField_4() { return &___U3CNonceU3Ek__BackingField_4; }
	inline void set_U3CNonceU3Ek__BackingField_4(String_t* value)
	{
		___U3CNonceU3Ek__BackingField_4 = value;
		Il2CppCodeGenWriteBarrier(&___U3CNonceU3Ek__BackingField_4, value);
	}

	inline static int32_t get_offset_of_U3COpaqueU3Ek__BackingField_5() { return static_cast<int32_t>(offsetof(Digest_t59399582, ___U3COpaqueU3Ek__BackingField_5)); }
	inline String_t* get_U3COpaqueU3Ek__BackingField_5() const { return ___U3COpaqueU3Ek__BackingField_5; }
	inline String_t** get_address_of_U3COpaqueU3Ek__BackingField_5() { return &___U3COpaqueU3Ek__BackingField_5; }
	inline void set_U3COpaqueU3Ek__BackingField_5(String_t* value)
	{
		___U3COpaqueU3Ek__BackingField_5 = value;
		Il2CppCodeGenWriteBarrier(&___U3COpaqueU3Ek__BackingField_5, value);
	}

	inline static int32_t get_offset_of_U3CAlgorithmU3Ek__BackingField_6() { return static_cast<int32_t>(offsetof(Digest_t59399582, ___U3CAlgorithmU3Ek__BackingField_6)); }
	inline String_t* get_U3CAlgorithmU3Ek__BackingField_6() const { return ___U3CAlgorithmU3Ek__BackingField_6; }
	inline String_t** get_address_of_U3CAlgorithmU3Ek__BackingField_6() { return &___U3CAlgorithmU3Ek__BackingField_6; }
	inline void set_U3CAlgorithmU3Ek__BackingField_6(String_t* value)
	{
		___U3CAlgorithmU3Ek__BackingField_6 = value;
		Il2CppCodeGenWriteBarrier(&___U3CAlgorithmU3Ek__BackingField_6, value);
	}

	inline static int32_t get_offset_of_U3CProtectedUrisU3Ek__BackingField_7() { return static_cast<int32_t>(offsetof(Digest_t59399582, ___U3CProtectedUrisU3Ek__BackingField_7)); }
	inline List_1_t1398341365 * get_U3CProtectedUrisU3Ek__BackingField_7() const { return ___U3CProtectedUrisU3Ek__BackingField_7; }
	inline List_1_t1398341365 ** get_address_of_U3CProtectedUrisU3Ek__BackingField_7() { return &___U3CProtectedUrisU3Ek__BackingField_7; }
	inline void set_U3CProtectedUrisU3Ek__BackingField_7(List_1_t1398341365 * value)
	{
		___U3CProtectedUrisU3Ek__BackingField_7 = value;
		Il2CppCodeGenWriteBarrier(&___U3CProtectedUrisU3Ek__BackingField_7, value);
	}

	inline static int32_t get_offset_of_U3CQualityOfProtectionsU3Ek__BackingField_8() { return static_cast<int32_t>(offsetof(Digest_t59399582, ___U3CQualityOfProtectionsU3Ek__BackingField_8)); }
	inline String_t* get_U3CQualityOfProtectionsU3Ek__BackingField_8() const { return ___U3CQualityOfProtectionsU3Ek__BackingField_8; }
	inline String_t** get_address_of_U3CQualityOfProtectionsU3Ek__BackingField_8() { return &___U3CQualityOfProtectionsU3Ek__BackingField_8; }
	inline void set_U3CQualityOfProtectionsU3Ek__BackingField_8(String_t* value)
	{
		___U3CQualityOfProtectionsU3Ek__BackingField_8 = value;
		Il2CppCodeGenWriteBarrier(&___U3CQualityOfProtectionsU3Ek__BackingField_8, value);
	}

	inline static int32_t get_offset_of_U3CNonceCountU3Ek__BackingField_9() { return static_cast<int32_t>(offsetof(Digest_t59399582, ___U3CNonceCountU3Ek__BackingField_9)); }
	inline int32_t get_U3CNonceCountU3Ek__BackingField_9() const { return ___U3CNonceCountU3Ek__BackingField_9; }
	inline int32_t* get_address_of_U3CNonceCountU3Ek__BackingField_9() { return &___U3CNonceCountU3Ek__BackingField_9; }
	inline void set_U3CNonceCountU3Ek__BackingField_9(int32_t value)
	{
		___U3CNonceCountU3Ek__BackingField_9 = value;
	}

	inline static int32_t get_offset_of_U3CHA1SessU3Ek__BackingField_10() { return static_cast<int32_t>(offsetof(Digest_t59399582, ___U3CHA1SessU3Ek__BackingField_10)); }
	inline String_t* get_U3CHA1SessU3Ek__BackingField_10() const { return ___U3CHA1SessU3Ek__BackingField_10; }
	inline String_t** get_address_of_U3CHA1SessU3Ek__BackingField_10() { return &___U3CHA1SessU3Ek__BackingField_10; }
	inline void set_U3CHA1SessU3Ek__BackingField_10(String_t* value)
	{
		___U3CHA1SessU3Ek__BackingField_10 = value;
		Il2CppCodeGenWriteBarrier(&___U3CHA1SessU3Ek__BackingField_10, value);
	}
};

struct Digest_t59399582_StaticFields
{
public:
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> BestHTTP.Authentication.Digest::<>f__switch$map0
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map0_11;

public:
	inline static int32_t get_offset_of_U3CU3Ef__switchU24map0_11() { return static_cast<int32_t>(offsetof(Digest_t59399582_StaticFields, ___U3CU3Ef__switchU24map0_11)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map0_11() const { return ___U3CU3Ef__switchU24map0_11; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map0_11() { return &___U3CU3Ef__switchU24map0_11; }
	inline void set_U3CU3Ef__switchU24map0_11(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map0_11 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map0_11, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

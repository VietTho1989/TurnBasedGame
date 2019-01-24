#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// System.Globalization.RegionInfo
struct RegionInfo_t3784626978;
// System.String
struct String_t;
// System.Collections.Generic.Dictionary`2<System.String,System.Int32>
struct Dictionary_2_t3986656710;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// System.Globalization.RegionInfo
struct  RegionInfo_t3784626978  : public Il2CppObject
{
public:
	// System.Int32 System.Globalization.RegionInfo::lcid
	int32_t ___lcid_1;
	// System.Int32 System.Globalization.RegionInfo::regionId
	int32_t ___regionId_2;
	// System.String System.Globalization.RegionInfo::iso2Name
	String_t* ___iso2Name_3;
	// System.String System.Globalization.RegionInfo::iso3Name
	String_t* ___iso3Name_4;
	// System.String System.Globalization.RegionInfo::win3Name
	String_t* ___win3Name_5;
	// System.String System.Globalization.RegionInfo::englishName
	String_t* ___englishName_6;
	// System.String System.Globalization.RegionInfo::currencySymbol
	String_t* ___currencySymbol_7;
	// System.String System.Globalization.RegionInfo::isoCurrencySymbol
	String_t* ___isoCurrencySymbol_8;
	// System.String System.Globalization.RegionInfo::currencyEnglishName
	String_t* ___currencyEnglishName_9;

public:
	inline static int32_t get_offset_of_lcid_1() { return static_cast<int32_t>(offsetof(RegionInfo_t3784626978, ___lcid_1)); }
	inline int32_t get_lcid_1() const { return ___lcid_1; }
	inline int32_t* get_address_of_lcid_1() { return &___lcid_1; }
	inline void set_lcid_1(int32_t value)
	{
		___lcid_1 = value;
	}

	inline static int32_t get_offset_of_regionId_2() { return static_cast<int32_t>(offsetof(RegionInfo_t3784626978, ___regionId_2)); }
	inline int32_t get_regionId_2() const { return ___regionId_2; }
	inline int32_t* get_address_of_regionId_2() { return &___regionId_2; }
	inline void set_regionId_2(int32_t value)
	{
		___regionId_2 = value;
	}

	inline static int32_t get_offset_of_iso2Name_3() { return static_cast<int32_t>(offsetof(RegionInfo_t3784626978, ___iso2Name_3)); }
	inline String_t* get_iso2Name_3() const { return ___iso2Name_3; }
	inline String_t** get_address_of_iso2Name_3() { return &___iso2Name_3; }
	inline void set_iso2Name_3(String_t* value)
	{
		___iso2Name_3 = value;
		Il2CppCodeGenWriteBarrier(&___iso2Name_3, value);
	}

	inline static int32_t get_offset_of_iso3Name_4() { return static_cast<int32_t>(offsetof(RegionInfo_t3784626978, ___iso3Name_4)); }
	inline String_t* get_iso3Name_4() const { return ___iso3Name_4; }
	inline String_t** get_address_of_iso3Name_4() { return &___iso3Name_4; }
	inline void set_iso3Name_4(String_t* value)
	{
		___iso3Name_4 = value;
		Il2CppCodeGenWriteBarrier(&___iso3Name_4, value);
	}

	inline static int32_t get_offset_of_win3Name_5() { return static_cast<int32_t>(offsetof(RegionInfo_t3784626978, ___win3Name_5)); }
	inline String_t* get_win3Name_5() const { return ___win3Name_5; }
	inline String_t** get_address_of_win3Name_5() { return &___win3Name_5; }
	inline void set_win3Name_5(String_t* value)
	{
		___win3Name_5 = value;
		Il2CppCodeGenWriteBarrier(&___win3Name_5, value);
	}

	inline static int32_t get_offset_of_englishName_6() { return static_cast<int32_t>(offsetof(RegionInfo_t3784626978, ___englishName_6)); }
	inline String_t* get_englishName_6() const { return ___englishName_6; }
	inline String_t** get_address_of_englishName_6() { return &___englishName_6; }
	inline void set_englishName_6(String_t* value)
	{
		___englishName_6 = value;
		Il2CppCodeGenWriteBarrier(&___englishName_6, value);
	}

	inline static int32_t get_offset_of_currencySymbol_7() { return static_cast<int32_t>(offsetof(RegionInfo_t3784626978, ___currencySymbol_7)); }
	inline String_t* get_currencySymbol_7() const { return ___currencySymbol_7; }
	inline String_t** get_address_of_currencySymbol_7() { return &___currencySymbol_7; }
	inline void set_currencySymbol_7(String_t* value)
	{
		___currencySymbol_7 = value;
		Il2CppCodeGenWriteBarrier(&___currencySymbol_7, value);
	}

	inline static int32_t get_offset_of_isoCurrencySymbol_8() { return static_cast<int32_t>(offsetof(RegionInfo_t3784626978, ___isoCurrencySymbol_8)); }
	inline String_t* get_isoCurrencySymbol_8() const { return ___isoCurrencySymbol_8; }
	inline String_t** get_address_of_isoCurrencySymbol_8() { return &___isoCurrencySymbol_8; }
	inline void set_isoCurrencySymbol_8(String_t* value)
	{
		___isoCurrencySymbol_8 = value;
		Il2CppCodeGenWriteBarrier(&___isoCurrencySymbol_8, value);
	}

	inline static int32_t get_offset_of_currencyEnglishName_9() { return static_cast<int32_t>(offsetof(RegionInfo_t3784626978, ___currencyEnglishName_9)); }
	inline String_t* get_currencyEnglishName_9() const { return ___currencyEnglishName_9; }
	inline String_t** get_address_of_currencyEnglishName_9() { return &___currencyEnglishName_9; }
	inline void set_currencyEnglishName_9(String_t* value)
	{
		___currencyEnglishName_9 = value;
		Il2CppCodeGenWriteBarrier(&___currencyEnglishName_9, value);
	}
};

struct RegionInfo_t3784626978_StaticFields
{
public:
	// System.Globalization.RegionInfo System.Globalization.RegionInfo::currentRegion
	RegionInfo_t3784626978 * ___currentRegion_0;
	// System.Collections.Generic.Dictionary`2<System.String,System.Int32> System.Globalization.RegionInfo::<>f__switch$map1D
	Dictionary_2_t3986656710 * ___U3CU3Ef__switchU24map1D_10;

public:
	inline static int32_t get_offset_of_currentRegion_0() { return static_cast<int32_t>(offsetof(RegionInfo_t3784626978_StaticFields, ___currentRegion_0)); }
	inline RegionInfo_t3784626978 * get_currentRegion_0() const { return ___currentRegion_0; }
	inline RegionInfo_t3784626978 ** get_address_of_currentRegion_0() { return &___currentRegion_0; }
	inline void set_currentRegion_0(RegionInfo_t3784626978 * value)
	{
		___currentRegion_0 = value;
		Il2CppCodeGenWriteBarrier(&___currentRegion_0, value);
	}

	inline static int32_t get_offset_of_U3CU3Ef__switchU24map1D_10() { return static_cast<int32_t>(offsetof(RegionInfo_t3784626978_StaticFields, ___U3CU3Ef__switchU24map1D_10)); }
	inline Dictionary_2_t3986656710 * get_U3CU3Ef__switchU24map1D_10() const { return ___U3CU3Ef__switchU24map1D_10; }
	inline Dictionary_2_t3986656710 ** get_address_of_U3CU3Ef__switchU24map1D_10() { return &___U3CU3Ef__switchU24map1D_10; }
	inline void set_U3CU3Ef__switchU24map1D_10(Dictionary_2_t3986656710 * value)
	{
		___U3CU3Ef__switchU24map1D_10 = value;
		Il2CppCodeGenWriteBarrier(&___U3CU3Ef__switchU24map1D_10, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

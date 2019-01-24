#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_NormalUI_UIData_Sub2148740373.h"

// VP`1<ReferenceData`1<Server>>
struct VP_1_t2173380836;
// VP`1<RequestChangeEnumUI/UIData>
struct VP_1_t3850875635;
// VP`1<AccountUI/UIData>
struct VP_1_t1943799622;
// VP`1<LoginStateUI/UIData>
struct VP_1_t3708195235;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// LoginUI/UIData
struct  UIData_t4187508358  : public Sub_t2148740373
{
public:
	// VP`1<ReferenceData`1<Server>> LoginUI/UIData::server
	VP_1_t2173380836 * ___server_5;
	// VP`1<RequestChangeEnumUI/UIData> LoginUI/UIData::accountType
	VP_1_t3850875635 * ___accountType_6;
	// VP`1<AccountUI/UIData> LoginUI/UIData::accountUIData
	VP_1_t1943799622 * ___accountUIData_7;
	// VP`1<LoginStateUI/UIData> LoginUI/UIData::loginStateUI
	VP_1_t3708195235 * ___loginStateUI_8;

public:
	inline static int32_t get_offset_of_server_5() { return static_cast<int32_t>(offsetof(UIData_t4187508358, ___server_5)); }
	inline VP_1_t2173380836 * get_server_5() const { return ___server_5; }
	inline VP_1_t2173380836 ** get_address_of_server_5() { return &___server_5; }
	inline void set_server_5(VP_1_t2173380836 * value)
	{
		___server_5 = value;
		Il2CppCodeGenWriteBarrier(&___server_5, value);
	}

	inline static int32_t get_offset_of_accountType_6() { return static_cast<int32_t>(offsetof(UIData_t4187508358, ___accountType_6)); }
	inline VP_1_t3850875635 * get_accountType_6() const { return ___accountType_6; }
	inline VP_1_t3850875635 ** get_address_of_accountType_6() { return &___accountType_6; }
	inline void set_accountType_6(VP_1_t3850875635 * value)
	{
		___accountType_6 = value;
		Il2CppCodeGenWriteBarrier(&___accountType_6, value);
	}

	inline static int32_t get_offset_of_accountUIData_7() { return static_cast<int32_t>(offsetof(UIData_t4187508358, ___accountUIData_7)); }
	inline VP_1_t1943799622 * get_accountUIData_7() const { return ___accountUIData_7; }
	inline VP_1_t1943799622 ** get_address_of_accountUIData_7() { return &___accountUIData_7; }
	inline void set_accountUIData_7(VP_1_t1943799622 * value)
	{
		___accountUIData_7 = value;
		Il2CppCodeGenWriteBarrier(&___accountUIData_7, value);
	}

	inline static int32_t get_offset_of_loginStateUI_8() { return static_cast<int32_t>(offsetof(UIData_t4187508358, ___loginStateUI_8)); }
	inline VP_1_t3708195235 * get_loginStateUI_8() const { return ___loginStateUI_8; }
	inline VP_1_t3708195235 ** get_address_of_loginStateUI_8() { return &___loginStateUI_8; }
	inline void set_loginStateUI_8(VP_1_t3708195235 * value)
	{
		___loginStateUI_8 = value;
		Il2CppCodeGenWriteBarrier(&___loginStateUI_8, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

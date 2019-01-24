#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_AccountUI_UIData_Sub2824630067.h"

// VP`1<EditData`1<AccountAdmin>>
struct VP_1_t1186726784;
// VP`1<RequestChangeStringUI/UIData>
struct VP_1_t1525575381;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// AccountAdminUI/UIData
struct  UIData_t3002024367  : public Sub_t2824630067
{
public:
	// VP`1<EditData`1<AccountAdmin>> AccountAdminUI/UIData::editAccountAdmin
	VP_1_t1186726784 * ___editAccountAdmin_5;
	// VP`1<RequestChangeStringUI/UIData> AccountAdminUI/UIData::customName
	VP_1_t1525575381 * ___customName_6;
	// VP`1<RequestChangeStringUI/UIData> AccountAdminUI/UIData::avatarUrl
	VP_1_t1525575381 * ___avatarUrl_7;

public:
	inline static int32_t get_offset_of_editAccountAdmin_5() { return static_cast<int32_t>(offsetof(UIData_t3002024367, ___editAccountAdmin_5)); }
	inline VP_1_t1186726784 * get_editAccountAdmin_5() const { return ___editAccountAdmin_5; }
	inline VP_1_t1186726784 ** get_address_of_editAccountAdmin_5() { return &___editAccountAdmin_5; }
	inline void set_editAccountAdmin_5(VP_1_t1186726784 * value)
	{
		___editAccountAdmin_5 = value;
		Il2CppCodeGenWriteBarrier(&___editAccountAdmin_5, value);
	}

	inline static int32_t get_offset_of_customName_6() { return static_cast<int32_t>(offsetof(UIData_t3002024367, ___customName_6)); }
	inline VP_1_t1525575381 * get_customName_6() const { return ___customName_6; }
	inline VP_1_t1525575381 ** get_address_of_customName_6() { return &___customName_6; }
	inline void set_customName_6(VP_1_t1525575381 * value)
	{
		___customName_6 = value;
		Il2CppCodeGenWriteBarrier(&___customName_6, value);
	}

	inline static int32_t get_offset_of_avatarUrl_7() { return static_cast<int32_t>(offsetof(UIData_t3002024367, ___avatarUrl_7)); }
	inline VP_1_t1525575381 * get_avatarUrl_7() const { return ___avatarUrl_7; }
	inline VP_1_t1525575381 ** get_address_of_avatarUrl_7() { return &___avatarUrl_7; }
	inline void set_avatarUrl_7(VP_1_t1525575381 * value)
	{
		___avatarUrl_7 = value;
		Il2CppCodeGenWriteBarrier(&___avatarUrl_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

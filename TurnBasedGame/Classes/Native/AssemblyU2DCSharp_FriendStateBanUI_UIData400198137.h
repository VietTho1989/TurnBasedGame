#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_FriendStateUI_UIData_Sub1685311667.h"

// VP`1<ReferenceData`1<FriendStateBan>>
struct VP_1_t1824517795;
// VP`1<FriendStateBanUI/UIData/State>
struct VP_1_t2477185003;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// FriendStateBanUI/UIData
struct  UIData_t400198137  : public Sub_t1685311667
{
public:
	// VP`1<ReferenceData`1<FriendStateBan>> FriendStateBanUI/UIData::friendStateBan
	VP_1_t1824517795 * ___friendStateBan_5;
	// VP`1<FriendStateBanUI/UIData/State> FriendStateBanUI/UIData::state
	VP_1_t2477185003 * ___state_6;

public:
	inline static int32_t get_offset_of_friendStateBan_5() { return static_cast<int32_t>(offsetof(UIData_t400198137, ___friendStateBan_5)); }
	inline VP_1_t1824517795 * get_friendStateBan_5() const { return ___friendStateBan_5; }
	inline VP_1_t1824517795 ** get_address_of_friendStateBan_5() { return &___friendStateBan_5; }
	inline void set_friendStateBan_5(VP_1_t1824517795 * value)
	{
		___friendStateBan_5 = value;
		Il2CppCodeGenWriteBarrier(&___friendStateBan_5, value);
	}

	inline static int32_t get_offset_of_state_6() { return static_cast<int32_t>(offsetof(UIData_t400198137, ___state_6)); }
	inline VP_1_t2477185003 * get_state_6() const { return ___state_6; }
	inline VP_1_t2477185003 ** get_address_of_state_6() { return &___state_6; }
	inline void set_state_6(VP_1_t2477185003 * value)
	{
		___state_6 = value;
		Il2CppCodeGenWriteBarrier(&___state_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

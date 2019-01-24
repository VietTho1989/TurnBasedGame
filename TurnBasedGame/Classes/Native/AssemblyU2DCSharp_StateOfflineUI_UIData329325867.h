#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_GlobalStateUI_UIData_Sub1416586640.h"

// VP`1<ReferenceData`1<Server/State/Offline>>
struct VP_1_t1808370146;
// VP`1<RequestChangeStringUI/UIData>
struct VP_1_t1525575381;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// StateOfflineUI/UIData
struct  UIData_t329325867  : public Sub_t1416586640
{
public:
	// VP`1<ReferenceData`1<Server/State/Offline>> StateOfflineUI/UIData::offline
	VP_1_t1808370146 * ___offline_5;
	// VP`1<RequestChangeStringUI/UIData> StateOfflineUI/UIData::txtOffline
	VP_1_t1525575381 * ___txtOffline_6;

public:
	inline static int32_t get_offset_of_offline_5() { return static_cast<int32_t>(offsetof(UIData_t329325867, ___offline_5)); }
	inline VP_1_t1808370146 * get_offline_5() const { return ___offline_5; }
	inline VP_1_t1808370146 ** get_address_of_offline_5() { return &___offline_5; }
	inline void set_offline_5(VP_1_t1808370146 * value)
	{
		___offline_5 = value;
		Il2CppCodeGenWriteBarrier(&___offline_5, value);
	}

	inline static int32_t get_offset_of_txtOffline_6() { return static_cast<int32_t>(offsetof(UIData_t329325867, ___txtOffline_6)); }
	inline VP_1_t1525575381 * get_txtOffline_6() const { return ___txtOffline_6; }
	inline VP_1_t1525575381 ** get_address_of_txtOffline_6() { return &___txtOffline_6; }
	inline void set_txtOffline_6(VP_1_t1525575381 * value)
	{
		___txtOffline_6 = value;
		Il2CppCodeGenWriteBarrier(&___txtOffline_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

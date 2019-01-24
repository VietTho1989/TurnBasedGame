#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_DataIdentity543951486.h"

// NetData`1<CoTuongUp.DefaultCoTuongUp>
struct NetData_1_t862848288;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// CoTuongUp.DefaultCoTuongUpIdentity
struct  DefaultCoTuongUpIdentity_t41995393  : public DataIdentity_t543951486
{
public:
	// System.Boolean CoTuongUp.DefaultCoTuongUpIdentity::allowViewCapture
	bool ___allowViewCapture_17;
	// System.Boolean CoTuongUp.DefaultCoTuongUpIdentity::allowWatcherViewHidden
	bool ___allowWatcherViewHidden_18;
	// System.Boolean CoTuongUp.DefaultCoTuongUpIdentity::allowOnlyFlip
	bool ___allowOnlyFlip_19;
	// NetData`1<CoTuongUp.DefaultCoTuongUp> CoTuongUp.DefaultCoTuongUpIdentity::netData
	NetData_1_t862848288 * ___netData_20;

public:
	inline static int32_t get_offset_of_allowViewCapture_17() { return static_cast<int32_t>(offsetof(DefaultCoTuongUpIdentity_t41995393, ___allowViewCapture_17)); }
	inline bool get_allowViewCapture_17() const { return ___allowViewCapture_17; }
	inline bool* get_address_of_allowViewCapture_17() { return &___allowViewCapture_17; }
	inline void set_allowViewCapture_17(bool value)
	{
		___allowViewCapture_17 = value;
	}

	inline static int32_t get_offset_of_allowWatcherViewHidden_18() { return static_cast<int32_t>(offsetof(DefaultCoTuongUpIdentity_t41995393, ___allowWatcherViewHidden_18)); }
	inline bool get_allowWatcherViewHidden_18() const { return ___allowWatcherViewHidden_18; }
	inline bool* get_address_of_allowWatcherViewHidden_18() { return &___allowWatcherViewHidden_18; }
	inline void set_allowWatcherViewHidden_18(bool value)
	{
		___allowWatcherViewHidden_18 = value;
	}

	inline static int32_t get_offset_of_allowOnlyFlip_19() { return static_cast<int32_t>(offsetof(DefaultCoTuongUpIdentity_t41995393, ___allowOnlyFlip_19)); }
	inline bool get_allowOnlyFlip_19() const { return ___allowOnlyFlip_19; }
	inline bool* get_address_of_allowOnlyFlip_19() { return &___allowOnlyFlip_19; }
	inline void set_allowOnlyFlip_19(bool value)
	{
		___allowOnlyFlip_19 = value;
	}

	inline static int32_t get_offset_of_netData_20() { return static_cast<int32_t>(offsetof(DefaultCoTuongUpIdentity_t41995393, ___netData_20)); }
	inline NetData_1_t862848288 * get_netData_20() const { return ___netData_20; }
	inline NetData_1_t862848288 ** get_address_of_netData_20() { return &___netData_20; }
	inline void set_netData_20(NetData_1_t862848288 * value)
	{
		___netData_20 = value;
		Il2CppCodeGenWriteBarrier(&___netData_20, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

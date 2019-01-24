#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UIBehavior_1_gen101770758.h"

// BanNormalUI
struct BanNormalUI_t1860239188;
// BanBanUI
struct BanBanUI_t2878396172;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// BanUI
struct  BanUI_t2500187775  : public UIBehavior_1_t101770758
{
public:
	// BanNormalUI BanUI::banNormalPrefab
	BanNormalUI_t1860239188 * ___banNormalPrefab_6;
	// BanBanUI BanUI::banBanPrefab
	BanBanUI_t2878396172 * ___banBanPrefab_7;

public:
	inline static int32_t get_offset_of_banNormalPrefab_6() { return static_cast<int32_t>(offsetof(BanUI_t2500187775, ___banNormalPrefab_6)); }
	inline BanNormalUI_t1860239188 * get_banNormalPrefab_6() const { return ___banNormalPrefab_6; }
	inline BanNormalUI_t1860239188 ** get_address_of_banNormalPrefab_6() { return &___banNormalPrefab_6; }
	inline void set_banNormalPrefab_6(BanNormalUI_t1860239188 * value)
	{
		___banNormalPrefab_6 = value;
		Il2CppCodeGenWriteBarrier(&___banNormalPrefab_6, value);
	}

	inline static int32_t get_offset_of_banBanPrefab_7() { return static_cast<int32_t>(offsetof(BanUI_t2500187775, ___banBanPrefab_7)); }
	inline BanBanUI_t2878396172 * get_banBanPrefab_7() const { return ___banBanPrefab_7; }
	inline BanBanUI_t2878396172 ** get_address_of_banBanPrefab_7() { return &___banBanPrefab_7; }
	inline void set_banBanPrefab_7(BanBanUI_t2878396172 * value)
	{
		___banBanPrefab_7 = value;
		Il2CppCodeGenWriteBarrier(&___banBanPrefab_7, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

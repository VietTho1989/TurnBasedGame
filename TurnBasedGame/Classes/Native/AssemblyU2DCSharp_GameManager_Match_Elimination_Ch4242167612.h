#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_frame8_Logic_Misc_Visual_UI_Scro3745452807.h"

// GameManager.Match.Elimination.ChooseBracketHolder
struct ChooseBracketHolder_t2402442703;
// UnityEngine.GameObject
struct GameObject_t1756533147;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GameManager.Match.Elimination.ChooseBracketAdapter
struct  ChooseBracketAdapter_t4242167612  : public SRIA_2_t3745452807
{
public:
	// GameManager.Match.Elimination.ChooseBracketHolder GameManager.Match.Elimination.ChooseBracketAdapter::holderPrefab
	ChooseBracketHolder_t2402442703 * ___holderPrefab_24;
	// UnityEngine.GameObject GameManager.Match.Elimination.ChooseBracketAdapter::noBrackets
	GameObject_t1756533147 * ___noBrackets_25;

public:
	inline static int32_t get_offset_of_holderPrefab_24() { return static_cast<int32_t>(offsetof(ChooseBracketAdapter_t4242167612, ___holderPrefab_24)); }
	inline ChooseBracketHolder_t2402442703 * get_holderPrefab_24() const { return ___holderPrefab_24; }
	inline ChooseBracketHolder_t2402442703 ** get_address_of_holderPrefab_24() { return &___holderPrefab_24; }
	inline void set_holderPrefab_24(ChooseBracketHolder_t2402442703 * value)
	{
		___holderPrefab_24 = value;
		Il2CppCodeGenWriteBarrier(&___holderPrefab_24, value);
	}

	inline static int32_t get_offset_of_noBrackets_25() { return static_cast<int32_t>(offsetof(ChooseBracketAdapter_t4242167612, ___noBrackets_25)); }
	inline GameObject_t1756533147 * get_noBrackets_25() const { return ___noBrackets_25; }
	inline GameObject_t1756533147 ** get_address_of_noBrackets_25() { return &___noBrackets_25; }
	inline void set_noBrackets_25(GameObject_t1756533147 * value)
	{
		___noBrackets_25 = value;
		Il2CppCodeGenWriteBarrier(&___noBrackets_25, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

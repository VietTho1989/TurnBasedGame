#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Save_Content2583047541.h"
#include "AssemblyU2DCSharp_GameType_Type2350072159.h"

// System.String
struct String_t;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// SaveFen
struct  SaveFen_t2517915814  : public Content_t2583047541
{
public:
	// GameType/Type SaveFen::gameType
	int32_t ___gameType_0;
	// System.String SaveFen::fen
	String_t* ___fen_1;

public:
	inline static int32_t get_offset_of_gameType_0() { return static_cast<int32_t>(offsetof(SaveFen_t2517915814, ___gameType_0)); }
	inline int32_t get_gameType_0() const { return ___gameType_0; }
	inline int32_t* get_address_of_gameType_0() { return &___gameType_0; }
	inline void set_gameType_0(int32_t value)
	{
		___gameType_0 = value;
	}

	inline static int32_t get_offset_of_fen_1() { return static_cast<int32_t>(offsetof(SaveFen_t2517915814, ___fen_1)); }
	inline String_t* get_fen_1() const { return ___fen_1; }
	inline String_t** get_address_of_fen_1() { return &___fen_1; }
	inline void set_fen_1(String_t* value)
	{
		___fen_1 = value;
		Il2CppCodeGenWriteBarrier(&___fen_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

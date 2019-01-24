#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_UpdateBehavior_1_gen2425183489.h"

// AdvancedCoroutines.Routine
struct Routine_t2502590640;
// Game
struct Game_t1600141214;
// Server
struct Server_t2724320767;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// TimeReportClientUpdate
struct  TimeReportClientUpdate_t979173133  : public UpdateBehavior_1_t2425183489
{
public:
	// AdvancedCoroutines.Routine TimeReportClientUpdate::waitToResend
	Routine_t2502590640 * ___waitToResend_4;
	// Game TimeReportClientUpdate::game
	Game_t1600141214 * ___game_5;
	// Server TimeReportClientUpdate::server
	Server_t2724320767 * ___server_6;

public:
	inline static int32_t get_offset_of_waitToResend_4() { return static_cast<int32_t>(offsetof(TimeReportClientUpdate_t979173133, ___waitToResend_4)); }
	inline Routine_t2502590640 * get_waitToResend_4() const { return ___waitToResend_4; }
	inline Routine_t2502590640 ** get_address_of_waitToResend_4() { return &___waitToResend_4; }
	inline void set_waitToResend_4(Routine_t2502590640 * value)
	{
		___waitToResend_4 = value;
		Il2CppCodeGenWriteBarrier(&___waitToResend_4, value);
	}

	inline static int32_t get_offset_of_game_5() { return static_cast<int32_t>(offsetof(TimeReportClientUpdate_t979173133, ___game_5)); }
	inline Game_t1600141214 * get_game_5() const { return ___game_5; }
	inline Game_t1600141214 ** get_address_of_game_5() { return &___game_5; }
	inline void set_game_5(Game_t1600141214 * value)
	{
		___game_5 = value;
		Il2CppCodeGenWriteBarrier(&___game_5, value);
	}

	inline static int32_t get_offset_of_server_6() { return static_cast<int32_t>(offsetof(TimeReportClientUpdate_t979173133, ___server_6)); }
	inline Server_t2724320767 * get_server_6() const { return ___server_6; }
	inline Server_t2724320767 ** get_address_of_server_6() { return &___server_6; }
	inline void set_server_6(Server_t2724320767 * value)
	{
		___server_6 = value;
		Il2CppCodeGenWriteBarrier(&___server_6, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

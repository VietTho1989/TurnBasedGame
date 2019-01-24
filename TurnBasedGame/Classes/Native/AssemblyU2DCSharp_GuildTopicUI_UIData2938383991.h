#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_TopicUI1439963363.h"

// VP`1<ReferenceData`1<GuildTopic>>
struct VP_1_t922514527;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// GuildTopicUI/UIData
struct  UIData_t2938383991  : public TopicUI_t1439963363
{
public:
	// VP`1<ReferenceData`1<GuildTopic>> GuildTopicUI/UIData::guildTopic
	VP_1_t922514527 * ___guildTopic_5;

public:
	inline static int32_t get_offset_of_guildTopic_5() { return static_cast<int32_t>(offsetof(UIData_t2938383991, ___guildTopic_5)); }
	inline VP_1_t922514527 * get_guildTopic_5() const { return ___guildTopic_5; }
	inline VP_1_t922514527 ** get_address_of_guildTopic_5() { return &___guildTopic_5; }
	inline void set_guildTopic_5(VP_1_t922514527 * value)
	{
		___guildTopic_5 = value;
		Il2CppCodeGenWriteBarrier(&___guildTopic_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

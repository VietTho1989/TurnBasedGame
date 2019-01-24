#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "AssemblyU2DCSharp_Foundation_Databinding_Observable280907994.h"

// Foundation.Example.ExampleOptions
struct ExampleOptions_t2666555878;
// System.String[]
struct StringU5BU5D_t1642385972;
// Foundation.Example.ExampleScore
struct ExampleScore_t1071466782;
// Foundation.Databinding.ObservableCollection`1<Foundation.Example.ExampleScore>
struct ObservableCollection_1_t1917800371;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Example.ExampleList
struct  ExampleList_t3532235008  : public ObservableBehaviour_t280907994
{
public:
	// Foundation.Example.ExampleOptions Foundation.Example.ExampleList::Options
	ExampleOptions_t2666555878 * ___Options_8;
	// System.Boolean Foundation.Example.ExampleList::_isVisible
	bool ____isVisible_9;
	// System.String[] Foundation.Example.ExampleList::DemoNames
	StringU5BU5D_t1642385972* ___DemoNames_10;
	// Foundation.Example.ExampleScore Foundation.Example.ExampleList::_myScore
	ExampleScore_t1071466782 * ____myScore_11;
	// Foundation.Databinding.ObservableCollection`1<Foundation.Example.ExampleScore> Foundation.Example.ExampleList::HighScores
	ObservableCollection_1_t1917800371 * ___HighScores_12;

public:
	inline static int32_t get_offset_of_Options_8() { return static_cast<int32_t>(offsetof(ExampleList_t3532235008, ___Options_8)); }
	inline ExampleOptions_t2666555878 * get_Options_8() const { return ___Options_8; }
	inline ExampleOptions_t2666555878 ** get_address_of_Options_8() { return &___Options_8; }
	inline void set_Options_8(ExampleOptions_t2666555878 * value)
	{
		___Options_8 = value;
		Il2CppCodeGenWriteBarrier(&___Options_8, value);
	}

	inline static int32_t get_offset_of__isVisible_9() { return static_cast<int32_t>(offsetof(ExampleList_t3532235008, ____isVisible_9)); }
	inline bool get__isVisible_9() const { return ____isVisible_9; }
	inline bool* get_address_of__isVisible_9() { return &____isVisible_9; }
	inline void set__isVisible_9(bool value)
	{
		____isVisible_9 = value;
	}

	inline static int32_t get_offset_of_DemoNames_10() { return static_cast<int32_t>(offsetof(ExampleList_t3532235008, ___DemoNames_10)); }
	inline StringU5BU5D_t1642385972* get_DemoNames_10() const { return ___DemoNames_10; }
	inline StringU5BU5D_t1642385972** get_address_of_DemoNames_10() { return &___DemoNames_10; }
	inline void set_DemoNames_10(StringU5BU5D_t1642385972* value)
	{
		___DemoNames_10 = value;
		Il2CppCodeGenWriteBarrier(&___DemoNames_10, value);
	}

	inline static int32_t get_offset_of__myScore_11() { return static_cast<int32_t>(offsetof(ExampleList_t3532235008, ____myScore_11)); }
	inline ExampleScore_t1071466782 * get__myScore_11() const { return ____myScore_11; }
	inline ExampleScore_t1071466782 ** get_address_of__myScore_11() { return &____myScore_11; }
	inline void set__myScore_11(ExampleScore_t1071466782 * value)
	{
		____myScore_11 = value;
		Il2CppCodeGenWriteBarrier(&____myScore_11, value);
	}

	inline static int32_t get_offset_of_HighScores_12() { return static_cast<int32_t>(offsetof(ExampleList_t3532235008, ___HighScores_12)); }
	inline ObservableCollection_1_t1917800371 * get_HighScores_12() const { return ___HighScores_12; }
	inline ObservableCollection_1_t1917800371 ** get_address_of_HighScores_12() { return &___HighScores_12; }
	inline void set_HighScores_12(ObservableCollection_1_t1917800371 * value)
	{
		___HighScores_12 = value;
		Il2CppCodeGenWriteBarrier(&___HighScores_12, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

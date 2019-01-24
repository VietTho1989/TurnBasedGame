#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "UnityEngine_UnityEngine_MonoBehaviour1158329972.h"

// Foundation.Example.IocExample/ExampleExport
struct ExampleExport_t2633576219;
// System.Collections.Generic.IEnumerable`1<Foundation.Example.IocExample/ExampleExport>
struct IEnumerable_1_t2925703264;
// Foundation.Example.IocExample/ExampleExport[]
struct ExampleExportU5BU5D_t3981992474;
// UnityEngine.UI.Text
struct Text_t356221433;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// Foundation.Example.IocExample
struct  IocExample_t2127941117  : public MonoBehaviour_t1158329972
{
public:
	// Foundation.Example.IocExample/ExampleExport Foundation.Example.IocExample::Importer1
	ExampleExport_t2633576219 * ___Importer1_2;
	// System.Collections.Generic.IEnumerable`1<Foundation.Example.IocExample/ExampleExport> Foundation.Example.IocExample::Importer2
	Il2CppObject* ___Importer2_3;
	// Foundation.Example.IocExample/ExampleExport[] Foundation.Example.IocExample::Importer3
	ExampleExportU5BU5D_t3981992474* ___Importer3_4;
	// UnityEngine.UI.Text Foundation.Example.IocExample::Logger
	Text_t356221433 * ___Logger_5;

public:
	inline static int32_t get_offset_of_Importer1_2() { return static_cast<int32_t>(offsetof(IocExample_t2127941117, ___Importer1_2)); }
	inline ExampleExport_t2633576219 * get_Importer1_2() const { return ___Importer1_2; }
	inline ExampleExport_t2633576219 ** get_address_of_Importer1_2() { return &___Importer1_2; }
	inline void set_Importer1_2(ExampleExport_t2633576219 * value)
	{
		___Importer1_2 = value;
		Il2CppCodeGenWriteBarrier(&___Importer1_2, value);
	}

	inline static int32_t get_offset_of_Importer2_3() { return static_cast<int32_t>(offsetof(IocExample_t2127941117, ___Importer2_3)); }
	inline Il2CppObject* get_Importer2_3() const { return ___Importer2_3; }
	inline Il2CppObject** get_address_of_Importer2_3() { return &___Importer2_3; }
	inline void set_Importer2_3(Il2CppObject* value)
	{
		___Importer2_3 = value;
		Il2CppCodeGenWriteBarrier(&___Importer2_3, value);
	}

	inline static int32_t get_offset_of_Importer3_4() { return static_cast<int32_t>(offsetof(IocExample_t2127941117, ___Importer3_4)); }
	inline ExampleExportU5BU5D_t3981992474* get_Importer3_4() const { return ___Importer3_4; }
	inline ExampleExportU5BU5D_t3981992474** get_address_of_Importer3_4() { return &___Importer3_4; }
	inline void set_Importer3_4(ExampleExportU5BU5D_t3981992474* value)
	{
		___Importer3_4 = value;
		Il2CppCodeGenWriteBarrier(&___Importer3_4, value);
	}

	inline static int32_t get_offset_of_Logger_5() { return static_cast<int32_t>(offsetof(IocExample_t2127941117, ___Logger_5)); }
	inline Text_t356221433 * get_Logger_5() const { return ___Logger_5; }
	inline Text_t356221433 ** get_address_of_Logger_5() { return &___Logger_5; }
	inline void set_Logger_5(Text_t356221433 * value)
	{
		___Logger_5 = value;
		Il2CppCodeGenWriteBarrier(&___Logger_5, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

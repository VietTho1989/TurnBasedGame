#pragma once

#include "il2cpp-config.h"

#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif

#include <stdint.h>

#include "mscorlib_System_Object2689449295.h"

// UnityImageLoader.ImageLoader
struct ImageLoader_t1566869356;
// System.Object
struct Il2CppObject;
// UnityImageLoader.Http.AbstractHttp
struct AbstractHttp_t2902004550;
// UnityImageLoader.Cache.AbstractMemoryCache
struct AbstractMemoryCache_t2717457341;
// UnityImageLoader.Cache.AbstractDiscCache
struct AbstractDiscCache_t3695984079;




#ifdef __clang__
#pragma clang diagnostic push
#pragma clang diagnostic ignored "-Winvalid-offsetof"
#pragma clang diagnostic ignored "-Wunused-variable"
#endif

// UnityImageLoader.ImageLoader
struct  ImageLoader_t1566869356  : public Il2CppObject
{
public:
	// UnityImageLoader.Http.AbstractHttp UnityImageLoader.ImageLoader::httpImpl
	AbstractHttp_t2902004550 * ___httpImpl_2;
	// UnityImageLoader.Cache.AbstractMemoryCache UnityImageLoader.ImageLoader::_memoryCache
	AbstractMemoryCache_t2717457341 * ____memoryCache_3;
	// UnityImageLoader.Cache.AbstractDiscCache UnityImageLoader.ImageLoader::_discCache
	AbstractDiscCache_t3695984079 * ____discCache_4;

public:
	inline static int32_t get_offset_of_httpImpl_2() { return static_cast<int32_t>(offsetof(ImageLoader_t1566869356, ___httpImpl_2)); }
	inline AbstractHttp_t2902004550 * get_httpImpl_2() const { return ___httpImpl_2; }
	inline AbstractHttp_t2902004550 ** get_address_of_httpImpl_2() { return &___httpImpl_2; }
	inline void set_httpImpl_2(AbstractHttp_t2902004550 * value)
	{
		___httpImpl_2 = value;
		Il2CppCodeGenWriteBarrier(&___httpImpl_2, value);
	}

	inline static int32_t get_offset_of__memoryCache_3() { return static_cast<int32_t>(offsetof(ImageLoader_t1566869356, ____memoryCache_3)); }
	inline AbstractMemoryCache_t2717457341 * get__memoryCache_3() const { return ____memoryCache_3; }
	inline AbstractMemoryCache_t2717457341 ** get_address_of__memoryCache_3() { return &____memoryCache_3; }
	inline void set__memoryCache_3(AbstractMemoryCache_t2717457341 * value)
	{
		____memoryCache_3 = value;
		Il2CppCodeGenWriteBarrier(&____memoryCache_3, value);
	}

	inline static int32_t get_offset_of__discCache_4() { return static_cast<int32_t>(offsetof(ImageLoader_t1566869356, ____discCache_4)); }
	inline AbstractDiscCache_t3695984079 * get__discCache_4() const { return ____discCache_4; }
	inline AbstractDiscCache_t3695984079 ** get_address_of__discCache_4() { return &____discCache_4; }
	inline void set__discCache_4(AbstractDiscCache_t3695984079 * value)
	{
		____discCache_4 = value;
		Il2CppCodeGenWriteBarrier(&____discCache_4, value);
	}
};

struct ImageLoader_t1566869356_StaticFields
{
public:
	// UnityImageLoader.ImageLoader UnityImageLoader.ImageLoader::instance
	ImageLoader_t1566869356 * ___instance_0;
	// System.Object UnityImageLoader.ImageLoader::locker
	Il2CppObject * ___locker_1;

public:
	inline static int32_t get_offset_of_instance_0() { return static_cast<int32_t>(offsetof(ImageLoader_t1566869356_StaticFields, ___instance_0)); }
	inline ImageLoader_t1566869356 * get_instance_0() const { return ___instance_0; }
	inline ImageLoader_t1566869356 ** get_address_of_instance_0() { return &___instance_0; }
	inline void set_instance_0(ImageLoader_t1566869356 * value)
	{
		___instance_0 = value;
		Il2CppCodeGenWriteBarrier(&___instance_0, value);
	}

	inline static int32_t get_offset_of_locker_1() { return static_cast<int32_t>(offsetof(ImageLoader_t1566869356_StaticFields, ___locker_1)); }
	inline Il2CppObject * get_locker_1() const { return ___locker_1; }
	inline Il2CppObject ** get_address_of_locker_1() { return &___locker_1; }
	inline void set_locker_1(Il2CppObject * value)
	{
		___locker_1 = value;
		Il2CppCodeGenWriteBarrier(&___locker_1, value);
	}
};

#ifdef __clang__
#pragma clang diagnostic pop
#endif

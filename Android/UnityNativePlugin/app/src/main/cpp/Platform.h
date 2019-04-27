//
// Created by Viet Tho on 6/26/18.
//

#ifndef NATIVECORE_PLATFORM_H
#define NATIVECORE_PLATFORM_H

#include <string>
#include <stdlib.h>
#include <cstdint>

#ifndef Debug
#define Debug
#endif

// Define EXPORTED for any platform
#ifdef _WIN32
# ifdef WIN_EXPORT
#   define EXPORTED  __declspec( dllexport )
# else
#   define EXPORTED  __declspec( dllimport )
# endif
#else
# define EXPORTED
#endif

#ifdef _MSC_VER
#define __FLT_EPSILON__ 1.192092896e-07F
#endif

int32_t fastRandom(int32_t maxValue);

uint32_t fast_random(uint32_t max);

#ifdef _MSC_VER
//not #if defined(_WIN32) || defined(_WIN64) because we have strncasecmp in mingw
#define strncasecmp _strnicmp
#define strcasecmp _stricmp
#endif

#ifndef Android
#define Android
#endif

#ifndef UsePThread
#define UsePThread
#endif

/*#ifndef BOOST_EXCEPTION_DISABLE
#define BOOST_EXCEPTION_DISABLE
#endif*/

#ifndef Android
#include <sys/timeb.h>
#else
#include <android/log.h>
#include <time.h>
#include <android/asset_manager.h>
#include <jni.h>

#include <ostream>
#include <iostream>
#include <vector>
#endif

inline int64_t now() {
    int64_t time = 0;
#ifndef Android
    timeb tb;
    ftime(&tb);
    time = (int64_t) tb.time * 1000 + tb.millitm;
#else
    struct timespec res;
    clock_gettime(CLOCK_REALTIME, &res);
    time = 1000.0 * res.tv_sec + (double) res.tv_nsec / 1e6;
#endif
    
/*#ifdef Android
    __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "time now: %lld\n", time);
#else
    printf("time now: %lld\n", time);
#endif*/
    return time;
}

#ifdef Android

extern "C"
{

void Java_turnbase_mdc_com_unitynativeplugin_Plugin_setAssetsNative(JNIEnv *env, jobject thiz, jobject jAssetManager);

};

extern AAssetManager* assetManager;

class asset_streambuf: public std::streambuf
{
public:
    asset_streambuf(AAssetManager* manager, const std::string& filename)
            : manager(manager)
    {
        __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "asset_streambuf: constructor: %s\n", filename.c_str());
        asset = AAssetManager_open(manager, filename.c_str(), AASSET_MODE_STREAMING);
        buffer.resize(1024);

        setg(0, 0, 0);
        setp(&buffer.front(), &buffer.front() + buffer.size());
    }

    virtual ~asset_streambuf()
    {
        __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "asset_streambuf: destructor\n");
        sync();
        if(asset!=NULL){
            AAsset_close(asset);
        } else {
            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "asset null\n");
        }
    }

    std::streambuf::int_type underflow() override
    {
        auto bufferPtr = &buffer.front();
        auto counter = AAsset_read(asset, bufferPtr, buffer.size());

        if(counter == 0)
            return traits_type::eof();
        if(counter < 0) //error, what to do now?
            return traits_type::eof();

        setg(bufferPtr, bufferPtr, bufferPtr + counter);

        return traits_type::to_int_type(*gptr());
    }

    std::streambuf::int_type overflow(std::streambuf::int_type value) override
    {
        return traits_type::eof();
    };

    int sync() override
    {
        std::streambuf::int_type result = overflow(traits_type::eof());
        return traits_type::eq_int_type(result, traits_type::eof()) ? -1 : 0;
    }

public:
    AAssetManager* manager;
    AAsset* asset;
    std::vector<char> buffer;
};


class assetistream: public std::istream
{
public:
    assetistream(AAssetManager* manager, const std::string& file) : std::istream(new asset_streambuf(manager, file))
    {

    }

    bool isOpen()
    {
        bool ret = false;
        {
            asset_streambuf* assetBuf = (asset_streambuf*)rdbuf();
            if(assetBuf->asset!=NULL){
                ret = true;
            } else {
                __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "assetBuf->asset null\n");
            }
        }
        return ret;
    }

    void openAsset(const char* fName)
    {
        asset_streambuf* assetBuf = (asset_streambuf*)rdbuf();
        if(assetBuf->asset==NULL){
            assetBuf->asset = AAssetManager_open(assetBuf->manager, fName, AASSET_MODE_STREAMING);
        } else {
            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "assetBuf->asset null\n");
        }
    }

    void close()
    {
        asset_streambuf* assetBuf = (asset_streambuf*)rdbuf();
        if(assetBuf->asset!=NULL){
            AAsset_close(assetBuf->asset);
            assetBuf->asset = NULL;
        } else {
            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "assetBuf->asset null\n");
        }
    }

    virtual ~assetistream()
    {
        delete rdbuf();
    }
};

#endif

#endif //NATIVECORE_PLATFORM_H

// TODO char thi chuyen doi thanh byte o C#

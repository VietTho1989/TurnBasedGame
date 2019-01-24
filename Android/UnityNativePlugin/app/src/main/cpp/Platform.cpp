//
// Created by Viet Tho on 6/26/18.
//

#include "Platform.h"

int32_t fastRandom(int32_t maxValue)
{
    int32_t randomValue = rand()%(maxValue + 1);
    return randomValue;
}

uint32_t fast_random(uint32_t maxValue)
{
    uint32_t randomValue = abs(rand())%(maxValue);
    // printf("fast_random %d, %d\n", randomValue, maxValue);
    return randomValue;
}

#ifdef Android

#include <android/asset_manager.h>
#include <android/asset_manager_jni.h>

AAssetManager* assetManager = NULL;

void Java_turnbase_mdc_com_unitynativeplugin_Plugin_setAssetsNative(JNIEnv *env, jobject thiz, jobject jAssetManager)
{
    assetManager = AAssetManager_fromJava(env, jAssetManager);
    if(assetManager!=NULL){
        AAsset* testAsset = AAssetManager_open(assetManager, "text.txt", AASSET_MODE_UNKNOWN);
        if (testAsset)
        {
            size_t assetLength = AAsset_getLength(testAsset);
            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "Asset file size: %d\n", assetLength);
            char* buffer = (char*) malloc(assetLength + 1);
            AAsset_read(testAsset, buffer, assetLength);
            buffer[assetLength] = 0;
            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "The value is %s", buffer);
            AAsset_close(testAsset);
            free(buffer);
        }
        else
        {
            __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "Cannot open file");
        }
    } else{
        __android_log_print(ANDROID_LOG_ERROR, "NativeCore", "AssetManager null\n");
    }
}

#endif

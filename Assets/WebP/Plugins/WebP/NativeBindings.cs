
using System;
using System.Text;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using UnityEngine;

#pragma warning disable 1591

namespace WebP.Extern
{
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct WebPIDecoder { }

    public enum WEBP_CSP_MODE
    {

        /// MODE_RGB -> 0
        MODE_RGB = 0,

        /// MODE_RGBA -> 1
        MODE_RGBA = 1,

        /// MODE_BGR -> 2
        MODE_BGR = 2,

        /// MODE_BGRA -> 3
        MODE_BGRA = 3,

        /// MODE_ARGB -> 4
        MODE_ARGB = 4,

        /// MODE_RGBA_4444 -> 5
        MODE_RGBA_4444 = 5,

        /// MODE_RGB_565 -> 6
        MODE_RGB_565 = 6,

        /// MODE_rgbA -> 7
        MODE_rgbA = 7,

        /// MODE_bgrA -> 8
        MODE_bgrA = 8,

        /// MODE_Argb -> 9
        MODE_Argb = 9,

        /// MODE_rgbA_4444 -> 10
        MODE_rgbA_4444 = 10,

        /// MODE_YUV -> 11
        MODE_YUV = 11,

        /// MODE_YUVA -> 12
        MODE_YUVA = 12,

        /// MODE_LAST -> 13
        MODE_LAST = 13,
    }

    //------------------------------------------------------------------------------
    // WebPDecBuffer: Generic structure for describing the output sample buffer.

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct WebPRGBABuffer
    {

        /// uint8_t*
        public IntPtr rgba;

        /// int
        public int stride;

        /// size_t->unsigned int
        public UIntPtr size;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct WebPYUVABuffer
    {

        /// uint8_t*
        public IntPtr y;

        /// uint8_t*
        public IntPtr u;

        /// uint8_t*
        public IntPtr v;

        /// uint8_t*
        public IntPtr a;

        /// int
        public int y_stride;

        /// int
        public int u_stride;

        /// int
        public int v_stride;

        /// int
        public int a_stride;

        /// size_t->unsigned int
        public UIntPtr y_size;

        /// size_t->unsigned int
        public UIntPtr u_size;

        /// size_t->unsigned int
        public UIntPtr v_size;

        /// size_t->unsigned int
        public UIntPtr a_size;
    }

    [StructLayoutAttribute(LayoutKind.Explicit)]
    public struct Anonymous_690ed5ec_4c3d_40c6_9bd0_0747b5a28b54
    {

        /// WebPRGBABuffer->Anonymous_47cdec86_3c1a_4b39_ab93_76bc7499076a
        [FieldOffsetAttribute(0)]
        public WebPRGBABuffer RGBA;

        /// WebPYUVABuffer->Anonymous_70de6e8e_c3ae_4506_bef0_c17f17a7e678
        [FieldOffsetAttribute(0)]
        public WebPYUVABuffer YUVA;
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct WebPDecBuffer
    {

        /// WEBP_CSP_MODE->Anonymous_cb136f5b_1d5d_49a0_aca4_656a79e9d159
        public WEBP_CSP_MODE colorspace;

        /// int
        public int width;

        /// int
        public int height;

        /// int
        public int is_external_memory;

        /// Anonymous_690ed5ec_4c3d_40c6_9bd0_0747b5a28b54
        public Anonymous_690ed5ec_4c3d_40c6_9bd0_0747b5a28b54 u;

        /// uint32_t[4]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
        public uint[] pad;

        /// uint8_t*
        public IntPtr private_memory;
    }


    //------------------------------------------------------------------------------
    // Enumeration of the status codes

    public enum VP8StatusCode
    {

        /// VP8_STATUS_OK -> 0
        VP8_STATUS_OK = 0,

        VP8_STATUS_OUT_OF_MEMORY,

        VP8_STATUS_INVALID_PARAM,

        VP8_STATUS_BITSTREAM_ERROR,

        VP8_STATUS_UNSUPPORTED_FEATURE,

        VP8_STATUS_SUSPENDED,

        VP8_STATUS_USER_ABORT,

        VP8_STATUS_NOT_ENOUGH_DATA,
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct WebPBitstreamFeatures
    {

        /// <summary>
        /// Width in pixels, as read from the bitstream
        /// </summary>
        public int width;

        /// <summary>
        /// Height in pixels, as read from the bitstream.
        /// </summary>
        public int height;

        /// <summary>
        /// // True if the bitstream contains an alpha channel.
        /// </summary>
        public int has_alpha;

        /// <summary>
        /// Unused for now - should be 0
        /// </summary>
        public int bitstream_version;

        /// <summary>
        /// If true, incremental decoding is not reccomended
        /// </summary>
        public int no_incremental_decoding;

        /// <summary>
        /// Unused, should be 0 for now
        /// </summary>
        public int rotate;

        /// <summary>
        /// Unused, should be 0 for now
        /// </summary>
        public int uv_sampling;

        /// <summary>
        /// Padding for later use
        /// </summary>
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.U4)]
        public uint[] pad;
    }

    // Decoding options
    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct WebPDecoderOptions
    {
        public int bypass_filtering;               // if true, skip the in-loop filtering
        public int no_fancy_upsampling;            // if true, use faster pointwise upsampler
        public int use_cropping;                   // if true, cropping is applied _first_
        public int crop_left, crop_top;            // top-left position for cropping.
        // Will be snapped to even values.
        public int crop_width, crop_height;        // dimension of the cropping area
        public int use_scaling;                    // if true, scaling is applied _afterward_
        public int scaled_width, scaled_height;    // final resolution
        public int use_threads;                    // if true, use multi-threaded decoding
        public int dithering_strength;             // dithering strength (0=Off, 100=full)

        // Unused for now:
        public int force_rotation;                 // forced rotation (to be applied _last_)
        public int no_enhancement;                 // if true, discard enhancement layer
        /// uint32_t[5]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.U4)]
        public uint[] pad;
    };

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct WebPDecoderConfig
    {

        /// WebPBitstreamFeatures->Anonymous_c6b01f0b_3e38_4731_b2d6_9c0e3bdb71aa
        public WebPBitstreamFeatures input;

        /// WebPDecBuffer->Anonymous_5c438b36_7de6_498e_934a_d3613b37f5fc
        public WebPDecBuffer output;

        /// WebPDecoderOptions->Anonymous_78066979_3e1e_4d74_aee5_f316b20e3385
        public WebPDecoderOptions options;
    }


    public enum WebPImageHint
    {

        /// WEBP_HINT_DEFAULT -> 0
        WEBP_HINT_DEFAULT = 0,

        WEBP_HINT_PICTURE,

        WEBP_HINT_PHOTO,

        WEBP_HINT_GRAPH,

        WEBP_HINT_LAST,
    }

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct WebPConfig
    {

        /// int
        public int lossless;

        /// float
        public float quality;

        /// int
        public int method;

        /// WebPImageHint->Anonymous_838f22f5_6f57_48a0_9ecb_8eec917009f9
        public WebPImageHint image_hint;

        /// int
        public int target_size;

        /// float
        public float target_PSNR;

        /// int
        public int segments;

        /// int
        public int sns_strength;

        /// int
        public int filter_strength;

        /// int
        public int filter_sharpness;

        /// int
        public int filter_type;

        /// int
        public int autofilter;

        /// int
        public int alpha_compression;

        /// int
        public int alpha_filtering;

        /// int
        public int alpha_quality;

        /// int
        public int pass;

        /// int
        public int show_compressed;

        /// int
        public int preprocessing;

        /// int
        public int partitions;

        /// int
        public int partition_limit;

        public int emulate_jpeg_size;

        public int thread_level;

        public int low_memory;

        /// uint32_t[5]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.U4)]
        public uint[] pad;
    }

    public enum WebPPreset
    {

        /// WEBP_PRESET_DEFAULT -> 0
        WEBP_PRESET_DEFAULT = 0,

        WEBP_PRESET_PICTURE,

        WEBP_PRESET_PHOTO,

        WEBP_PRESET_DRAWING,

        WEBP_PRESET_ICON,

        WEBP_PRESET_TEXT,
    }






    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct WebPAuxStats
    {

        /// int
        public int coded_size;

        /// float[5]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 5, ArraySubType = UnmanagedType.R4)]
        public float[] PSNR;

        /// int[3]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.I4)]
        public int[] block_count;

        /// int[2]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.I4)]
        public int[] header_bytes;

        /// int[12]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 12, ArraySubType = UnmanagedType.I4)]
        public int[] residual_bytes;

        /// int[4]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I4)]
        public int[] segment_size;

        /// int[4]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I4)]
        public int[] segment_quant;

        /// int[4]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.I4)]
        public int[] segment_level;

        /// int
        public int alpha_data_size;

        /// int
        public int layer_data_size;

        /// uint32_t->unsigned int
        public uint lossless_features;

        /// int
        public int histogram_bits;

        /// int
        public int transform_bits;

        /// int
        public int cache_bits;

        /// int
        public int palette_size;

        /// int
        public int lossless_size;

        /// uint32_t[4]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 4, ArraySubType = UnmanagedType.U4)]
        public uint[] pad;
    }


    /// Return Type: int
    ///data: uint8_t*
    ///data_size: size_t->unsigned int
    ///picture: WebPPicture*
    public delegate int WebPWriterFunction([InAttribute()] IntPtr data, UIntPtr data_size, ref WebPPicture picture);

    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct WebPMemoryWriter
    {

        /// uint8_t*
        public IntPtr mem;

        /// size_t->unsigned int
        public UIntPtr size;

        /// size_t->unsigned int
        public UIntPtr max_size;

        /// uint32_t[1]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 1, ArraySubType = UnmanagedType.U4)]
        public uint[] pad;
    }



    /// Return Type: int
    ///percent: int
    ///picture: WebPPicture*
    public delegate int WebPProgressHook(int percent, ref WebPPicture picture);

    public enum WebPEncCSP
    {

        /// WEBP_YUV420 -> 0
        WEBP_YUV420 = 0,

        /// WEBP_YUV422 -> 1
        WEBP_YUV422 = 1,

        /// WEBP_YUV444 -> 2
        WEBP_YUV444 = 2,

        /// WEBP_YUV400 -> 3
        WEBP_YUV400 = 3,

        /// WEBP_CSP_UV_MASK -> 3
        WEBP_CSP_UV_MASK = 3,

        /// WEBP_YUV420A -> 4
        WEBP_YUV420A = 4,

        /// WEBP_YUV422A -> 5
        WEBP_YUV422A = 5,

        /// WEBP_YUV444A -> 6
        WEBP_YUV444A = 6,

        /// WEBP_YUV400A -> 7
        WEBP_YUV400A = 7,

        /// WEBP_CSP_ALPHA_BIT -> 4
        WEBP_CSP_ALPHA_BIT = 4,
    }


    public enum WebPEncodingError
    {

        /// VP8_ENC_OK -> 0
        VP8_ENC_OK = 0,

        VP8_ENC_ERROR_OUT_OF_MEMORY,

        VP8_ENC_ERROR_BITSTREAM_OUT_OF_MEMORY,

        VP8_ENC_ERROR_NULL_PARAMETER,

        VP8_ENC_ERROR_INVALID_CONFIGURATION,

        VP8_ENC_ERROR_BAD_DIMENSION,

        VP8_ENC_ERROR_PARTITION0_OVERFLOW,

        VP8_ENC_ERROR_PARTITION_OVERFLOW,

        VP8_ENC_ERROR_BAD_WRITE,

        VP8_ENC_ERROR_FILE_TOO_BIG,

        VP8_ENC_ERROR_USER_ABORT,

        VP8_ENC_ERROR_LAST,
    }



    [StructLayoutAttribute(LayoutKind.Sequential)]
    public struct WebPPicture
    {

        /// int
        public int use_argb;

        /// WebPEncCSP->Anonymous_84ce7065_fe91_48b4_93d8_1f0e84319dba
        public WebPEncCSP colorspace;

        /// int
        public int width;

        /// int
        public int height;

        /// uint8_t*
        public IntPtr y;

        /// uint8_t*
        public IntPtr u;

        /// uint8_t*
        public IntPtr v;

        /// int
        public int y_stride;

        /// int
        public int uv_stride;

        /// uint8_t*
        public IntPtr a;

        /// int
        public int a_stride;

        /// uint32_t[2]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.U4)]
        public uint[] pad1;

        /// uint32_t*
        public IntPtr argb;

        /// int
        public int argb_stride;

        /// uint32_t[3]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.U4)]
        public uint[] pad2;

        /// WebPWriterFunction
        public WebPWriterFunction writer;

        /// void*
        public IntPtr custom_ptr;

        /// int
        public int extra_info_type;

        /// uint8_t*
        public IntPtr extra_info;

        /// WebPAuxStats*
        public IntPtr stats;

        /// WebPEncodingError->Anonymous_8b714d63_f91b_46af_b0d0_667c703ed356
        public WebPEncodingError error_code;

        /// WebPProgressHook
        public WebPProgressHook progress_hook;

        /// void*
        public IntPtr user_data;

        /// uint32_t[3]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 3, ArraySubType = UnmanagedType.U4)]
        public uint[] pad3;

        /// uint8_t*
        public IntPtr u0;

        /// uint8_t*
        public IntPtr v0;

        /// int
        public int uv0_stride;

        /// uint32_t[7]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 7, ArraySubType = UnmanagedType.U4)]
        public uint[] pad4;

        /// void*
        public IntPtr memory_;

        /// void*
        public IntPtr memory_argb_;

        /// void*[2]
        [MarshalAsAttribute(UnmanagedType.ByValArray, SizeConst = 2, ArraySubType = UnmanagedType.SysUInt)]
        public IntPtr[] pad5;
    }

    public class NativeBindings {

        /// WEBP_DECODER_ABI_VERSION 0x0203    // MAJOR(8b) + MINOR(8b)
        public const int WEBP_DECODER_ABI_VERSION = 515;

        /// WEBP_ENCODER_ABI_VERSION 0x0202    // MAJOR(8b) + MINOR(8b)
        public const int WEBP_ENCODER_ABI_VERSION = 514;

        public static string CurrentPlatform = "";
        public static string GetPlatformName() {
            if (CurrentPlatform != "") {
                return CurrentPlatform;
            }

            if (Application.platform == RuntimePlatform.OSXEditor || Application.platform == RuntimePlatform.Android) {
                CurrentPlatform = "android";
            } else {
                CurrentPlatform = "ios";
            }

            return CurrentPlatform;
        }
        // Some useful macros:

        /// <summary>
        /// Returns true if the specified mode uses a premultiplied alpha
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static bool WebPIsPremultipliedMode(WEBP_CSP_MODE mode)
        {

            return (mode == WEBP_CSP_MODE.MODE_rgbA || mode == WEBP_CSP_MODE.MODE_bgrA || mode == WEBP_CSP_MODE.MODE_Argb ||
                mode == WEBP_CSP_MODE.MODE_rgbA_4444);

        }

        /// <summary>
        /// Returns true if the given mode is RGB(A)
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static bool WebPIsRGBMode(WEBP_CSP_MODE mode)
        {

            return (mode < WEBP_CSP_MODE.MODE_YUV);

        }


        /// <summary>
        /// Returns true if the given mode has an alpha channel
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        public static bool WebPIsAlphaMode(WEBP_CSP_MODE mode)
        {

            return (mode == WEBP_CSP_MODE.MODE_RGBA || mode == WEBP_CSP_MODE.MODE_BGRA || mode == WEBP_CSP_MODE.MODE_ARGB ||
                    mode == WEBP_CSP_MODE.MODE_RGBA_4444 || mode == WEBP_CSP_MODE.MODE_YUVA ||
                    WebPIsPremultipliedMode(mode));

        }



        // 

        /// <summary>
        /// Retrieve features from the bitstream. The *features structure is filled
        /// with information gathered from the bitstream.
        /// Returns false in case of error or version mismatch.
        /// In case of error, features->bitstream_status will reflect the error code.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="data_size"></param>
        /// <param name="features"></param>
        /// <returns></returns>
        public static VP8StatusCode WebPGetFeatures(IntPtr data, UIntPtr data_size, ref WebPBitstreamFeatures features)
        {
            if (GetPlatformName() == "android") {
                return NativeBindings_Android.WebPGetFeaturesInternal(data, data_size, ref features, WEBP_DECODER_ABI_VERSION);
            } else {
                return NativeBindings_iOS.WebPGetFeaturesInternal(data, data_size, ref features, WEBP_DECODER_ABI_VERSION);
            }
        }

        /// <summary>
        /// Initialize the configuration as empty. This function must always be
        /// called first, unless WebPGetFeatures() is to be called.
        /// Returns false in case of mismatched version.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static int WebPInitDecoderConfig(ref WebPDecoderConfig config)
        {
            if (GetPlatformName() == "android") {
                return NativeBindings_Android.WebPInitDecoderConfigInternal(ref config, WEBP_DECODER_ABI_VERSION);
            } else {
                return NativeBindings_iOS.WebPInitDecoderConfigInternal(ref config, WEBP_DECODER_ABI_VERSION);
            }
        }

        public static int WebPGetInfo(IntPtr data, UIntPtr data_size, ref int width, ref int height) {
            if (GetPlatformName() == "android") {
                return NativeBindings_Android.WebPGetInfo(data, data_size, ref width, ref height);
            } else {
                return NativeBindings_iOS.WebPGetInfo(data, data_size, ref width, ref height);
            }
        }

        /// <summary>
        /// Initialize the structure as empty. Must be called before any other use. Returns false in case of version mismatch
        /// </summary>
        /// <param name="buffer"></param>
        /// <returns></returns>
        public static int WebPInitDecBuffer(ref WebPDecBuffer buffer)
        {
            if (GetPlatformName() == "android") {
                return NativeBindings_Android.WebPInitDecBufferInternal(ref buffer, WEBP_DECODER_ABI_VERSION);
            } else {
                return NativeBindings_iOS.WebPInitDecBufferInternal(ref buffer, WEBP_DECODER_ABI_VERSION);
            }
        }



        //    // Deprecated alpha-less version of WebPIDecGetYUVA(): it will ignore the

        //// alpha information (if present). Kept for backward compatibility.

        //public IntPtr WebPIDecGetYUV(IntPtr decoder, int* last_y, uint8_t** u, uint8_t** v,

        //    int* width, int* height, int* stride, int* uv_stride) {

        //  return WebPIDecGetYUVA(idec, last_y, u, v, NULL, width, height,

        //                         stride, uv_stride, NULL);

        /// <summary>
        /// Should always be called, to initialize a fresh WebPConfig structure before
        /// modification. Returns false in case of version mismatch. WebPConfigInit()
        /// must have succeeded before using the 'config' object.
        /// Note that the default values are lossless=0 and quality=75.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public static int WebPConfigInit(ref WebPConfig config)
        {
            if (GetPlatformName() == "android") {
                return NativeBindings_Android.WebPConfigInitInternal(ref config, WebPPreset.WEBP_PRESET_DEFAULT, 75.0f, WEBP_ENCODER_ABI_VERSION);
            } else {
                return NativeBindings_iOS.WebPConfigInitInternal(ref config, WebPPreset.WEBP_PRESET_DEFAULT, 75.0f, WEBP_ENCODER_ABI_VERSION);
            }
        }

        /// <summary>
        /// This function will initialize the configuration according to a predefined
        /// set of parameters (referred to by 'preset') and a given quality factor.
        /// This function can be called as a replacement to WebPConfigInit(). Will return false in case of error.
        /// </summary>
        /// <param name="config"></param>
        /// <param name="preset"></param>
        /// <param name="quality"></param>
        /// <returns></returns>
        public static int WebPConfigPreset(ref WebPConfig config, WebPPreset preset, float quality)
        {
            if (GetPlatformName() == "android") {
                return NativeBindings_Android.WebPConfigInitInternal(ref config, preset, quality, WEBP_ENCODER_ABI_VERSION);
            } else {
                return NativeBindings_iOS.WebPConfigInitInternal(ref config, preset, quality, WEBP_ENCODER_ABI_VERSION);
            }
        }

        /// <summary>
        /// Should always be called, to initialize the structure. Returns false in case
        /// of version mismatch. WebPPictureInit() must have succeeded before using the
        /// 'picture' object.
        /// Note that, by default, use_argb is false and colorspace is WEBP_YUV420.
        /// </summary>
        /// <param name="picture"></param>
        /// <returns></returns>
        public static int WebPPictureInit(ref WebPPicture picture)
        {
            if (GetPlatformName() == "android") {
                return NativeBindings_Android.WebPPictureInitInternal(ref picture, WEBP_ENCODER_ABI_VERSION);
            } else {
                return NativeBindings_iOS.WebPPictureInitInternal(ref picture, WEBP_ENCODER_ABI_VERSION);
            }
        }
        
        public static UIntPtr WebPEncodeLosslessRGBA(IntPtr rgb, int width, int height, int stride, ref IntPtr output) {
            if (GetPlatformName() == "android") {
                return NativeBindings_Android.WebPEncodeLosslessRGBA(rgb, width, height, stride, ref output);
            } else {
                return NativeBindings_iOS.WebPEncodeLosslessRGBA(rgb, width, height, stride, ref output);
            }
        }

        public static UIntPtr WebPEncodeRGBA (IntPtr rgba, int width, int height, int stride, float quality_factor, ref IntPtr output) {
            if (GetPlatformName() == "android") {
                return NativeBindings_Android.WebPEncodeRGBA(rgba, width, height, stride, quality_factor, ref output);
            } else {
                return NativeBindings_iOS.WebPEncodeRGBA(rgba, width, height, stride, quality_factor, ref output);
            }
        }
        
        public static void WebPSafeFree(IntPtr toDeallocate) {
            if (GetPlatformName() == "android") {
                NativeBindings_Android.WebPSafeFree(toDeallocate);
            } else {
                NativeBindings_iOS.WebPSafeFree(toDeallocate);
            }
        }

        public static VP8StatusCode WebPDecode (IntPtr data, UIntPtr data_size, ref WebPDecoderConfig config) {
            if (GetPlatformName() == "android") {
                return NativeBindings_Android.WebPDecode(data, data_size, ref config);
            } else {
                return NativeBindings_iOS.WebPDecode(data, data_size, ref config);
            }
        }
    }
}

#pragma warning restore 1591

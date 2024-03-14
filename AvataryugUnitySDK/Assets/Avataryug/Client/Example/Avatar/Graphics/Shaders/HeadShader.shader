Shader "Avataryug/HeadShader"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _TatooTexture ("Tatoo Texture", 2D) = "white" {}
        _HairTexture ("Hair Texture", 2D) = "white" {}
        _HairColor ("Hair Color", Color) = (1,1,1,1)
        _BeardTexture ("Beard Texture", 2D) = "white" {}
        _BeardColor ("Beard Color", Color) = (1,1,1,1)
        _EyebrowTexture ("Eyebrow Texture", 2D) = "white" {}
        _EyebrowColor ("Eyebrow Color", Color) = (1,1,1,1)
        _LipsTexture ("Lip Texture", 2D) = "white" {}
        _LipsColor ("Lip Color", Color) = (1,1,1,1)
        _BumpMap ("Normal Map", 2D) = "bump" {}
        //_RoughnessMap("Roughness Map", 2D) = "white" {}
        //_RoughnessRange("Metallic", Range(0.0, 1.0)) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
         #pragma surface surf Standard fullforwardshadows

        #pragma target 3.5

        sampler2D _MainTex;
        sampler2D _TatooTexture;
        sampler2D _HairTexture;
        sampler2D _BeardTexture;
        sampler2D _EyebrowTexture;
        sampler2D _LipsTexture;
        sampler2D _BumpMap;
       // sampler2D _RoughnessMap;
        struct Input
        {
            float2 uv_MainTex;
            float2 uv_TatooTexture;
            float2 uv_HairTexture;
            float2 uv_BeardTexture;
            float2 uv_EyebrowTexture;
            float2 uv_LipsTexture;
        };

        fixed4 _HairColor; 
        fixed4 _BeardColor; 
        fixed4 _EyebrowColor; 
        fixed4 _LipsColor;
        float _RoughnessRange;

        UNITY_INSTANCING_BUFFER_START(Props)
            UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard  o)
        {
            fixed4 faceTex = tex2D (_MainTex, IN.uv_MainTex) ;
            fixed4 tatooTex = tex2D (_TatooTexture, IN.uv_TatooTexture) ;
            fixed4 hairTex = tex2D (_HairTexture, IN.uv_HairTexture) * _HairColor;
            fixed4 beardTex = tex2D (_BeardTexture, IN.uv_BeardTexture) * _BeardColor;
            fixed4 eyebroTex = tex2D (_EyebrowTexture, IN.uv_EyebrowTexture) * _EyebrowColor;
            fixed4 lipTex = tex2D (_LipsTexture, IN.uv_LipsTexture) * _LipsColor ;

            fixed4 faceXtatoo = lerp(faceTex,tatooTex,tatooTex.a);
            fixed4 ftXhair = lerp(faceXtatoo,hairTex,hairTex.a);
            fixed4 fthXbeard = lerp(ftXhair,beardTex,beardTex.a);
            fixed4 fthbXeyebro = lerp(fthXbeard,eyebroTex,eyebroTex.a);
            fixed4 fthbeeXlip = lerp(fthbXeyebro,lipTex,lipTex.a);
            o.Albedo = fthbeeXlip ;
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex));
            //o.Smoothness = tex2D(_RoughnessMap, IN.uv_MainTex) * _RoughnessRange;
        }
        ENDCG
    }
    FallBack "Diffuse"
}

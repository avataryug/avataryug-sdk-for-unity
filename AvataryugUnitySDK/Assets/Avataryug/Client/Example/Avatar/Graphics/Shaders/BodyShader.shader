Shader "Avataryug/BodyShader"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _Glossiness ("Smoothness", Range(0,1)) = 0.16
        _FrontBodyTattoo ("FrontBodyTattoo", 2D) = "white" {}
        _BackBodyTattoo("BackBodyTattoo", 2D) = "white" {}
        _RightArmTattoo("RightArmTattoo", 2D) = "white" {}
        _LeftArmTattoo("LeftArmTattoo", 2D) = "white" {}
        _FrontRightLegTattoo("FrontRightLegTattoo", 2D) = "white" {}
        _FrontLeftLegTattoo("FrontLeftLegTattoo", 2D) = "white" {}
        _BackRightLegTattoo("BackRightLegTattoo", 2D) = "white" {}
        _BackLeftLegTattoo("BackLeftLegTattoo", 2D) = "white" {}
        _RightHandTattoo("RightHandTattoo", 2D) = "white" {}
        _LeftHandTattoo("LeftHandTattoo", 2D) = "white" {}
        _RightFootTattoo("RightFootTattoo", 2D) = "white" {}
        _LeftFootTattoo("LeftFootTattoo", 2D) = "white" {}

    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf StandardSpecular fullforwardshadows

        #pragma target 3.5

        sampler2D _MainTex;

        sampler2D _FrontBodyTattoo;
        sampler2D _BackBodyTattoo;
        sampler2D _RightArmTattoo;
        sampler2D _LeftArmTattoo;
        sampler2D _FrontRightLegTattoo;
        sampler2D _FrontLeftLegTattoo;
        sampler2D _BackRightLegTattoo;
        sampler2D _BackLeftLegTattoo;
        sampler2D _RightHandTattoo;
        sampler2D _LeftHandTattoo;
        sampler2D _RightFootTattoo;
        sampler2D _LeftFootTattoo;

        struct Input
        {
            float2 uv_MainTex;
            float2 uv_TatooTexture;
            float2 uv_FrontBodyTattoo;
            float2 uv_BackBodyTattoo;
            float2 uv_RightArmTattoo;
            float2 uv_LeftArmTattoo;
            float2 uv_FrontRightLegTattoo;
            float2 uv_FrontLeftLegTattoo;
            float2 uv_BackRightLegTattoo;
            float2 uv_BackLeftLegTattoo;
            float2 uv_RightHandTattoo;
            float2 uv_LeftHandTattoo;
            float2 uv_RightFootTattoo;
            float2 uv_LeftFootTattoo;
        };

        fixed4 _Color;

        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandardSpecular o)
        {
            fixed4 faceTex = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            fixed4 frontBodyTattoo = tex2D (_FrontBodyTattoo, IN.uv_FrontBodyTattoo);
            fixed4 backBodyTattoo = tex2D (_BackBodyTattoo, IN.uv_BackBodyTattoo);
            fixed4 rightArmTattoo = tex2D (_RightArmTattoo, IN.uv_RightArmTattoo);
            fixed4 leftArmTattoo = tex2D (_LeftArmTattoo, IN.uv_LeftArmTattoo);
            fixed4 frontRightLegTattoo = tex2D (_FrontRightLegTattoo, IN.uv_FrontRightLegTattoo);
            fixed4 frontLeftLegTattoo = tex2D (_FrontLeftLegTattoo, IN.uv_FrontLeftLegTattoo);
            fixed4 backRightLegTattoo = tex2D (_BackRightLegTattoo, IN.uv_BackRightLegTattoo);
            fixed4 backLeftLegTattoo = tex2D (_BackLeftLegTattoo, IN.uv_BackLeftLegTattoo);
            fixed4 rightHandTattoo = tex2D (_RightHandTattoo, IN.uv_RightHandTattoo);
            fixed4 leftHandTattoo = tex2D (_LeftHandTattoo, IN.uv_LeftHandTattoo);
            fixed4 rightFootTattoo = tex2D (_RightFootTattoo, IN.uv_RightFootTattoo);
            fixed4 leftFootTattoo = tex2D (_LeftFootTattoo, IN.uv_LeftFootTattoo);

            fixed4 baset1 = lerp(faceTex,frontBodyTattoo,frontBodyTattoo.a);
            fixed4 baset2 = lerp(baset1,backBodyTattoo,backBodyTattoo.a);
            fixed4 baset3 = lerp(baset2,rightArmTattoo,rightArmTattoo.a);
            fixed4 baset4 = lerp(baset3,leftArmTattoo,leftArmTattoo.a);
            fixed4 baset5 = lerp(baset4,frontRightLegTattoo,frontRightLegTattoo.a);
            fixed4 baset6 = lerp(baset5,frontLeftLegTattoo,frontLeftLegTattoo.a);
            fixed4 baset7 = lerp(baset6,backRightLegTattoo,backRightLegTattoo.a);
            fixed4 baset8 = lerp(baset7,backLeftLegTattoo,backLeftLegTattoo.a);
            fixed4 baset9 = lerp(baset8,rightHandTattoo,rightHandTattoo.a);
            fixed4 baset10 = lerp(baset9,leftHandTattoo,leftHandTattoo.a);
            fixed4 baset11 = lerp(baset10,rightFootTattoo,rightFootTattoo.a);
            fixed4 baset12 = lerp(baset11,leftFootTattoo,leftFootTattoo.a);

            o.Albedo = baset12 ;
            o.Alpha = baset12.a;
            //o.Metallic = _Metallic;
            //o.Smoothness = _Glossiness;
              
        }
        ENDCG
    }
    FallBack "Diffuse"
}

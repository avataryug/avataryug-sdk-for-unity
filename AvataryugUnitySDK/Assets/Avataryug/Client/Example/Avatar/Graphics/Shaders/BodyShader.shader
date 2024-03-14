Shader "Avataryug/BodyShader"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        //_FrontBodyTattoo ("FrontBodyTattoo", 2D) = "white" {}
        //_BackBodyTattoo("BackBodyTattoo", 2D) = "white" {}
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
        _BumpMap ("Normal Map", 2D) = "bump" {}
        //_RoughnessMap ("Roughness Map", 2D) = "white" {}
        //_RoughnessRange("Roughness", Range(0.0, 1.0)) = 0.0
    }
    SubShader
    {
           Tags { "RenderType" = "Opaque" }
        LOD 200

        CGPROGRAM
         #pragma surface surf Standard fullforwardshadows

        #pragma target 3.5

        sampler2D _MainTex;
        //sampler2D _FrontBodyTattoo;
        //sampler2D _BackBodyTattoo;
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
        sampler2D _BumpMap;
        //sampler2D _RoughnessMap;
        //float _RoughnessRange;
        struct Input
        {
            float2 uv_MainTex;
            float2 uv_TatooTexture;
            //float2 uv_FrontBodyTattoo;
            //float2 uv_BackBodyTattoo;
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


        UNITY_INSTANCING_BUFFER_START(Props)
        UNITY_INSTANCING_BUFFER_END(Props)

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 faceTex = tex2D (_MainTex, IN.uv_MainTex);
            //fixed4 frontBodyTattoo = tex2D (_FrontBodyTattoo, IN.uv_FrontBodyTattoo);
            //fixed4 backBodyTattoo = tex2D (_BackBodyTattoo, IN.uv_BackBodyTattoo);
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


            //fixed4 baset1 = lerp(faceTex,frontBodyTattoo,frontBodyTattoo.a);
            //fixed4 baset2 = lerp(baset1,backBodyTattoo,backBodyTattoo.a);
            //fixed4 baset3 = lerp(baset2,rightArmTattoo,rightArmTattoo.a);
            //fixed4 baset4 = lerp(baset3,leftArmTattoo,leftArmTattoo.a);
            //fixed4 baset5 = lerp(baset4,frontRightLegTattoo,frontRightLegTattoo.a);
            //fixed4 baset6 = lerp(baset5,frontLeftLegTattoo,frontLeftLegTattoo.a);
            //fixed4 baset7 = lerp(baset6,backRightLegTattoo,backRightLegTattoo.a);
            //fixed4 baset8 = lerp(baset7,backLeftLegTattoo,backLeftLegTattoo.a);
            //fixed4 baset9 = lerp(baset8,rightHandTattoo,rightHandTattoo.a);
            //fixed4 baset10 = lerp(baset9,leftHandTattoo,leftHandTattoo.a);
            //fixed4 baset11 = lerp(baset10,rightFootTattoo,rightFootTattoo.a);
            //fixed4 baset12 = lerp(baset11,leftFootTattoo,leftFootTattoo.a);


            fixed4 base1 = lerp(faceTex, rightArmTattoo, rightArmTattoo.a);
            fixed4 base2 = lerp(base1, leftArmTattoo, leftArmTattoo.a);
            fixed4 base3 = lerp(base2, frontRightLegTattoo, frontRightLegTattoo.a);
            fixed4 base4 = lerp(base3, frontLeftLegTattoo, frontLeftLegTattoo.a);
            fixed4 base5 = lerp(base4, backRightLegTattoo, backRightLegTattoo.a);
            fixed4 base6 = lerp(base5, backLeftLegTattoo, backLeftLegTattoo.a);
            fixed4 base7 = lerp(base6, rightHandTattoo, rightHandTattoo.a);
            fixed4 base8 = lerp(base7, leftHandTattoo, leftHandTattoo.a);
            fixed4 base9 = lerp(base8, rightFootTattoo, rightFootTattoo.a);
            fixed4 base10 = lerp(base9, leftFootTattoo, leftFootTattoo.a);

            o.Albedo = base10;
            o.Alpha = base10.a;
            o.Normal = UnpackNormal(tex2D(_BumpMap, IN.uv_MainTex));
           // o.Smoothness = tex2D(_RoughnessMap, IN.uv_MainTex) * 1;
            //o.Specular = tex2D(_SpecularMap, IN.uv_MainTex);
            
              
        }
        ENDCG
    }
    FallBack "Diffuse"
}

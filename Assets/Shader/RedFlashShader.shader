Shader "Custom/RedFlashShader"
{
    Properties
    {
        _Color("Main Color", Color) = (1, 1, 1, 1)
        _FlashColor("Flash Color", Color) = (1, 0, 0, 1)
        _FlashIntensity("Flash Intensity", Range(0, 1)) = 0
    }

        SubShader
    {
        Tags { "RenderType" = "Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        sampler2D _Color;
        fixed4 _FlashColor;
        float _FlashIntensity;

        struct Input
        {
            float2 uv_MainTex;
        };

        void surf(Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D(_Color, IN.uv_MainTex);
            c.rgb += _FlashColor.rgb * _FlashIntensity;
            o.Albedo = c.rgb;
            o.Alpha = c.a;
        }
        ENDCG
    }
        FallBack "Diffuse"
}
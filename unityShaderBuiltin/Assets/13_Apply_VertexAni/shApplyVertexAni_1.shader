/*
    Vertex Animation 예시

        ex)풀이 반복적인 패턴을 보이며 흔들림, 바다가 반복적인 패턴을 보이며 출렁임
        이런 움직임이라면 Vertex Animation이 효율적으로 적용될 수 있다

    step_1 vertex animation 수행
*/

Shader "Custom/shApplyVertexAni_1"
{
    Properties
    {
        _MainTex ("Albedo (RGB)", 2D) = "white" {}

        _Cutoff("Cut off", float) = 0.5 //알파테스트를 위한 기준값

        _Amplitude("Amplitude", Range(0,5)) = 0
        _Frequency("Frequency", Range(0,5)) = 0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        // Physically based Standard lighting model, and enable shadows on all light types
        #pragma surface surf Standard fullforwardshadows alphatest:_Cutoff vertex:DoVert

        // Use shader model 3.0 target, to get nicer looking lighting
        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
        };

        fixed _Amplitude;
        fixed _Frequency;


        // Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
        // See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
        // #pragma instancing_options assumeuniformscaling
        UNITY_INSTANCING_BUFFER_START(Props)
            // put more per-instance properties here
        UNITY_INSTANCING_BUFFER_END(Props)

        float random(float2 uv)
        {
            return frac(sin(dot(uv, float2(12.9898, 78.233))) * 43758.5453123);
            // frac : 주어진 수의 소수점 이하 값만 취한다
        }

        void DoVert(inout appdata_full v)
        {
            // vertex animation 정점 애니메이션
            //v.vertex.y += sin(_Time.y);
            //v.vertex.y += _SinTime.w;
            //v.vertex.y += 2.0 * sin(_Time.y);   // 진폭 조정 움직임의 크기
            //v.vertex.y += sin(_Time.y * 0.5);   // 주파수 조정 움직임의 빠르기
            
            v.vertex.y += _Amplitude * sin(_Time.y * _Frequency) * random(v.texcoord);
            
        }

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            // Albedo comes from a texture tinted by color
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex);
            o.Albedo = c.rgb;

            o.Alpha = c.a;
            
        }
        ENDCG
    }
    FallBack "Diffuse"
}

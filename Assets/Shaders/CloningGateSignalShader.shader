Shader "ProjectShaders/CloningGateShaderSignal" {

    Properties{
        _Color ("Color", Color) = (1, 0, 0, 1)
        _FlashingSpeed ("Flashing speed", Range(0, 20)) = 1
    }

    SubShader{
        Tags { 
            "RenderType" = "Transparent"
            "Queue" = "Transparent"
        }
        LOD 100

        Pass {
            Cull Off // Turns off backface culling
            ZWrite Off // Do not write to the depth buffer
            Blend One One // Aditive Blending

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            #define TAU 6.28318530718

            float4 _Color;
            float _FlashingSpeed;

            struct MeshData {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolators {
                float4 vertex : SV_POSITION;
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
            };

            Interpolators vert (MeshData v) {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            // Acts the same as map(...) from Processing : Translates (or maps) a range a values to another range of values
            float InverseLerp(float a, float b, float v) {
                return (v - a) / (b - a);
            }

            fixed4 frag(Interpolators i) : SV_Target{
                float flashingEffect = cos(_Time.y * _FlashingSpeed);
                flashingEffect = saturate(flashingEffect);

                float4 col = i.uv.xxxx;
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);
                return flashingEffect * _Color;
            }
            ENDCG
        }
    }
}

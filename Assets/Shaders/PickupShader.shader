Shader "ProjectShaders/Pickups/PickupShader" {

    Properties{
        // For a A -> B gradient
        _ColorA ("Color A", Color) = (1, 0, 0, 1)
        _ColorB ("Color B", Color) = (1, 0, 0, 1)
        _ColorStart("Color Start", Range(0, 1)) = 0
        _ColorEnd("Color End", Range(0, 1)) = 1
    }

    SubShader{
            Tags { 
                "RenderType" = "Opaque"
            }
            LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            float4 _ColorA;
            float4 _ColorB;
            float _ColorStart;
            float _ColorEnd;

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
                // Centers the UV coordinates
                float2 centeredUvs = (i.uv * 2 - 1);
                // Gets the distance of every pixel to the UVs center point
                float3 radialDistance = length(centeredUvs);

                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);

                float t = InverseLerp(_ColorStart, _ColorEnd, radialDistance);
                t = saturate(t);

                float4 gradientColor = lerp(_ColorA, _ColorB, t);
                return gradientColor;
            }
            ENDCG
        }
    }
}

Shader "ProjectShaders/DitherShader" {
    Properties {
        _MainTex ("Texture", 2D) = "white" {}
        _Transparency ("Transparency threshold", Range(0, 1)) = 1.0
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct MeshData {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct Interpolators {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float4 screenPos : TEXCOORD1;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _Transparency;

            Interpolators vert (MeshData v) {
                Interpolators o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.screenPos = ComputeScreenPos(o.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);

                return o;
            }

            fixed4 frag (Interpolators i) : SV_Target {
                // sample the texture
                fixed4 col = tex2D(_MainTex, i.uv);
                // apply fog
                UNITY_APPLY_FOG(i.fogCoord, col);

                float2 screenPos = i.screenPos.xy / i.screenPos.w;
                screenPos *= _ScreenParams.xy;

                // Dither matrix size
                int ditherMatrixSize = 4;
                // Dither threshold *matrix*
                float ditherThresholdsMatrix[16] =
                {
                    1.0 / 17.0,  9.0 / 17.0,  3.0 / 17.0, 11.0 / 17.0,
                    13.0 / 17.0,  5.0 / 17.0, 15.0 / 17.0,  7.0 / 17.0,
                    4.0 / 17.0, 12.0 / 17.0,  2.0 / 17.0, 10.0 / 17.0,
                    16.0 / 17.0,  8.0 / 17.0, 14.0 / 17.0,  6.0 / 17.0
                };

                int ditherIndex = (uint(screenPos.x) % ditherMatrixSize) * ditherMatrixSize + uint(screenPos.y) % ditherMatrixSize;
                // Remove the pixel from rendering if needed
                clip(_Transparency - ditherThresholdsMatrix[ditherIndex]);

                return col;
            }
            ENDCG
        }
    }
}

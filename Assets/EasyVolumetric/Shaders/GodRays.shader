// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

// Unlit alpha-blended shader.
// - no lighting
// - no lightmap support
// - no per-material color

Shader "FX/GodRays" {
Properties {
    _Color ("Tint", Color) = (1,1,1,1)
	_Noise ("Noise Texture", 2D) = "white" {}
	_NoiseScale ("Noise Scale", Float) = 1.0
	_NoiseScrollX ("Noise Scroll X", float) = 0.1
	_NoiseScrollY ("Noise Scroll X", float) = 0.1
	_InvFade("Soft Particles Factor", Range(0.01,3.0)) = 1.0
}

SubShader {
    Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
    LOD 100

	Cull Off
    ZWrite Off
    Blend SrcAlpha OneMinusSrcAlpha

    Pass {
        CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #pragma target 2.0
			#pragma multi_compile_particles
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata_t {
                float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
                UNITY_VERTEX_INPUT_INSTANCE_ID
            };

            struct v2f {
                float4 vertex : SV_POSITION;
				float3 normal : NORMAL;
				fixed4 color    : COLOR;
				float2 texcoord : TEXCOORD0;
                UNITY_FOG_COORDS(1)
				#ifdef SOFTPARTICLES_ON
				float4 projPos : TEXCOORD2;
				#endif
                UNITY_VERTEX_OUTPUT_STEREO
            };
			
			UNITY_INSTANCING_BUFFER_START(Props)
				UNITY_DEFINE_INSTANCED_PROP(float4, _Color)
			UNITY_INSTANCING_BUFFER_END(Props)

			sampler2D _Noise;
			sampler2D_float _CameraDepthTexture;
			float4 _CameraDepthTexture_TexelSize;
			float _NoiseScale;
			float _NoiseScrollX;
			float _NoiseScrollY;
			float _InvFade;

            v2f vert (appdata_t v)
            {
                v2f o;
                UNITY_SETUP_INSTANCE_ID(v);
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
                o.vertex = UnityObjectToClipPos(v.vertex);
				o.color = v.color;
				#ifdef SOFTPARTICLES_ON
				o.projPos = ComputeScreenPos (o.vertex);
				COMPUTE_EYEDEPTH(o.projPos.z);
				#endif
				
				float3 n = normalize(mul(unity_ObjectToWorld, v.normal).xyz);
				float3 vDirection = float3(0, 0, 1);
				if(abs(n.y) < 1.0f)
				{
					vDirection = normalize(float3(0, 1, 0) - n.y * n);
				}
				float3 uDirection = normalize(cross(n, vDirection));
				float3 worldSpace = mul(unity_ObjectToWorld, v.vertex).xyz;
				o.texcoord.xy = float2(dot(worldSpace, uDirection), dot(worldSpace, vDirection)) * _NoiseScale;
				o.texcoord.x += _NoiseScrollX * _Time.y;
				o.texcoord.y += _NoiseScrollY * _Time.y;
				
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
				#ifdef SOFTPARTICLES_ON
				float sceneZ = LinearEyeDepth (SAMPLE_DEPTH_TEXTURE_PROJ(_CameraDepthTexture, UNITY_PROJ_COORD(i.projPos)));
                float partZ = i.projPos.z;
                float fade = saturate (_InvFade * (sceneZ-partZ));
                i.color.a *= fade;
				#endif
				
				fixed4 noise = tex2D(_Noise, i.texcoord);
				
                fixed4 col = _Color * i.color * noise.a;
                UNITY_APPLY_FOG(i.fogCoord, col);
                return col;
            }
        ENDCG
    }
}

}

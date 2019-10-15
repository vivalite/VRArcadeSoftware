Shader "AVProVideo/FillBackground"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "black" {}
	}
	SubShader
	{
		Tags { "RenderType"="Opaque" "Queue"="Background" }
		LOD 100
		Cull Off
		ZWrite Off
		ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;
			float4 _MainTex_TexelSize;

			float2 ScaleZoomToFit(float targetWidth, float targetHeight, float sourceWidth, float sourceHeight)
			{
				float targetAspect = targetHeight / targetWidth;
				float sourceAspect = sourceHeight / sourceWidth;
				float2 scale = float2(1.0, sourceAspect / targetAspect);
				if (targetAspect < sourceAspect)
				{
					scale = float2(targetAspect / sourceAspect, 1.0);
				}
				return scale;
			}
			
			v2f vert (appdata_img v)
			{
				v2f o;

				float2 scale = ScaleZoomToFit(_ScreenParams.x, _ScreenParams.y, _MainTex_TexelSize.z, _MainTex_TexelSize.w);
				float2 pos = ((v.vertex.xy) * scale * 2.0);		

				// we're rendering with upside-down flipped projection,
				// so flip the vertical UV coordinate too
				if (_ProjectionParams.x < 0)
				{
					pos.y = (1 - pos.y) - 1;
				}

				o.vertex = float4(pos, UNITY_NEAR_CLIP_VALUE, 1);

				o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
				
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				// Sample the texture
				fixed4 col = tex2D(_MainTex, i.uv);
				return fixed4(col.rgb, 1.0);
			}
			ENDCG
		}
	}
}
